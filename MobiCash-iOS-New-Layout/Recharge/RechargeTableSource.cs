using System;
using System.Collections.Generic;
using System.IO;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace MobiCashiOSNewLayout
{
	public class RechargeTableSource:UITableViewSource
	{
		List<RechargeTableItem> tableItems;
		NSString cellIdentifier = new NSString("TableCell");
		UIViewController parentController;
		UIButton rechargeBtn;
		int balance;

		public RechargeTableSource (List<RechargeTableItem> tableItems, UIViewController parentCont, UIButton rechargeBtn, int balance)
		{
			this.tableItems = tableItems;
			parentController = parentCont;
			this.rechargeBtn = rechargeBtn;
			this.balance = balance;
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
			if (tableView.CellAt (indexPath).Accessory == UITableViewCellAccessory.Checkmark) {
				tableView.CellAt (indexPath).Accessory = UITableViewCellAccessory.None;
				rechargeBtn.Enabled = false;
				tableView.DeselectRow (indexPath, true);
			}
			else {
				for (int i = 0; i < tableView.NumberOfRowsInSection (0); i++) {
					UITableViewCell cell = tableView.CellAt (NSIndexPath.FromItemSection (i, 0));
					cell.Accessory = UITableViewCellAccessory.None;
				}
				rechargeBtn.Enabled = true;
				tableView.CellAt (indexPath).Accessory = UITableViewCellAccessory.Checkmark;

				int intBalance;
				if (tableItems [indexPath.Row].getAmount () == "5 EGP")
				 intBalance = Convert.ToInt32 (Char.GetNumericValue (tableItems [indexPath.Row].getAmount () [0]));
				else
					intBalance = int.Parse(tableItems [indexPath.Row].getAmount ().Substring(0,2));
				if (intBalance > balance) 
				{
					rechargeBtn.Enabled = false;
				}
			}
		}



		/// <summary>
		/// Called by the TableView to get the actual UITableViewCell to render for the particular row
		/// </summary>
		public override UITableViewCell GetCell (UITableView tableView, MonoTouch.Foundation.NSIndexPath indexPath)
		{
			// request a recycled cell to save memory
			RechargeTableCell cell = tableView.DequeueReusableCell (cellIdentifier) as RechargeTableCell;

			// if there are no cells to reuse, create a new one
			if (cell == null) {
				cell = new RechargeTableCell (cellIdentifier);
			}

			cell.UpdateCell (tableItems [indexPath.Row].getAmount());
			//cell.Accessory = UITableViewCellAccessory.Checkmark;
			return cell;
		}

		public string GetCellName (int rowIndex)
		{
			return tableItems [rowIndex].getAmount();
		}
	}
}

