using MonoTouch.UIKit;
namespace MobiCashiOSNewLayout
{
	public class ContactsTableItem
	{
		private string name;
		private string mobileNumber;
		private bool doesHaveApp;


		public UITableViewCellStyle CellStyle
		{
			get { return cellStyle; }
			set { cellStyle = value; }
		}
		protected UITableViewCellStyle cellStyle = UITableViewCellStyle.Default;

		public UITableViewCellAccessory CellAccessory
		{
			get { return cellAccessory; }
			set { cellAccessory = value; }
		}
		protected UITableViewCellAccessory cellAccessory = UITableViewCellAccessory.None;

		public ContactsTableItem (string name, string mobileNumber,  bool doesHaveApp)
		{
			this.name = name;
			this.doesHaveApp = doesHaveApp;
			this.mobileNumber = mobileNumber;

		}

		public ContactsTableItem (ContactsTableItem guest)
		{ 
			this.name = guest.name;
			this.doesHaveApp = guest.doesHaveApp;
			this.mobileNumber = guest.mobileNumber;
		}

		public string getName ()
		{
			return this.name;
		}

		public bool getDoesHaveApp()
		{
			return this.doesHaveApp;
		}

		public string getMobileNumber()
		{
			return this.mobileNumber;
		}
	

	}
}

