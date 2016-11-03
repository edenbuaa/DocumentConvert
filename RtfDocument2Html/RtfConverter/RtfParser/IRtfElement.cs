
namespace RtfConverter.Parser
{

	// ------------------------------------------------------------------------
	public interface IRtfElement
	{

		// ----------------------------------------------------------------------
		RtfElementKind Kind { get; }

		// ----------------------------------------------------------------------
		void Visit( IRtfElementVisitor visitor );

	} // interface IRtfElement

} 