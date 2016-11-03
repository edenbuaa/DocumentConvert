
using RtfConverter.Common;
namespace RtfConverter.RtfInterpreter.Model
{

	// ------------------------------------------------------------------------
	public sealed class RtfVisualSpecialChar : RtfVisual, IRtfVisualSpecialChar
	{

		// ----------------------------------------------------------------------
		public RtfVisualSpecialChar( RtfVisualSpecialCharKind charKind ) :
			base( RtfVisualKind.Special )
		{
			this.charKind = charKind;
		} // RtfVisualSpecialChar

		// ----------------------------------------------------------------------
		protected override void DoVisit( IRtfVisualVisitor visitor )
		{
			visitor.VisitSpecial( this );
		} // DoVisit

		// ----------------------------------------------------------------------
		public RtfVisualSpecialCharKind CharKind
		{
			get { return charKind; }
		} // CharKind

		// ----------------------------------------------------------------------
		protected override bool IsEqual( object obj )
		{
			RtfVisualSpecialChar compare = obj as RtfVisualSpecialChar; // guaranteed to be non-null
			return 
				compare != null &&
				base.IsEqual( compare ) &&
				charKind == compare.charKind;
		} // IsEqual

		// ----------------------------------------------------------------------
		protected override int ComputeHashCode()
		{
			return HashTool.AddHashCode( base.ComputeHashCode(), charKind );
		} // ComputeHashCode

		// ----------------------------------------------------------------------
		public override string ToString()
		{
			return charKind.ToString();
		} // ToString

		// ----------------------------------------------------------------------
		// members
		private readonly RtfVisualSpecialCharKind charKind;

	} // class RtfVisualSpecialChar

}

