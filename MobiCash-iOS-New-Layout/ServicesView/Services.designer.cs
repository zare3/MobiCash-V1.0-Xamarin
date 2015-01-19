// WARNING
//
// This file has been generated automatically by Xamarin Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System;
using System.CodeDom.Compiler;

namespace MobiCashiOSNewLayout
{
	[Register ("Services")]
	partial class Services
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITableView ServicesTable { get; set; }

		void ReleaseDesignerOutlets ()
		{
			if (ServicesTable != null) {
				ServicesTable.Dispose ();
				ServicesTable = null;
			}
		}
	}
}
