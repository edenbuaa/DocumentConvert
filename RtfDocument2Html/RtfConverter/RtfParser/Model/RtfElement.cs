using RtfConverter.Common;
using System;

namespace RtfConverter.Parser
{

	// ------------------------------------------------------------------------
	public abstract class RtfElement : IRtfElement
	{

		// ----------------------------------------------------------------------
		protected RtfElement( RtfElementKind kind )
		{
			this.kind = kind;
		} // RtfElement

		// ----------------------------------------------------------------------
		public RtfElementKind Kind
		{
			get { return kind; }
		} // Kind

		// ----------------------------------------------------------------------
		public void Visit( IRtfElementVisitor visitor )
		{
			if ( visitor == null )
			{
				throw new ArgumentNullException( "visitor" );
			}
			DoVisit( visitor );
		} // Visit

		// ----------------------------------------------------------------------
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
		} // Equals

		// ----------------------------------------------------------------------
		public sealed override int GetHashCode()
		{
			return HashTool.AddHashCode( GetType().GetHashCode(), ComputeHashCode() );
		} // GetHashCode

		// ----------------------------------------------------------------------
		protected abstract void DoVisit( IRtfElementVisitor visitor );

		// ----------------------------------------------------------------------
		protected virtual bool IsEqual( object obj )
		{
			return true;
		} // IsEqual

		// ----------------------------------------------------------------------
		protected virtual int ComputeHashCode()
		{
			return 0x0f00ba11;
		} // ComputeHashCode

		// ----------------------------------------------------------------------
		// members
		private readonly RtfElementKind kind;

	} // class RtfElement

}

