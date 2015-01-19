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
	[Register ("History_Sent")]
	partial class History_Sent
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITableView SentTable { get; set; }

		void ReleaseDesignerOutlets ()
		{
			if (SentTable != null) {
				SentTable.Dispose ();
				SentTable = null;
			}
		}
	}
}
