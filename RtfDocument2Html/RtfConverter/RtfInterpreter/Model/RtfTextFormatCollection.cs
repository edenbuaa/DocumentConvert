using RtfConverter.Parser;
using System;

namespace RtfConverter.RtfInterpreter.Model
{

	// ------------------------------------------------------------------------
	public sealed class RtfTextFormatCollection : ReadOnlyBaseCollection, IRtfTextFormatCollection
	{

		// ----------------------------------------------------------------------
		public IRtfTextFormat this[ int index ]
		{
			get { return InnerList[ index ] as IRtfTextFormat; }
		} // this[ int ]

		// ----------------------------------------------------------------------
		public bool Contains( IRtfTextFormat format )
		{
			return IndexOf( format ) >= 0;
		} // Contains

		// ----------------------------------------------------------------------
		public int IndexOf( IRtfTextFormat format )
		{
			if ( format != null )
			{
				// PERFORMANCE: most probably we should maintain a hashmap for fast searching ...
				int count = Count;
				for ( int i = 0; i < count; i++ )
				{
					if ( format.Equals( InnerList[ i ] ) )
					{
						return i;
					}
				}
			}
			return -1;
		} // IndexOf

		// ----------------------------------------------------------------------
		public void CopyTo( IRtfTextFormat[] array, int index )
		{
			InnerList.CopyTo( array, index );
		} // CopyTo

		// ----------------------------------------------------------------------
		public void Add( IRtfTextFormat item )
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

	} // class RtfTextFormatCollection

}

