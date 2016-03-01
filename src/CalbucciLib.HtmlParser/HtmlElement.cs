using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace CalbucciLib
{
	/// <summary>
	/// Represents an HTML Element
	/// </summary>
	public class HtmlElement
	{
		public enum QuoteType
		{
			None,
			Single,
			Double
		};
		// ====================================================================
		//
		//  STATIC FIELDS
		//
		// ====================================================================


		// ====================================================================
		//
		//  PRIVATE FIELDS
		//
		// ====================================================================
		private List<string> _Errors;
		private List<string> _Warnings;


		// ====================================================================
		//
		//  CONSTRUCTORS
		//
		// ====================================================================
		internal HtmlElement(string openElement, HtmlElement parent, List<string> errors, List<string> warnings)
		{
			OriginalOpenTag = openElement;

			Parent = parent;

			_Errors = errors;
			_Warnings = warnings;

			HasOnlyKnownAttributes = true;
			HasDeprecatedAttribute = false;

			// openElement contains any type of open tag/single tag
			// Examples:
			//	<br>
			//  <br/>
			//	<br clear=left>
			//	<div style="color:#fff">
			//	<img src='/a/b/c'>

			Attributes = new List<Tuple<string, string>>();

			int len = openElement.Length;

			int pos = 1; // skip the <
			for(; pos < len; pos++)
			{
				char c = openElement[pos];
				if(!char.IsWhiteSpace(c))
					break;
			}

			if(pos == len)
			{
				// Error: Empty tag with whitespaces only: "<   >";
				_Errors.Add("Invalid tag (whitespaces only).");
				SyntaxError = true;
				return;
			}

			for(;pos < len; pos++)
			{
				char c = openElement[pos];
				if(c == '>')
				{
					if(pos == 1)
					{
						// Error: Empty tag like "<>"
						_Errors.Add("Empty tag <>");
						SyntaxError = true;
						return;
					}
					// This is it
					TagName = openElement.Substring(1, pos - 1).Trim().ToLowerInvariant();
					CheckTag();
					return;
				}
				
				if(char.IsWhiteSpace(c))
				{
					TagName = openElement.Substring(1, pos - 1).Trim().ToLowerInvariant();
					CheckTag();
					break;
				}
			}

			pos++; // skip the whitespace

			
			int end = openElement.LastIndexOf('>');
			if (end == -1)
			{
				_Errors.Add("Missing closing >");
				SyntaxError = true;
				FatalSyntaxError = true;
				return;
			}
			end--;
			while (end >= pos)
			{
				if (openElement[end] == '/')
				{
					XmlEmptyTag = true;
					end--;
					break;
				}
				if (!char.IsWhiteSpace(openElement[end]))
					break;
				end--;
			}

			if (end > pos)
			{
				ParseAttributes(SqueezeSpaces(openElement.Substring(pos, end - pos + 1)));
			}
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
		public string GetOpenTag(bool noEvents = false, bool noUnknownAttributes = false)
		{
			return InternalBuildOpenTag(ElementInfo, TagNameNS, Attributes, noEvents, noUnknownAttributes, XmlEmptyTag);
		}

		public string GetCloseTag()
		{
			return "</" + TagNameNS + ">";
		}

		public string GetAttributeValue(string attrName)
		{
			int index = FindAttributeIndex(attrName);
			if (index >= 0)
				return Attributes[index].Item2;
			return null;
		}

		public void SetAttribute(string attrName, string attrValue)
		{
			if (string.IsNullOrWhiteSpace(attrName))
				return;

			if(attrValue.IndexOfAny(new char[]{ '\r', '\n', '\t'}) >= 0)
				throw new ArgumentException("attrValue cannot contain control characters");

			var ap = new Tuple<string, string>(attrName, attrValue);
			int index = FindAttributeIndex(attrName);
			if (index >= 0)
			{
				Attributes[index] = ap;
			}
			else
			{
				Attributes.Add(ap);
			}
		}

		public bool RemoveAttribute(string attrName)
		{
			var index = FindAttributeIndex(attrName);
			if (index != -1)
			{
				Attributes.RemoveAt(index);
				return true;
			}
			return false;
		}

		public bool HasAttribute(string attrName)
		{
			return FindAttributeIndex(attrName) != -1;
		}

		public Tuple<string, string> GetAttribute(int attrIndex)
		{
			return Attributes[attrIndex];
		}

		public int FindAttributeIndex(string attrName)
		{
			if (Attributes.Count == 0 || string.IsNullOrWhiteSpace(attrName))
				return -1;

			for (int i = 0; i < Attributes.Count; i++)
			{
				var ap = Attributes[i];
				if (string.Compare(ap.Item1, attrName, StringComparison.InvariantCultureIgnoreCase) == 0)
				{
					return i;
				}
			}
			return -1;
		}


		// ====================================================================
		//
		//  PRIVATE/PROTECTED METHODS
		//
		// ====================================================================
		private void CheckTag()
		{
			if(TagName.EndsWith("/"))
				TagName = TagName.Substring(0, TagName.Length - 1);
			TagNameNS = TagName;

			ElementInfo = HtmlElementInfo.GetElementInfo(TagNameNS);

			int pos = TagName.IndexOf(':');
			if(pos!=-1)
			{
				Namespace = TagName.Substring(0, pos);
				TagName = TagName.Substring(pos + 1);
			}
			if(ElementInfo==null)
			{
				if(Namespace==null)
					AddWarning("Unknown tag: " + TagName);
			}
			else
			{
				if(Parent!=null)
				{
					if(!ElementInfo.IsValidParent(Parent.TagName))
					{
						AddWarning("Invalid parent for " + TagName + " (parent: " + Parent.TagName + ")");
					}
				}
			}
		}

		private void AddAttribute(string attrName, string attrVal)
		{
			if(string.IsNullOrWhiteSpace(attrName))
				return;

			if(attrName=="style")
				attrVal = CleanStyleAttr(attrVal);
			else if(attrName=="id")
				Id = attrVal;

			if(ElementInfo!=null)
			{
				//bool useUrl;
				AttrStatus ast = ElementInfo.GetAttributeStatus(attrName);
				if(ast == AttrStatus.Unknown)
				{
					if(attrName.IndexOf(':') > 0)
					{
						
					}
					else
					{
						HasOnlyKnownAttributes = false;
						AddWarning("Unknown attribute: " + attrName + " (tag: " + TagNameNS + ")");
					}
				}
				else if(ast==AttrStatus.Deprecated)
				{
					HasDeprecatedAttribute = true;
					AddWarning("Deprecated attribute: " + attrName + " (tag: " + TagNameNS + ")");
				}
			}

			if(!string.IsNullOrEmpty(attrVal))
				attrVal = WebUtility.HtmlDecode(attrVal);

			Attributes.Add(new Tuple<string, string>(attrName, attrVal));
		}
		//
		// Remove extra spaces from an element.
		// 1) Compress all whitespace to 1 ' '.
		// 2) Remove all white space around an '='.
		//
		private string SqueezeSpaces(string s)
		{
			StringBuilder n = new StringBuilder(s.Length);
			bool atSpace = false;
			bool atEqual = false;
			bool inQuote = false;
			char quote = '-';

			for (int i = 0; i < s.Length; i++) {
				char c = s[i];

				if (inQuote) {
					if (c == quote) {
						inQuote = false;
					}
					n.Append(c);
					continue;
				}
				if (char.IsWhiteSpace(c)) {
					atSpace = true;
					continue;
				}
				if (c == '=') {
					atEqual = true;
					continue;
				}
				// At this point, we know the char is not white or '='.
				if (atEqual) {
					n.Append('='); atEqual = false;
					atSpace = false;
				}
				if (atSpace) {
					n.Append(' '); atSpace = false;
				}
				if (c == '"' || c == '\'') {
					inQuote = true;
					quote = c;
				}
				n.Append(c);
			}

			if (atEqual) {
				n.Append('='); 
			}
			return n.ToString();
		}

		private void ParseAttributes(string openElement)
		{
			int len = openElement.Length;
			string attrName;
			string attrVal;
			int p = 0;
			char c;
			bool found;
			// Parse all the attributes now
			for(;p < len; p++)
			{
				// skip all the whitespaces
				while(char.IsWhiteSpace(openElement[p]))
				{
					p++;
					if(p==len)
						return;					
				}

				// now, search for the attribute name by either finding a whitespace or the "=" sign
				found = false;
				int startAttrName = p;
				while(true)
				{
					c = openElement[p];
					if(char.IsWhiteSpace(c) || c=='>')
					{
						// This is an empty attribute like "checked" in "<input type=checkbox checked>"
						attrName = openElement.Substring(startAttrName, p - startAttrName).Trim().ToLowerInvariant();
						AddAttribute(attrName, "");
						if(c=='>')
							return;
						found = true;
						break;
					}
					if(c=='=')
						break;
					p++;
					if(p>=len)
					{
						attrName = openElement.Substring(startAttrName, p - startAttrName).Trim().ToLowerInvariant();
						AddAttribute(attrName, "");
						return;
					}
				}
				if(found)
					continue;

				if(startAttrName==p)
				{
					_Errors.Add("Attribute name starts with the '=' sign.");
					SyntaxError = true;
					// Invalid attribute, starts with an '=' sign
					// Skip it to the next whitespace
					p++;
					c = openElement[p];
					if(c=='\'')
						p = openElement.IndexOf('\'', p+1);
					else if(c=='\"')
						p = openElement.IndexOf('\"', p+1);
					continue;
				}

				attrName = openElement.Substring(startAttrName, p - startAttrName).Trim().ToLowerInvariant();
				p++; // skipt the equal sign
				if (p == len)
				{
					_Errors.Add("Attribute ends with equal sign.");
					SyntaxError = true;
					FatalSyntaxError = true;
					return;
				}

				int startAttrVal = p;
				c = openElement[p];

				if(char.IsWhiteSpace(c) || c=='>')
				{
					// This is a malformed attribute since it has a whitespace after the '=' sign,
					// like <a class= abc> or <a class=>
					_Errors.Add("Attribute is missing value: " + attrName);
					SyntaxError = true;
					AddAttribute(attrName, "");
					continue;
				}

				if(c=='\'' || c=='\"')
				{
					startAttrVal++;
					p = openElement.IndexOf(c, p+1);
					if(p==-1)
					{
						// Argh, this attribute is missing the end quote, stop parsing
						_Errors.Add("Attribute is missing end quote: " + attrName);
						SyntaxError = true;
						FatalSyntaxError = true;
						return;
					}
					if(p==startAttrVal)
						attrVal = "";
					else
						attrVal = openElement.Substring(startAttrVal, p - startAttrVal);
					AddAttribute(attrName, attrVal);
					continue;
				}

				// This is an attribute without a quote. Find the first whitespace or >
				for(; p < len; p++)
				{
					c = openElement[p];
					if(char.IsWhiteSpace(c) || c=='>' || p == len - 1)
					{
						attrVal = openElement.Substring(startAttrVal, p - startAttrVal + 1);
						AddAttribute(attrName, attrVal);
						break;
					}
				}
			}

		}


		private void AddWarning(string text)
		{
			if(!_Warnings.Contains(text))
				_Warnings.Add(text);
		}
		// ====================================================================
		//
		//  STATIC METHODS (public)
		//
		// ====================================================================
		public static string ParseClosingTag(string elem)
		{
			if(!elem.StartsWith("</"))
				return null;

			for(int p = 2; p < elem.Length; p++)
			{
				char c = elem[p];
				if(c=='>' || char.IsWhiteSpace(c))
				{
					return elem.Substring(2, p - 2).Trim().ToLowerInvariant();
				}
			}
			return elem.Substring(2).Trim().ToLowerInvariant();
		}

		public static string BuildOpenTag(HtmlElementInfo ei, List<Tuple<string, string>> attributes, bool noEvents, bool noUnknownAttributes)
		{
			return InternalBuildOpenTag(ei, ei.TagName, attributes, noEvents, noUnknownAttributes, false);
		}

		public static string BuildOpenTag(string tagName, List<Tuple<string, string>> attributes, bool noEvents, bool noUnknownAttributes)
		{
			HtmlElementInfo ei = null;
			if(noUnknownAttributes)
				ei = HtmlElementInfo.GetElementInfo(tagName);
			return InternalBuildOpenTag(ei, tagName, attributes, noEvents, noUnknownAttributes, false);
		}


		public static string HtmlAttributeEncode(string attributeValue)
		{
			if(attributeValue == null)
				return null;

			if (attributeValue.IndexOfAny(new []{'&', '"'}) == -1)
				return attributeValue;

			StringBuilder sb = new StringBuilder();
			foreach (char c in attributeValue)
				switch (c)
				{
					case '&':
						sb.Append("&amp;");
						break;
					case '"':
						sb.Append("&quot;");
						break;
					default:
						sb.Append(c);
						break;
				}

			return sb.ToString();
		}

		/// <summary>
		/// Determines if an attribute must have a quote (and what type) according to HTML 4.01 spec (http://www.w3.org/TR/html401/)
		/// section 3.2.2.
		/// </summary>
		public static QuoteType NeedQuotesForAttr(string val)
		{
			if(string.IsNullOrWhiteSpace(val))
				return QuoteType.Double;

			QuoteType qt = QuoteType.None;
			foreach(char c in val)
			{
				if( c >= 'a' && c <= 'z')
					continue;
				if( c >= 'A' && c <= 'Z')
					continue;
				if( c >= '0' && c <= '9')
					continue;
				if(c=='_' || c=='-' || c=='.' || c==',') // According to http://www.w3.org/TR/html401/intro/sgmltut.html#h-3.2.2
					continue;
				qt = QuoteType.Double;
				if(c=='\"')
					qt = QuoteType.Single;
			}
			return qt;
		}

		public static string CleanStyleAttr(string style)
		{
			if(string.IsNullOrWhiteSpace(style))
				return style;

			string[] parts = style.Split(new []{';'}, StringSplitOptions.RemoveEmptyEntries);

			StringBuilder sb = new StringBuilder(30 + parts.Length * 16);

			foreach(string part in parts)
			{
				var p2 = part.Trim();
				if(p2.Length == 0)
					continue;
				int pos = p2.IndexOf(':');
				if(pos==-1)
					continue;
				string styleName = p2.Substring(0, pos).ToLower();
				string styleValue = p2.Substring(pos+1).Trim();

				if(string.IsNullOrWhiteSpace(styleValue))
					continue;

				if(sb.Length > 0)
					sb.AppendFormat(";{0}:{1}", styleName, styleValue);
				else
					sb.AppendFormat("{0}:{1}", styleName, styleValue);
			}

			return sb.ToString();

		}


		// ====================================================================
		//
		//  STATIC METHODS (private/protected)
		//
		// ====================================================================
		private static string InternalBuildOpenTag(HtmlElementInfo ei, string tagName, List<Tuple<string, string>> attributes, 
			bool noEvents, bool noUnknownAttributes, bool xmlEmptyTag)
		{
			if(!noUnknownAttributes)
				ei = null;

			StringBuilder sb = new StringBuilder(16 + attributes.Count * 32);
			sb.Append("<");
			sb.Append(tagName);

			foreach(Tuple<string, string> p in attributes)
			{
				string name = p.Item1;
				if(string.IsNullOrWhiteSpace(name) || noEvents && name.StartsWith("on"))
					continue;

				
				if(ei != null && ei.GetAttributeStatus(name)==AttrStatus.Unknown)
					continue;

				if (p.Item2 == null)
					continue; // Empty attribute (valid on HTML5 and above)

				sb.AppendFormat(" {0}=", p.Item1);
				string encodedValue = p.Item2 == null? "" : WebUtility.HtmlEncode(p.Item2);
				sb.AppendFormat("\"{0}\"", encodedValue);
			}
			if(xmlEmptyTag)
				sb.Append(" />");
			else
				sb.Append(">");
			return sb.ToString();

		}


		// ====================================================================
		//
		//  PROPERTIES
		//
		// ====================================================================
		public string TagName { get; private set; }

		public string TagNameNS { get; private set; }

		public string Id { get; private set; }

		public List<Tuple<string, string>> Attributes { get; private set; }

		public HtmlElementInfo ElementInfo { get; private set; }

		public string Namespace { get; private set; }

		public bool HasNamespace  { get; private set; }

		public bool XmlEmptyTag  { get; private set; }

		public HtmlElement Parent  { get; private set; }

		public bool HasDeprecatedAttribute  { get; private set; }

		public bool HasOnlyKnownAttributes  { get; private set; }

		public bool SyntaxError  { get; private set; }

		public bool FatalSyntaxError  { get; private set; }

		public string OriginalOpenTag  { get; private set; }




		// ====================================================================
		//
		//  INTERFACE IMPLEMENTATIONS
		//
		// ====================================================================


	}
}

