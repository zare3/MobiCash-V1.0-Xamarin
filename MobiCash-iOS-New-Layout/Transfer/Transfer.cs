using MonoTouch.UIKit;
using System;
using MonoTouch.AddressBookUI;
using MonoTouch.AddressBook;

namespace MobiCashiOSNewLayout
{
	partial class Transfer : UIViewController
	{
		private ABPeoplePickerNavigationController contactController;
		private string phoneNumber;
		private string amount;
		public Transfer (IntPtr handle) : base (handle)
		{
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			loadViewSettings ();

		}

		private void loadViewSettings()
		{
			phoneNumberTextField.Placeholder = "Transfer to: (Mobile Number) ";
			amountTextField.Placeholder = "Amount";
			messageTextField.Placeholder = "Message";

			phoneNumberTextField.KeyboardType = UIKeyboardType.PhonePad;
			amountTextField.KeyboardType = UIKeyboardType.NumberPad;

			messageTextField.ReturnKeyType = UIReturnKeyType.Done;
			messageTextField.ShouldReturn = TextFieldKeyboardReturn;

			var g = new UITapGestureRecognizer(() => View.EndEditing(true));
			View.AddGestureRecognizer(g);

			this.NavigationItem.SetHidesBackButton (true, false);

			setMessageMaxLengthListener ();
			setSwipeLeftGesture ();
			setRightNavBarItem ();
			setAddContactBtnListener ();
		}

		private void setMessageMaxLengthListener()

		{
			messageTextField.ShouldChangeCharacters = (textField, range, replacementString) => {
				var newLength = messageTextField.Text.Length + replacementString.Length - range.Length;
				return newLength <= 125;
			};

			messageTextField.EditingChanged += (object sender, EventArgs e) => {

				if (125 - messageTextField.Text.Length < 10)
					numOfCharsLabel.Text = "00"+(125 - messageTextField.Text.Length ) + " Character(s)";
				else if (125 - messageTextField.Text.Length < 100) numOfCharsLabel.Text = "0"+(125 - messageTextField.Text.Length ) + " Character(s)";
				else numOfCharsLabel.Text = (125 - messageTextField.Text.Length ) + " Character(s)";
			};

		}

		private bool TextFieldKeyboardReturn (UITextField uitf)
		{
			 if (uitf == messageTextField)
				uitf.ResignFirstResponder();
			return true;
		}

		private void setAddContactBtnListener()
		{
			contactController = new ABPeoplePickerNavigationController ();

			contactController.Cancelled += delegate {
				this.DismissViewController (true,null);

			};
				
				
			contactController.SelectPerson2 +=
				delegate(object sender, ABPeoplePickerSelectPerson2EventArgs e) {

				ABMultiValue<string> phones = e.Person.GetPhones();
				if (phones.Count>0)
					phoneNumberTextField.Text = String.Format ("{0}", phones[0].Value);
				this.DismissViewController (true,null);
			};
		}

		partial void addNumberFromContactsBtn_TouchUpInside (UIButton sender)
		{
			this.PresentViewController (contactController, true,null);
		}

	

		partial void transferBtn_TouchUpInside (UIButton sender)
		{
			phoneNumber = phoneNumberTextField.Text;
			amount = amountTextField.Text;
			UIAlertView confirmTopUp = new UIAlertView("Transfer",
				"Do you want to transfer "+amount+" EGP to "+phoneNumber+"?", 
				null, "YES", "NO");

			confirmTopUp.Clicked += (object s, UIButtonEventArgs e) => { 
				if (e.ButtonIndex == 0) // 0 == YES
					new UIAlertView ("Done","Transfer was successfull!",null,"OK").Show();
			};

			confirmTopUp.Show();
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

			/*this.NavigationItem.SetRightBarButtonItem(
				new UIBarButtonItem(UIBarButtonSystemItem.FastForward, (sender,args) => {
					openMainNavController();
				})
				, true);*/
		}
		public void openMainNavController()
		{
			MainNavController main_nav_controller = this.Storyboard.InstantiateViewController ("MainNavController") as MainNavController;
			this.NavigationController.PushViewController (main_nav_controller, true);
		}
	}
}
