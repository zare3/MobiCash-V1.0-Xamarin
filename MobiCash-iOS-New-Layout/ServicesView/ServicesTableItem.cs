using System;
using MonoTouch.UIKit;

namespace MobiCashiOSNewLayout
{
	public enum ServicesViewType
	{
		InternetBill,
		MobileBill
	};
	public class ServicesTableItem
	{
		private string heading ;
		private string imageAddress;
		private ServicesViewType servicesViewType;



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

		public ServicesTableItem (string heading, string imageAddress, ServicesViewType servicesViewType)
		{
			this.heading = heading;
			this.imageAddress = imageAddress;
			this.servicesViewType = servicesViewType;
		}

		public ServicesTableItem (ServicesTableItem guest)
		{ 
			this.heading = guest.heading;
			this.imageAddress = guest.imageAddress;
		}
			

		public void setHeading (String heading)
		{
			this.heading = heading;
		}

		public String getHeading ()
		{
			return this.heading;
		}

		public void setImageAddress (String imageAddress)
		{
			this.imageAddress = imageAddress;
		}

		public String getImageAddress ()
		{
			return this.imageAddress;
		}
	
		public ServicesViewType getViewType()
		{
			return this.servicesViewType;
		}

		public void setViewType (ServicesViewType servicesViewType)
		{
			this.servicesViewType = servicesViewType;
		}
	}

}


