using MonoTouch.UIKit;
using System;
using System.Collections.Generic;

namespace MobiCashiOSNewLayout
{
	partial class PayBill : UIViewController
	{

		private List<string> billamounts;
		private List<string> billIssueDates;
		private List<string> InternetbillDueDates;
		private List<bool> billSettlements;
		private List<BillTableItem> billTableItems;
		private string phoneNumber;
		private string amount;

		public PayBill (IntPtr handle) : base (handle)
		{
		}

		partial void payBtn_TouchUpInside (UIButton sender)
		{
			phoneNumber = numberTextField.Text;
			amount = amountToBePaidTextField.Text;
			UIAlertView confirmTopUp = new UIAlertView("Pay Internet bill",
				"Do you want to pay a bill of amount "+amount+" EGP for "+phoneNumber+"?", 
				null, "YES", "NO");

			confirmTopUp.Clicked += (object s, UIButtonEventArgs e) => { 
				if (e.ButtonIndex == 0) // 0 == YES
					new UIAlertView ("Done","Bill Paid Succesfully!",null,"OK").Show();
			};

			confirmTopUp.Show();
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			loadViewSettings ();
			makeSettlementsReady ();
			makeAmountsReady();
			makeIssueDatesReady();
			makeDueDatesReady();
			createViewTable ();
		}
		private void loadViewSettings()
		{
			numberTextField.Placeholder = " Number";
			amountToBePaidTextField.Placeholder = "Amount";
		
			this.NavigationItem.SetHidesBackButton (true, false);
			setSwipeLeftGesture ();
			setRightNavBarItem ();

			numberTextField.ShouldReturn = TextFieldKeyboardReturn;
			amountToBePaidTextField.ShouldReturn = TextFieldKeyboardReturn;

			numberTextField.ReturnKeyType = UIReturnKeyType.Next;
			amountToBePaidTextField.ReturnKeyType = UIReturnKeyType.Done;

			numberTextField.KeyboardType = UIKeyboardType.PhonePad;
			amountToBePaidTextField.KeyboardType = UIKeyboardType.NumberPad;

			var g = new UITapGestureRecognizer(() => View.EndEditing(true));
			View.AddGestureRecognizer(g);
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

		private bool TextFieldKeyboardReturn (UITextField uitf)
		{
			if (uitf == numberTextField) 
				amountToBePaidTextField.BecomeFirstResponder ();


			else if (uitf == amountToBePaidTextField)
				uitf.ResignFirstResponder();
			return true;
		}

		private void makeSettlementsReady()
		{
			billSettlements = new List<bool> ();
			billSettlements.Add (true);
			billSettlements.Add (false);
			billSettlements.Add (false);
			billSettlements.Add (false);

		}

		private void makeAmountsReady()
		{
			billamounts = new List<string> ();
			billamounts.Add("100 EGP");
			billamounts.Add("200 EGP");
			billamounts.Add("300 EGP");
			billamounts.Add("400 EGP");
		}

		private void makeIssueDatesReady()
		{
			billIssueDates = new List<string> ();
			billIssueDates.Add("02/05/2014");
			billIssueDates.Add("02/06/2014");
			billIssueDates.Add("02/07/2014");
			billIssueDates.Add("02/08/2014");
		}

		private void makeDueDatesReady()
		{
			InternetbillDueDates = new List<string> ();
			InternetbillDueDates.Add("02/06/2014");
			InternetbillDueDates.Add("02/07/2014");
			InternetbillDueDates.Add("02/08/2014");
			InternetbillDueDates.Add("02/09/2014");
		}

		private void createViewTable()
		{

			billTableItems = new List<BillTableItem> ();
			for (int i = 0; i < billamounts.Count; i++)
				billTableItems.Add (new BillTableItem (billamounts [i], billIssueDates [i],
					InternetbillDueDates [i], billSettlements [i]));
			billsTable.Source = new BillTableSource (billTableItems, this);
			Add (billsTable);
		}

		private bool validatePhoneNumber ()
		{
			//validate phone number from server
			return true;
		}

		private bool validateAmount ()
		{
			//validate amount from server
			return true;
		}
	}
}
