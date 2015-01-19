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
	[Register ("MobileBill")]
	partial class MobileBill
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel amountClarificationTable { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITextField amountTextField { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel balanceLabel { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIView k { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITableView lastBillsTable { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIButton PayBtn { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITextField phoneNumberTextField { get; set; }

		[Action ("PayBtn_TouchUpInside:")]
		[GeneratedCode ("iOS Designer", "1.0")]
		partial void PayBtn_TouchUpInside (UIButton sender);

		void ReleaseDesignerOutlets ()
		{
			if (amountClarificationTable != null) {
				amountClarificationTable.Dispose ();
				amountClarificationTable = null;
			}
			if (amountTextField != null) {
				amountTextField.Dispose ();
				amountTextField = null;
			}
			if (balanceLabel != null) {
				balanceLabel.Dispose ();
				balanceLabel = null;
			}
			if (k != null) {
				k.Dispose ();
				k = null;
			}
			if (lastBillsTable != null) {
				lastBillsTable.Dispose ();
				lastBillsTable = null;
			}
			if (PayBtn != null) {
				PayBtn.Dispose ();
				PayBtn = null;
			}
			if (phoneNumberTextField != null) {
				phoneNumberTextField.Dispose ();
				phoneNumberTextField = null;
			}
		}
	}
}
