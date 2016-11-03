using RtfConverter.Common;
using System;
using System.Collections;

namespace RtfConverter.RtfInterpreter.Image
{

	// ------------------------------------------------------------------------
	public sealed class RtfConvertedImageInfoCollection : ReadOnlyCollectionBase, IRtfConvertedImageInfoCollection
	{

		// ----------------------------------------------------------------------
		public IRtfConvertedImageInfo this[ int index ]
		{
			get { return InnerList[ index ] as RtfConvertedImageInfo; }
		} // this[ int ]

		// ----------------------------------------------------------------------
		public void CopyTo( IRtfConvertedImageInfo[] array, int index )
		{
			InnerList.CopyTo( array, index );
		} // CopyTo

		// ----------------------------------------------------------------------
		public void Add( IRtfConvertedImageInfo item )
		{
			if ( item == null )
			{
				throw new ArgumentNullException( "item" );
			}
			InnerList.Add( item );
		} // Add

		// ----------------------------------------------------------------------
		public void Clear()
		{
			InnerList.Clear();
		} // Clear

		// ----------------------------------------------------------------------
		public override string ToString()
		{
			return CollectionTool.ToString( this );
		} // ToString

	} // class RtfConvertedImageInfoCollection

} 