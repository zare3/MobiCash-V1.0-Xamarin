using System;
using Mono.Data.Sqlite;
using System.Data;
using System.Collections.Generic;

namespace MobiCashiOSNewLayout

{
public class SQLiteDatabase
{
	public SQLiteDatabase ()
	{
	}
	/*Here we create the DB or verify if the DB Exists*/
	public void createDB(){
		/*I use this line to get the pat to the root of files of the phone and save that directory in "documents"*/
		var documents = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
		try{
			/*Check if the DB exists*/
			var connectionString = String.Format("Data Source={0};Version=3;",documents+"DatabaseMobiCash.db");
		}catch(Exception ex){
			/*If the DB nos exists, we create it*/
			SqliteConnection.CreateFile(documents+"//DatabaseMobiCash.db");
		}finally{
			/*Here we create the table*/
			/*I use this line to conenct to the file .db, The Physical DB
			It's like: USE Dtabase; in SQL
			*/
			var connectionString = String.Format("Data Source={0};Version=3;",documents+"DatabaseMobiCash.db");
			using (var conn= new SqliteConnection(connectionString))
			{
				/*This line open the connection to the DB*/
				conn.Open();
				using (var cmd = conn.CreateCommand())
				{
					
					cmd.CommandText = "CREATE TABLE IF NOT EXISTS SERVICES (serviceID INTEGER PRIMARY KEY AUTOINCREMENT " +
						", serviceName VARCHAR," +
						" serviceImage VARCHAR," +
						" serviceType SMALLINT," +
						" isDonation SMALLINT )";
					cmd.CommandType = CommandType.Text;
					cmd.ExecuteNonQuery();

					cmd.CommandText = "CREATE TABLE IF NOT EXISTS RECENTS" +
						" (recentID INTEGER PRIMARY KEY AUTOINCREMENT , " +
						"name VARCHAR," +
						" imageAddrs VARCHAR," +
						"timeStamp VARCHAR," +
						" lastMessage VARCHAR," +
						" wasThereATransactionMade SMALLINT," +
						" lastTransactionStatus SMALLINT," +
						" lastTransactionAmnt VARCHAR," +
						" isTherePendingMessages SMALLINT," +
						" pendingMessagesCount VARCHAR)";
					cmd.CommandType = CommandType.Text;
					cmd.ExecuteNonQuery();

					cmd.CommandText = "CREATE TABLE IF NOT EXISTS TRANSACTIONS" +
							" (recentID INTEGER PRIMARY KEY AUTOINCREMENT , " +
							"recipent VARCHAR," +
							" amount VARCHAR," +
							"timeStamp VARCHAR," +
							" historyViewType SMALLINT)" ;
					cmd.CommandType = CommandType.Text;
					cmd.ExecuteNonQuery();

					conn.Close();
				}
			}
		}
	}



		private int convertFromHistoryViewTypeToInt (HistoryViewType historyViewType)
		{
			if (historyViewType == HistoryViewType.Pending)
				return 1;
			else if (historyViewType == HistoryViewType.Received)
				return 2;
			else if (historyViewType == HistoryViewType.Sent)
				return 3;
			return -1;
		}

		private HistoryViewType convertFromIntToHistoryViewType (int historyViewType)
		{
			if (historyViewType == 1)
				return HistoryViewType.Pending;
			else if (historyViewType == 2)
				return HistoryViewType.Received;
			else if (historyViewType == 3)
				return HistoryViewType.Sent;
			return HistoryViewType.Sent;
		}

		private int convertFromTransactionStatusToInt (TransactionStatus transactionStatus)
		{
			if (transactionStatus == TransactionStatus.Pending)
				return 1;
			else if (transactionStatus == TransactionStatus.Received)
				return 2;
			else if (transactionStatus == TransactionStatus.Sent)
				return 3;
			else if (transactionStatus == TransactionStatus.NULL)
				return -1;
			return -2;
		}

		private TransactionStatus convertFromIntToTransactionStatus(int transactionStatus)
		{
			if (transactionStatus == 1)
				return TransactionStatus.Pending;
			else if (transactionStatus == 2)
				return TransactionStatus.Received;
			else if (transactionStatus == 3)
				return TransactionStatus.Sent;
			else if (transactionStatus == -1)
				return TransactionStatus.NULL;
			return TransactionStatus.NULL;
		}

		private int convertFromServicesViewTypeToInt (ServicesViewType servicesViewType)
		{
			if (servicesViewType == ServicesViewType.InternetBill)
				return 1;
			else if (servicesViewType == ServicesViewType.MobileBill)
				return 2;
			return -1;
		}

		private ServicesViewType convertFromIntToServicesViewType (int servicesViewType)
		{
			if (servicesViewType == 1)
				return ServicesViewType.InternetBill;
			else if (servicesViewType == 2)
				return ServicesViewType.MobileBill;
			return ServicesViewType.MobileBill;
		}



		public void insertService(string serviceName, string serviceImage, int isDonation, ServicesViewType servicesViewType){
		var documents = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
		var connectionString = String.Format("Data Source={0};Version=3;", documents+"DatabaseMobiCash.db");
		using (var conn= new SqliteConnection(connectionString))
		{
			conn.Open();
			using (var cmd = conn.CreateCommand())
			{
				/*Here we insert the values into the DB*/
					int integerType = convertFromServicesViewTypeToInt (servicesViewType);
					cmd.CommandText = "INSERT INTO SERVICES (serviceName, serviceImage, serviceType, isDonation ) " +
						"VALUES('"+serviceName+"','"+serviceImage+"','"+integerType+"','"+isDonation+"')";
				cmd.CommandType = CommandType.Text;
				cmd.ExecuteNonQuery();
				conn.Close();
			}
		}
	}

		public void insertRecentConversation(string name, string imgAddrs, DateTime timeStamp, string  lastMessage, int wasThereTransactionMade, TransactionStatus transactionStatus, string transactionAmount, int isTherePendingMessages, string pendingMessagesCount ){
			var documents = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
			var connectionString = String.Format("Data Source={0};Version=3;", documents+"DatabaseMobiCash.db");
			using (var conn= new SqliteConnection(connectionString))
			{
				conn.Open();
				using (var cmd = conn.CreateCommand())
				{
					/*Here we insert the values into the DB*/
					int integerTransactionStatus = convertFromTransactionStatusToInt (transactionStatus);
					cmd.CommandText = "INSERT INTO RECENTS (name, imageAddrs, timeStamp, lastMessage, wasThereATransactionMade, lastTransactionStatus, lastTransactionAmnt, isTherePendingMessages, pendingMessagesCount   ) " +
						"VALUES('"+name+"','"+imgAddrs+
						"','"+timeStamp.ToString()+"','"+lastMessage+
						"','"+wasThereTransactionMade+"','"+integerTransactionStatus+
						"','"+transactionAmount+"','"+isTherePendingMessages+"','"+pendingMessagesCount+"')";
					cmd.CommandType = CommandType.Text;
					cmd.ExecuteNonQuery();
					conn.Close();
				}
			}
		}


		public void insertTransaction(string recipentName, string amount, DateTime timeStamp, HistoryViewType historyViewType ){
			var documents = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
			var connectionString = String.Format("Data Source={0};Version=3;", documents+"DatabaseMobiCash.db");
			using (var conn= new SqliteConnection(connectionString))
			{
				conn.Open();
				using (var cmd = conn.CreateCommand())
				{
					/*Here we insert the values into the DB*/
					int integerHistoryViewType = convertFromHistoryViewTypeToInt(historyViewType);
					cmd.CommandText = "INSERT INTO TRANSACTIONS (recipent, amount, timeStamp, historyViewType) " +
						"VALUES('"+recipentName+"','"+amount+
						"','"+timeStamp.ToString()+
						"','"+integerHistoryViewType+"')";
					cmd.CommandType = CommandType.Text;
					cmd.ExecuteNonQuery();
					conn.Close();
				}
			}
		}
			

		public List<HistoryTableItem> getAllPendingTransactions(){
			var documents = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
			var connectionString = String.Format("Data Source={0};Version=3;", documents+"DatabaseMobiCash.db");
			using (var conn= new SqliteConnection(connectionString))
			{
				conn.Open();

				using (var cmd = conn.CreateCommand())
				{
					/*This line is used to select all the items of the DB*/
					cmd.CommandText = "SELECT * FROM TRANSACTIONS WHERE historyViewType = '1' ";
					cmd.CommandType = CommandType.Text;
					/*I use the ExecuteReader() to get an array of all the records in my DB*/
					SqliteDataReader reader=cmd.ExecuteReader();
					List<HistoryTableItem> pendingTableItems = new List<HistoryTableItem> ();
					/*I use this loop to get all the records*/
					while(reader.Read()){
						/*I use the function GetValue(n), to get the especific record due to the array that I get before
                          we can see I select the position 1 and 2,.. due to I have the ID and its position is 0 due to
                          the order of the Table 
                         */
						string recipent =""+reader.GetValue(1);
						string amount = ""+reader.GetValue(2);
						DateTime timeStamp = Convert.ToDateTime ("" + reader.GetValue (3));
						HistoryViewType historyViewType = convertFromIntToHistoryViewType (int.Parse ( ("" + reader.GetValue (4) ) ) );

						pendingTableItems.Add (new HistoryTableItem (recipent, amount, timeStamp,historyViewType));
					}
					conn.Close();
					return pendingTableItems;
				}
			}
		}


		public List<HistoryTableItem> getAllReceivedTransactions(){
			var documents = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
			var connectionString = String.Format("Data Source={0};Version=3;", documents+"DatabaseMobiCash.db");
			using (var conn= new SqliteConnection(connectionString))
			{
				conn.Open();

				using (var cmd = conn.CreateCommand())
				{
					/*This line is used to select all the items of the DB*/
					cmd.CommandText = "SELECT * FROM TRANSACTIONS WHERE historyViewType = '2' ";
					cmd.CommandType = CommandType.Text;
					/*I use the ExecuteReader() to get an array of all the records in my DB*/
					SqliteDataReader reader=cmd.ExecuteReader();
					List<HistoryTableItem> reveivedTableItems = new List<HistoryTableItem> ();
					/*I use this loop to get all the records*/
					while(reader.Read()){
						/*I use the function GetValue(n), to get the especific record due to the array that I get before
                          we can see I select the position 1 and 2,.. due to I have the ID and its position is 0 due to
                          the order of the Table 
                         */
						string recipent =""+reader.GetValue(1);
						string amount = ""+reader.GetValue(2);
						DateTime timeStamp = Convert.ToDateTime ("" + reader.GetValue (3));
						HistoryViewType historyViewType = convertFromIntToHistoryViewType (int.Parse ( ("" + reader.GetValue (4) ) ) );

						reveivedTableItems.Add (new HistoryTableItem (recipent, amount, timeStamp,historyViewType));
					}
					conn.Close();
					return reveivedTableItems;
				}
			}
		}

		public List<HistoryTableItem> getAllSentTransactions(){
			var documents = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
			var connectionString = String.Format("Data Source={0};Version=3;", documents+"DatabaseMobiCash.db");
			using (var conn= new SqliteConnection(connectionString))
			{
				conn.Open();

				using (var cmd = conn.CreateCommand())
				{
					/*This line is used to select all the items of the DB*/
					cmd.CommandText = "SELECT * FROM TRANSACTIONS WHERE historyViewType = '3' ";
					cmd.CommandType = CommandType.Text;
					/*I use the ExecuteReader() to get an array of all the records in my DB*/
					SqliteDataReader reader=cmd.ExecuteReader();
					List<HistoryTableItem> sentTableItems = new List<HistoryTableItem> ();
					/*I use this loop to get all the records*/
					while(reader.Read()){
						/*I use the function GetValue(n), to get the especific record due to the array that I get before
                          we can see I select the position 1 and 2,.. due to I have the ID and its position is 0 due to
                          the order of the Table 
                         */
						string recipent =""+reader.GetValue(1);
						string amount = ""+reader.GetValue(2);
						DateTime timeStamp = Convert.ToDateTime ("" + reader.GetValue (3));
						HistoryViewType historyViewType = convertFromIntToHistoryViewType (int.Parse ( ("" + reader.GetValue (4) ) ) );

						sentTableItems.Add (new HistoryTableItem (recipent, amount, timeStamp,historyViewType));
					}
					conn.Close();
					return sentTableItems;
				}
			}
		}



		public List<HistoryTableItem> getAllTransactions(){
			var documents = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
			var connectionString = String.Format("Data Source={0};Version=3;", documents+"DatabaseMobiCash.db");
			using (var conn= new SqliteConnection(connectionString))
			{
				conn.Open();

				using (var cmd = conn.CreateCommand())
				{
					/*This line is used to select all the items of the DB*/
					cmd.CommandText = "SELECT * FROM TRANSACTIONS";
					cmd.CommandType = CommandType.Text;
					/*I use the ExecuteReader() to get an array of all the records in my DB*/
					SqliteDataReader reader=cmd.ExecuteReader();
					List<HistoryTableItem> allTableItems = new List<HistoryTableItem> ();
					/*I use this loop to get all the records*/
					while(reader.Read()){
						/*I use the function GetValue(n), to get the especific record due to the array that I get before
                          we can see I select the position 1 and 2,.. due to I have the ID and its position is 0 due to
                          the order of the Table 
                         */
						string recipent =""+reader.GetValue(1);
						string amount = ""+reader.GetValue(2);
						DateTime timeStamp = Convert.ToDateTime ("" + reader.GetValue (3));
						HistoryViewType historyViewType = convertFromIntToHistoryViewType (int.Parse ( ("" + reader.GetValue (4) ) ) );

						allTableItems.Add (new HistoryTableItem (recipent, amount, timeStamp,historyViewType));
					}
					conn.Close();
					return allTableItems;
				}
			}
		}
			
		public List<ServicesTableItem> getAllServices(){
		var documents = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
		var connectionString = String.Format("Data Source={0};Version=3;", documents+"DatabaseMobiCash.db");
		using (var conn= new SqliteConnection(connectionString))
		{
			conn.Open();
	
			using (var cmd = conn.CreateCommand())
			{
				/*This line is used to select all the items of the DB*/
				cmd.CommandText = "SELECT * FROM SERVICES";
				cmd.CommandType = CommandType.Text;
				/*I use the ExecuteReader() to get an array of all the records in my DB*/
				SqliteDataReader reader=cmd.ExecuteReader();
				List<ServicesTableItem> servicesTableItems = new List<ServicesTableItem> ();
				/*I use this loop to get all the records*/
				while(reader.Read()){
					/*I use the function GetValue(n), to get the especific record due to the array that I get before
                          we can see I select the position 1 and 2,.. due to I have the ID and its position is 0 due to
                          the order of the Table 
                         */
						string name =""+reader.GetValue(1);
						string imageAddr = ""+reader.GetValue(2);
						ServicesViewType serviceType = convertFromIntToServicesViewType(int.Parse(""+reader.GetValue(3)));
						int isDonation = int.Parse(""+reader.GetValue(4));

						servicesTableItems.Add (new ServicesTableItem (name, imageAddr, serviceType));
				}
				conn.Close();
					return servicesTableItems;
			}
		}
	}
			
		public List<RecentsTableItem> getAllRecents(){
			var documents = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
			var connectionString = String.Format("Data Source={0};Version=3;", documents+"DatabaseMobiCash.db");
			using (var conn= new SqliteConnection(connectionString))
			{
				conn.Open();

				using (var cmd = conn.CreateCommand())
				{
					/*This line is used to select all the items of the DB*/
					cmd.CommandText = "SELECT * FROM RECENTS";
					cmd.CommandType = CommandType.Text;

					SqliteDataReader reader=cmd.ExecuteReader();
					List<RecentsTableItem> recentsTableItems = new List<RecentsTableItem> ();
					/*I use this loop to get all the records*/
					while(reader.Read()){
						/*I use the function GetValue(n), to get the especific record due to the array that I get before
                          we can see I select the position 1 and 2,.. due to I have the ID and its position is 0 due to
                          the order of the Table 
                         */
						string name =""+reader.GetValue(1);
						string imageAddr = ""+reader.GetValue(2);
						DateTime timeStamp = Convert.ToDateTime ("" + reader.GetValue (3));
						string lastMessage = ""+reader.GetValue(4);
						int wasThereATransactionMade = int.Parse(""+reader.GetValue(5));
						TransactionStatus lastTransactionStatus = convertFromIntToTransactionStatus(int.Parse(""+reader.GetValue(6)));
						string lastTransactionAmount = ""+reader.GetValue(7);
						int isTherePendingMessages = int.Parse(""+reader.GetValue(8));
						string pendingMessagesCount = ""+reader.GetValue(9);

						recentsTableItems.Add (new RecentsTableItem (name, imageAddr, timeStamp, lastMessage,
							Convert.ToBoolean(wasThereATransactionMade), lastTransactionStatus, lastTransactionAmount, Convert.ToBoolean(isTherePendingMessages), pendingMessagesCount));
					}
					conn.Close();
					return recentsTableItems;
				}
			}
		}



}
}