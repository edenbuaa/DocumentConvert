using System;
using System.Drawing;
using System.Drawing.Imaging;

namespace RtfConverter.RtfInterpreter.Image
{

	// ------------------------------------------------------------------------
	public class RtfConvertedImageInfo : IRtfConvertedImageInfo
	{

		// ----------------------------------------------------------------------
		public RtfConvertedImageInfo( string fileName, ImageFormat format, Size size )
		{
			if ( fileName == null )
			{
				throw new ArgumentNullException( "fileName" );
			}

			this.fileName = fileName;
			this.format = format;
			this.size = size;
		} // RtfConvertedImageInfo

		// ----------------------------------------------------------------------
		public string FileName
		{
			get { return fileName; }
		} // FileName

		// ----------------------------------------------------------------------
		public ImageFormat Format
		{
			get { return format; }
		} // Format

		// ----------------------------------------------------------------------
		public Size Size
		{
			get { return size; }
		} // Size

		// ----------------------------------------------------------------------
		public override string ToString()
		{
			return fileName + " " + format + " " + size.Width + "x" + size.Height;
		} // ToString

		// ----------------------------------------------------------------------
		// members
		private readonly string fileName;
		private readonly ImageFormat format;
		private readonly Size size;

	} // class RtfConvertedImageInfo

} 