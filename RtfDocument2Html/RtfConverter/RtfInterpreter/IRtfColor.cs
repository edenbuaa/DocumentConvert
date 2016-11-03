﻿// -- FILE ------------------------------------------------------------------
// name       : IRtfColor.cs
// project    : RTF Framelet
// created    : Leon Poyyayil - 2008.05.20
// language   : c#
// environment: .NET 2.0
// copyright  : (c) 2004-2013 by Jani Giannoudis, Switzerland
// --------------------------------------------------------------------------
using System.Drawing;

namespace RtfConverter.RtfInterpreter
{

	// ------------------------------------------------------------------------
	public interface IRtfColor
	{

		// ----------------------------------------------------------------------
		int Red { get; }

		// ----------------------------------------------------------------------
		int Green { get; }

		// ----------------------------------------------------------------------
		int Blue { get; }

		// ----------------------------------------------------------------------
		Color AsDrawingColor { get; }

	} // interface IRtfColor

} 

