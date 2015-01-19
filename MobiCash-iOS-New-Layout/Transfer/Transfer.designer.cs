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
	[Register ("Transfer")]
	partial class Transfer
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIButton addNumberFromContactsBtn { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITextField amountTextField { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITextField messageTextField { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel numOfCharsLabel { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITextField phoneNumberTextField { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIButton transferBtn { get; set; }

		[Action ("addNumberFromContactsBtn_TouchUpInside:")]
		[GeneratedCode ("iOS Designer", "1.0")]
		partial void addNumberFromContactsBtn_TouchUpInside (UIButton sender);

		[Action ("transferBtn_TouchUpInside:")]
		[GeneratedCode ("iOS Designer", "1.0")]
		partial void transferBtn_TouchUpInside (UIButton sender);

		void ReleaseDesignerOutlets ()
		{
			if (addNumberFromContactsBtn != null) {
				addNumberFromContactsBtn.Dispose ();
				addNumberFromContactsBtn = null;
			}
			if (amountTextField != null) {
				amountTextField.Dispose ();
				amountTextField = null;
			}
			if (messageTextField != null) {
				messageTextField.Dispose ();
				messageTextField = null;
			}
			if (numOfCharsLabel != null) {
				numOfCharsLabel.Dispose ();
				numOfCharsLabel = null;
			}
			if (phoneNumberTextField != null) {
				phoneNumberTextField.Dispose ();
				phoneNumberTextField = null;
			}
			if (transferBtn != null) {
				transferBtn.Dispose ();
				transferBtn = null;
			}
		}
	}
}
