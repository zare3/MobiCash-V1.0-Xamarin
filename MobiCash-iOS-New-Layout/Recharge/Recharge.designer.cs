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
	[Register ("Recharge")]
	partial class Recharge
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITableView amountsTable { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel balanceLabel { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel lastUpdateLabel { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITextField phoneNumberTextField { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIButton rechargeBtn { get; set; }

		[Action ("rechargeBtn_TouchUpInside:")]
		[GeneratedCode ("iOS Designer", "1.0")]
		partial void rechargeBtn_TouchUpInside (UIButton sender);

		void ReleaseDesignerOutlets ()
		{
			if (amountsTable != null) {
				amountsTable.Dispose ();
				amountsTable = null;
			}
			if (balanceLabel != null) {
				balanceLabel.Dispose ();
				balanceLabel = null;
			}
			if (lastUpdateLabel != null) {
				lastUpdateLabel.Dispose ();
				lastUpdateLabel = null;
			}
			if (phoneNumberTextField != null) {
				phoneNumberTextField.Dispose ();
				phoneNumberTextField = null;
			}
			if (rechargeBtn != null) {
				rechargeBtn.Dispose ();
				rechargeBtn = null;
			}
		}
	}
}
