using System;
using System.Collections;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Net;
using System.Net.Mime;
using System.Text;
using System.Threading;
using System.Xml;
using System.Collections.Specialized;
using System.Collections.Generic;

namespace CalbucciLib
{
	/// <summary>
	/// HTML Parser
	/// </summary>
	public class HtmlParser
	{
		// ====================================================================
		//
		//  STATIC FIELDS
		//
		// ====================================================================
		static private readonly int _MaxInnerTextLengthStored = 65500;
		static HashSet<string> _IgnoreTextInsideTag;
		static char[] _NonSignificantWhitespace;


		// ====================================================================
		//
		//  PRIVATE FIELDS
		//
		// ====================================================================
		private string _OrigHtml;
		private bool _Stop;

		private Action<string, HtmlElement> _TextCallback;
		private Action<HtmlElement, bool> _ElementCallback;
		private Action<string> _EndElementCallback;


		private List<string> _Errors;
		private List<string> _Warnings;

		private Dictionary<string, string> _Ids;

		private StringBuilder _InnerTextBuilder;


		// ====================================================================
		//
		//  CONSTRUCTORS
		//
		// ====================================================================
		static HtmlParser()
		{
			// List of Tags that we will simply drop the TextNode inside them
			_IgnoreTextInsideTag = new HashSet<string>
			{
				"head",
				"html",
				"ol",
				"select",
				"table",
				"tbody",
				"thead",
				"tfoot",
				"tr"
			};

			_NonSignificantWhitespace = new char[32];
			for (int i = 0; i < 32; i++)
				_NonSignificantWhitespace[i] = (char)i;
		}

		public HtmlParser(string html)
		{
			_OrigHtml = html;
			SkipComments = true;
			PreserveCRLFTab = true;
		}

		// ====================================================================
		//
		//  VIRTUAL METHODS (public/protected)
		//
		// ====================================================================


		// ====================================================================
		//
		//  PUBLIC METHODS (instance)
		//
		// ====================================================================
		/// <summary>
		/// Parses the HTML
		/// </summary>
		/// <param name="textCallback">Call back for text and comments (must set SkipComments to false)</param>
		/// <param name="elementCallback">Call back for empty elements and open elements</param>
		/// <param name="endElementCallback">Call back for closing elements</param>
		/// <returns></returns>
		public bool Parse(Action<string, HtmlElement> textCallback = null, Action<HtmlElement, bool> elementCallback = null, Action<string> endElementCallback = null)
		{
			if (_Stop)
			{
				throw new InvalidOperationException("You cannot call parse again.");
			}

			_TextCallback = textCallback;
			_ElementCallback = elementCallback;
			_EndElementCallback = endElementCallback;

			HasValidSyntax = true;
			HasOnlyValidTags = true;
			HasOnlyValidAttributes = true;
			HasDeprecatedAttributes = false;
			HasDeprecatedTags = false;
			

			HasOnlyKnownTags = true;

			_Errors = new List<string>();
			_Warnings = new List<string>();
			_Ids = new Dictionary<string, string>();

			// null html
			if (_OrigHtml == null)
			{
				InnerText = "";
				return true;
			}

			int itLen = Math.Min(_MaxInnerTextLengthStored, 256 + _OrigHtml.Length / 2);

			_InnerTextBuilder = new StringBuilder(itLen);

			// check if this html has at least one tag, otherwise it is just a string
			int pos = _OrigHtml.IndexOf('<');
			if (pos == -1)
			{
				CallText(_OrigHtml, null);
			}
			else
			{
				InternalParse();
			}

			InnerText = WebUtility.HtmlDecode(_InnerTextBuilder.ToString());
			_Stop = true;

			return HasValidSyntax;
		}

		/// <summary>
		/// Stops the parsing. The state of the properties are unknown.
		/// </summary>
		public void Stop()
		{
			_Stop = true;
		}


		// ====================================================================
		//
		//  PRIVATE/PROTECTED METHODS
		//
		// ====================================================================
		private void CallText(string text, HtmlElement parent)
		{
			if (PreserveCRLFTab)
			{
				if (string.IsNullOrEmpty(text))
					return;
			}

			if (string.IsNullOrWhiteSpace(text))
				return;

			if (parent != null && parent.ElementInfo != null)
			{
				var childrenTypes = parent.ElementInfo.PermittedChildrenTypes;
				if ((childrenTypes & (HtmlElementType.Text | HtmlElementType.NRCharData)) == 0)
				{
					AddWarning(string.Format("Text node inside a {0} element is not valid", parent.TagName));
				}
			}

			if (parent != null && _IgnoreTextInsideTag.Contains(parent.TagNameNS))
				return;

			bool clearText = !PreserveCRLFTab;

			if (parent != null)
			{
				switch (parent.TagNameNS)
				{
					case "pre":
					case "script":
					case "style":
						clearText = false;
						break;
				}
			}
			if (clearText && text.StartsWith("<!--"))
			{
					clearText = false;
			}

			if (clearText)
			{
				// Remove all tags, CR, LF
				StringBuilder sb = new StringBuilder(text.Length);
				int pos = 0;
				int last = 0;
				do
				{
					pos = text.IndexOfAny(_NonSignificantWhitespace, pos);


					if (pos == -1)
						break;

					if (text[pos] == '\r' || text[pos] == '\n')
					{
						sb.Append(text, last, pos - last);
						sb.Append(' ');
					}
					else if (last != pos)
					{
						sb.Append(text, last, pos - last);
					}
					pos++;
					last = pos;
				} while (pos < text.Length);

				if (last < text.Length)
					sb.Append(text, last, text.Length - last);

				text = sb.ToString();
			}
			text = WebUtility.HtmlDecode(text);

			if (_TextCallback != null)
			{
				_TextCallback(text, parent);
				if (_Stop)
					return;
			}

			bool useBlock = false;
			if (parent != null && parent.ElementInfo != null)
			{
				if (parent.ElementInfo.ElementType == HtmlElementType.Flow)
					useBlock = true;
				else
				{
					// This is whacky. We messed up on the definition of block-level elements for TR/TD
					// because of the optional tags.
					switch (parent.TagNameNS)
					{
						case "tr":
						case "td":
							useBlock = true;
							break;
					}
				}
			}

			if (_InnerTextBuilder.Length < _MaxInnerTextLengthStored)
			{
				if (useBlock)
				{
					char prevChar = '\0';
					if (_InnerTextBuilder.Length > 0)
						prevChar = _InnerTextBuilder[_InnerTextBuilder.Length - 1];

					if (prevChar != '\n' && prevChar != '\r')
						_InnerTextBuilder.Append("\n");
					_InnerTextBuilder.Append(text);
					_InnerTextBuilder.Append("\n");
				}
				else
				{
					_InnerTextBuilder.Append(text);
				}
			}
		}

		private void InternalParse()
		{
			Stack<HtmlElement> openedTags = new Stack<HtmlElement>();
			Stack<HtmlElement> openedBlocks = new Stack<HtmlElement>();

			bool anyContent = false;

			HtmlElement parent;
			HtmlElement blockParent;

			bool fatal = false;

			//_LineCount = 1;

			string text;
			int last = 0;
			int len = _OrigHtml.Length;
			int len1 = len - 1;
			char c;
			for (int p = 0; p < len; p++)
			{
				if (_Stop)
					return;
				c = _OrigHtml[p];

				if (c != '<')
					continue;

				int diff = p - last;
				if (diff >= 1)
				{
					parent = null;
					if (HasValidSyntax && openedTags.Count > 0)
						parent = openedTags.Peek();
					string text2 = _OrigHtml.Substring(last, diff);
					if (!string.IsNullOrWhiteSpace(text2))
						anyContent = true;
					CallText(text2, parent);
					if (_Stop)
						return;
				}
				// Yes, this is an open (or closing) tag
				if (p >= len1)
				{
					HasValidSyntax = false;
					fatal = true;
					AddError("HTML ends with < character");
					break; // the html ends with this open tag
				}

				int startElem = p;
				string elem = GetElementString(startElem);
				if (elem == null)
				{
					fatal = true;
					break; // fatal syntax error
				}
				p += elem.Length - 1;
				if (elem.Length <= 2)
				{
					// bad HTML, like "<>"
					AddError("Element is empty <>");
					HasValidSyntax = false;
					continue;
				}
				last = p + 1;
				parent = blockParent = null;
				if (HasValidSyntax)
				{
					if (openedTags.Count > 0)
						parent = openedTags.Peek();
					if (openedBlocks.Count > 0)
						blockParent = openedBlocks.Peek();
				}

				if (elem[1] == '/')
				{
					anyContent = true;
					// This is a closing tag
					string tag = HtmlElement.ParseClosingTag(elem);

					if (HasValidSyntax)
					{
						UnwindForClose(tag, openedTags, openedBlocks);
						if (_Stop)
							return;
					}
					if (_EndElementCallback != null)
					{
						_EndElementCallback(tag);
						if (_Stop)
							return;
					}
				}
				else
				{
					if (elem.StartsWith("<!"))
					{
						if (elem.StartsWith("<!--"))
						{
							p = p - elem.Length + 1;
							// It's a comment
							int ec = _OrigHtml.IndexOf("-->", p + 4, StringComparison.InvariantCultureIgnoreCase);
							if (ec == -1)
							{
								HasValidSyntax = false;
								fatal = true;
								AddError("Missing end comment -->");
								break;
							}
							text = _OrigHtml.Substring(p, ec - p + 3);
							if (!SkipComments)
							{
								CallText(text, null);
								if (_Stop)
									return;
							}
							p += text.Length;
							last = p;
							p--;
							continue;
						}
						// Looks like a doctype
						string e2 = elem.ToLower();
						if (e2.StartsWith("<!doctype "))
						{
							if (anyContent)
							{
								HasValidSyntax = false;
								AddError("The doctype declaration must be the first element of the HTML:" + e2);
							}
							anyContent = true;
							CallText(elem, null);
							if (_Stop)
								return;
							continue;
						}
					}
					anyContent = true;
					HtmlElement he = new HtmlElement(elem, parent, _Errors, _Warnings);
					if (he.HasDeprecatedAttribute)
						HasDeprecatedAttributes = true;
					if (!he.HasOnlyKnownAttributes)
						HasOnlyValidAttributes = false;

					if (!string.IsNullOrWhiteSpace(he.Id) && _Ids.ContainsKey(he.Id))
					{
						AddWarning("Duplicate id: " + he.Id + " - Element: " + he.OriginalOpenTag);
					}
					_Ids[he.Id] = he.Id;

					if (he.SyntaxError)
					{
						HasValidSyntax = false;
						if (he.FatalSyntaxError)
						{
							fatal = true;
							break;
						}
						AddError("Element syntax error for " + he.OriginalOpenTag);
						continue;
					}

					// Special cases for script and style
					if (he.TagNameNS == "script" || he.TagNameNS == "style")
					{
						int startScript = p + 1;
						int endScript = 0;
						string endTag = null;
						int cp = startScript;
						while (true)
						{
							cp = _OrigHtml.IndexOf("</", cp, StringComparison.InvariantCultureIgnoreCase);
							if (cp == -1)
							{
								HasValidSyntax = false;
								fatal = true;
								AddError("Missing close tag: " + he.OriginalOpenTag);
								break;
							}
							endScript = cp;
							elem = GetElementString(cp);
							if (elem == null)
							{
								HasValidSyntax = false;
								fatal = true;
								AddError("Missing close > for closing tag: " + he.OriginalOpenTag);
								break;
							}
							cp += elem.Length;
							last = cp;
							endTag = HtmlElement.ParseClosingTag(elem);
							if (endTag == he.TagNameNS)
								break;
							endTag = null;
						}
						if (endTag == null)
						{
							p = _OrigHtml.Length;
							break;
						}
						p = cp - 1;

						if (_ElementCallback != null)
						{
							_ElementCallback(he, false);
							if (_Stop)
								return;
						}

						CallText(_OrigHtml.Substring(startScript, endScript - startScript), he);
						if (_Stop)
							return;

						if (_EndElementCallback != null)
						{
							_EndElementCallback(he.TagNameNS);
							if (_Stop)
								return;
						}

						continue;
					}

					// We consider this a single element if
					// 1) the ElementInfo.Single is flagged
					// 2) It is an unknown element (but not in any namespace)
					if (he.ElementInfo == null)
					{
						HasOnlyKnownTags = false;
						// Unknown HTML 4.01 tag
						if (!he.HasNamespace)
						{
							AddWarning("Unknown tag: " + he.TagNameNS);
							// Really unknown and invalid tag
							if (he.XmlEmptyTag)
							{
								if (_ElementCallback != null)
								{
									_ElementCallback(he, true);
									if (_Stop)
										return;
								}
							}
							else
							{
								if (_ElementCallback != null)
								{
									_ElementCallback(he, false);
									if (_Stop)
										return;
								}
								if (HasValidSyntax)
									openedTags.Push(he);
							}
						}
						else
						{
							// it is unknown, but correctly declared in an XML namespace
							if (he.XmlEmptyTag)
							{
								if (_ElementCallback != null)
								{
									_ElementCallback(he, true);
									if (_Stop)
										return;
								}
							}
							else
							{
								if (_ElementCallback != null)
								{
									_ElementCallback(he, false);
									if (_Stop)
										return;
								}
								if (HasValidSyntax)
									openedTags.Push(he);
							}
						}
					}
					else
					{
						if (he.ElementInfo.Obsolete)
						{
							AddWarning("Deprecated Tag: " + he.TagNameNS);
							HasDeprecatedTags = true;
						}

						// It's  known tag
						if (he.ElementInfo.TagFormatting == HtmlTagFormatting.Single || he.XmlEmptyTag)
						{
							if (_ElementCallback != null)
							{
								_ElementCallback(he, true);
								if (_Stop)
									return;
							}
						}
						else
						{
							if (HasValidSyntax)
							{
								if (he.ElementInfo.ElementType == HtmlElementType.Flow)
								{
									// Some Tags have optional closing (like LI or TD or P)
									// We assume an automatic closing for these tags on the following situation:
									// 1) Current element is block-level, and
									// 2) Parent node is also a block-level and supports optional closing
									// 3) Current element is the same class as parent element
									//    or Current element is the closing tag of the parent element
									if (blockParent != null && blockParent.ElementInfo.TagFormatting == HtmlTagFormatting.OptionalClosing)
									{
										if (!Equals(parent, blockParent))
										{
											AddWarning(string.Format("Invalid parent for {0} (inside of {1})", blockParent.TagName, parent.TagName));
										}
										else
										{
											if (he.TagName == blockParent.TagName)
											{
												if (_EndElementCallback != null)
												{
													_EndElementCallback(parent.TagNameNS);
													if (_Stop)
														return;
												}
												openedTags.Pop();
												openedBlocks.Pop();
											}
										}
									}
									if (HasValidSyntax)
										openedBlocks.Push(he);
								}
								if (HasValidSyntax)
									openedTags.Push(he);
							}
							if (_ElementCallback != null)
								_ElementCallback(he, false);

						}
					}

				}
			} // for loop


			if (!fatal)
			{
				// commit the last piece of text
				parent = null;
				if (HasValidSyntax && openedTags.Count > 0)
					parent = openedTags.Peek();

				if (last < len)
				{
					text = _OrigHtml.Substring(last);
					CallText(text, parent);
					if (_Stop)
						return;
				}

				if (HasValidSyntax)
				{
					while (openedTags.Count > 0)
					{
						parent = openedTags.Peek();
						if (parent.ElementInfo == null || parent.ElementInfo.TagFormatting != HtmlTagFormatting.OptionalClosing)
							break;
						if (_EndElementCallback != null)
						{
							_EndElementCallback(parent.TagNameNS);
							if (_Stop)
								return;
						}
						openedTags.Pop();
						blockParent = null;
						if (openedBlocks.Count > 0)
							blockParent = openedBlocks.Peek();
						if (Equals(parent, blockParent))
							openedBlocks.Pop();
					}
				}
			}

			if (HasValidSyntax)
			{
				if (openedBlocks.Count > 0)
				{
					if (openedTags.Count != openedBlocks.Count)
					{
						HasValidSyntax = false;
						AddError("Missing " + openedTags.Count + " tag(s) closing.");
					}
					else
					{
						while (openedBlocks.Count > 0)
						{
							blockParent = openedBlocks.Pop();
							parent = openedTags.Pop();
							if (!Equals(parent, blockParent))
							{
								HasValidSyntax = false;
								AddError("Missing a close tag for a block-element. Opened Tag: " + parent.TagNameNS);
								break;
							}
							if (_EndElementCallback != null)
							{
								_EndElementCallback(parent.TagNameNS);
								if (_Stop)
									return;
							}
						}

					}
				}
				else if (openedTags.Count > 0)
				{
					AddError("Missing " + openedTags.Count + " tag(s) closing.");
					HasValidSyntax = false;
				}
			}
		}

		private void UnwindForClose(string tag, Stack<HtmlElement> openedTags, Stack<HtmlElement> openedBlocks)
		{
			HtmlElement parent = null;
			if (openedTags.Count > 0)
				parent = openedTags.Peek();

			if (parent == null)
			{
				HasValidSyntax = false;
				AddError("Closing tag without opening: " + tag);
				return;
			}

			string firstParent = parent.TagNameNS;

			HtmlElement blockParent = null;
			if (openedBlocks.Count > 0)
				blockParent = openedBlocks.Peek();

			do
			{
				if (parent.TagNameNS == tag)
				{
					openedTags.Pop();
					if (blockParent != null && blockParent.TagNameNS == tag)
						openedBlocks.Pop();
					return;
				}

				if (parent.ElementInfo == null)
					break; // mismatch

				// This could be either a tag mismatch, or an optional element missing
				if (parent.ElementInfo.TagFormatting != HtmlTagFormatting.OptionalClosing)
					break; // mismatch

				// inject the optional closing tag
				if (_EndElementCallback != null)
				{
					_EndElementCallback(parent.TagNameNS);
					if (_Stop)
						return;
				}

				if (openedTags.Count == 0)
					break;
				openedTags.Pop();
				if (Equals(blockParent, parent))
				{
					openedBlocks.Pop();
					blockParent = null;
					if (openedBlocks.Count > 0)
						blockParent = openedBlocks.Peek();
				}
				parent = parent.Parent;
			} while (parent != null);

			AddError("Tag mismatch. Open tag: " + firstParent + " / Closing tag: " + tag);
			HasValidSyntax = false;


		}


		// ====================================================================
		//
		//  STATIC METHODS (public)
		//
		// ====================================================================


		// ====================================================================
		//
		//  STATIC METHODS (private/protected)
		//
		// ====================================================================
		private string GetElementString(int startPos)
		{
			char c;
			int endElem = 0;
			int len = _OrigHtml.Length;
			int p = startPos;
			for (; p < len; p++)
			{
				c = _OrigHtml[p];
				if (c == '>')
				{
					endElem = p;
					break;
				}
				if (c == '\"' || c == '\'')
				{
					p = _OrigHtml.IndexOf(c, p + 1);
					if (p == -1)
					{
						// Not well formed HTML: <div attr="value>   (missing quote)
						var logString = _OrigHtml.Substring(startPos);
						if (logString.Length > 40)
							logString = logString.Substring(40);
						AddError("Attribute start quote but doesn't end with quote: " + logString);
						HasValidSyntax = false;
						return null;
					}
				}
			}

			if (endElem == 0)
			{
				HasValidSyntax = false;
				var logString = _OrigHtml.Substring(startPos);
				if (logString.Length > 40)
					logString = logString.Substring(40);
				AddError("Can't find > for tag: " + logString);
				return null;
			}

			return _OrigHtml.Substring(startPos, endElem - startPos + 1);

		}

		private void AddError(string error)
		{
			_Errors.Add(error);
		}

		private void AddWarning(string warning)
		{
			_Warnings.Add(warning);
		}


		// ====================================================================
		//
		//  PROPERTIES
		//
		// ====================================================================

		public string InnerText { get; private set; }

		/// <summary>
		/// 
		/// </summary>
		public bool IsValidStrictHTML401
		{
			get
			{
				return HasValidSyntax && HasOnlyValidTags && HasOnlyValidAttributes;
			}
		}

		public bool IsValidStrictHTMLNoDeprecated
		{
			get
			{
				return HasValidSyntax && HasOnlyValidTags && HasOnlyValidAttributes && !HasDeprecatedAttributes && !HasDeprecatedTags;
			}
		}

		public bool IsValidHTML401
		{
			get
			{
				return HasValidSyntax && HasOnlyValidTags && HasOnlyValidAttributes;
			}
		}

		/// <summary>
		/// The document is syntatically correct
		/// </summary>
		public bool HasValidSyntax { get; private set; }

		/// <summary>
		/// All tags on the document are valid HTML 4.01 tags (known or declared using namespaces)
		/// </summary>
		public bool HasOnlyValidTags { get; private set; }

		/// <summary>
		/// All attributes on the document are defined in HTML 4.01 (we don't validate the value of the attributes)
		/// </summary>
		public bool HasOnlyValidAttributes { get; private set; }

		public bool HasOnlyKnownTags { get; private set; }

		public bool HasDeprecatedAttributes { get; private set; }

		/// <summary>
		/// Has at least one tag or one attribute that is deprecated
		/// </summary>
		public bool HasDeprecatedTags { get; private set; }

		public List<string> Errors { get { return _Errors; } }
		public List<string> Warnings { get { return _Warnings; } }

		public bool SkipComments { get; set; }

		public bool PreserveCRLFTab { get; set; }


		// ====================================================================
		//
		//  INTERFACE IMPLEMENTATIONS
		//
		// ====================================================================


	}
}

