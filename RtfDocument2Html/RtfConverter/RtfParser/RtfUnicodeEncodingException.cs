using System;
using System.Runtime.Serialization;

namespace RtfConverter.Parser
{

	// ------------------------------------------------------------------------
	/// <summary>Thrown upon RTF specific error conditions.</summary>
	[Serializable]
	public class RtfUnicodeEncodingException : RtfEncodingException
	{

		// ----------------------------------------------------------------------
		/// <summary>Creates a new instance.</summary>
		public RtfUnicodeEncodingException()
		{
		} // RtfUnicodeEncodingException

		// ----------------------------------------------------------------------
		/// <summary>Creates a new instance with the given message.</summary>
		/// <param name="message">the message to display</param>
		public RtfUnicodeEncodingException( string message ) :
			base( message )
		{
		} // RtfUnicodeEncodingException

		// ----------------------------------------------------------------------
		/// <summary>Creates a new instance with the given message, based on the given cause.</summary>
		/// <param name="message">the message to display</param>
		/// <param name="cause">the original cause for this exception</param>
		public RtfUnicodeEncodingException( string message, Exception cause ) :
			base( message, cause )
		{
		} // RtfUnicodeEncodingException

		// ----------------------------------------------------------------------
		/// <summary>Serialization support.</summary>
		/// <param name="info">the info to use for serialization</param>
		/// <param name="context">the context to use for serialization</param>
		protected RtfUnicodeEncodingException( SerializationInfo info, StreamingContext context ) :
			base( info, context )
		{
		} // RtfUnicodeEncodingException

	} // class RtfUnicodeEncodingException

} 