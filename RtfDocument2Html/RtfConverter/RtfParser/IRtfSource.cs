using System.IO;

namespace RtfConverter.Parser
{

	// ------------------------------------------------------------------------
	public interface IRtfSource
	{

		// ----------------------------------------------------------------------
		TextReader Reader { get; }

	} // interface IRtfSource

} 