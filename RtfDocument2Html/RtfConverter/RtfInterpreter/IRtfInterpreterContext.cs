
namespace RtfConverter.RtfInterpreter
{

	// ------------------------------------------------------------------------
	public interface IRtfInterpreterContext
	{

		// ----------------------------------------------------------------------
		RtfInterpreterState State { get; }

		// ----------------------------------------------------------------------
		int RtfVersion { get; }

		// ----------------------------------------------------------------------
		string DefaultFontId { get; }

		// ----------------------------------------------------------------------
		IRtfFont DefaultFont { get; }

		// ----------------------------------------------------------------------
		IRtfFontCollection FontTable { get; }

		// ----------------------------------------------------------------------
		IRtfColorCollection ColorTable { get; }

		// ----------------------------------------------------------------------
		string Generator { get; }

		// ----------------------------------------------------------------------
		IRtfTextFormatCollection UniqueTextFormats { get; }

		// ----------------------------------------------------------------------
		IRtfTextFormat CurrentTextFormat { get; }

		// ----------------------------------------------------------------------
		IRtfTextFormat GetSafeCurrentTextFormat();

		// ----------------------------------------------------------------------
		IRtfTextFormat GetUniqueTextFormatInstance( IRtfTextFormat templateFormat );

		// ----------------------------------------------------------------------
		IRtfDocumentInfo DocumentInfo { get; }

		// ----------------------------------------------------------------------
		IRtfDocumentPropertyCollection UserProperties { get; }

	} // interface IRtfInterpreterContext

} 

