using MonoTouch.UIKit;
using System;
using System.Collections.Generic;

namespace MobiCashiOSNewLayout
{
	partial class MobileBill : UIViewController
	{
		private List<string> MobileBillamounts;
		private List<string> MobileBillIssueDates;
		private List<string> InternetBillDueDates;
		private List<bool> MobileBillSettlements;
		private List<BillTableItem> BillTableItems;
		private string phoneNumber;
		private string amount;

		public MobileBill (IntPtr handle) : base (handle)
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
			MobileBillSettlements = new List<bool> ();
			MobileBillSettlements.Add (true);
			MobileBillSettlements.Add (false);
			MobileBillSettlements.Add (false);
			MobileBillSettlements.Add (false);

		}
		private void makeAmountsReady()
		{
			MobileBillamounts = new List<string> ();
			MobileBillamounts.Add("100 EGP");
			MobileBillamounts.Add("200 EGP");
			MobileBillamounts.Add("300 EGP");
			MobileBillamounts.Add("400 EGP");
		}

		private void makeIssueDatesReady()
		{
			MobileBillIssueDates = new List<string> ();
			MobileBillIssueDates.Add("02/05/2014");
			MobileBillIssueDates.Add("02/06/2014");
			MobileBillIssueDates.Add("02/07/2014");
			MobileBillIssueDates.Add("02/08/2014");
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
			for (int i = 0; i < MobileBillamounts.Count; i++)
				BillTableItems.Add (new BillTableItem (MobileBillamounts [i], MobileBillIssueDates [i],
					InternetBillDueDates [i], MobileBillSettlements [i]));
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
