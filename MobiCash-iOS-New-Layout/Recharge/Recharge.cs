using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System;
using System.CodeDom.Compiler;
using System.Drawing;
using System.Collections.Generic;

namespace MobiCashiOSNewLayout
{
	partial class Recharge : UIViewController
	{
		private List<RechargeTableItem> rechargeTableItems;
		private List<string> rechargeTableStrings;
		private string phoneNumber;
		private string amount;
		private string balance;
		public Recharge (IntPtr handle) : base (handle)
		{
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			loadViewSettings ();
			makeRechargeTableStringsReady ();
			createViewTable ();
		}
		private void loadViewSettings()
		{

			phoneNumberTextField.Placeholder = "Mobile number";
			balance = "10";

			this.NavigationItem.SetHidesBackButton (true, false);
			setSwipeLeftGesture ();
			setRightNavBarItem ();

			var tap = new UITapGestureRecognizer { CancelsTouchesInView = false };
			tap.AddTarget(() => View.EndEditing(true));
			tap.ShouldReceiveTouch += (recognizer, touch) => !(touch.View is UITableViewCell);
			View.AddGestureRecognizer(tap);
			rechargeBtn.Enabled = false;

		}

		public void setSwipeLeftGesture()
		{

			UISwipeGestureRecognizer recognizer = new UISwipeGestureRecognizer (openMainNavController);
			recognizer.Direction = UISwipeGestureRecognizerDirection.Left;
			this.View.AddGestureRecognizer (recognizer);
		}

		public void setRightNavBarItem()
		{
			this.NavigationItem.SetRightBarButtonItem(
				new UIBarButtonItem(UIImage.FromFile("Images/MainNavDrawer/main_nav_drawer.png")
					, UIBarButtonItemStyle.Plain
					, (sender,args) => {
						openMainNavController();
					})
				, true);

		}
		public void openMainNavController()
		{
			MainNavController main_nav_controller = this.Storyboard.InstantiateViewController ("MainNavController") as MainNavController;
			this.NavigationController.PushViewController (main_nav_controller, true);
		}

		private void makeRechargeTableStringsReady()
		{
			rechargeTableStrings = new List<string> ();
			rechargeTableStrings.Add ("5 EGP");
			rechargeTableStrings.Add ("10 EGP");
			rechargeTableStrings.Add ("15 EGP");
			rechargeTableStrings.Add ("25 EGP");
			rechargeTableStrings.Add ("50 EGP");
		}



		private void createViewTable()
		{

			rechargeTableItems = new List<RechargeTableItem> ();
			for (int i = 0; i < rechargeTableStrings.Count; i++)
				rechargeTableItems.Add (new RechargeTableItem (rechargeTableStrings [i]));
			amountsTable.Source = new RechargeTableSource (rechargeTableItems, this, rechargeBtn,Convert.ToInt32(balance));
			Add (amountsTable);
		}


		private string getAmountSelected ()
		{
			int idx = -1;

			for (int i = 0; i < amountsTable.NumberOfRowsInSection (0); i++) {
				UITableViewCell cell = amountsTable.CellAt (NSIndexPath.FromItemSection (i, 0));
				if (cell.Accessory == UITableViewCellAccessory.Checkmark)
					idx = i;
			}

			return rechargeTableStrings [idx];
		}

		partial void rechargeBtn_TouchUpInside (UIButton sender)
		{
			phoneNumber = phoneNumberTextField.Text;
			amount = getAmountSelected();
			UIAlertView confirmTopUp = new UIAlertView("Transfer",
				"Do you want to recharge the mobile balance of "+phoneNumber+" with an amount of "+amount+" ?", 
				null, "YES", "NO");

			confirmTopUp.Clicked += (object s, UIButtonEventArgs e) => { 
				if (e.ButtonIndex == 0) // 0 == YES
					new UIAlertView ("Done","Recharge was successfull!",null,"OK").Show();
			};
			confirmTopUp.Show();


		}


	}
}
