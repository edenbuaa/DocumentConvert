
using System.Drawing.Imaging;

namespace RtfConverter.RtfInterpreter.Image
{

	// ------------------------------------------------------------------------
	public interface IRtfVisualImageAdapter
	{

		// ----------------------------------------------------------------------
		string FileNamePattern { get; }

		// ----------------------------------------------------------------------
		ImageFormat TargetFormat { get; }

		// ----------------------------------------------------------------------
		double DpiX { get; }

		// ----------------------------------------------------------------------
		double DpiY { get; }

		// ----------------------------------------------------------------------
		ImageFormat GetImageFormat( RtfVisualImageFormat rtfVisualImageFormat );

		// ----------------------------------------------------------------------
		string ResolveFileName( int index, RtfVisualImageFormat rtfVisualImageFormat );

		// ----------------------------------------------------------------------
		int CalcImageWidth( RtfVisualImageFormat format, int width,
			int desiredWidth, int scaleWidthPercent );

		// ----------------------------------------------------------------------
		int CalcImageHeight( RtfVisualImageFormat format, int height,
			int desiredHeight, int scaleHeightPercent );

	} // interface IRtfVisualImageAdapter

} 