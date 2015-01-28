using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System;
using System.CodeDom.Compiler;
using System.Drawing;
using System.Collections.Generic;

namespace MobiCashiOSNewLayout
{
	partial class Services : UITableViewController
	{
		private List<ServicesTableItem> servicesTableItems;
		private SQLiteDatabase db;
	
		public Services (IntPtr handle) : base (handle)
		{
		}


		private void createViewTable()
		{
			ServicesTable = new UITableView(UIScreen.MainScreen.Bounds);
			db = new SQLiteDatabase ();
			servicesTableItems = db.getAllServices ();
			ServicesTable.Source = new ServicesTableSource (servicesTableItems,this);
			Add (ServicesTable);

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

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			loadViewSettings ();
			createViewTable ();

		}


	}
}
