using System;
using System.Collections.Generic;
using System.IO;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace MobiCashiOSNewLayout
{
	public class HistoryTableSource:UITableViewSource
	{
		List<HistoryTableItem> tableItems;
		NSString cellIdentifier = new NSString("TableCell");
		UIViewController parentController;


		public HistoryTableSource (List<HistoryTableItem> tableItems, UIViewController parentCont)
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



		/// <summary>
		/// Called when a row is touched
		/// </summary>
		public override void RowSelected (UITableView tableView, NSIndexPath indexPath)
		{
			if (tableItems [indexPath.Row].getHistoryViewType() == HistoryViewType.Pending)
			{
				string name = tableItems [indexPath.Row].getRecipent();
				string amount = tableItems [indexPath.Row].getAmount();
				UIAlertView confirmTopUp = new UIAlertView("Pending Request",
					"Do you want to accept "+name+"'s request to transfer an amount of "+amount+" to his MobiCash account?", 
					null, "YES", "NO");

				confirmTopUp.Clicked += (object s, UIButtonEventArgs e) => { 
					if (e.ButtonIndex == 0) // 0 == YES
						new UIAlertView ("Done","Transaction was successfull!",null,"OK").Show();
				};
				confirmTopUp.Show();
			}
			else if (tableItems [indexPath.Row].getHistoryViewType() == HistoryViewType.Sent)
			{
				string name = tableItems [indexPath.Row].getRecipent();
				string amount = tableItems [indexPath.Row].getAmount();
				string timeStamp = tableItems [indexPath.Row].getTimeStamp ().ToString();
				UIAlertView confirmTopUp = new UIAlertView("Transaction Completed",
					"You have sent to "+name+" an amount of "+amount+" on " +timeStamp,
					null, "OK", null);

				confirmTopUp.Show();
			}

			else if (tableItems [indexPath.Row].getHistoryViewType() == HistoryViewType.Received)
			{
				string name = tableItems [indexPath.Row].getRecipent();
				string amount = tableItems [indexPath.Row].getAmount();
				string timeStamp = tableItems [indexPath.Row].getTimeStamp ().ToString();
				UIAlertView confirmTopUp = new UIAlertView("Transaction Completed",
					"You have received from "+name+" an amount of "+amount+" on " +timeStamp,
					null, "OK", null);

				confirmTopUp.Show();
			}
			tableView.DeselectRow (indexPath, true);

		}

		/// <summary>
		/// Called by the TableView to get the actual UITableViewCell to render for the particular row
		/// </summary>
		public override UITableViewCell GetCell (UITableView tableView, MonoTouch.Foundation.NSIndexPath indexPath)
		{
			// request a recycled cell to save memory
			HistoryTableCell cell = tableView.DequeueReusableCell (cellIdentifier) as HistoryTableCell;

			// if there are no cells to reuse, create a new one
			if (cell == null) {
				cell = new HistoryTableCell (cellIdentifier);
			}

			cell.UpdateCell (tableItems [indexPath.Row].getRecipent(),tableItems [indexPath.Row].getHistoryViewTypeString(),tableItems [indexPath.Row].getAmount(), tableItems [indexPath.Row].getTimeStamp(), tableItems [indexPath.Row].getHistoryViewType()   );
			return cell;
		}
			
		public string GetCellName (int rowIndex)
		{
			return tableItems [rowIndex].getTimeStamp().ToString();
		}
	}
}

