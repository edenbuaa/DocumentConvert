using System.Collections;

namespace RtfConverter.Parser
{

	// ------------------------------------------------------------------------
	public interface IRtfElementCollection : IEnumerable
	{

		// ----------------------------------------------------------------------
		int Count { get; }

		// ----------------------------------------------------------------------
		IRtfElement this[ int index ] { get; }

		// ----------------------------------------------------------------------
		void CopyTo( IRtfElement[] array, int index );

	} // interface IRtfElementCollection

} 