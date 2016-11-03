using RtfConverter.Parser;
using System;

namespace RtfConverter.RtfInterpreter.Model
{

	// ------------------------------------------------------------------------
	public sealed class RtfVisualCollection : ReadOnlyBaseCollection, IRtfVisualCollection
	{

		// ----------------------------------------------------------------------
		public IRtfVisual this[ int index ]
		{
			get { return InnerList[ index ] as IRtfVisual; }
		} // this[ int ]

		// ----------------------------------------------------------------------
		public void CopyTo( IRtfVisual[] array, int index )
		{
			InnerList.CopyTo( array, index );
		} // CopyTo

		// ----------------------------------------------------------------------
		public void Add( IRtfVisual item )
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

	} // class RtfVisualCollection

}

