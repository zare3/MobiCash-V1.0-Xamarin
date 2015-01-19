using System;
using MonoTouch.UIKit;
namespace MobiCashiOSNewLayout
{
	public class BillTableItem
	{
		private string amount ;
		private string issueDate ;
		private string dueDate ;
		private bool isSettled;

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

		public BillTableItem (string amount, string issueDate, string dueDate, bool isSettled )
		{
			this.amount = amount;
			this.issueDate = issueDate;
			this.dueDate = dueDate;
			this.isSettled = isSettled;
		}

		public string getAmount ()
		{
			return this.amount;
		}

		public string getIssueDate()
		{
			return this.issueDate;
		}

		public string getDueDate ()
		{
			return this.dueDate;
		}

		public bool getIsSettled()
		{
			return this.isSettled;
		}
	}
}

