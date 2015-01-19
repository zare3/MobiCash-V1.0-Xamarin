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
		private List<string> servicesTableItemsHeaders;
		private List<string> servicesTableItemsImages;
		private List<ServicesViewType> servicesTableItemsTypes;
	
		public Services (IntPtr handle) : base (handle)
		{
		}

		private void makeServicesTableItemsTypesReady()
		{
			servicesTableItemsTypes = new List<ServicesViewType> ();
			servicesTableItemsTypes.Add (ServicesViewType.InternetBill);
			servicesTableItemsTypes.Add (ServicesViewType.MobileBill);
		}
		private void makeServicesTableItemsHeadersReady ()
		{
			servicesTableItemsHeaders = new List<string> ();
			servicesTableItemsHeaders.Add ("Internet Bill");
			servicesTableItemsHeaders.Add ("Mobile Bill");
		}

		private void makeServicesTableItemsImagesReady()
		{
			servicesTableItemsImages = new List<string> ();
			servicesTableItemsImages.Add ("Images/Services/Table Icons/services_table_internet_bill.png");
			servicesTableItemsImages.Add ("Images/Services/Table Icons/services_table_mobile_bill.png");
		}

		private void createViewTable()
		{
			ServicesTable = new UITableView(UIScreen.MainScreen.Bounds);
			servicesTableItems = new List<ServicesTableItem> ();
			for (int i=0; i<servicesTableItemsHeaders.Count; i++)
				servicesTableItems.Add(new ServicesTableItem (servicesTableItemsHeaders[i],servicesTableItemsImages[i],servicesTableItemsTypes[i]) );

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

			/*this.NavigationItem.SetRightBarButtonItem(
				new UIBarButtonItem(UIBarButtonSystemItem.FastForward, (sender,args) => {
					openMainNavController();
				})
				, true);*/
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
			makeServicesTableItemsHeadersReady ();
			makeServicesTableItemsImagesReady ();
			makeServicesTableItemsTypesReady ();
			createViewTable ();

		}


	}
}
