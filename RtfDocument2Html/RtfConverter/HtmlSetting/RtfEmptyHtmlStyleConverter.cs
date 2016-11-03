using RtfConverter.RtfInterpreter;
namespace RtfConverter.HtmlSetting
{

	// ------------------------------------------------------------------------
	public class RtfEmptyHtmlStyleConverter : IRtfHtmlStyleConverter
	{

		// ----------------------------------------------------------------------
		public virtual IRtfHtmlStyle TextToHtml( IRtfVisualText visualText )
		{
			return RtfHtmlStyle.Empty;
		} // TextToHtml

	} // class RtfEmptyHtmlStyleConverter

} 

