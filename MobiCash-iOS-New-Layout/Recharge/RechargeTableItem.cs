using System;
using MonoTouch.UIKit;
namespace MobiCashiOSNewLayout
{
	public class RechargeTableItem
	{
		private string amount;
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
		public RechargeTableItem (string amount)
		{
			this.amount = amount;
		}

		public string getAmount () {
			return this.amount;
		}

		public RechargeTableItem (RechargeTableItem guest)
		{
			this.amount = guest.amount;
		}

	}
}

