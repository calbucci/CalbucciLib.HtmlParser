using System.Collections.Generic;

namespace CalbucciLib
{
	public partial class HtmlElementInfo
	{
		private static void Initialize()
		{
			AllElements = new List<HtmlElementInfo>
			{
				new HtmlElementInfo
				{
					TagName = "a",
					HtmlVersion = 3,
					Obsolete = false,
					ElementType = HtmlElementType.Flow,
					PermittedChildrenTypes = HtmlElementType.AnyContent,
					PermittedChildrenTagsString = "",
					AttributesString = "href;target;rel;hreflang;media;type",
					TagFormatting = HtmlTagFormatting.Complete,
					ParentTagsString = "",
					ExcludeParentTagsString = "a;button",
					ParentContentTypes = HtmlElementType.Flow | HtmlElementType.Phrasing,
					ObsoleteAttributesString = "coords;shape;urn;charset;methods;rev;name"
				},
				new HtmlElementInfo
				{
					TagName = "abbr",
					HtmlVersion = 3,
					Obsolete = false,
					ElementType = HtmlElementType.Phrasing,
					PermittedChildrenTypes = HtmlElementType.Phrasing | HtmlElementType.Text,
					PermittedChildrenTagsString = "",
					AttributesString = "",
					TagFormatting = HtmlTagFormatting.Complete,
					ParentTagsString = "",
					ExcludeParentTagsString = "",
					ParentContentTypes = HtmlElementType.Phrasing,
					ObsoleteAttributesString = ""
				},
				new HtmlElementInfo
				{
					TagName = "acronym",
					HtmlVersion = 4,
					Obsolete = true,
					ElementType = HtmlElementType.Phrasing,
					PermittedChildrenTypes = HtmlElementType.AnyContent,
					PermittedChildrenTagsString = "",
					AttributesString = "",
					TagFormatting = HtmlTagFormatting.Complete,
					ParentTagsString = "",
					ExcludeParentTagsString = "",
					ParentContentTypes = HtmlElementType.Phrasing,
					ObsoleteAttributesString = ""
				},
				new HtmlElementInfo
				{
					TagName = "address",
					HtmlVersion = 3,
					Obsolete = false,
					ElementType = HtmlElementType.Flow,
					PermittedChildrenTypes = HtmlElementType.AnyContent,
					PermittedChildrenTagsString = "",
					AttributesString = "",
					TagFormatting = HtmlTagFormatting.Complete,
					ParentTagsString = "",
					ExcludeParentTagsString = "address",
					ParentContentTypes = HtmlElementType.Flow,
					ObsoleteAttributesString = ""
				},
				new HtmlElementInfo
				{
					TagName = "applet",
					HtmlVersion = 3,
					Obsolete = true,
					ElementType = HtmlElementType.Phrasing,
					PermittedChildrenTypes = HtmlElementType.AnyContent,
					PermittedChildrenTagsString = "",
					AttributesString = "",
					TagFormatting = HtmlTagFormatting.Complete,
					ParentTagsString = "",
					ExcludeParentTagsString = "",
					ParentContentTypes = HtmlElementType.Phrasing,
					ObsoleteAttributesString = ""
				},
				new HtmlElementInfo
				{
					TagName = "area",
					HtmlVersion = 3,
					Obsolete = false,
					ElementType = HtmlElementType.Phrasing,
					PermittedChildrenTypes = HtmlElementType.None,
					PermittedChildrenTagsString = "",
					AttributesString = "alt;href;target;rel;media;hreflang;type;shape;coords",
					TagFormatting = HtmlTagFormatting.Single,
					ParentTagsString = "map",
					ExcludeParentTagsString = "",
					ParentContentTypes = HtmlElementType.None,
					ObsoleteAttributesString = "nohref"
				},
				new HtmlElementInfo
				{
					TagName = "article",
					HtmlVersion = 5,
					Obsolete = false,
					ElementType = HtmlElementType.Flow,
					PermittedChildrenTypes = HtmlElementType.AnyContent,
					PermittedChildrenTagsString = "",
					AttributesString = "",
					TagFormatting = HtmlTagFormatting.Complete,
					ParentTagsString = "",
					ExcludeParentTagsString = "",
					ParentContentTypes = HtmlElementType.Flow,
					ObsoleteAttributesString = ""
				},
				new HtmlElementInfo
				{
					TagName = "aside",
					HtmlVersion = 5,
					Obsolete = false,
					ElementType = HtmlElementType.Flow,
					PermittedChildrenTypes = HtmlElementType.AnyContent,
					PermittedChildrenTagsString = "",
					AttributesString = "",
					TagFormatting = HtmlTagFormatting.Complete,
					ParentTagsString = "",
					ExcludeParentTagsString = "address",
					ParentContentTypes = HtmlElementType.Flow,
					ObsoleteAttributesString = ""
				},
				new HtmlElementInfo
				{
					TagName = "audio",
					HtmlVersion = 5,
					Obsolete = false,
					ElementType = HtmlElementType.Phrasing,
					PermittedChildrenTypes = HtmlElementType.Flow | HtmlElementType.Phrasing,
					PermittedChildrenTagsString = "",
					AttributesString = "autoplay;preload;controls;loop;mediagroup;muted;src",
					TagFormatting = HtmlTagFormatting.Complete,
					ParentTagsString = "",
					ExcludeParentTagsString = "a;button",
					ParentContentTypes = HtmlElementType.Flow | HtmlElementType.Phrasing,
					ObsoleteAttributesString = ""
				},
				new HtmlElementInfo
				{
					TagName = "b",
					HtmlVersion = 3,
					Obsolete = false,
					ElementType = HtmlElementType.Phrasing,
					PermittedChildrenTypes = HtmlElementType.Phrasing | HtmlElementType.Text,
					PermittedChildrenTagsString = "",
					AttributesString = "",
					TagFormatting = HtmlTagFormatting.Complete,
					ParentTagsString = "",
					ExcludeParentTagsString = "",
					ParentContentTypes = HtmlElementType.Phrasing,
					ObsoleteAttributesString = ""
				},
				new HtmlElementInfo
				{
					TagName = "base",
					HtmlVersion = 3,
					Obsolete = false,
					ElementType = HtmlElementType.Phrasing,
					PermittedChildrenTypes = HtmlElementType.None,
					PermittedChildrenTagsString = "",
					AttributesString = "href;target",
					TagFormatting = HtmlTagFormatting.Single,
					ParentTagsString = "head",
					ExcludeParentTagsString = "",
					ParentContentTypes = HtmlElementType.None,
					ObsoleteAttributesString = ""
				},
				new HtmlElementInfo
				{
					TagName = "basefont",
					HtmlVersion = 3,
					Obsolete = true,
					ElementType = HtmlElementType.Phrasing,
					PermittedChildrenTypes = HtmlElementType.None,
					PermittedChildrenTagsString = "",
					AttributesString = "",
					TagFormatting = HtmlTagFormatting.Single,
					ParentTagsString = "",
					ExcludeParentTagsString = "",
					ParentContentTypes = HtmlElementType.Phrasing,
					ObsoleteAttributesString = ""
				},
				new HtmlElementInfo
				{
					TagName = "bdi",
					HtmlVersion = 5,
					Obsolete = false,
					ElementType = HtmlElementType.Phrasing,
					PermittedChildrenTypes = HtmlElementType.Phrasing | HtmlElementType.Text,
					PermittedChildrenTagsString = "",
					AttributesString = "",
					TagFormatting = HtmlTagFormatting.Complete,
					ParentTagsString = "",
					ExcludeParentTagsString = "",
					ParentContentTypes = HtmlElementType.Phrasing,
					ObsoleteAttributesString = ""
				},
				new HtmlElementInfo
				{
					TagName = "bdo",
					HtmlVersion = 3,
					Obsolete = false,
					ElementType = HtmlElementType.Phrasing,
					PermittedChildrenTypes = HtmlElementType.Phrasing | HtmlElementType.Text,
					PermittedChildrenTagsString = "",
					AttributesString = "",
					TagFormatting = HtmlTagFormatting.Complete,
					ParentTagsString = "",
					ExcludeParentTagsString = "",
					ParentContentTypes = HtmlElementType.Phrasing,
					ObsoleteAttributesString = ""
				},
				new HtmlElementInfo
				{
					TagName = "big",
					HtmlVersion = 3,
					Obsolete = true,
					ElementType = HtmlElementType.Phrasing,
					PermittedChildrenTypes = HtmlElementType.Phrasing | HtmlElementType.Text,
					PermittedChildrenTagsString = "",
					AttributesString = "",
					TagFormatting = HtmlTagFormatting.Complete,
					ParentTagsString = "",
					ExcludeParentTagsString = "",
					ParentContentTypes = HtmlElementType.Phrasing,
					ObsoleteAttributesString = ""
				},
				new HtmlElementInfo
				{
					TagName = "blockquote",
					HtmlVersion = 3,
					Obsolete = false,
					ElementType = HtmlElementType.Flow,
					PermittedChildrenTypes = HtmlElementType.AnyContent,
					PermittedChildrenTagsString = "",
					AttributesString = "cite",
					TagFormatting = HtmlTagFormatting.Complete,
					ParentTagsString = "",
					ExcludeParentTagsString = "",
					ParentContentTypes = HtmlElementType.Flow,
					ObsoleteAttributesString = ""
				},
				new HtmlElementInfo
				{
					TagName = "body",
					HtmlVersion = 3,
					Obsolete = false,
					ElementType = HtmlElementType.Flow,
					PermittedChildrenTypes = HtmlElementType.AnyContent,
					PermittedChildrenTagsString = "script;style",
					AttributesString =
						"onafterprint;onbeforeprint;onbeforeunload;onblur;onerror;onfocus;onhaschange;onload;onmessage;onoffline;ononline;onpagehide;onpageshow;onpopstate;onresize;onstoragte;onunload;",
					TagFormatting = HtmlTagFormatting.OptionalClosing,
					ParentTagsString = "html",
					ExcludeParentTagsString = "",
					ParentContentTypes = HtmlElementType.None,
					ObsoleteAttributesString =
						"alink;background;bgcolor;link;marginbottom;marginheight;marginleft;marginright;margintop;marginwidth;text;vlink"
				},
				new HtmlElementInfo
				{
					TagName = "br",
					HtmlVersion = 3,
					Obsolete = false,
					ElementType = HtmlElementType.Phrasing,
					PermittedChildrenTypes = HtmlElementType.None,
					PermittedChildrenTagsString = "",
					AttributesString = "",
					TagFormatting = HtmlTagFormatting.Single,
					ParentTagsString = "",
					ExcludeParentTagsString = "",
					ParentContentTypes = HtmlElementType.Flow | HtmlElementType.Phrasing,
					ObsoleteAttributesString = "clear"
				},
				new HtmlElementInfo
				{
					TagName = "button",
					HtmlVersion = 4,
					Obsolete = false,
					ElementType = HtmlElementType.Phrasing,
					PermittedChildrenTypes = HtmlElementType.Phrasing | HtmlElementType.Text,
					PermittedChildrenTagsString = "",
					AttributesString =
						"name;disabled;form;type;value;formaction;autofocus;formenctype;formmethod;formtarget;formnovalidate",
					TagFormatting = HtmlTagFormatting.Complete,
					ParentTagsString = "",
					ExcludeParentTagsString = "a;button",
					ParentContentTypes = HtmlElementType.Phrasing,
					ObsoleteAttributesString = ""
				},
				new HtmlElementInfo
				{
					TagName = "canvas",
					HtmlVersion = 5,
					Obsolete = false,
					ElementType = HtmlElementType.Flow,
					PermittedChildrenTypes = HtmlElementType.AnyContent,
					PermittedChildrenTagsString = "",
					AttributesString = "height;width",
					TagFormatting = HtmlTagFormatting.Complete,
					ParentTagsString = "",
					ExcludeParentTagsString = "",
					ParentContentTypes = HtmlElementType.Flow | HtmlElementType.Phrasing,
					ObsoleteAttributesString = ""
				},
				new HtmlElementInfo
				{
					TagName = "caption",
					HtmlVersion = 3,
					Obsolete = false,
					ElementType = HtmlElementType.Phrasing,
					PermittedChildrenTypes = HtmlElementType.AnyContent,
					PermittedChildrenTagsString = "",
					AttributesString = "",
					TagFormatting = HtmlTagFormatting.Complete,
					ParentTagsString = "table",
					ExcludeParentTagsString = "",
					ParentContentTypes = HtmlElementType.None,
					ObsoleteAttributesString = "align"
				},
				new HtmlElementInfo
				{
					TagName = "center",
					HtmlVersion = 3,
					Obsolete = true,
					ElementType = HtmlElementType.Flow,
					PermittedChildrenTypes = HtmlElementType.AnyContent,
					PermittedChildrenTagsString = "",
					AttributesString = "",
					TagFormatting = HtmlTagFormatting.Complete,
					ParentTagsString = "",
					ExcludeParentTagsString = "",
					ParentContentTypes = HtmlElementType.Flow,
					ObsoleteAttributesString = ""
				},
				new HtmlElementInfo
				{
					TagName = "cite",
					HtmlVersion = 3,
					Obsolete = false,
					ElementType = HtmlElementType.Phrasing,
					PermittedChildrenTypes = HtmlElementType.Phrasing | HtmlElementType.Text,
					PermittedChildrenTagsString = "",
					AttributesString = "",
					TagFormatting = HtmlTagFormatting.Complete,
					ParentTagsString = "",
					ExcludeParentTagsString = "",
					ParentContentTypes = HtmlElementType.Phrasing,
					ObsoleteAttributesString = ""
				},
				new HtmlElementInfo
				{
					TagName = "code",
					HtmlVersion = 3,
					Obsolete = false,
					ElementType = HtmlElementType.Phrasing,
					PermittedChildrenTypes = HtmlElementType.Phrasing | HtmlElementType.Text,
					PermittedChildrenTagsString = "",
					AttributesString = "",
					TagFormatting = HtmlTagFormatting.Complete,
					ParentTagsString = "",
					ExcludeParentTagsString = "",
					ParentContentTypes = HtmlElementType.Phrasing,
					ObsoleteAttributesString = ""
				},
				new HtmlElementInfo
				{
					TagName = "col",
					HtmlVersion = 3,
					Obsolete = false,
					ElementType = HtmlElementType.Phrasing,
					PermittedChildrenTypes = HtmlElementType.None,
					PermittedChildrenTagsString = "",
					AttributesString = "span",
					TagFormatting = HtmlTagFormatting.Single,
					ParentTagsString = "colgroup",
					ExcludeParentTagsString = "",
					ParentContentTypes = HtmlElementType.None,
					ObsoleteAttributesString = "align;width;char;charoff;valign"
				},
				new HtmlElementInfo
				{
					TagName = "colgroup",
					HtmlVersion = 4,
					Obsolete = false,
					ElementType = HtmlElementType.Phrasing,
					PermittedChildrenTypes = HtmlElementType.Phrasing | HtmlElementType.Text,
					PermittedChildrenTagsString = "",
					AttributesString = "span",
					TagFormatting = HtmlTagFormatting.OptionalClosing,
					ParentTagsString = "table",
					ExcludeParentTagsString = "",
					ParentContentTypes = HtmlElementType.None,
					ObsoleteAttributesString = "width;char;charoff;valign"
				},
				new HtmlElementInfo
				{
					TagName = "command",
					HtmlVersion = 5,
					Obsolete = false,
					ElementType = HtmlElementType.Meta,
					PermittedChildrenTypes = HtmlElementType.None,
					PermittedChildrenTagsString = "",
					AttributesString = "type;label;icon;disabled;radiogroup;checked;",
					TagFormatting = HtmlTagFormatting.Single,
					ParentTagsString = "",
					ExcludeParentTagsString = "",
					ParentContentTypes = HtmlElementType.Phrasing | HtmlElementType.Meta,
					ObsoleteAttributesString = ""
				},
				new HtmlElementInfo
				{
					TagName = "datalist",
					HtmlVersion = 5,
					Obsolete = false,
					ElementType = HtmlElementType.Phrasing,
					PermittedChildrenTypes = HtmlElementType.Phrasing | HtmlElementType.Text,
					PermittedChildrenTagsString = "",
					AttributesString = "",
					TagFormatting = HtmlTagFormatting.Complete,
					ParentTagsString = "",
					ExcludeParentTagsString = "",
					ParentContentTypes = HtmlElementType.Phrasing,
					ObsoleteAttributesString = ""
				},
				new HtmlElementInfo
				{
					TagName = "dd",
					HtmlVersion = 3,
					Obsolete = false,
					ElementType = HtmlElementType.Flow,
					PermittedChildrenTypes = HtmlElementType.AnyContent,
					PermittedChildrenTagsString = "",
					AttributesString = "",
					TagFormatting = HtmlTagFormatting.OptionalClosing,
					ParentTagsString = "dl",
					ExcludeParentTagsString = "",
					ParentContentTypes = HtmlElementType.None,
					ObsoleteAttributesString = ""
				},
				new HtmlElementInfo
				{
					TagName = "del",
					HtmlVersion = 4,
					Obsolete = false,
					ElementType = HtmlElementType.Phrasing,
					PermittedChildrenTypes = HtmlElementType.AnyContent,
					PermittedChildrenTagsString = "",
					AttributesString = "cite;datetime",
					TagFormatting = HtmlTagFormatting.Complete,
					ParentTagsString = "",
					ExcludeParentTagsString = "",
					ParentContentTypes = HtmlElementType.Flow | HtmlElementType.Phrasing,
					ObsoleteAttributesString = ""
				},
				new HtmlElementInfo
				{
					TagName = "details",
					HtmlVersion = 5,
					Obsolete = false,
					ElementType = HtmlElementType.Flow,
					PermittedChildrenTypes = HtmlElementType.AnyContent,
					PermittedChildrenTagsString = "",
					AttributesString = "open",
					TagFormatting = HtmlTagFormatting.Complete,
					ParentTagsString = "",
					ExcludeParentTagsString = "a;button",
					ParentContentTypes = HtmlElementType.Flow,
					ObsoleteAttributesString = ""
				},
				new HtmlElementInfo
				{
					TagName = "dfn",
					HtmlVersion = 3,
					Obsolete = false,
					ElementType = HtmlElementType.Phrasing,
					PermittedChildrenTypes = HtmlElementType.Phrasing | HtmlElementType.Text,
					PermittedChildrenTagsString = "",
					AttributesString = "",
					TagFormatting = HtmlTagFormatting.Complete,
					ParentTagsString = "",
					ExcludeParentTagsString = "",
					ParentContentTypes = HtmlElementType.Phrasing,
					ObsoleteAttributesString = ""
				},
				new HtmlElementInfo
				{
					TagName = "dir",
					HtmlVersion = 3,
					Obsolete = true,
					ElementType = HtmlElementType.Flow,
					PermittedChildrenTypes = HtmlElementType.AnyContent,
					PermittedChildrenTagsString = "",
					AttributesString = "",
					TagFormatting = HtmlTagFormatting.Complete,
					ParentTagsString = "",
					ExcludeParentTagsString = "",
					ParentContentTypes = HtmlElementType.Flow,
					ObsoleteAttributesString = ""
				},
				new HtmlElementInfo
				{
					TagName = "div",
					HtmlVersion = 3,
					Obsolete = false,
					ElementType = HtmlElementType.Flow,
					PermittedChildrenTypes = HtmlElementType.AnyContent,
					PermittedChildrenTagsString = "",
					AttributesString = "",
					TagFormatting = HtmlTagFormatting.Complete,
					ParentTagsString = "",
					ExcludeParentTagsString = "",
					ParentContentTypes = HtmlElementType.Flow,
					ObsoleteAttributesString = ""
				},
				new HtmlElementInfo
				{
					TagName = "dl",
					HtmlVersion = 3,
					Obsolete = false,
					ElementType = HtmlElementType.Flow,
					PermittedChildrenTypes = HtmlElementType.AnyContent,
					PermittedChildrenTagsString = "",
					AttributesString = "",
					TagFormatting = HtmlTagFormatting.Complete,
					ParentTagsString = "",
					ExcludeParentTagsString = "",
					ParentContentTypes = HtmlElementType.Flow,
					ObsoleteAttributesString = "compact"
				},
				new HtmlElementInfo
				{
					TagName = "dt",
					HtmlVersion = 3,
					Obsolete = false,
					ElementType = HtmlElementType.Flow,
					PermittedChildrenTypes = HtmlElementType.AnyContent,
					PermittedChildrenTagsString = "",
					AttributesString = "",
					TagFormatting = HtmlTagFormatting.OptionalClosing,
					ParentTagsString = "dl",
					ExcludeParentTagsString = "",
					ParentContentTypes = HtmlElementType.None,
					ObsoleteAttributesString = ""
				},
				new HtmlElementInfo
				{
					TagName = "em",
					HtmlVersion = 3,
					Obsolete = false,
					ElementType = HtmlElementType.Phrasing,
					PermittedChildrenTypes = HtmlElementType.Phrasing | HtmlElementType.Text,
					PermittedChildrenTagsString = "",
					AttributesString = "",
					TagFormatting = HtmlTagFormatting.Complete,
					ParentTagsString = "",
					ExcludeParentTagsString = "",
					ParentContentTypes = HtmlElementType.Phrasing,
					ObsoleteAttributesString = ""
				},
				new HtmlElementInfo
				{
					TagName = "embed",
					HtmlVersion = 3,
					Obsolete = true,
					ElementType = HtmlElementType.Phrasing,
					PermittedChildrenTypes = HtmlElementType.Phrasing | HtmlElementType.Text,
					PermittedChildrenTagsString = "",
					AttributesString = "",
					TagFormatting = HtmlTagFormatting.Single,
					ParentTagsString = "",
					ExcludeParentTagsString = "",
					ParentContentTypes = HtmlElementType.Phrasing,
					ObsoleteAttributesString = ""
				},
				new HtmlElementInfo
				{
					TagName = "fieldset",
					HtmlVersion = 4,
					Obsolete = false,
					ElementType = HtmlElementType.Flow,
					PermittedChildrenTypes = HtmlElementType.AnyContent,
					PermittedChildrenTagsString = "",
					AttributesString = "name;disabled;form",
					TagFormatting = HtmlTagFormatting.Complete,
					ParentTagsString = "",
					ExcludeParentTagsString = "",
					ParentContentTypes = HtmlElementType.Flow,
					ObsoleteAttributesString = ""
				},
				new HtmlElementInfo
				{
					TagName = "figcaption",
					HtmlVersion = 5,
					Obsolete = false,
					ElementType = HtmlElementType.Flow,
					PermittedChildrenTypes = HtmlElementType.AnyContent,
					PermittedChildrenTagsString = "",
					AttributesString = "",
					TagFormatting = HtmlTagFormatting.Complete,
					ParentTagsString = "figure",
					ExcludeParentTagsString = "",
					ParentContentTypes = HtmlElementType.None,
					ObsoleteAttributesString = ""
				},
				new HtmlElementInfo
				{
					TagName = "figure",
					HtmlVersion = 5,
					Obsolete = false,
					ElementType = HtmlElementType.Flow,
					PermittedChildrenTypes = HtmlElementType.AnyContent,
					PermittedChildrenTagsString = "",
					AttributesString = "",
					TagFormatting = HtmlTagFormatting.Complete,
					ParentTagsString = "",
					ExcludeParentTagsString = "",
					ParentContentTypes = HtmlElementType.Flow,
					ObsoleteAttributesString = ""
				},
				new HtmlElementInfo
				{
					TagName = "font",
					HtmlVersion = 3,
					Obsolete = true,
					ElementType = HtmlElementType.Phrasing,
					PermittedChildrenTypes = HtmlElementType.Phrasing | HtmlElementType.Text,
					PermittedChildrenTagsString = "",
					AttributesString = "",
					TagFormatting = HtmlTagFormatting.Complete,
					ParentTagsString = "",
					ExcludeParentTagsString = "",
					ParentContentTypes = HtmlElementType.Phrasing,
					ObsoleteAttributesString = ""
				},
				new HtmlElementInfo
				{
					TagName = "footer",
					HtmlVersion = 5,
					Obsolete = false,
					ElementType = HtmlElementType.Flow,
					PermittedChildrenTypes = HtmlElementType.AnyContent,
					PermittedChildrenTagsString = "",
					AttributesString = "",
					TagFormatting = HtmlTagFormatting.Complete,
					ParentTagsString = "",
					ExcludeParentTagsString = "header;footer;address",
					ParentContentTypes = HtmlElementType.Flow,
					ObsoleteAttributesString = ""
				},
				new HtmlElementInfo
				{
					TagName = "form",
					HtmlVersion = 3,
					Obsolete = false,
					ElementType = HtmlElementType.Flow,
					PermittedChildrenTypes = HtmlElementType.AnyContent,
					PermittedChildrenTagsString = "",
					AttributesString = "action;method;enctype;name;accept-charset;novalidate;target;autocomplete",
					TagFormatting = HtmlTagFormatting.Complete,
					ParentTagsString = "",
					ExcludeParentTagsString = "form",
					ParentContentTypes = HtmlElementType.Flow,
					ObsoleteAttributesString = ""
				},
				new HtmlElementInfo
				{
					TagName = "frame",
					HtmlVersion = 3,
					Obsolete = true,
					ElementType = HtmlElementType.Flow,
					PermittedChildrenTypes = HtmlElementType.AnyContent,
					PermittedChildrenTagsString = "",
					AttributesString = "",
					TagFormatting = HtmlTagFormatting.Single,
					ParentTagsString = "",
					ExcludeParentTagsString = "",
					ParentContentTypes = HtmlElementType.Flow,
					ObsoleteAttributesString = ""
				},
				new HtmlElementInfo
				{
					TagName = "frameset",
					HtmlVersion = 3,
					Obsolete = true,
					ElementType = HtmlElementType.Flow,
					PermittedChildrenTypes = HtmlElementType.AnyContent,
					PermittedChildrenTagsString = "",
					AttributesString = "",
					TagFormatting = HtmlTagFormatting.Complete,
					ParentTagsString = "",
					ExcludeParentTagsString = "",
					ParentContentTypes = HtmlElementType.Flow,
					ObsoleteAttributesString = ""
				},
				new HtmlElementInfo
				{
					TagName = "h1",
					HtmlVersion = 3,
					Obsolete = false,
					ElementType = HtmlElementType.Flow,
					PermittedChildrenTypes = HtmlElementType.Phrasing | HtmlElementType.Text,
					PermittedChildrenTagsString = "",
					AttributesString = "",
					TagFormatting = HtmlTagFormatting.Complete,
					ParentTagsString = "hgroup",
					ExcludeParentTagsString = "address",
					ParentContentTypes = HtmlElementType.Flow,
					ObsoleteAttributesString = "align"
				},
				new HtmlElementInfo
				{
					TagName = "h2",
					HtmlVersion = 3,
					Obsolete = false,
					ElementType = HtmlElementType.Flow,
					PermittedChildrenTypes = HtmlElementType.Phrasing | HtmlElementType.Text,
					PermittedChildrenTagsString = "",
					AttributesString = "",
					TagFormatting = HtmlTagFormatting.Complete,
					ParentTagsString = "hgroup",
					ExcludeParentTagsString = "address",
					ParentContentTypes = HtmlElementType.Flow,
					ObsoleteAttributesString = "align"
				},
				new HtmlElementInfo
				{
					TagName = "h3",
					HtmlVersion = 3,
					Obsolete = false,
					ElementType = HtmlElementType.Flow,
					PermittedChildrenTypes = HtmlElementType.Phrasing | HtmlElementType.Text,
					PermittedChildrenTagsString = "",
					AttributesString = "",
					TagFormatting = HtmlTagFormatting.Complete,
					ParentTagsString = "hgroup",
					ExcludeParentTagsString = "address",
					ParentContentTypes = HtmlElementType.Flow,
					ObsoleteAttributesString = "align"
				},
				new HtmlElementInfo
				{
					TagName = "h4",
					HtmlVersion = 3,
					Obsolete = false,
					ElementType = HtmlElementType.Flow,
					PermittedChildrenTypes = HtmlElementType.Phrasing | HtmlElementType.Text,
					PermittedChildrenTagsString = "",
					AttributesString = "",
					TagFormatting = HtmlTagFormatting.Complete,
					ParentTagsString = "hgroup",
					ExcludeParentTagsString = "address",
					ParentContentTypes = HtmlElementType.Flow,
					ObsoleteAttributesString = "align"
				},
				new HtmlElementInfo
				{
					TagName = "h5",
					HtmlVersion = 3,
					Obsolete = false,
					ElementType = HtmlElementType.Flow,
					PermittedChildrenTypes = HtmlElementType.Phrasing | HtmlElementType.Text,
					PermittedChildrenTagsString = "",
					AttributesString = "",
					TagFormatting = HtmlTagFormatting.Complete,
					ParentTagsString = "hgroup",
					ExcludeParentTagsString = "address",
					ParentContentTypes = HtmlElementType.Flow,
					ObsoleteAttributesString = "align"
				},
				new HtmlElementInfo
				{
					TagName = "h6",
					HtmlVersion = 3,
					Obsolete = false,
					ElementType = HtmlElementType.Flow,
					PermittedChildrenTypes = HtmlElementType.Phrasing | HtmlElementType.Text,
					PermittedChildrenTagsString = "",
					AttributesString = "",
					TagFormatting = HtmlTagFormatting.Complete,
					ParentTagsString = "hgroup",
					ExcludeParentTagsString = "address",
					ParentContentTypes = HtmlElementType.Flow,
					ObsoleteAttributesString = "align"
				},
				new HtmlElementInfo
				{
					TagName = "head",
					HtmlVersion = 3,
					Obsolete = false,
					ElementType = HtmlElementType.Meta,
					PermittedChildrenTypes = HtmlElementType.Meta,
					PermittedChildrenTagsString = "",
					AttributesString = "",
					TagFormatting = HtmlTagFormatting.OptionalClosing,
					ParentTagsString = "html",
					ExcludeParentTagsString = "",
					ParentContentTypes = HtmlElementType.None,
					ObsoleteAttributesString = "profile"
				},
				new HtmlElementInfo
				{
					TagName = "header",
					HtmlVersion = 5,
					Obsolete = false,
					ElementType = HtmlElementType.Flow,
					PermittedChildrenTypes = HtmlElementType.AnyContent,
					PermittedChildrenTagsString = "",
					AttributesString = "",
					TagFormatting = HtmlTagFormatting.Complete,
					ParentTagsString = "",
					ExcludeParentTagsString = "footer;address;header",
					ParentContentTypes = HtmlElementType.Flow,
					ObsoleteAttributesString = ""
				},
				new HtmlElementInfo
				{
					TagName = "hgroup",
					HtmlVersion = 5,
					Obsolete = false,
					ElementType = HtmlElementType.Flow,
					PermittedChildrenTypes = HtmlElementType.None,
					PermittedChildrenTagsString = "h1;h2;h3;h4;h5;h6",
					AttributesString = "",
					TagFormatting = HtmlTagFormatting.Complete,
					ParentTagsString = "",
					ExcludeParentTagsString = "",
					ParentContentTypes = HtmlElementType.Flow,
					ObsoleteAttributesString = ""
				},
				new HtmlElementInfo
				{
					TagName = "hr",
					HtmlVersion = 3,
					Obsolete = false,
					ElementType = HtmlElementType.Flow,
					PermittedChildrenTypes = HtmlElementType.None,
					PermittedChildrenTagsString = "",
					AttributesString = "",
					TagFormatting = HtmlTagFormatting.Single,
					ParentTagsString = "",
					ExcludeParentTagsString = "",
					ParentContentTypes = HtmlElementType.Flow,
					ObsoleteAttributesString = "align;width;noshade;size;color"
				},
				new HtmlElementInfo
				{
					TagName = "html",
					HtmlVersion = 3,
					Obsolete = false,
					ElementType = HtmlElementType.Phrasing,
					PermittedChildrenTypes = HtmlElementType.None,
					PermittedChildrenTagsString = "head;body",
					AttributesString = "manifest",
					TagFormatting = HtmlTagFormatting.OptionalClosing,
					ParentTagsString = "",
					ExcludeParentTagsString = "",
					ParentContentTypes = HtmlElementType.None,
					ObsoleteAttributesString = "version"
				},
				new HtmlElementInfo
				{
					TagName = "i",
					HtmlVersion = 3,
					Obsolete = false,
					ElementType = HtmlElementType.Phrasing,
					PermittedChildrenTypes = HtmlElementType.Phrasing | HtmlElementType.Text,
					PermittedChildrenTagsString = "",
					AttributesString = "",
					TagFormatting = HtmlTagFormatting.Complete,
					ParentTagsString = "",
					ExcludeParentTagsString = "",
					ParentContentTypes = HtmlElementType.Phrasing,
					ObsoleteAttributesString = ""
				},
				new HtmlElementInfo
				{
					TagName = "iframe",
					HtmlVersion = 3,
					Obsolete = false,
					ElementType = HtmlElementType.Flow,
					PermittedChildrenTypes = HtmlElementType.Text,
					PermittedChildrenTagsString = "",
					AttributesString = "src;srcdoc;name;width;height;sandbox;seamless;",
					TagFormatting = HtmlTagFormatting.Complete,
					ParentTagsString = "",
					ExcludeParentTagsString = "a;button",
					ParentContentTypes = HtmlElementType.Phrasing,
					ObsoleteAttributesString = "longdesc;align;allowtransparency;frameborder;marginheight;marginwidth;scrolling"
				},
				new HtmlElementInfo
				{
					TagName = "img",
					HtmlVersion = 3,
					Obsolete = false,
					ElementType = HtmlElementType.Phrasing,
					PermittedChildrenTypes = HtmlElementType.None,
					PermittedChildrenTagsString = "",
					AttributesString = "src;alt;height;width;usemap;ismap;border",
					TagFormatting = HtmlTagFormatting.Single,
					ParentTagsString = "",
					ExcludeParentTagsString = "",
					ParentContentTypes = HtmlElementType.Phrasing,
					ObsoleteAttributesString = "longdesc;name;align;hspace;vspace;border"
				},
				new HtmlElementInfo
				{
					TagName = "input",
					HtmlVersion = 3,
					Obsolete = false,
					ElementType = HtmlElementType.Phrasing,
					PermittedChildrenTypes = HtmlElementType.None,
					PermittedChildrenTagsString = "",
					AttributesString =
						"name;disabled;form;type;maxlength;readonly;size;value;autocomplete;autofocus;list;pattern;required;placeholder;dirname;checked;formaction;formenctype;formmethod;formtarget;formnovalidate;accept;multiple;alt;src;height;width;list;min;max;step;",
					TagFormatting = HtmlTagFormatting.Single,
					ParentTagsString = "",
					ExcludeParentTagsString = "",
					ParentContentTypes = HtmlElementType.Phrasing,
					ObsoleteAttributesString = "usemap;align"
				},
				new HtmlElementInfo
				{
					TagName = "ins",
					HtmlVersion = 4,
					Obsolete = false,
					ElementType = HtmlElementType.Phrasing,
					PermittedChildrenTypes = HtmlElementType.AnyContent,
					PermittedChildrenTagsString = "",
					AttributesString = "cite;datetime",
					TagFormatting = HtmlTagFormatting.Complete,
					ParentTagsString = "",
					ExcludeParentTagsString = "",
					ParentContentTypes = HtmlElementType.Flow | HtmlElementType.Phrasing,
					ObsoleteAttributesString = ""
				},
				new HtmlElementInfo
				{
					TagName = "isindex",
					HtmlVersion = 3,
					Obsolete = true,
					ElementType = HtmlElementType.Flow,
					PermittedChildrenTypes = HtmlElementType.AnyContent,
					PermittedChildrenTagsString = "",
					AttributesString = "",
					TagFormatting = HtmlTagFormatting.Single,
					ParentTagsString = "",
					ExcludeParentTagsString = "",
					ParentContentTypes = HtmlElementType.Flow,
					ObsoleteAttributesString = ""
				},
				new HtmlElementInfo
				{
					TagName = "kbd",
					HtmlVersion = 3,
					Obsolete = false,
					ElementType = HtmlElementType.Phrasing,
					PermittedChildrenTypes = HtmlElementType.Phrasing | HtmlElementType.Text,
					PermittedChildrenTagsString = "",
					AttributesString = "",
					TagFormatting = HtmlTagFormatting.Complete,
					ParentTagsString = "",
					ExcludeParentTagsString = "",
					ParentContentTypes = HtmlElementType.Phrasing,
					ObsoleteAttributesString = ""
				},
				new HtmlElementInfo
				{
					TagName = "keygen",
					HtmlVersion = 5,
					Obsolete = false,
					ElementType = HtmlElementType.Phrasing,
					PermittedChildrenTypes = HtmlElementType.Phrasing | HtmlElementType.Text,
					PermittedChildrenTagsString = "",
					AttributesString = "challenge;keytype;autofocus;name;disabled;form",
					TagFormatting = HtmlTagFormatting.Single,
					ParentTagsString = "",
					ExcludeParentTagsString = "",
					ParentContentTypes = HtmlElementType.Phrasing,
					ObsoleteAttributesString = ""
				},
				new HtmlElementInfo
				{
					TagName = "label",
					HtmlVersion = 4,
					Obsolete = false,
					ElementType = HtmlElementType.Phrasing,
					PermittedChildrenTypes = HtmlElementType.Phrasing | HtmlElementType.Text,
					PermittedChildrenTagsString = "",
					AttributesString = "for;form",
					TagFormatting = HtmlTagFormatting.Complete,
					ParentTagsString = "",
					ExcludeParentTagsString = "",
					ParentContentTypes = HtmlElementType.Phrasing,
					ObsoleteAttributesString = ""
				},
				new HtmlElementInfo
				{
					TagName = "legend",
					HtmlVersion = 3,
					Obsolete = false,
					ElementType = HtmlElementType.Phrasing,
					PermittedChildrenTypes = HtmlElementType.Phrasing | HtmlElementType.Text,
					PermittedChildrenTagsString = "",
					AttributesString = "",
					TagFormatting = HtmlTagFormatting.Complete,
					ParentTagsString = "fieldset",
					ExcludeParentTagsString = "",
					ParentContentTypes = HtmlElementType.None,
					ObsoleteAttributesString = ""
				},
				new HtmlElementInfo
				{
					TagName = "li",
					HtmlVersion = 3,
					Obsolete = false,
					ElementType = HtmlElementType.Flow,
					PermittedChildrenTypes = HtmlElementType.AnyContent,
					PermittedChildrenTagsString = "",
					AttributesString = "value",
					TagFormatting = HtmlTagFormatting.OptionalClosing,
					ParentTagsString = "ul;ol;menu",
					ExcludeParentTagsString = "",
					ParentContentTypes = HtmlElementType.None,
					ObsoleteAttributesString = ""
				},
				new HtmlElementInfo
				{
					TagName = "link",
					HtmlVersion = 3,
					Obsolete = false,
					ElementType = HtmlElementType.Meta,
					PermittedChildrenTypes = HtmlElementType.None,
					PermittedChildrenTagsString = "",
					AttributesString = "href;rel;hreflang;media;type;sizes",
					TagFormatting = HtmlTagFormatting.Single,
					ParentTagsString = "noscript",
					ExcludeParentTagsString = "",
					ParentContentTypes = HtmlElementType.Meta,
					ObsoleteAttributesString = "target;urn;charset;methods;rev"
				},
				new HtmlElementInfo
				{
					TagName = "map",
					HtmlVersion = 3,
					Obsolete = false,
					ElementType = HtmlElementType.Phrasing,
					PermittedChildrenTypes = HtmlElementType.AnyContent,
					PermittedChildrenTagsString = "",
					AttributesString = "name",
					TagFormatting = HtmlTagFormatting.Complete,
					ParentTagsString = "",
					ExcludeParentTagsString = "",
					ParentContentTypes = HtmlElementType.Flow | HtmlElementType.Phrasing,
					ObsoleteAttributesString = ""
				},
				new HtmlElementInfo
				{
					TagName = "mark",
					HtmlVersion = 5,
					Obsolete = false,
					ElementType = HtmlElementType.Phrasing,
					PermittedChildrenTypes = HtmlElementType.Phrasing | HtmlElementType.Text,
					PermittedChildrenTagsString = "",
					AttributesString = "",
					TagFormatting = HtmlTagFormatting.Complete,
					ParentTagsString = "",
					ExcludeParentTagsString = "",
					ParentContentTypes = HtmlElementType.Phrasing,
					ObsoleteAttributesString = ""
				},
				new HtmlElementInfo
				{
					TagName = "menu",
					HtmlVersion = 3,
					Obsolete = false,
					ElementType = HtmlElementType.Flow,
					PermittedChildrenTypes = HtmlElementType.AnyContent,
					PermittedChildrenTagsString = "",
					AttributesString = "type;label",
					TagFormatting = HtmlTagFormatting.Complete,
					ParentTagsString = "",
					ExcludeParentTagsString = "",
					ParentContentTypes = HtmlElementType.Flow,
					ObsoleteAttributesString = "compact"
				},
				new HtmlElementInfo
				{
					TagName = "meta",
					HtmlVersion = 3,
					Obsolete = false,
					ElementType = HtmlElementType.Meta,
					PermittedChildrenTypes = HtmlElementType.None,
					PermittedChildrenTagsString = "",
					AttributesString = "name;content;http-equiv;charset;",
					TagFormatting = HtmlTagFormatting.Single,
					ParentTagsString = "",
					ExcludeParentTagsString = "",
					ParentContentTypes = HtmlElementType.Meta,
					ObsoleteAttributesString = ""
				},
				new HtmlElementInfo
				{
					TagName = "meter",
					HtmlVersion = 5,
					Obsolete = false,
					ElementType = HtmlElementType.Phrasing,
					PermittedChildrenTypes = HtmlElementType.Phrasing | HtmlElementType.Text,
					PermittedChildrenTagsString = "",
					AttributesString = "value;min;low;high;max;optimum",
					TagFormatting = HtmlTagFormatting.Complete,
					ParentTagsString = "",
					ExcludeParentTagsString = "",
					ParentContentTypes = HtmlElementType.Phrasing,
					ObsoleteAttributesString = ""
				},
				new HtmlElementInfo
				{
					TagName = "nav",
					HtmlVersion = 5,
					Obsolete = false,
					ElementType = HtmlElementType.Flow,
					PermittedChildrenTypes = HtmlElementType.AnyContent,
					PermittedChildrenTagsString = "",
					AttributesString = "",
					TagFormatting = HtmlTagFormatting.Complete,
					ParentTagsString = "",
					ExcludeParentTagsString = "address",
					ParentContentTypes = HtmlElementType.Flow,
					ObsoleteAttributesString = ""
				},
				new HtmlElementInfo
				{
					TagName = "nobr",
					HtmlVersion = 3,
					Obsolete = true,
					ElementType = HtmlElementType.Phrasing,
					PermittedChildrenTypes = HtmlElementType.Phrasing | HtmlElementType.Text,
					PermittedChildrenTagsString = "",
					AttributesString = "",
					TagFormatting = HtmlTagFormatting.Complete,
					ParentTagsString = "",
					ExcludeParentTagsString = "",
					ParentContentTypes = HtmlElementType.Phrasing,
					ObsoleteAttributesString = ""
				},
				new HtmlElementInfo
				{
					TagName = "noframes",
					HtmlVersion = 3,
					Obsolete = true,
					ElementType = HtmlElementType.Flow,
					PermittedChildrenTypes = HtmlElementType.AnyContent,
					PermittedChildrenTagsString = "",
					AttributesString = "",
					TagFormatting = HtmlTagFormatting.Complete,
					ParentTagsString = "",
					ExcludeParentTagsString = "",
					ParentContentTypes = HtmlElementType.Flow,
					ObsoleteAttributesString = ""
				},
				new HtmlElementInfo
				{
					TagName = "noscript",
					HtmlVersion = 3,
					Obsolete = false,
					ElementType = HtmlElementType.Meta,
					PermittedChildrenTypes = HtmlElementType.Meta | HtmlElementType.AnyContent,
					PermittedChildrenTagsString = "",
					AttributesString = "",
					TagFormatting = HtmlTagFormatting.Complete,
					ParentTagsString = "",
					ExcludeParentTagsString = "noscript",
					ParentContentTypes = HtmlElementType.Meta | HtmlElementType.Flow | HtmlElementType.Phrasing,
					ObsoleteAttributesString = ""
				},
				new HtmlElementInfo
				{
					TagName = "object",
					HtmlVersion = 3,
					Obsolete = false,
					ElementType = HtmlElementType.Phrasing,
					PermittedChildrenTypes = HtmlElementType.AnyContent,
					PermittedChildrenTagsString = "",
					AttributesString = "data;type;height;width;usemap;name;form",
					TagFormatting = HtmlTagFormatting.Complete,
					ParentTagsString = "",
					ExcludeParentTagsString = "a;button",
					ParentContentTypes = HtmlElementType.Flow | HtmlElementType.Phrasing,
					ObsoleteAttributesString = "archive;classid;code;codebase;codetype;declare;standby;align;hspace;vspace;border"
				},
				new HtmlElementInfo
				{
					TagName = "ol",
					HtmlVersion = 3,
					Obsolete = false,
					ElementType = HtmlElementType.Flow,
					PermittedChildrenTypes = HtmlElementType.None,
					PermittedChildrenTagsString = "li",
					AttributesString = "start;reversed;type",
					TagFormatting = HtmlTagFormatting.Complete,
					ParentTagsString = "",
					ExcludeParentTagsString = "",
					ParentContentTypes = HtmlElementType.Flow,
					ObsoleteAttributesString = "compact"
				},
				new HtmlElementInfo
				{
					TagName = "optgroup",
					HtmlVersion = 3,
					Obsolete = false,
					ElementType = HtmlElementType.Phrasing,
					PermittedChildrenTypes = HtmlElementType.None,
					PermittedChildrenTagsString = "option",
					AttributesString = "label;disabled",
					TagFormatting = HtmlTagFormatting.OptionalClosing,
					ParentTagsString = "select",
					ExcludeParentTagsString = "",
					ParentContentTypes = HtmlElementType.None,
					ObsoleteAttributesString = ""
				},
				new HtmlElementInfo
				{
					TagName = "option",
					HtmlVersion = 3,
					Obsolete = false,
					ElementType = HtmlElementType.Phrasing,
					PermittedChildrenTypes = HtmlElementType.Text,
					PermittedChildrenTagsString = "",
					AttributesString = "disabled;selected;label;value",
					TagFormatting = HtmlTagFormatting.OptionalClosing,
					ParentTagsString = "optgroup;select;datalist",
					ExcludeParentTagsString = "",
					ParentContentTypes = HtmlElementType.None,
					ObsoleteAttributesString = "name"
				},
				new HtmlElementInfo
				{
					TagName = "output",
					HtmlVersion = 5,
					Obsolete = false,
					ElementType = HtmlElementType.Phrasing,
					PermittedChildrenTypes = HtmlElementType.Phrasing | HtmlElementType.Text,
					PermittedChildrenTagsString = "",
					AttributesString = "name;form;for",
					TagFormatting = HtmlTagFormatting.Complete,
					ParentTagsString = "",
					ExcludeParentTagsString = "",
					ParentContentTypes = HtmlElementType.Phrasing,
					ObsoleteAttributesString = ""
				},
				new HtmlElementInfo
				{
					TagName = "p",
					HtmlVersion = 3,
					Obsolete = false,
					ElementType = HtmlElementType.Flow,
					PermittedChildrenTypes = HtmlElementType.Phrasing | HtmlElementType.Text,
					PermittedChildrenTagsString = "",
					AttributesString = "",
					TagFormatting = HtmlTagFormatting.OptionalClosing,
					ParentTagsString = "",
					ExcludeParentTagsString = "",
					ParentContentTypes = HtmlElementType.Flow,
					ObsoleteAttributesString = "align"
				},
				new HtmlElementInfo
				{
					TagName = "param",
					HtmlVersion = 3,
					Obsolete = false,
					ElementType = HtmlElementType.Meta,
					PermittedChildrenTypes = HtmlElementType.None,
					PermittedChildrenTagsString = "",
					AttributesString = "name;value",
					TagFormatting = HtmlTagFormatting.Single,
					ParentTagsString = "object",
					ExcludeParentTagsString = "",
					ParentContentTypes = HtmlElementType.None,
					ObsoleteAttributesString = "type;valuetype"
				},
				new HtmlElementInfo
				{
					TagName = "pre",
					HtmlVersion = 3,
					Obsolete = false,
					ElementType = HtmlElementType.Flow,
					PermittedChildrenTypes = HtmlElementType.Phrasing | HtmlElementType.Text,
					PermittedChildrenTagsString = "",
					AttributesString = "",
					TagFormatting = HtmlTagFormatting.Complete,
					ParentTagsString = "",
					ExcludeParentTagsString = "",
					ParentContentTypes = HtmlElementType.Flow,
					ObsoleteAttributesString = ""
				},
				new HtmlElementInfo
				{
					TagName = "progress",
					HtmlVersion = 5,
					Obsolete = false,
					ElementType = HtmlElementType.Phrasing,
					PermittedChildrenTypes = HtmlElementType.Phrasing | HtmlElementType.Text,
					PermittedChildrenTagsString = "",
					AttributesString = "value;max",
					TagFormatting = HtmlTagFormatting.Complete,
					ParentTagsString = "",
					ExcludeParentTagsString = "",
					ParentContentTypes = HtmlElementType.Phrasing,
					ObsoleteAttributesString = ""
				},
				new HtmlElementInfo
				{
					TagName = "q",
					HtmlVersion = 4,
					Obsolete = false,
					ElementType = HtmlElementType.Phrasing,
					PermittedChildrenTypes = HtmlElementType.Phrasing | HtmlElementType.Text,
					PermittedChildrenTagsString = "",
					AttributesString = "cite",
					TagFormatting = HtmlTagFormatting.Complete,
					ParentTagsString = "",
					ExcludeParentTagsString = "",
					ParentContentTypes = HtmlElementType.Phrasing,
					ObsoleteAttributesString = ""
				},
				new HtmlElementInfo
				{
					TagName = "rp",
					HtmlVersion = 5,
					Obsolete = false,
					ElementType = HtmlElementType.Phrasing,
					PermittedChildrenTypes = HtmlElementType.Phrasing | HtmlElementType.Text,
					PermittedChildrenTagsString = "",
					AttributesString = "",
					TagFormatting = HtmlTagFormatting.Complete,
					ParentTagsString = "ruby",
					ExcludeParentTagsString = "",
					ParentContentTypes = HtmlElementType.None,
					ObsoleteAttributesString = ""
				},
				new HtmlElementInfo
				{
					TagName = "rt",
					HtmlVersion = 5,
					Obsolete = false,
					ElementType = HtmlElementType.Phrasing,
					PermittedChildrenTypes = HtmlElementType.Phrasing | HtmlElementType.Text,
					PermittedChildrenTagsString = "",
					AttributesString = "",
					TagFormatting = HtmlTagFormatting.Complete,
					ParentTagsString = "ruby",
					ExcludeParentTagsString = "",
					ParentContentTypes = HtmlElementType.None,
					ObsoleteAttributesString = ""
				},
				new HtmlElementInfo
				{
					TagName = "ruby",
					HtmlVersion = 5,
					Obsolete = false,
					ElementType = HtmlElementType.Phrasing,
					PermittedChildrenTypes = HtmlElementType.Phrasing | HtmlElementType.Text,
					PermittedChildrenTagsString = "",
					AttributesString = "",
					TagFormatting = HtmlTagFormatting.Complete,
					ParentTagsString = "",
					ExcludeParentTagsString = "",
					ParentContentTypes = HtmlElementType.Phrasing,
					ObsoleteAttributesString = ""
				},
				new HtmlElementInfo
				{
					TagName = "s",
					HtmlVersion = 3,
					Obsolete = true,
					ElementType = HtmlElementType.Phrasing,
					PermittedChildrenTypes = HtmlElementType.Phrasing | HtmlElementType.Text,
					PermittedChildrenTagsString = "",
					AttributesString = "",
					TagFormatting = HtmlTagFormatting.Complete,
					ParentTagsString = "",
					ExcludeParentTagsString = "",
					ParentContentTypes = HtmlElementType.Phrasing,
					ObsoleteAttributesString = ""
				},
				new HtmlElementInfo
				{
					TagName = "samp",
					HtmlVersion = 3,
					Obsolete = false,
					ElementType = HtmlElementType.Phrasing,
					PermittedChildrenTypes = HtmlElementType.Phrasing | HtmlElementType.Text,
					PermittedChildrenTagsString = "",
					AttributesString = "",
					TagFormatting = HtmlTagFormatting.Complete,
					ParentTagsString = "",
					ExcludeParentTagsString = "",
					ParentContentTypes = HtmlElementType.Phrasing,
					ObsoleteAttributesString = ""
				},
				new HtmlElementInfo
				{
					TagName = "script",
					HtmlVersion = 3,
					Obsolete = false,
					ElementType = HtmlElementType.Meta,
					PermittedChildrenTypes = HtmlElementType.NRCharData,
					PermittedChildrenTagsString = "",
					AttributesString = "type;src;defer;async;charset",
					TagFormatting = HtmlTagFormatting.Complete,
					ParentTagsString = "",
					ExcludeParentTagsString = "",
					ParentContentTypes = HtmlElementType.Meta | HtmlElementType.Phrasing | HtmlElementType.Flow,
					ObsoleteAttributesString = "language"
				},
				new HtmlElementInfo
				{
					TagName = "section",
					HtmlVersion = 5,
					Obsolete = false,
					ElementType = HtmlElementType.Flow,
					PermittedChildrenTypes = HtmlElementType.AnyContent,
					PermittedChildrenTagsString = "style",
					AttributesString = "",
					TagFormatting = HtmlTagFormatting.Complete,
					ParentTagsString = "",
					ExcludeParentTagsString = "",
					ParentContentTypes = HtmlElementType.Flow,
					ObsoleteAttributesString = ""
				},
				new HtmlElementInfo
				{
					TagName = "select",
					HtmlVersion = 3,
					Obsolete = false,
					ElementType = HtmlElementType.Phrasing,
					PermittedChildrenTypes = HtmlElementType.None,
					PermittedChildrenTagsString = "optgroup;option",
					AttributesString = "name;disabled;form;size;multiple;autofocus;required",
					TagFormatting = HtmlTagFormatting.Complete,
					ParentTagsString = "",
					ExcludeParentTagsString = "a;button",
					ParentContentTypes = HtmlElementType.Phrasing,
					ObsoleteAttributesString = ""
				},
				new HtmlElementInfo
				{
					TagName = "small",
					HtmlVersion = 3,
					Obsolete = false,
					ElementType = HtmlElementType.Phrasing,
					PermittedChildrenTypes = HtmlElementType.Phrasing | HtmlElementType.Text,
					PermittedChildrenTagsString = "",
					AttributesString = "",
					TagFormatting = HtmlTagFormatting.Complete,
					ParentTagsString = "",
					ExcludeParentTagsString = "",
					ParentContentTypes = HtmlElementType.Phrasing,
					ObsoleteAttributesString = ""
				},
				new HtmlElementInfo
				{
					TagName = "source",
					HtmlVersion = 5,
					Obsolete = false,
					ElementType = HtmlElementType.Meta,
					PermittedChildrenTypes = HtmlElementType.None,
					PermittedChildrenTagsString = "",
					AttributesString = "src;type;media",
					TagFormatting = HtmlTagFormatting.Complete,
					ParentTagsString = "audio;video",
					ExcludeParentTagsString = "",
					ParentContentTypes = HtmlElementType.None,
					ObsoleteAttributesString = ""
				},
				new HtmlElementInfo
				{
					TagName = "span",
					HtmlVersion = 3,
					Obsolete = false,
					ElementType = HtmlElementType.Phrasing,
					PermittedChildrenTypes = HtmlElementType.Phrasing | HtmlElementType.Text,
					PermittedChildrenTagsString = "",
					AttributesString = "",
					TagFormatting = HtmlTagFormatting.Complete,
					ParentTagsString = "",
					ExcludeParentTagsString = "",
					ParentContentTypes = HtmlElementType.Phrasing,
					ObsoleteAttributesString = ""
				},
				new HtmlElementInfo
				{
					TagName = "strike",
					HtmlVersion = 3,
					Obsolete = true,
					ElementType = HtmlElementType.Phrasing,
					PermittedChildrenTypes = HtmlElementType.Phrasing | HtmlElementType.Text,
					PermittedChildrenTagsString = "",
					AttributesString = "",
					TagFormatting = HtmlTagFormatting.Complete,
					ParentTagsString = "",
					ExcludeParentTagsString = "",
					ParentContentTypes = HtmlElementType.Phrasing,
					ObsoleteAttributesString = ""
				},
				new HtmlElementInfo
				{
					TagName = "strong",
					HtmlVersion = 3,
					Obsolete = false,
					ElementType = HtmlElementType.Phrasing,
					PermittedChildrenTypes = HtmlElementType.Phrasing | HtmlElementType.Text,
					PermittedChildrenTagsString = "",
					AttributesString = "",
					TagFormatting = HtmlTagFormatting.Complete,
					ParentTagsString = "",
					ExcludeParentTagsString = "",
					ParentContentTypes = HtmlElementType.Phrasing,
					ObsoleteAttributesString = ""
				},
				new HtmlElementInfo
				{
					TagName = "style",
					HtmlVersion = 3,
					Obsolete = false,
					ElementType = HtmlElementType.Meta,
					PermittedChildrenTypes = HtmlElementType.NRCharData,
					PermittedChildrenTagsString = "",
					AttributesString = "type;media;scoped",
					TagFormatting = HtmlTagFormatting.Complete,
					ParentTagsString = "div;noscript;section;article;aside",
					ExcludeParentTagsString = "",
					ParentContentTypes = HtmlElementType.Meta,
					ObsoleteAttributesString = ""
				},
				new HtmlElementInfo
				{
					TagName = "sub",
					HtmlVersion = 3,
					Obsolete = false,
					ElementType = HtmlElementType.Phrasing,
					PermittedChildrenTypes = HtmlElementType.Phrasing | HtmlElementType.Text,
					PermittedChildrenTagsString = "",
					AttributesString = "",
					TagFormatting = HtmlTagFormatting.Complete,
					ParentTagsString = "",
					ExcludeParentTagsString = "",
					ParentContentTypes = HtmlElementType.Phrasing,
					ObsoleteAttributesString = ""
				},
				new HtmlElementInfo
				{
					TagName = "summary",
					HtmlVersion = 5,
					Obsolete = false,
					ElementType = HtmlElementType.Flow,
					PermittedChildrenTypes = HtmlElementType.Phrasing | HtmlElementType.Text,
					PermittedChildrenTagsString = "",
					AttributesString = "",
					TagFormatting = HtmlTagFormatting.Complete,
					ParentTagsString = "details",
					ExcludeParentTagsString = "",
					ParentContentTypes = HtmlElementType.None,
					ObsoleteAttributesString = ""
				},
				new HtmlElementInfo
				{
					TagName = "sup",
					HtmlVersion = 3,
					Obsolete = false,
					ElementType = HtmlElementType.Phrasing,
					PermittedChildrenTypes = HtmlElementType.Phrasing | HtmlElementType.Text,
					PermittedChildrenTagsString = "",
					AttributesString = "",
					TagFormatting = HtmlTagFormatting.Complete,
					ParentTagsString = "",
					ExcludeParentTagsString = "",
					ParentContentTypes = HtmlElementType.Phrasing,
					ObsoleteAttributesString = ""
				},
				new HtmlElementInfo
				{
					TagName = "table",
					HtmlVersion = 3,
					Obsolete = false,
					ElementType = HtmlElementType.Flow,
					PermittedChildrenTypes = HtmlElementType.None,
					PermittedChildrenTagsString = "capition;colgroup;thead;tfoot;tbody;tr",
					AttributesString = "border",
					TagFormatting = HtmlTagFormatting.Complete,
					ParentTagsString = "",
					ExcludeParentTagsString = "",
					ParentContentTypes = HtmlElementType.Flow,
					ObsoleteAttributesString = "summary;align;width;bgcolor;cellpadding;cellspacing;frame;rules"
				},
				new HtmlElementInfo
				{
					TagName = "tbody",
					HtmlVersion = 3,
					Obsolete = false,
					ElementType = HtmlElementType.Phrasing,
					PermittedChildrenTypes = HtmlElementType.None,
					PermittedChildrenTagsString = "tr",
					AttributesString = "",
					TagFormatting = HtmlTagFormatting.OptionalClosing,
					ParentTagsString = "table",
					ExcludeParentTagsString = "",
					ParentContentTypes = HtmlElementType.None,
					ObsoleteAttributesString = "align;char;charoff;valign"
				},
				new HtmlElementInfo
				{
					TagName = "td",
					HtmlVersion = 3,
					Obsolete = false,
					ElementType = HtmlElementType.Phrasing,
					PermittedChildrenTypes = HtmlElementType.AnyContent,
					PermittedChildrenTagsString = "",
					AttributesString = "colspan;rowspan;headers",
					TagFormatting = HtmlTagFormatting.OptionalClosing,
					ParentTagsString = "tr",
					ExcludeParentTagsString = "",
					ParentContentTypes = HtmlElementType.None,
					ObsoleteAttributesString = "scope;abbr;axis;align;width;char;charoff;valign;bgcolor;height;nowrap"
				},
				new HtmlElementInfo
				{
					TagName = "textarea",
					HtmlVersion = 3,
					Obsolete = false,
					ElementType = HtmlElementType.Phrasing,
					PermittedChildrenTypes = HtmlElementType.Text,
					PermittedChildrenTagsString = "",
					AttributesString = "name;disabled;form;readonly;maxlength;autofocus;required;placeholder;dirname;rows;wrap;cols",
					TagFormatting = HtmlTagFormatting.Complete,
					ParentTagsString = "",
					ExcludeParentTagsString = "",
					ParentContentTypes = HtmlElementType.Phrasing,
					ObsoleteAttributesString = ""
				},
				new HtmlElementInfo
				{
					TagName = "tfoot",
					HtmlVersion = 3,
					Obsolete = false,
					ElementType = HtmlElementType.Phrasing,
					PermittedChildrenTypes = HtmlElementType.None,
					PermittedChildrenTagsString = "tr",
					AttributesString = "",
					TagFormatting = HtmlTagFormatting.OptionalClosing,
					ParentTagsString = "table",
					ExcludeParentTagsString = "",
					ParentContentTypes = HtmlElementType.None,
					ObsoleteAttributesString = "align;char;charoff;valign"
				},
				new HtmlElementInfo
				{
					TagName = "th",
					HtmlVersion = 3,
					Obsolete = false,
					ElementType = HtmlElementType.Flow,
					PermittedChildrenTypes = HtmlElementType.AnyContent,
					PermittedChildrenTagsString = "",
					AttributesString = "scope;scolspan;rowspan;headers",
					TagFormatting = HtmlTagFormatting.OptionalClosing,
					ParentTagsString = "tr",
					ExcludeParentTagsString = "",
					ParentContentTypes = HtmlElementType.None,
					ObsoleteAttributesString = "scope;abbr;axis;align;width;char;charoff;valign;bgcolor;height;nowrap"
				},
				new HtmlElementInfo
				{
					TagName = "thead",
					HtmlVersion = 3,
					Obsolete = false,
					ElementType = HtmlElementType.Phrasing,
					PermittedChildrenTypes = HtmlElementType.None,
					PermittedChildrenTagsString = "tr",
					AttributesString = "",
					TagFormatting = HtmlTagFormatting.OptionalClosing,
					ParentTagsString = "table",
					ExcludeParentTagsString = "",
					ParentContentTypes = HtmlElementType.None,
					ObsoleteAttributesString = "align;char;charoff;valign"
				},
				new HtmlElementInfo
				{
					TagName = "time",
					HtmlVersion = 5,
					Obsolete = false,
					ElementType = HtmlElementType.Phrasing,
					PermittedChildrenTypes = HtmlElementType.Phrasing | HtmlElementType.Text,
					PermittedChildrenTagsString = "",
					AttributesString = "datetime",
					TagFormatting = HtmlTagFormatting.Complete,
					ParentTagsString = "",
					ExcludeParentTagsString = "time",
					ParentContentTypes = HtmlElementType.Phrasing,
					ObsoleteAttributesString = ""
				},
				new HtmlElementInfo
				{
					TagName = "title",
					HtmlVersion = 3,
					Obsolete = false,
					ElementType = HtmlElementType.Meta,
					PermittedChildrenTypes = HtmlElementType.Text,
					PermittedChildrenTagsString = "",
					AttributesString = "",
					TagFormatting = HtmlTagFormatting.Complete,
					ParentTagsString = "head",
					ExcludeParentTagsString = "",
					ParentContentTypes = HtmlElementType.None,
					ObsoleteAttributesString = ""
				},
				new HtmlElementInfo
				{
					TagName = "tr",
					HtmlVersion = 3,
					Obsolete = false,
					ElementType = HtmlElementType.Phrasing,
					PermittedChildrenTypes = HtmlElementType.None,
					PermittedChildrenTagsString = "td;th",
					AttributesString = "",
					TagFormatting = HtmlTagFormatting.OptionalClosing,
					ParentTagsString = "table;thead;tfoot;tbody",
					ExcludeParentTagsString = "",
					ParentContentTypes = HtmlElementType.None,
					ObsoleteAttributesString = "align;char;charoff;valign;bgcolor"
				},
				new HtmlElementInfo
				{
					TagName = "track",
					HtmlVersion = 5,
					Obsolete = false,
					ElementType = HtmlElementType.Meta,
					PermittedChildrenTypes = HtmlElementType.None,
					PermittedChildrenTagsString = "",
					AttributesString = "kind;src;srclang;label;default",
					TagFormatting = HtmlTagFormatting.Single,
					ParentTagsString = "audio;video",
					ExcludeParentTagsString = "",
					ParentContentTypes = HtmlElementType.None,
					ObsoleteAttributesString = ""
				},
				new HtmlElementInfo
				{
					TagName = "tt",
					HtmlVersion = 3,
					Obsolete = true,
					ElementType = HtmlElementType.Phrasing,
					PermittedChildrenTypes = HtmlElementType.Phrasing | HtmlElementType.Text,
					PermittedChildrenTagsString = "",
					AttributesString = "",
					TagFormatting = HtmlTagFormatting.Complete,
					ParentTagsString = "",
					ExcludeParentTagsString = "",
					ParentContentTypes = HtmlElementType.Phrasing,
					ObsoleteAttributesString = ""
				},
				new HtmlElementInfo
				{
					TagName = "u",
					HtmlVersion = 3,
					Obsolete = true,
					ElementType = HtmlElementType.Phrasing,
					PermittedChildrenTypes = HtmlElementType.Phrasing | HtmlElementType.Text,
					PermittedChildrenTagsString = "",
					AttributesString = "",
					TagFormatting = HtmlTagFormatting.Complete,
					ParentTagsString = "",
					ExcludeParentTagsString = "",
					ParentContentTypes = HtmlElementType.Phrasing,
					ObsoleteAttributesString = ""
				},
				new HtmlElementInfo
				{
					TagName = "ul",
					HtmlVersion = 3,
					Obsolete = false,
					ElementType = HtmlElementType.Flow,
					PermittedChildrenTypes = HtmlElementType.None,
					PermittedChildrenTagsString = "li",
					AttributesString = "",
					TagFormatting = HtmlTagFormatting.Complete,
					ParentTagsString = "",
					ExcludeParentTagsString = "",
					ParentContentTypes = HtmlElementType.Flow,
					ObsoleteAttributesString = "type;compact"
				},
				new HtmlElementInfo
				{
					TagName = "var",
					HtmlVersion = 3,
					Obsolete = false,
					ElementType = HtmlElementType.Phrasing,
					PermittedChildrenTypes = HtmlElementType.Phrasing | HtmlElementType.Text,
					PermittedChildrenTagsString = "",
					AttributesString = "",
					TagFormatting = HtmlTagFormatting.Complete,
					ParentTagsString = "",
					ExcludeParentTagsString = "",
					ParentContentTypes = HtmlElementType.Phrasing,
					ObsoleteAttributesString = ""
				},
				new HtmlElementInfo
				{
					TagName = "video",
					HtmlVersion = 5,
					Obsolete = false,
					ElementType = HtmlElementType.Flow,
					PermittedChildrenTypes = HtmlElementType.AnyContent,
					PermittedChildrenTagsString = "",
					AttributesString = "autoplay;preload;controls;loop;poster;height;width;mediagroup;muted;src",
					TagFormatting = HtmlTagFormatting.Complete,
					ParentTagsString = "",
					ExcludeParentTagsString = "a;button",
					ParentContentTypes = HtmlElementType.Flow | HtmlElementType.Phrasing,
					ObsoleteAttributesString = ""
				},
				new HtmlElementInfo
				{
					TagName = "wbr",
					HtmlVersion = 3,
					Obsolete = false,
					ElementType = HtmlElementType.Phrasing,
					PermittedChildrenTypes = HtmlElementType.None,
					PermittedChildrenTagsString = "",
					AttributesString = "",
					TagFormatting = HtmlTagFormatting.Single,
					ParentTagsString = "",
					ExcludeParentTagsString = "",
					ParentContentTypes = HtmlElementType.Phrasing,
					ObsoleteAttributesString = ""
				}
			};
		}
	}
}
