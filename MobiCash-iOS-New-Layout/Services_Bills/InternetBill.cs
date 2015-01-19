using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System;
using System.CodeDom.Compiler;
using System.Drawing;
using System.Collections.Generic;


namespace MobiCashiOSNewLayout
{
	partial class InternetBill : UIViewController
	{
		private List<string> InternetBillamounts;
		private List<string> InternetBillIssueDates;
		private List<string> InternetBillDueDates;
		private List<bool> InternetBillSettlements;
		private List<BillTableItem> BillTableItems;
		private string phoneNumber;
		private string amount;

		public InternetBill (IntPtr handle) : base (handle)
		{
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
		private void makeSettlementsReady()
		{
			InternetBillSettlements = new List<bool> ();
			InternetBillSettlements.Add (true);
			InternetBillSettlements.Add (false);
			InternetBillSettlements.Add (false);
			InternetBillSettlements.Add (false);

		}
		private void makeAmountsReady()
		{
			InternetBillamounts = new List<string> ();
			InternetBillamounts.Add("100 EGP");
			InternetBillamounts.Add("200 EGP");
			InternetBillamounts.Add("300 EGP");
			InternetBillamounts.Add("400 EGP");
		}

		private void makeIssueDatesReady()
		{
			InternetBillIssueDates = new List<string> ();
			InternetBillIssueDates.Add("02/05/2014");
			InternetBillIssueDates.Add("02/06/2014");
			InternetBillIssueDates.Add("02/07/2014");
			InternetBillIssueDates.Add("02/08/2014");
		}

		private void makeDueDatesReady()
		{
			InternetBillDueDates = new List<string> ();
			InternetBillDueDates.Add("02/06/2014");
			InternetBillDueDates.Add("02/07/2014");
			InternetBillDueDates.Add("02/08/2014");
			InternetBillDueDates.Add("02/09/2014");
		}

		private void createViewTable()
		{

			BillTableItems = new List<BillTableItem> ();
			for (int i = 0; i < InternetBillamounts.Count; i++)
				BillTableItems.Add (new BillTableItem (InternetBillamounts [i], InternetBillIssueDates [i],
					InternetBillDueDates [i], InternetBillSettlements [i]));
			lastBillsTable.Source = new BillTableSource (BillTableItems, this);
			Add (lastBillsTable);
		}

		private void loadViewSettings()
		{
			phoneNumberTextField.Placeholder = "Mobile Number";
			amountTextField.Placeholder = "Amount";

			phoneNumberTextField.ShouldReturn = TextFieldKeyboardReturn;
			amountTextField.ShouldReturn = TextFieldKeyboardReturn;

			phoneNumberTextField.ReturnKeyType = UIReturnKeyType.Next;
			amountTextField.ReturnKeyType = UIReturnKeyType.Done;

			phoneNumberTextField.KeyboardType = UIKeyboardType.PhonePad;
			amountTextField.KeyboardType = UIKeyboardType.NumberPad;

			var g = new UITapGestureRecognizer(() => View.EndEditing(true));
			View.AddGestureRecognizer(g);
		}
			

		private bool TextFieldKeyboardReturn (UITextField uitf)
		{
			if (uitf == phoneNumberTextField) 
				amountTextField.BecomeFirstResponder ();

			
			else if (uitf == amountTextField)
				uitf.ResignFirstResponder();
			return true;
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
	
		partial void PayBtn_TouchUpInside (UIButton sender)
		{
			phoneNumber = phoneNumberTextField.Text;
			amount = amountTextField.Text;
			UIAlertView confirmTopUp = new UIAlertView("Pay Internet Bill",
				"Do you want to pay a bill of amount "+amount+" EGP for "+phoneNumber+"?", 
				null, "YES", "NO");

			confirmTopUp.Clicked += (object s, UIButtonEventArgs e) => { 
				if (e.ButtonIndex == 0) // 0 == YES
					new UIAlertView ("Done","Bill Paid Succesfully!",null,"OK").Show();
			};

			confirmTopUp.Show();
		}




	}
}
