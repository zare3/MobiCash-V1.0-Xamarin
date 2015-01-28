using MonoTouch.UIKit;
using System;
using System.Collections.Generic;

namespace MobiCashiOSNewLayout
{
	partial class History_Received : UITableViewController
	{
		private List<HistoryTableItem> ReceivedTableItems;
		private List<string> ReceivedTableItemsRecipentsNames;
		private List<string> ReceivedTableItemsAmounts;
		private List<HistoryViewType> ReceivedTableItemsTypes;
		private List<DateTime> ReceivedTableItemsTimeStamps;
		public History_Received (IntPtr handle) : base (handle)
		{
		}

		public override void ViewDidAppear (bool animated)
		{
			this.TabBarController.TabBar.Hidden = false;
		}

		public override void ViewWillDisappear (bool animated)
		{
			this.TabBarController.TabBar.Hidden = true;

		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			loadViewSettings ();
			makeReceivedTableItemsRecipentsNamesReady ();
			makeReceivedTableItemsAmountsReady ();
			makeReceivedTableItemsTypesReady ();
			makeReceivedTableItemsTimeStampsReady ();
			makeReceivedTableItemsReady ();
			makeReceivedTableReady ();
		}

		private void makeReceivedTableItemsRecipentsNamesReady()
		{
			ReceivedTableItemsRecipentsNames = new List<string> ();

			ReceivedTableItemsRecipentsNames.Add ("Lafeek Razoola");

		}

		private void makeReceivedTableItemsAmountsReady ()
		{
			ReceivedTableItemsAmounts = new List<string> ();
			ReceivedTableItemsAmounts.Add ("250 EGP");

		}

		private void makeReceivedTableItemsTypesReady()
		{
			ReceivedTableItemsTypes = new List<HistoryViewType> ();
			ReceivedTableItemsTypes.Add (HistoryViewType.Received);
		}

		private void makeReceivedTableItemsTimeStampsReady()
		{
			ReceivedTableItemsTimeStamps = new List<DateTime> ();
			ReceivedTableItemsTimeStamps.Add ( new DateTime (2015, 1, 27, 14, 34, 43) );
			ReceivedTableItemsTimeStamps.Add ( new DateTime (2015, 5, 14, 14, 34, 43) );
			ReceivedTableItemsTimeStamps.Add ( new DateTime (2015, 5, 14, 14, 34, 43) );

			ReceivedTableItemsTimeStamps.Add ( new DateTime (2015, 5, 14, 14, 34, 43) );
			ReceivedTableItemsTimeStamps.Add ( new DateTime (2015, 5, 14, 14, 34, 43) );

			ReceivedTableItemsTimeStamps.Add ( new DateTime (2015, 5, 14, 14, 34, 43) );

		}

		private void makeReceivedTableItemsReady()
		{
			ReceivedTableItems = new List<HistoryTableItem> ();
			for (int i = 0; i < ReceivedTableItemsAmounts.Count; i++) 
			{
				ReceivedTableItems.Add (new HistoryTableItem (ReceivedTableItemsRecipentsNames [i], ReceivedTableItemsAmounts [i], ReceivedTableItemsTimeStamps [i], ReceivedTableItemsTypes [i]));
			}
		}

		private void makeReceivedTableReady ()
		{
			ReceivedTable = new UITableView(UIScreen.MainScreen.Bounds);
			ReceivedTable.Source = new HistoryTableSource (ReceivedTableItems, this);
			Add (ReceivedTable);
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
