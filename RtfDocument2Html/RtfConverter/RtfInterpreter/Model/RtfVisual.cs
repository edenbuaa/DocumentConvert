using RtfConverter.Common;
using System;

namespace RtfConverter.RtfInterpreter.Model
{

	// ------------------------------------------------------------------------
	public abstract class RtfVisual : IRtfVisual
	{

		protected RtfVisual( RtfVisualKind kind )
		{
			this.kind = kind;
		} // RtfVisual

		// ----------------------------------------------------------------------
		public RtfVisualKind Kind
		{
			get { return kind; }
		} // Kind

		// ----------------------------------------------------------------------
		public void Visit( IRtfVisualVisitor visitor )
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
		protected abstract void DoVisit( IRtfVisualVisitor visitor );

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
		private readonly RtfVisualKind kind;

	} // class RtfVisual

}

