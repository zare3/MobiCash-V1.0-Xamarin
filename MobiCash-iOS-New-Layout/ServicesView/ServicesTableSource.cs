using System;
using System.Collections.Generic;
using System.IO;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace MobiCashiOSNewLayout
{
	public class ServicesTableSource:UITableViewSource
	{
		List<ServicesTableItem> tableItems;
		NSString cellIdentifier = new NSString("TableCell");
		UIViewController parentController;


		public ServicesTableSource (List<ServicesTableItem> tableItems, UIViewController parentCont)
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

			if (tableItems [indexPath.Row].getViewType () == ServicesViewType.InternetBill) {
				InternetBill internet_bill_nav_controller = parentController.Storyboard.InstantiateViewController ("InternetBill") as InternetBill;
				parentController.NavigationController.PushViewController (internet_bill_nav_controller, true);

			} 
			else if (tableItems [indexPath.Row].getViewType () == ServicesViewType.MobileBill) {

				MobileBill mobile_bill_nav_controller = parentController.Storyboard.InstantiateViewController ("MobileBill") as MobileBill;
				parentController.NavigationController.PushViewController (mobile_bill_nav_controller, true);
			}
			tableView.DeselectRow (indexPath, true);


		}



		/// <summary>
		/// Called by the TableView to get the actual UITableViewCell to render for the particular row
		/// </summary>
		public override UITableViewCell GetCell (UITableView tableView, MonoTouch.Foundation.NSIndexPath indexPath)
		{
			// request a recycled cell to save memory
			ServicesTableCell cell = tableView.DequeueReusableCell (cellIdentifier) as ServicesTableCell;

			// if there are no cells to reuse, create a new one
			if (cell == null) {
				cell = new ServicesTableCell (cellIdentifier);
			}

			cell.UpdateCell (tableItems [indexPath.Row].getHeading(),UIImage.FromFile(tableItems[indexPath.Row].getImageAddress()),tableItems [indexPath.Row].getViewType() );

			return cell;
		}

		public string GetCellName (int rowIndex)
		{
			return tableItems [rowIndex].getHeading();
		}
	}
}

