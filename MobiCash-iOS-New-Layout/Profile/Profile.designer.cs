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
	[Register ("Profile")]
	partial class Profile
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITextField balanceTextField { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIImageView maskImageView { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel nameLabel { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel phoneNumberLabel { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIImageView profilePicImageView { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIView ss { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIButton transferBtn { get; set; }

		[Action ("transferBtn_TouchUpInside:")]
		[GeneratedCode ("iOS Designer", "1.0")]
		partial void transferBtn_TouchUpInside (UIButton sender);

		void ReleaseDesignerOutlets ()
		{
			if (balanceTextField != null) {
				balanceTextField.Dispose ();
				balanceTextField = null;
			}
			if (maskImageView != null) {
				maskImageView.Dispose ();
				maskImageView = null;
			}
			if (nameLabel != null) {
				nameLabel.Dispose ();
				nameLabel = null;
			}
			if (phoneNumberLabel != null) {
				phoneNumberLabel.Dispose ();
				phoneNumberLabel = null;
			}
			if (profilePicImageView != null) {
				profilePicImageView.Dispose ();
				profilePicImageView = null;
			}
			if (ss != null) {
				ss.Dispose ();
				ss = null;
			}
			if (transferBtn != null) {
				transferBtn.Dispose ();
				transferBtn = null;
			}
		}
	}
}
