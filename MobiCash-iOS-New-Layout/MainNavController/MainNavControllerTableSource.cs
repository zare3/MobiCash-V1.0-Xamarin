using System;
using System.Collections.Generic;
using System.IO;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using MonoTouch.AddressBookUI;
using MonoTouch.AddressBook;

namespace MobiCashiOSNewLayout
{
	public class MainNavControllerTableSource:UITableViewSource
	{
		List<MainNavControllerTableItem> tableItems;
		NSString cellIdentifier = new NSString("TableCell");
		UIViewController parentController;


		public MainNavControllerTableSource (List<MainNavControllerTableItem> tableItems, UIViewController parentCont)
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
		
			if (tableItems [indexPath.Row].getViewType() == MainNavViewType.Services)
			{
				Services services_nav_controller = parentController.Storyboard.InstantiateViewController ("ServicesView") as Services;
				parentController.NavigationController.PushViewController (services_nav_controller, true);
			}
			else if (tableItems [indexPath.Row].getViewType() == MainNavViewType.Transfer)
			{
				Transfer transfer_nav_controller = parentController.Storyboard.InstantiateViewController ("Transfer") as Transfer;
				parentController.NavigationController.PushViewController (transfer_nav_controller, true);
			}

			else if (tableItems [indexPath.Row].getViewType() == MainNavViewType.Request)
			{
				Request request_nav_controller = parentController.Storyboard.InstantiateViewController ("Request") as Request;
				parentController.NavigationController.PushViewController (request_nav_controller, true);
			}

			else if (tableItems [indexPath.Row].getViewType() == MainNavViewType.Profile)
			{
				Profile profile_nav_controller = parentController.Storyboard.InstantiateViewController ("Profile") as Profile;
				parentController.NavigationController.PushViewController (profile_nav_controller, true);
			}

			else if (tableItems [indexPath.Row].getViewType() == MainNavViewType.Recharge)
			{
				Recharge recharge_nav_controller = parentController.Storyboard.InstantiateViewController ("Recharge") as Recharge;
				parentController.NavigationController.PushViewController (recharge_nav_controller, true);
			}

			else if (tableItems [indexPath.Row].getViewType() == MainNavViewType.History)
			{
				HistoryTabBarController history_nav_controller = parentController.Storyboard.InstantiateViewController ("HistoryTabBarController") as HistoryTabBarController;
				parentController.NavigationController.PushViewController (history_nav_controller, true);
			}

			else if (tableItems [indexPath.Row].getViewType() == MainNavViewType.Contacts)
			{
				var iPhoneAddressBook =  ABAddressBook.Create (out NSError e);
				//if (e==null) throw System.Exception;
				var authStatus = ABAddressBook.GetAuthorizationStatus();
				if (authStatus != ABAuthorizationStatus.Authorized) {
					iPhoneAddressBook.RequestAccess (delegate(bool granted,
						NSError error) {
						if (granted)
						{
							Contacts contacts_nav_controller = parentController.Storyboard.InstantiateViewController ("Contacts") as Contacts;
							parentController.NavigationController.PushViewController (contacts_nav_controller, true);
						}
					});

				}
				else
				{
					Contacts contacts_nav_controller = parentController.Storyboard.InstantiateViewController ("Contacts") as Contacts;
					parentController.NavigationController.PushViewController (contacts_nav_controller, true);
				}

			}

			else if (tableItems [indexPath.Row].getViewType() == MainNavViewType.PayBill)
			{
				PayBill bills_nav_controller = parentController.Storyboard.InstantiateViewController ("PayBill") as PayBill;
				parentController.NavigationController.PushViewController (bills_nav_controller, true);
			}
			tableView.DeselectRow (indexPath, true);


		}

		/// <summary>
		/// Called by the TableView to get the actual UITableViewCell to render for the particular row
		/// </summary>
		public override UITableViewCell GetCell (UITableView tableView, MonoTouch.Foundation.NSIndexPath indexPath)
		{
			// request a recycled cell to save memory
			MainNavControllerTableCell cell = tableView.DequeueReusableCell (cellIdentifier) as MainNavControllerTableCell;

			// if there are no cells to reuse, create a new one
			if (cell == null) {
				cell = new MainNavControllerTableCell (cellIdentifier);
			}

			cell.UpdateCell (tableItems [indexPath.Row].getHeading());

			return cell;
		}

		public string GetCellName (int rowIndex)
		{
			return tableItems [rowIndex].getHeading();
		}
	}
}

