using MonoTouch.UIKit;
using System;
using System.Collections.Generic;

namespace MobiCashiOSNewLayout
{
	partial class History_Sent : UITableViewController
	{
		private List<HistoryTableItem> SentTableItems;
		private List<string> SentTableItemsRecipentsNames;
		private List<string> SentTableItemsAmounts;
		private List<HistoryViewType> SentTableItemsTypes;
		private List<DateTime> SentTableItemsTimeStamps;
		public History_Sent (IntPtr handle) : base (handle)
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
			makeSentTableItemsRecipentsNamesReady ();
			makeSentTableItemsAmountsReady ();
			makeSentTableItemsTypesReady ();
			makeSentTableItemsTimeStampsReady ();
			makeSentTableItemsReady ();
			makeSentTableReady ();
		}

		private void makeSentTableItemsRecipentsNamesReady()
		{
			SentTableItemsRecipentsNames = new List<string> ();
			SentTableItemsRecipentsNames.Add ("Borksha Zofolo");
			SentTableItemsRecipentsNames.Add ("Konan Rafiqi");
			SentTableItemsRecipentsNames.Add ("Lafeek Razoola");

			SentTableItemsRecipentsNames.Add ("Borksha Zofolo");
			SentTableItemsRecipentsNames.Add ("Konan Rafiqi");

			SentTableItemsRecipentsNames.Add ("Lafeek Razoola");

		}

		private void makeSentTableItemsAmountsReady ()
		{
			SentTableItemsAmounts = new List<string> ();

			SentTableItemsAmounts.Add ("50 EGP");
			SentTableItemsAmounts.Add ("150 EGP");

		}

		private void makeSentTableItemsTypesReady()
		{
			SentTableItemsTypes = new List<HistoryViewType> ();
			SentTableItemsTypes.Add (HistoryViewType.Sent);
			SentTableItemsTypes.Add (HistoryViewType.Sent);
		}

		private void makeSentTableItemsTimeStampsReady()
		{
			SentTableItemsTimeStamps = new List<DateTime> ();

			SentTableItemsTimeStamps.Add ( new DateTime (2015, 5, 14, 14, 34, 43) );
			SentTableItemsTimeStamps.Add ( new DateTime (2015, 5, 14, 14, 34, 43) );

		}

		private void makeSentTableItemsReady()
		{
			SentTableItems = new List<HistoryTableItem> ();
			for (int i = 0; i < SentTableItemsAmounts.Count; i++) 
			{
				SentTableItems.Add (new HistoryTableItem (SentTableItemsRecipentsNames [i], SentTableItemsAmounts [i], SentTableItemsTimeStamps [i], SentTableItemsTypes [i]));
			}
		}

		private void makeSentTableReady ()
		{
			SentTable = new UITableView(UIScreen.MainScreen.Bounds);
			SentTable.Source = new HistoryTableSource (SentTableItems, this);
			Add (SentTable);
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
