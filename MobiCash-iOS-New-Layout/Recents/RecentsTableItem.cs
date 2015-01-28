using System;
using MonoTouch.UIKit;

namespace MobiCashiOSNewLayout
{
	public enum TransactionStatus
	{
		Pending, Sent, Received, NULL
	};

	public class RecentsTableItem
	{
		private String name ;
		private String imgAddrs;
		private DateTime timeStamp;
		private String lastMsg;
		private bool wasThereATransactionMade;
		private TransactionStatus lastTransactionStatus;
		private String lastTransactionAmnt;
		private bool isTherePendingMessages;
		private String pendingMessagesCount;


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

		public RecentsTableItem (String name, String imgAddrs, DateTime timeStamp, String lastMsg, bool wasThereATransactionMade, TransactionStatus lastTransactionStatus, String lastTransactionAmnt,  bool isTherePendingMessages, String pendingMessagesCount)
		{
			this.name = name;
			this.imgAddrs = imgAddrs;
			this.timeStamp = timeStamp;
			this.lastMsg = lastMsg;
			this.wasThereATransactionMade = wasThereATransactionMade;
			this.lastTransactionStatus = lastTransactionStatus;
			this.lastTransactionAmnt = lastTransactionAmnt;
			this.isTherePendingMessages = isTherePendingMessages;
			this.pendingMessagesCount = pendingMessagesCount;
		}


		public String getImageAddress()
		{
			return this.imgAddrs;
		}
		public String getName ()
		{
			return this.name;
		}
		public DateTime getTimeStamp()
		{
			return this.timeStamp;
		}

		public String getLastMsg()
		{
			return this.lastMsg;
		}

		public bool getIfThereWasATransactionMade ()
		{
			return wasThereATransactionMade;
		}

		public TransactionStatus getLastTransactionStatus()
		{
			return this.lastTransactionStatus;
		}

		public string getLastTransactionStatusString()
		{
			if (this.lastTransactionStatus == TransactionStatus.Pending)
				return "Pending";
			else if (this.lastTransactionStatus == TransactionStatus.Received)
				return "Received";
			else if (this.lastTransactionStatus == TransactionStatus.Sent)
				return "Sent";
			return "";
		}

		public bool getIsTherePendingMessages()
		{
			return this.isTherePendingMessages;
		}

		public string getPendingMessagesCount()
		{
			return this.pendingMessagesCount;
		}

		public String getLastTransactionAmnt ()
		{
			return this.lastTransactionAmnt;
		}

	}
}

