using System.Collections;

namespace RtfConverter.RtfInterpreter.Image
{

	// ------------------------------------------------------------------------
	public interface IRtfConvertedImageInfoCollection : IEnumerable
	{

		// ----------------------------------------------------------------------
		int Count { get; }

		// ----------------------------------------------------------------------
		IRtfConvertedImageInfo this[ int index ] { get; }

		// ----------------------------------------------------------------------
		void CopyTo( IRtfConvertedImageInfo[] array, int index );

	} // interface IRtfConvertedImageInfoCollection

} 