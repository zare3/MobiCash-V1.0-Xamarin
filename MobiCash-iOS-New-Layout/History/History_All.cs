using MonoTouch.UIKit;
using System;
using System.Collections.Generic;


namespace MobiCashiOSNewLayout
{
	partial class History_All : UITableViewController
	{

		private List<HistoryTableItem> AllTableItems;

		SQLiteDatabase db;

		public History_All (IntPtr handle) : base (handle)
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
			makeAllTableItemsReady ();
			makeAllTableReady ();
		}



		private void makeAllTableItemsReady()
		{
			db = new SQLiteDatabase ();
			AllTableItems = db.getAllTransactions ();
		}

		private void makeAllTableReady ()
		{
			AllTable = new UITableView(UIScreen.MainScreen.Bounds);
			AllTable.Source = new HistoryTableSource (AllTableItems, this);
			Add (AllTable);
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
