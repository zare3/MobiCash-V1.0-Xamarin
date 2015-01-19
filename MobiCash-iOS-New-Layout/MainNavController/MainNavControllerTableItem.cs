
using System;
using MonoTouch.UIKit;

namespace MobiCashiOSNewLayout
{
	public enum MainNavViewType  {
		Recents,
		Services, 
		Donations, 
		Transfer, PayBill, 
		Contacts,Request,Profile,Recharge,History
	};
	public class MainNavControllerTableItem
	{
		private string heading ;
		private MainNavViewType mainNavViewType;


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

		public MainNavControllerTableItem (String Heading, MainNavViewType mainNavViewType)
		{
			this.heading = Heading;
			this.mainNavViewType = mainNavViewType;
		}

		public MainNavControllerTableItem (MainNavControllerTableItem guest)
		{ 
			this.heading = guest.heading;
			this.mainNavViewType = guest.mainNavViewType;
		}

		public void setHeading (String Heading)
		{
			this.heading = Heading;
		}

		public String getHeading ()
		{
			return this.heading;
		}

		public void setViewType(MainNavViewType mainNavViewType)
		{
			this.mainNavViewType = mainNavViewType;
		}

		public MainNavViewType getViewType ()
		{
			return this.mainNavViewType;
		}

	}
}

