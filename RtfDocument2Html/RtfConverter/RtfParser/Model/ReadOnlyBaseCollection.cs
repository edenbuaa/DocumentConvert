using RtfConverter.Common;
using System.Collections;


namespace RtfConverter.Parser
{
	public abstract class ReadOnlyBaseCollection : ReadOnlyCollectionBase
	{
		public sealed override bool Equals( object obj )
		{
			if ( obj == this )
			{
				return true;
			}
			
			if ( obj == null || GetType() != obj.GetType() )
			{
				return false;
			}

			return IsEqual( obj );
		}

		public override string ToString()
		{
			return CollectionTool.ToString( this );
		} 

		protected virtual bool IsEqual( object obj )
		{
			return CollectionTool.AreEqual( this, obj );
		} 

		public sealed override int GetHashCode()
		{
			return HashTool.AddHashCode( GetType().GetHashCode(), ComputeHashCode() );
		} 

		protected virtual int ComputeHashCode()
		{
			return HashTool.ComputeHashCode( this );
		} 


	} 

} 