using System;
using System.Collections.Generic;
using System.IO;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace MobiCashiOSNewLayout
{
	public class RecentsTableSource:UITableViewSource
	{
		List<RecentsTableItem> tableItems;
		NSString cellIdentifier = new NSString("TableCell");
		UIViewController parentController;


		public RecentsTableSource (List<RecentsTableItem> tableItems, UIViewController parentCont)
		{
			this.tableItems = tableItems;
			parentController = parentCont;
		}

		/// <summary>
		/// Called by the TableView to determine how many cells to create for that particular section.
		/// </summary>
		public override int RowsInSection (UITableView tableview, int section)
		{
			return tableItems.Count;
		}


		public override float GetHeightForRow(UITableView tableView, NSIndexPath indexPath)
		{
			// In here you could customize how you want to get the height for row. Then   
			// just return it. 

			return 80;
		}


		/// <summary>
		/// Called when a row is touched
		/// </summary>
		public override void RowSelected (UITableView tableView, NSIndexPath indexPath)
		{



			tableView.DeselectRow (indexPath, true);


		}

		/// <summary>
		/// Called by the TableView to get the actual UITableViewCell to render for the particular row
		/// </summary>
		public override UITableViewCell GetCell (UITableView tableView, MonoTouch.Foundation.NSIndexPath indexPath)
		{
			// request a recycled cell to save memory
			RecentsTableCell cell = tableView.DequeueReusableCell (cellIdentifier) as RecentsTableCell;

			// if there are no cells to reuse, create a new one
			if (cell == null) {
				cell = new RecentsTableCell (cellIdentifier);
			}
			//(string name, UIImage profileImg, string lastMsg, string lastTransactionStatus, string lastTransactionAmnt, string timeStamp )
			cell.UpdateCell (tableItems [indexPath.Row].getName()
				, UIImage.FromFile(tableItems[indexPath.Row].getImageAddress())
				,tableItems [indexPath.Row].getLastMsg()
				,tableItems [indexPath.Row].getLastTransactionStatusString()
				, tableItems [indexPath.Row].getLastTransactionStatus()
				, tableItems [indexPath.Row].getLastTransactionAmnt()
				,tableItems [indexPath.Row].getTimeStamp().ToString()
				,tableItems [indexPath.Row].getIsTherePendingMessages()
				,tableItems [indexPath.Row].getPendingMessagesCount() );

			return cell;
		}

		public string GetCellName (int rowIndex)
		{
			return tableItems [rowIndex].getTimeStamp().ToString();
		}
	}
}

