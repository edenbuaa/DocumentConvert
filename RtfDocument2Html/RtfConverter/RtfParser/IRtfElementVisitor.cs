
namespace RtfConverter.Parser
{

	// ------------------------------------------------------------------------
	public interface IRtfElementVisitor
	{

		// ----------------------------------------------------------------------
		void VisitTag( IRtfTag tag );

		// ----------------------------------------------------------------------
		void VisitGroup( IRtfGroup group );

		// ----------------------------------------------------------------------
		void VisitText( IRtfText text );

	} // interface IRtfElementVisitor

} 