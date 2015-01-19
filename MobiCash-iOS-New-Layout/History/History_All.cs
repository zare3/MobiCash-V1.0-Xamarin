using MonoTouch.UIKit;
using System;
using System.Collections.Generic;


namespace MobiCashiOSNewLayout
{
	partial class History_All : UITableViewController
	{

		private List<HistoryTableItem> AllTableItems;
		private List<string> AllTableItemsRecipentsNames;
		private List<string> AllTableItemsAmounts;
		private List<HistoryViewType> AllTableItemsTypes;
		private List<string> AllTableItemsTimeStamps;
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
			makeAllTableItemsRecipentsNamesReady ();
			makeAllTableItemsAmountsReady ();
			makeAllTableItemsTypesReady ();
			makeAllTableItemsTimeStampsReady ();
			makeAllTableItemsReady ();
			makeAllTableReady ();
		}

		private void makeAllTableItemsRecipentsNamesReady()
		{
			AllTableItemsRecipentsNames = new List<string> ();
			AllTableItemsRecipentsNames.Add ("Borksha Zofolo");
			AllTableItemsRecipentsNames.Add ("Konan Rafiqi");
			AllTableItemsRecipentsNames.Add ("Lafeek Razoola");

			AllTableItemsRecipentsNames.Add ("Borksha Zofolo");
			AllTableItemsRecipentsNames.Add ("Konan Rafiqi");

			AllTableItemsRecipentsNames.Add ("Lafeek Razoola");

		}

		private void makeAllTableItemsAmountsReady ()
		{
			AllTableItemsAmounts = new List<string> ();
			AllTableItemsAmounts.Add ("50 EGP");
			AllTableItemsAmounts.Add ("150 EGP");
			AllTableItemsAmounts.Add ("250 EGP");

			AllTableItemsAmounts.Add ("50 EGP");
			AllTableItemsAmounts.Add ("150 EGP");

			AllTableItemsAmounts.Add ("250 EGP");

		}

		private void makeAllTableItemsTypesReady()
		{
			AllTableItemsTypes = new List<HistoryViewType> ();
			AllTableItemsTypes.Add (HistoryViewType.Pending);
			AllTableItemsTypes.Add (HistoryViewType.Pending);
			AllTableItemsTypes.Add (HistoryViewType.Pending);

			AllTableItemsTypes.Add (HistoryViewType.Sent);
			AllTableItemsTypes.Add (HistoryViewType.Sent);

			AllTableItemsTypes.Add (HistoryViewType.Received);
		}

		private void makeAllTableItemsTimeStampsReady()
		{
			AllTableItemsTimeStamps = new List<string> ();
			AllTableItemsTimeStamps.Add ("12/5/2014");
			AllTableItemsTimeStamps.Add ("22/2/2014");
			AllTableItemsTimeStamps.Add ("18/1/2014");

			AllTableItemsTimeStamps.Add ("12/5/2014");
			AllTableItemsTimeStamps.Add ("22/2/2014");

			AllTableItemsTimeStamps.Add ("18/1/2014");

		}

		private void makeAllTableItemsReady()
		{
			AllTableItems = new List<HistoryTableItem> ();
			for (int i = 0; i < AllTableItemsAmounts.Count; i++) 
			{
				AllTableItems.Add (new HistoryTableItem (AllTableItemsRecipentsNames [i], AllTableItemsAmounts [i], AllTableItemsTimeStamps [i], AllTableItemsTypes [i]));
			}
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
