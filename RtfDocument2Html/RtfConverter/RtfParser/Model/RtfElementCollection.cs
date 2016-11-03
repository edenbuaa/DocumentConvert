using System;

namespace RtfConverter.Parser
{

	// ------------------------------------------------------------------------
	public sealed class RtfElementCollection : ReadOnlyBaseCollection, IRtfElementCollection
	{

		// ----------------------------------------------------------------------
		public IRtfElement this[ int index ]
		{
			get { return InnerList[ index ] as IRtfElement; }
		} // this[ int ]

		// ----------------------------------------------------------------------
		public void CopyTo( IRtfElement[] array, int index )
		{
			InnerList.CopyTo( array, index );
		} // CopyTo

		// ----------------------------------------------------------------------
		public void Add( IRtfElement item )
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

	} // class RtfElementCollection

} 