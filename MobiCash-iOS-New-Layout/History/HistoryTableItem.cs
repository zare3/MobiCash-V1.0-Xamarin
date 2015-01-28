using System;
using MonoTouch.UIKit;
namespace MobiCashiOSNewLayout
{
	public enum HistoryViewType
	{
		Pending,Sent,Received
	};
	public class HistoryTableItem
	{
		private string recipent;
		private string amount;
		private DateTime timeStamp;
		private HistoryViewType historyViewType;
		private string historyViewTypeString;


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

		public HistoryTableItem (string recipent, string amount, DateTime timeStamp, HistoryViewType historyViewType)
		{
			this.recipent = recipent;
			this.amount = amount;
			this.timeStamp = timeStamp;
			this.historyViewType = historyViewType;

			if (historyViewType == HistoryViewType.Pending)
				historyViewTypeString = "Pending";
			else if (historyViewType == HistoryViewType.Sent)
				historyViewTypeString = "Sent";
			else if (historyViewType == HistoryViewType.Received)
				historyViewTypeString = "Recieved";
		}

		public HistoryTableItem (HistoryTableItem guest)
		{ 
			this.recipent = guest.recipent;
			this.amount = guest.amount;
			this.timeStamp = guest.timeStamp;
			this.historyViewType = guest.historyViewType;
			this.historyViewTypeString = guest.historyViewTypeString;
		}

		public string getRecipent ()
		{
			return this.recipent;
		}

		public string getAmount ()
		{
			return this.amount;
		}

		public DateTime getTimeStamp()
		{
			return this.timeStamp;
		}
			

		public HistoryViewType getHistoryViewType ()
		{
			return this.historyViewType;
		}

		public string getHistoryViewTypeString ()
		{
			return this.historyViewTypeString;
		}

	}
}

