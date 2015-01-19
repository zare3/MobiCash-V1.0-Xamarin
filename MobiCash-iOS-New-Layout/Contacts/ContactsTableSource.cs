using System.Collections.Generic;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace MobiCashiOSNewLayout
{

	public class ContactsTableSource:UITableViewSource
	{
		List<ContactsTableItem> tableItems;
		NSString cellIdentifier = new NSString("TableCell");
		UIViewController parentController;


		public ContactsTableSource (List<ContactsTableItem> tableItems, UIViewController parentCont)
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

			tableView.DeselectRow (indexPath, true);

		}

		/// <summary>
		/// Called by the TableView to get the actual UITableViewCell to render for the particular row
		/// </summary>
		public override UITableViewCell GetCell (UITableView tableView, MonoTouch.Foundation.NSIndexPath indexPath)
		{
			// request a recycled cell to save memory
			ContactsTableCell cell = tableView.DequeueReusableCell (cellIdentifier) as ContactsTableCell;

			// if there are no cells to reuse, create a new one
			if (cell == null) {
				cell = new ContactsTableCell (cellIdentifier);
			}
			cell.Accessory = UITableViewCellAccessory.DisclosureIndicator;
			cell.UpdateCell (tableItems [indexPath.Row].getName());
			return cell;
		}

		public string GetCellName (int rowIndex)
		{
			return tableItems [rowIndex].getMobileNumber();
		}

	}
}

