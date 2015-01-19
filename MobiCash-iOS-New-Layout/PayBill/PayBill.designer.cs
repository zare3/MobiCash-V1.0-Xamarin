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
	[Register ("PayBill")]
	partial class PayBill
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel amountDueLabel { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITextField amountToBePaidTextField { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel balanceLabel { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITableView billsTable { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITextField numberTextField { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIButton payBtn { get; set; }

		[Action ("payBtn_TouchUpInside:")]
		[GeneratedCode ("iOS Designer", "1.0")]
		partial void payBtn_TouchUpInside (UIButton sender);

		void ReleaseDesignerOutlets ()
		{
			if (amountDueLabel != null) {
				amountDueLabel.Dispose ();
				amountDueLabel = null;
			}
			if (amountToBePaidTextField != null) {
				amountToBePaidTextField.Dispose ();
				amountToBePaidTextField = null;
			}
			if (balanceLabel != null) {
				balanceLabel.Dispose ();
				balanceLabel = null;
			}
			if (billsTable != null) {
				billsTable.Dispose ();
				billsTable = null;
			}
			if (numberTextField != null) {
				numberTextField.Dispose ();
				numberTextField = null;
			}
			if (payBtn != null) {
				payBtn.Dispose ();
				payBtn = null;
			}
		}
	}
}
