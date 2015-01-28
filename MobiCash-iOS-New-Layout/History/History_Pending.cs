
using MonoTouch.UIKit;
using System;
using System.Collections.Generic;

namespace MobiCashiOSNewLayout
{
	partial class History_Pending : UITableViewController
	{
		private List<HistoryTableItem> pendingTableItems;
		private List<string> pendingTableItemsRecipentsNames;
		private List<string> pendingTableItemsAmounts;
		private List<HistoryViewType> pendingTableItemsTypes;
		private List<DateTime> pendingTableItemsTimeStamps;

		public override void ViewDidAppear (bool animated)
		{
			this.TabBarController.TabBar.Hidden = false;
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			loadViewSettings ();
			makePendingTableItemsRecipentsNamesReady ();
			makePendingTableItemsAmountsReady ();
			makePendingTableItemsTypesReady ();
			makePendingTableItemsTimeStampsReady ();
			makePendingTableItemsReady ();
			makePendingTableReady ();
		}

		public override void ViewWillDisappear (bool animated)
		{
			this.TabBarController.TabBar.Hidden = true;

		}
		public History_Pending (IntPtr handle) : base (handle)
		{
		}
		private void makePendingTableItemsRecipentsNamesReady()
		{
			pendingTableItemsRecipentsNames = new List<string> ();
			pendingTableItemsRecipentsNames.Add ("Borksha Zofolo");
			pendingTableItemsRecipentsNames.Add ("Konan Rafiqi");
			pendingTableItemsRecipentsNames.Add ("Lafeek Razoola");

		}

		private void makePendingTableItemsAmountsReady ()
		{
			pendingTableItemsAmounts = new List<string> ();
			pendingTableItemsAmounts.Add ("50 EGP");
			pendingTableItemsAmounts.Add ("150 EGP");
			pendingTableItemsAmounts.Add ("250 EGP");

		}

		private void makePendingTableItemsTypesReady()
		{
			pendingTableItemsTypes = new List<HistoryViewType> ();
			pendingTableItemsTypes.Add (HistoryViewType.Pending);
			pendingTableItemsTypes.Add (HistoryViewType.Pending);
			pendingTableItemsTypes.Add (HistoryViewType.Pending);
		}

		private void makePendingTableItemsTimeStampsReady()
		{
			pendingTableItemsTimeStamps = new List<DateTime> ();
			pendingTableItemsTimeStamps.Add ( new DateTime (2015, 5, 14, 14, 34, 43) );
			pendingTableItemsTimeStamps.Add ( new DateTime (2015, 5, 14, 14, 34, 43) );
			pendingTableItemsTimeStamps.Add ( new DateTime (2015, 5, 14, 14, 34, 43) );

		}

		private void makePendingTableItemsReady()
		{
			pendingTableItems = new List<HistoryTableItem> ();
			for (int i = 0; i < pendingTableItemsAmounts.Count; i++) 
			{
				pendingTableItems.Add (new HistoryTableItem (pendingTableItemsRecipentsNames [i], pendingTableItemsAmounts [i], pendingTableItemsTimeStamps [i], pendingTableItemsTypes [i]));
			}
		}

		private void makePendingTableReady ()
		{
			PendingTable = new UITableView(UIScreen.MainScreen.Bounds);
			PendingTable.Source = new HistoryTableSource (pendingTableItems, this);
			Add (PendingTable);
		}
	
		private void loadViewSettings ()
		{
			setSwipeLeftGesture ();
			setRightNavBarItem ();
			this.NavigationItem.SetHidesBackButton (true, false);
		}
		public void setSwipeLeftGesture()
		{

			UISwipeGestureRecognizer recognizer = new UISwipeGestureRecognizer (openMainNavController);
			recognizer.Direction = UISwipeGestureRecognizerDirection.Left;
			this.View.AddGestureRecognizer (recognizer);
		}

		public void setRightNavBarItem()
		{
			this.NavigationItem.SetRightBarButtonItem(
				new UIBarButtonItem(UIImage.FromFile("Images/MainNavDrawer/main_nav_drawer.png")
					, UIBarButtonItemStyle.Plain
					, (sender,args) => {
						openMainNavController();
					})
				, true);
		}
		public void openMainNavController()
		{
			MainNavController main_nav_controller = this.Storyboard.InstantiateViewController ("MainNavController") as MainNavController;
			this.NavigationController.PushViewController (main_nav_controller, true);
		}

	}
}
