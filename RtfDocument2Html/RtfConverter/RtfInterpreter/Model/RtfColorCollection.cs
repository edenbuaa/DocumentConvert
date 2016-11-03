using RtfConverter.Parser;
using System;

namespace RtfConverter.RtfInterpreter.Model
{

	// ------------------------------------------------------------------------
	public sealed class RtfColorCollection : ReadOnlyBaseCollection, IRtfColorCollection
	{

		// ----------------------------------------------------------------------
		public IRtfColor this[ int index ]
		{
			get { return InnerList[ index ] as IRtfColor; }
		} // this[ int ]

		// ----------------------------------------------------------------------
		public void CopyTo( IRtfColor[] array, int index )
		{
			InnerList.CopyTo( array, index );
		} // CopyTo

		// ----------------------------------------------------------------------
		public void Add( IRtfColor item )
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

	} // class RtfColorCollection

}

