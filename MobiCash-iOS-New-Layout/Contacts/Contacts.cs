using MonoTouch.UIKit;
using System;
using System.Collections.Generic;
using MonoTouch.AddressBookUI;
using MonoTouch.AddressBook;
using MonoTouch.Foundation;

namespace MobiCashiOSNewLayout
{
	partial class Contacts : UITableViewController
	{
		private List<string> contactsNames;
		private List<ContactsTableItem> contactsTableItems;
		ABAddressBook iPhoneAddressBook;
		public Contacts (IntPtr handle) : base (handle)
		{
		}
			
		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			loadViewSettings ();
			makeContactsNameReady ();
			makeTableItemsReady ();
			makeTableReady ();
		}

		private void makeTableReady ()
		{
			ContactsTable = new UITableView(UIScreen.MainScreen.Bounds);
			ContactsTable.Source = new ContactsTableSource (contactsTableItems, this);
			Add (ContactsTable);
		}

		private void makeTableItemsReady()
		{
			contactsTableItems = new List<ContactsTableItem> ();
			for (int i=0; i<contactsNames.Count; i++) contactsTableItems.Add ( new ContactsTableItem (contactsNames[i] , "NULL", true) );
		}
		private void makeContactsNameReady()
		{
			contactsNames = new List<string> ();
			iPhoneAddressBook =  ABAddressBook.Create (out NSError e);
			//if (e==null) throw System.Exception;
			var authStatus = ABAddressBook.GetAuthorizationStatus();
			if (authStatus != ABAuthorizationStatus.Authorized) {

				iPhoneAddressBook.RequestAccess (delegate(bool granted,
				                                         NSError error) {
					if (granted) {
						getAllContacts ();
					}
				});

			}
			else
			{
				getAllContacts ();
			}
	    }

		private void getAllContacts ()
		{
			ABPerson[] myContacts = iPhoneAddressBook.GetPeople();
			foreach (ABPerson contact in myContacts)
			{
				/*ABMultiValue<string> myContact = contact.GetPhones();
				foreach (ABMultiValueEntry<string> cont in myContact) 
					phone = cont.Value;*/
				contactsNames.Add(contact.FirstName + " " + contact.LastName);
			}

		}

		private void loadViewSettings ()
		{
			this.NavigationItem.SetHidesBackButton (true, false);
			setSwipeLeftGesture ();
			setRightNavBarItem ();
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
}

}