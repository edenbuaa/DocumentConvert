using System.Drawing;
using System.Drawing.Imaging;

namespace RtfConverter.RtfInterpreter.Image
{

	// ------------------------------------------------------------------------
	public interface IRtfConvertedImageInfo
	{

		// ----------------------------------------------------------------------
		string FileName { get; }

		// ----------------------------------------------------------------------
		ImageFormat Format { get; }

		// ----------------------------------------------------------------------
		Size Size { get; }

	} // interface IRtfConvertedImageInfo

} 