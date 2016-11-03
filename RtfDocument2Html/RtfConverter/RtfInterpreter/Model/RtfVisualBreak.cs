﻿
using RtfConverter.Common;
namespace RtfConverter.RtfInterpreter.Model
{

	// ------------------------------------------------------------------------
	public sealed class RtfVisualBreak : RtfVisual, IRtfVisualBreak
	{

		// ----------------------------------------------------------------------
		public RtfVisualBreak( RtfVisualBreakKind breakKind ) :
			base( RtfVisualKind.Break )
		{
			this.breakKind = breakKind;
		} // RtfVisualBreak

		// ----------------------------------------------------------------------
		public RtfVisualBreakKind BreakKind
		{
			get { return breakKind; }
		} // BreakKind

		// ----------------------------------------------------------------------
		public override string ToString()
		{
			return breakKind.ToString();
		} // ToString

		// ----------------------------------------------------------------------
		protected override void DoVisit( IRtfVisualVisitor visitor )
		{
			visitor.VisitBreak( this );
		} // DoVisit

		// ----------------------------------------------------------------------
		protected override bool IsEqual( object obj )
		{
			RtfVisualBreak compare = obj as RtfVisualBreak; // guaranteed to be non-null
			return 
				compare != null &&
				base.IsEqual( compare ) &&
				breakKind == compare.breakKind;
		} // IsEqual

		// ----------------------------------------------------------------------
		protected override int ComputeHashCode()
		{
			return HashTool.AddHashCode( base.ComputeHashCode(), breakKind );
		} // ComputeHashCode

		// ----------------------------------------------------------------------
		// members
		private readonly RtfVisualBreakKind breakKind;

	} // class RtfVisualBreak

}

