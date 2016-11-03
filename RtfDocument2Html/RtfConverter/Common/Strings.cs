using System.Resources;

namespace RtfConverter.Common
{	
	/// <summary>
    /// Provides strongly typed resource access for this namespace.
    /// </summary>
	internal sealed class Strings : StringsBase
	{

		// ----------------------------------------------------------------------
		public static string ArgumentMayNotBeEmpty
		{
			get { return inst.GetString( "ArgumentMayNotBeEmpty" ); }
		} // ArgumentMayNotBeEmpty

		// ----------------------------------------------------------------------
		public static string CollectionToolInvalidEnum( string value, string enumType, string possibleValues )
		{
			return Format( inst.GetString( "CollectionToolInvalidEnum" ), value, enumType, possibleValues );
		} // CollectionToolInvalidEnum

		// ----------------------------------------------------------------------
		public static string LoggerNameMayNotBeEmpty
		{
			get { return inst.GetString( "LoggerNameMayNotBeEmpty" ); }
		} // LoggerNameMayNotBeEmpty

		// ----------------------------------------------------------------------
		public static string LoggerFactoryConfigError
		{
			get { return inst.GetString( "LoggerFactoryConfigError" ); }
		} // LoggerFactoryConfigError

		// ----------------------------------------------------------------------
		public static string ProgramPressAnyKeyToQuit
		{
			get { return inst.GetString( "ProgramPressAnyKeyToQuit" ); }
		} // ProgramPressAnyKeyToQuit

		// ----------------------------------------------------------------------
		public static string StringToolSeparatorIncludesQuoteOrEscapeChar
		{
			get { return inst.GetString( "StringToolSeparatorIncludesQuoteOrEscapeChar" ); }
		} // StringToolSeparatorIncludesQuoteOrEscapeChar

		// ----------------------------------------------------------------------
		public static string StringToolMissingEscapedHexCode
		{
			get { return inst.GetString( "StringToolMissingEscapedHexCode" ); }
		} // StringToolMissingEscapedHexCode

		// ----------------------------------------------------------------------
		public static string StringToolMissingEscapedChar
		{
			get { return inst.GetString( "StringToolMissingEscapedChar" ); }
		} // StringToolMissingEscapedChar

		// ----------------------------------------------------------------------
		public static string StringToolUnbalancedQuotes
		{
			get { return inst.GetString( "StringToolUnbalancedQuotes" ); }
		} // StringToolUnbalancedQuotes

		// ----------------------------------------------------------------------
		public static string StringToolContainsInvalidHexChar
		{
			get { return inst.GetString( "StringToolContainsInvalidHexChar" ); }
		} // StringToolContainsInvalidHexChar

		// ----------------------------------------------------------------------
		public static string LoggerLogFileNotSupportedByType( string typeName )
		{
			return Format( inst.GetString( "LoggerLogFileNotSupportedByType" ), typeName );
		} // LoggerLogFileNotSupportedByType

		// ----------------------------------------------------------------------
		public static string LoggerLoggingLevelXmlError
		{
			get { return inst.GetString( "LoggerLoggingLevelXmlError" ); }
		} // LoggerLoggingLevelXmlError

		// ----------------------------------------------------------------------
		public static string LoggerLoggingLevelRepository
		{
			get { return inst.GetString( "LoggerLoggingLevelRepository" ); }
		} // LoggerLoggingLevelRepository

		// ----------------------------------------------------------------------
		// members
		private static readonly ResourceManager inst = NewInst( typeof( Strings ) );

	} // class Strings

} 
