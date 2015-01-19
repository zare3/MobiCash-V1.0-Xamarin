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
	[Register ("History_Received")]
	partial class History_Received
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITableView ReceivedTable { get; set; }

		void ReleaseDesignerOutlets ()
		{
			if (ReceivedTable != null) {
				ReceivedTable.Dispose ();
				ReceivedTable = null;
			}
		}
	}
}
