using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;

namespace MobiCashiOSNewLayout
{
	partial class Recents : UITableViewController
	{


		private List<RecentsTableItem> recentsTableItems;
		private SQLiteDatabase db;

		public Recents (IntPtr handle) : base (handle)
		{
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			loadViewSettings ();
			makeRecentsTableItemsReady ();
			makeTableReady ();

		}


		public void loadViewSettings ()
		{
			this.NavigationItem.SetHidesBackButton (true, false);
			setSwipeLeftGesture ();
			setRightNavBarItem ();


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

	

		private void makeRecentsTableItemsReady()
		{
			db = new SQLiteDatabase ();
			recentsTableItems = db.getAllRecents ();
		}

		private void makeTableReady()
		{
			RecentsTable.Source = new RecentsTableSource (recentsTableItems, this);
		}


	}
}
