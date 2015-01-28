using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;

namespace MobiCashiOSNewLayout
{
	partial class Profile : UIViewController
	{
	


		public Profile (IntPtr handle) : base (handle)
		{
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			loadViewSettings ();

		}

		private void loadViewSettings ()
		{
			this.NavigationItem.SetHidesBackButton (true, false);
			setSwipeLeftGesture ();
			setRightNavBarItem ();
			loadProfileImage ();



		}
			
	

		private void loadProfileImage()
		{
			UIImage profileImg = new UIImage ();
			profileImg = UIImage.FromFile ("Images/Profile/dummy_pp_v1.png");
			profilePicImageView.Image = profileImg;
		}

		private void setSwipeLeftGesture()
		{

			UISwipeGestureRecognizer recognizer = new UISwipeGestureRecognizer (openMainNavController);
			recognizer.Direction = UISwipeGestureRecognizerDirection.Left;
			this.View.AddGestureRecognizer (recognizer);
		}

		private void setRightNavBarItem()
		{
			this.NavigationItem.SetRightBarButtonItem(
				new UIBarButtonItem(UIImage.FromFile("Images/MainNavDrawer/main_nav_drawer.png")
					, UIBarButtonItemStyle.Plain
					, (sender,args) => {
						openMainNavController();
					})
				, true);
				
		}
		private void openMainNavController()
		{
			MainNavController main_nav_controller = this.Storyboard.InstantiateViewController ("MainNavController") as MainNavController;
			this.NavigationController.PushViewController (main_nav_controller, true);
		}

		partial void transferBtn_TouchUpInside (UIButton sender)
		{
			Transfer transfer_nav_controller = this.Storyboard.InstantiateViewController ("Transfer") as Transfer;
			this.NavigationController.PushViewController (transfer_nav_controller, true);
		}
	}
}
