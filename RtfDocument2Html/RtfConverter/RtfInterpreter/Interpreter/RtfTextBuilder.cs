using System.Text;
using RtfConverter.RtfInterpreter.Support;
using RtfConverter.Parser;

namespace RtfConverter.RtfInterpreter
{

	// ------------------------------------------------------------------------
	public sealed class RtfTextBuilder : RtfElementVisitorBase
	{

		// ----------------------------------------------------------------------
		public RtfTextBuilder() :
			base( RtfElementVisitorOrder.DepthFirst )
		{
			Reset();
		} // RtfTextBuilder

		// ----------------------------------------------------------------------
		public string CombinedText
		{
			get { return buffer.ToString(); }
		} // CombinedText

		// ----------------------------------------------------------------------
		public void Reset()
		{
			buffer.Remove( 0, buffer.Length );
		} // Reset

		// ----------------------------------------------------------------------
		protected override void DoVisitText( IRtfText text )
		{
			buffer.Append( text.Text );
		} // DoVisitText

		// ----------------------------------------------------------------------
		// members
		private readonly StringBuilder buffer = new StringBuilder();

	} // class RtfTextBuilder

} 

