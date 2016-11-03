using System.Collections.Specialized;

namespace RtfConverter.HtmlSetting
{

	// ------------------------------------------------------------------------
	public interface IRtfHtmlCssStyle
	{

		// ----------------------------------------------------------------------
		NameValueCollection Properties { get; }

		// ----------------------------------------------------------------------
		string SelectorName { get; }

	} // interface IRtfHtmlCssStyle

} 

