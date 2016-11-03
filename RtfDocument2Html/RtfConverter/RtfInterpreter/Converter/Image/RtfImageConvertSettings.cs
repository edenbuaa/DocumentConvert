using System;
using System.Drawing;
using System.IO;

namespace RtfConverter.RtfInterpreter.Image
{

	// ------------------------------------------------------------------------
	public class RtfImageConvertSettings
	{

		// ----------------------------------------------------------------------
		public RtfImageConvertSettings() :
			this( new RtfVisualImageAdapter() )
		{
		} // RtfImageConvertSettings

		// ----------------------------------------------------------------------
		public RtfImageConvertSettings( IRtfVisualImageAdapter imageAdapter )
		{
			if ( imageAdapter == null )
			{
				throw new ArgumentNullException( "imageAdapter" );
			}

			this.imageAdapter = imageAdapter;
		} // RtfImageConvertSettings

		// ----------------------------------------------------------------------
		public IRtfVisualImageAdapter ImageAdapter
		{
			get { return imageAdapter; }
		} // ImageAdapter

		// ----------------------------------------------------------------------
		public Color? BackgroundColor { get; set; }

		// ----------------------------------------------------------------------
		public string ImagesPath
		{
			get { return imagesPath; }
			set { imagesPath = value; }
		} // ImagesPath

		// ----------------------------------------------------------------------
		public bool ScaleImage
		{
			get { return scaleImage; }
			set { scaleImage = value; }
		} // ScaleImage

		// ----------------------------------------------------------------------
		public float ScaleOffset { get; set; }

		// ----------------------------------------------------------------------
		public float ScaleExtension { get; set; }

		// ----------------------------------------------------------------------
		public string GetImageFileName( int index, RtfVisualImageFormat rtfVisualImageFormat )
		{
			string imageFileName = imageAdapter.ResolveFileName( index, rtfVisualImageFormat );
			if ( !string.IsNullOrEmpty( imagesPath ) )
			{
				imageFileName = Path.Combine( imagesPath, imageFileName );
			}
			return imageFileName;
		} // GetImageFileName

		// ----------------------------------------------------------------------
		private readonly IRtfVisualImageAdapter imageAdapter;
		private string imagesPath;
		private bool scaleImage = true;
	} // class RtfImageConvertSettings

} 
