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
	[Register ("Request")]
	partial class Request
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIButton addNumberFromContactsBtn { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITextField amountTextField { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIView ds { get; set; }

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
		UIButton requestBtn { get; set; }

		[Action ("addNumberFromContactsBtn_TouchUpInside:")]
		[GeneratedCode ("iOS Designer", "1.0")]
		partial void addNumberFromContactsBtn_TouchUpInside (UIButton sender);

		[Action ("requestBtn_TouchUpInside:")]
		[GeneratedCode ("iOS Designer", "1.0")]
		partial void requestBtn_TouchUpInside (UIButton sender);

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
			if (ds != null) {
				ds.Dispose ();
				ds = null;
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
			if (requestBtn != null) {
				requestBtn.Dispose ();
				requestBtn = null;
			}
		}
	}
}
