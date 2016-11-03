namespace RtfConverter.Common
{

	// ------------------------------------------------------------------------
	public static class CompareTool
	{

		// ----------------------------------------------------------------------
		public static bool AreEqual( object left, object right )
		{
			return left == right || ( left != null && left.Equals( right ) );
		} // AreEqual

	} // class CompareTool

} 