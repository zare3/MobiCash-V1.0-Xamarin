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
	[Register ("InternetBill")]
	partial class InternetBill
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel amountClarificationLabel { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITextField amountTextField { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel balanceLabel { get; set; }

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
			if (amountClarificationLabel != null) {
				amountClarificationLabel.Dispose ();
				amountClarificationLabel = null;
			}
			if (amountTextField != null) {
				amountTextField.Dispose ();
				amountTextField = null;
			}
			if (balanceLabel != null) {
				balanceLabel.Dispose ();
				balanceLabel = null;
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
