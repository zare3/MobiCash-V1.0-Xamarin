using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System;
using System.CodeDom.Compiler;
using System.Drawing;
using System.Collections.Generic;

namespace MobiCashiOSNewLayout
{
	partial class MainNavController : UITableViewController
	{
		private List<MainNavControllerTableItem> mainNavControllerItems;
		private List<MainNavViewType> viewTypes ;
		private List<String> mainNavControllerItemsNames;
		public MainNavController (IntPtr handle) : base (handle)
		{
		}


		private void makeViewTypesListReady()
		{
			viewTypes = new List<MainNavViewType> ();

			viewTypes.Add (MainNavViewType.Profile);
			viewTypes.Add (MainNavViewType.Transfer);
			viewTypes.Add (MainNavViewType.Request);
			viewTypes.Add (MainNavViewType.Services);
			viewTypes.Add (MainNavViewType.PayBill);
			viewTypes.Add (MainNavViewType.Recharge);
			viewTypes.Add (MainNavViewType.Recents);
			viewTypes.Add (MainNavViewType.Donations);
			viewTypes.Add (MainNavViewType.Contacts);
			viewTypes.Add (MainNavViewType.History);

		}

		private void makeViewNamesListReady()
		{


			mainNavControllerItemsNames = new List<String> ();

			mainNavControllerItemsNames.Add ("Profile");
			mainNavControllerItemsNames.Add ("Make a transfer");
			mainNavControllerItemsNames.Add ("Make a request");
			mainNavControllerItemsNames.Add ("My Services");
			mainNavControllerItemsNames.Add ("Bills");
			mainNavControllerItemsNames.Add ("Recharge");
			mainNavControllerItemsNames.Add ("Recents");
			mainNavControllerItemsNames.Add ("Donations");
			mainNavControllerItemsNames.Add ("Contacts");
			mainNavControllerItemsNames.Add ("History");

		}

		private void createViewTable()
		{
			mainNavControllerTable = new UITableView(UIScreen.MainScreen.Bounds);
			mainNavControllerItems = new List<MainNavControllerTableItem> ();
			for (int i=0; i<mainNavControllerItemsNames.Count; i++)
				mainNavControllerItems.Add(new MainNavControllerTableItem (mainNavControllerItemsNames[i],viewTypes[i]) );

			mainNavControllerTable.Source = new MainNavControllerTableSource (mainNavControllerItems,this);
			Add (mainNavControllerTable);

		}

		public void loadViewSettings ()
		{
			this.NavigationItem.SetHidesBackButton (true, false);
		}
		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			loadViewSettings ();
			makeViewTypesListReady ();
			makeViewNamesListReady ();
			createViewTable ();
		}

	
	}
}
