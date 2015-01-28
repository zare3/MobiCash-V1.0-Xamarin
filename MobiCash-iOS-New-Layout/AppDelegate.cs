using System;
using System.Collections.Generic;
using System.Linq;

using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace MobiCashiOSNewLayout
{
	// The UIApplicationDelegate for the application. This class is responsible for launching the
	// User Interface of the application, as well as listening (and optionally responding) to
	// application events from iOS.
	[Register ("AppDelegate")]
	public partial class AppDelegate : UIApplicationDelegate
	{
		// class-level declarations

		//serivces
		private List<string> servicesTableItemsHeaders;
		private List<string> servicesTableItemsImages;
		private List<ServicesViewType> servicesTableItemsTypes;
		//recents
		private List<string> recentsNames;
		private List<string> recentsImgsAddresses;
		private List<string> recentsLastSent;
		private List<DateTime> recentsTimeStamps;
		private List<bool> recentsTransactionsWereMade;
		private List<string> recentsAmounts;
		private List<TransactionStatus> recentsTransactionStatuses;
		private List<bool> recentsIsTherePendingMessages;
		private List<string> recentsPendingMessagesCount;
		//history
		private List<string> AllTableItemsRecipentsNames;
		private List<string> AllTableItemsAmounts;
		private List<HistoryViewType> AllTableItemsTypes;
		private List<DateTime> AllTableItemsTimeStamps;
		SQLiteDatabase db;
		public override UIWindow Window {
			get;
			set;
		}
		
		// This method is invoked when the application is about to move from active to inactive state.
		// OpenGL applications should use this method to pause.
		public override void OnResignActivation (UIApplication application)
		{
		}
		
		// This method should be used to release shared resources and it should store the application state.
		// If your application supports background exection this method is called instead of WillTerminate
		// when the user quits.
		public override void DidEnterBackground (UIApplication application)
		{
		}
		
		// This method is called as part of the transiton from background to active state.
		public override void WillEnterForeground (UIApplication application)
		{
		}
		
		// This method is called when the application is about to terminate. Save data, if needed.
		public override void WillTerminate (UIApplication application)
		{
		}

		public override void FinishedLaunching (UIApplication application) {
			db = new SQLiteDatabase ();
			db.createDB ();
			var defaults = NSUserDefaults.StandardUserDefaults;
			const string key = "LaunchedBeforeKey";
			if (!defaults.BoolForKey(key)) {
				// First launch
				defaults.SetBool(true, key);
				defaults.Synchronize();

				makeServicesTableItemsTypesReady ();
				makeServicesTableItemsHeadersReady ();
				makeServicesTableItemsImagesReady();
				insertServicesIntoDatabase ();

				makeRecentsNamesReady ();
				makeRecentsImgsAddressesReady ();
				makeRecentsLastSentReady ();
				makeRecentsTimeStampsReady ();
				makeRecentsTransactionsWereMadeReady ();
				makeRecentsAmountsReady ();
				makeRecentsTransactionStatusesReady ();
				makeRecentsIsTherePendingMessagesReady ();
				makeRecentsPendingMessagesCountReady ();
				insertRecentsIntoDatabase ();

				makeAllTableItemsRecipentsNamesReady ();
				makeAllTableItemsTypesReady ();
				makeAllTableItemsAmountsReady ();
				makeAllTableItemsTimeStampsReady ();
				insertAllHistoryIntoDatabase ();
			}

				
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

		private void insertServicesIntoDatabase()
		{
			for (int i = 0; i < servicesTableItemsHeaders.Count; i++) 
			{
				db.insertService (servicesTableItemsHeaders [i], servicesTableItemsImages [i], 0, servicesTableItemsTypes [i]);
			}
		}

		private void makeRecentsNamesReady()
		{
			recentsNames = new List<string> ();
			recentsNames.Add ("Borkana Mazeelas asdsasdaksadklsadkjlasdjkladsjklasdkjlasdkjlkjlkjlsajkladkljads");
			recentsNames.Add ("Fagoola Shoomala dasdsaasdjlasdjlasjasdjkasjksajk");
			recentsNames.Add ("Fagoola Shoomala dasdsaasdjlasdjlasjasdjkasjksajk");
			recentsNames.Add ("Borkana Mazeelas asdsasdaksadklsadkjlasdjkladsjklasdkjlasdkjlkjlkjlsajkladkljads");
		}

		private void makeRecentsImgsAddressesReady()
		{
			recentsImgsAddresses = new List<string> ();
			recentsImgsAddresses.Add ("Images/Recents/dummy_recents_pic_1.png");
			recentsImgsAddresses.Add ("Images/Recents/dummy_recents_pic_2.png");
			recentsImgsAddresses.Add ("Images/Recents/dummy_recents_pic_2.png");
			recentsImgsAddresses.Add ("Images/Recents/dummy_recents_pic_1.png");
		}

		private void makeRecentsLastSentReady()
		{
			recentsLastSent = new List<string> ();
			recentsLastSent.Add ("some random text for testing purposes");
			recentsLastSent.Add ("here is a very long text i wonder law hayhayyes walla la2");
			recentsLastSent.Add ("here is a very long text i wonder law hayhayyes walla la2");
			recentsLastSent.Add ("some random text for testing purposes");
		}

		private void makeRecentsTimeStampsReady()
		{
			recentsTimeStamps = new List<DateTime>();
			//DateTime x = new DateTime (2015, 5, 14, 14, 34, 43);
			recentsTimeStamps.Add( new DateTime (2015, 5, 14, 14, 34, 43) );
			recentsTimeStamps.Add( new DateTime (2015, 4, 23, 22, 2, 23) );
			recentsTimeStamps.Add( new DateTime (2015, 4, 23, 22, 2, 23) );
			recentsTimeStamps.Add( new DateTime (2015, 5, 14, 14, 34, 43) );
		}

		private void makeRecentsTransactionsWereMadeReady()
		{
			recentsTransactionsWereMade = new List<bool>();
			recentsTransactionsWereMade.Add(true);
			recentsTransactionsWereMade.Add(false);
			recentsTransactionsWereMade.Add(true);
			recentsTransactionsWereMade.Add(true);
		}

		private void makeRecentsAmountsReady()
		{
			recentsAmounts = new List<string> ();
			recentsAmounts.Add("298 EGP");
			recentsAmounts.Add ("");
			recentsAmounts.Add("442 EGP");
			recentsAmounts.Add("290 EGP");

		}

		private void makeRecentsTransactionStatusesReady()
		{
			recentsTransactionStatuses = new List<TransactionStatus>();
			recentsTransactionStatuses.Add(TransactionStatus.Received);
			recentsTransactionStatuses.Add(TransactionStatus.NULL);
			recentsTransactionStatuses.Add(TransactionStatus.Pending);
			recentsTransactionStatuses.Add(TransactionStatus.Sent);

		}

		private void makeRecentsIsTherePendingMessagesReady()
		{
			recentsIsTherePendingMessages = new List<bool> ();
			recentsIsTherePendingMessages.Add (true);
			recentsIsTherePendingMessages.Add (true);
			recentsIsTherePendingMessages.Add (false);
			recentsIsTherePendingMessages.Add (false);
		}

		private void makeRecentsPendingMessagesCountReady()
		{
			recentsPendingMessagesCount = new List<string> ();
			recentsPendingMessagesCount.Add ("2");
			recentsPendingMessagesCount.Add ("1");
			recentsPendingMessagesCount.Add ("0");
			recentsPendingMessagesCount.Add ("0");

		}

		private void insertRecentsIntoDatabase()
		{
			for (int i=0; i<recentsNames.Count; i++)
				db.insertRecentConversation (recentsNames[i],recentsImgsAddresses[i],recentsTimeStamps[i],recentsLastSent[i],Convert.ToInt32(recentsTransactionsWereMade[i]),recentsTransactionStatuses[i],recentsAmounts[i],Convert.ToInt32(recentsIsTherePendingMessages[i]),recentsPendingMessagesCount[i]);
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
			AllTableItemsTimeStamps = new List<DateTime> ();
			AllTableItemsTimeStamps.Add ( new DateTime (2015, 5, 14, 14, 34, 43) );
			AllTableItemsTimeStamps.Add ( new DateTime (2015, 5, 14, 14, 34, 43) );
			AllTableItemsTimeStamps.Add ( new DateTime (2015, 5, 14, 14, 34, 43) );

			AllTableItemsTimeStamps.Add ( new DateTime (2015, 5, 14, 14, 34, 43) );
			AllTableItemsTimeStamps.Add ( new DateTime (2015, 5, 14, 14, 34, 43) );

			AllTableItemsTimeStamps.Add ( new DateTime (2015, 5, 14, 14, 34, 43) );

		}

		private void insertAllHistoryIntoDatabase()
		{
			for (int i=0; i<AllTableItemsRecipentsNames.Count; i++)
			{
				db.insertTransaction (AllTableItemsRecipentsNames [i], AllTableItemsAmounts [i], AllTableItemsTimeStamps [i], AllTableItemsTypes [i]);
			}
		}

	}
}

