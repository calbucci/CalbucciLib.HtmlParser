using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalbucciLib
{
	public enum AttrStatus
	{
		Valid,
		Deprecated,
		Unknown
	};

	[Flags]
	public enum HtmlElementType
	{
		Phrasing = 0x1, // former "inline element"
		Flow = 0x2, // former "block element"
		Meta = 0x4, // control elements
		Text = 0x8, // text block
		NRCharData = 0x10, // Non-Replaceable Char Data

		AnyContent = Phrasing | Flow | Text,
		Transparent = Phrasing | Flow,
		None = 0
	}

	public enum HtmlTagFormatting
	{
		Single, // Has no closing tag, e.g. <br>
		OptionalClosing, // has an optional closing tag, e.g. <li>
		Complete // must have a closing tag
	}



}
