using System;
using System.Linq;
using System.Collections.Generic;

namespace CalbucciLib
{
	/// <summary>
	/// HTML Element
	/// </summary>
	public partial class HtmlElementInfo
	{
		// ====================================================================
		//
		//  STATIC FIELDS
		//
		// ====================================================================
		/// <summary>
		/// Elements that cannot contain script or any other "unsafe" content
		/// </summary>
		public static List<string> GlobaAttributes;

		private static List<HtmlElementInfo> AllElements;
		static private Dictionary<string, HtmlElementInfo> ElemsInfo;


		// ====================================================================
		//
		//  PRIVATE FIELDS
		//
		// ====================================================================


		// ====================================================================
		//
		//  CONSTRUCTORS
		//
		// ====================================================================
		static HtmlElementInfo()
		{
			GlobaAttributes =
				"accesskey;class;contenteditable;contextmenu;dir;draggable;dropzone;hidden;id;lang;spellcheck;style;tabindex;title;translate;;onabort;onblur;oncanplay;oncanplaythrough;onchange;onclick;oncontextmenu;ondblclick;ondrag;ondragend;ondragenter;ondragleave;ondragover;ondragstart;ondrop;ondurationchange;onemptied;onended;onerror;onfocus;oninput;oninvalid;onkeydown;onkeypress;onkeyup;onload;onloaddata;onloadeddata;onloadedmetadata;onloadstart;onmousedown;onmousemove;onmouseout;onmouseover;onmouseup;onmousewheel;onpause;onplay;onplaying;onprogress;onratechange;onreadystatechange;onreset;onscroll;onseekend;onseeking;onselect;onshow;onstalled;onsubmit;onsuspended;ontimeupdate;onvolumechange;onwaiting;xml:base;xml:lang;xml:space"
					.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries)
					.Distinct().OrderBy(a => a).ToList();

			Initialize();

			ElemsInfo = new Dictionary<string, HtmlElementInfo>();
			foreach (var hei in AllElements)
			{
				ElemsInfo[hei.TagName] = hei;
			}
		}
		internal HtmlElementInfo()
		{
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
		public AttrStatus GetAttributeStatus(string attrName)
		{
			if (string.IsNullOrWhiteSpace(attrName))
				return AttrStatus.Unknown;

			attrName = attrName.ToLowerInvariant();

			if (ObsoleteAttributes != null)
			{
				if (ObsoleteAttributes.Contains(attrName))
					return AttrStatus.Deprecated;
			}

			if (Attributes.Contains(attrName))
				return AttrStatus.Valid;

			return AttrStatus.Unknown;
		}

		public bool IsValidParent(string parentTagName)
		{
			if (string.IsNullOrWhiteSpace(parentTagName))
				return true; // no parent is always valid here

			parentTagName = parentTagName.ToLowerInvariant();

			// Check if the parent is in the not-allowed list
			if (ExcludeParentTags != null)
			{
				if (ExcludeParentTags.Contains(parentTagName))
					return false;
			}

			// Check if the parent is in the white list
			if (ParentTags != null)
			{
				if (ParentTags.Contains(parentTagName))
					return true;
			}

			// Finally, check if the content type is allowed
			if (ParentContentTypes == HtmlElementType.None)
				return false;

			var parentInfo = GetElementInfo(parentTagName);
			if (parentInfo == null)
			{
				if (parentTagName.IndexOf(':') >= 0)
					return true; // assume it's a custom defined element

				return false;
			}

			if ((ParentContentTypes & parentInfo.PermittedChildrenTypes) != 0)
				return true;

			return false;
		}


		// ====================================================================
		//
		//  PRIVATE/PROTECTED METHODS
		//
		// ====================================================================


		// ====================================================================
		//
		//  STATIC METHODS (public)
		//
		// ====================================================================
		/// <summary>
		/// Returns the HtmlElementInfo for the tag.
		/// </summary>
		static public HtmlElementInfo GetElementInfo(string tagName)
		{
			if (string.IsNullOrWhiteSpace(tagName))
				return null;
			HtmlElementInfo elementInfo;
			ElemsInfo.TryGetValue(tagName.ToLowerInvariant(), out elementInfo);
			return elementInfo;
		}


		static private IList<string> ConvertSemicolonDelimited(string text)
		{
			List<string> strList;
			if (text != null)
			{
				strList = text.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries)
					.Select(t => t.ToLowerInvariant())
					.Distinct()
					.OrderBy(t => t).ToList();
				if (strList.Count > 0)
					return strList;
			}
			return null;
		}



		// ====================================================================
		//
		//  PROPERTIES
		//
		// ====================================================================

		public string TagName { get; private set; }
		/// <summary>
		/// HTML verison that introduced this tag
		/// </summary>
		public int HtmlVersion { get; private set; }
		/// <summary>
		/// Indicates if this element is obsolete
		/// </summary>
		public bool Obsolete { get; private set; }
		public HtmlTagFormatting TagFormatting { get; private set; }
		public HtmlElementType ElementType { get; private set; }
		/// <summary>
		/// Valid types of elements that can be nested inside this tag
		/// </summary>
		public HtmlElementType PermittedChildrenTypes { get; private set; }
		/// <summary>
		/// Valid children for this tag
		/// </summary>
		public IList<string> PermittedChildrenTags { get; private set; }
		public IList<string> Attributes { get; private set; }
		public IList<string> ObsoleteAttributes { get; private set; }
		public HtmlElementType ParentContentTypes { get; private set; }
		public IList<string> ParentTags { get; private set; }
		public IList<string> ExcludeParentTags { get; private set; }

		private string PermittedChildrenTagsString
		{
			set { PermittedChildrenTags = ConvertSemicolonDelimited(value); }
		}

		private string AttributesString
		{
			set
			{
				var additionalAttributes = ConvertSemicolonDelimited(value);
				if (additionalAttributes != null)
					Attributes = GlobaAttributes.Union(additionalAttributes).OrderBy(a => a).ToList();
				else
					Attributes = GlobaAttributes;
			}
		}

		private string ObsoleteAttributesString
		{
			set { ObsoleteAttributes = ConvertSemicolonDelimited(value); }
		}

		private string ParentTagsString
		{
			set { ParentTags = ConvertSemicolonDelimited(value); }
		}

		private string ExcludeParentTagsString
		{
			set { ExcludeParentTags = ConvertSemicolonDelimited(value); }
		}





	}
}

