using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.Drawing;

namespace MobiCashiOSNewLayout
{
	public class RecentsTableCell: UITableViewCell
	{
		UILabel nameLabel;
		UIImageView profileImgView;
		UIImageView maskImgView;
		UIImageView counterImageView;
		UILabel pendingMessagesCountLabel;
		//UIImage.FromFile(tableItems[indexPath.Row].getImageAddress())
		UILabel lastMsgLabel;
		UILabel lastTransactionStatusLabel;
		UILabel lastTransactionAmntLabel;
		UILabel timeStampLabel;
		bool isTherePendingMessages;




		public RecentsTableCell (NSString cellId) : base (UITableViewCellStyle.Default, cellId)
		{
			SelectionStyle = UITableViewCellSelectionStyle.Gray;

			ContentView.BackgroundColor = UIColor.FromRGB (255, 255, 255);

			nameLabel = new UILabel () {
				Font = UIFont.FromName("Helvetica", 14f),
				TextColor = UIColor.FromRGB (0, 0, 0),
				BackgroundColor = UIColor.Clear
			};

			profileImgView = new UIImageView();
			maskImgView = new UIImageView ();
			counterImageView = new UIImageView ();

			lastMsgLabel = new UILabel () {
				Font = UIFont.FromName("Helvetica", 9f),
				TextColor = UIColor.FromRGB (0, 0, 0),
				BackgroundColor = UIColor.Clear
			};

			lastTransactionStatusLabel = new UILabel () {
				Font = UIFont.FromName("Helvetica", 9f),
				TextColor = UIColor.FromRGB (0, 0, 0),
				BackgroundColor = UIColor.Clear
			};

			lastTransactionAmntLabel = new UILabel () {
				Font = UIFont.FromName("Helvetica", 9f),
				TextColor = UIColor.FromRGB (0, 0, 0),
				BackgroundColor = UIColor.Clear
			};

			timeStampLabel = new UILabel () {
				Font = UIFont.FromName("Helvetica", 9f),
				TextColor = UIColor.FromRGB (0, 0, 0),
				BackgroundColor = UIColor.Clear
			};

			pendingMessagesCountLabel = new UILabel () {
				Font = UIFont.FromName("Helvetica", 11f),
				TextColor = UIColor.FromRGB (255, 255, 255),
				BackgroundColor = UIColor.Clear
			};

			ContentView.Add (nameLabel);
			ContentView.Add (profileImgView);
			ContentView.Add (maskImgView);
			ContentView.Add (lastMsgLabel);
			ContentView.Add (lastTransactionStatusLabel);
			ContentView.Add (lastTransactionAmntLabel);
			ContentView.Add (timeStampLabel);
			ContentView.Add (counterImageView);
			ContentView.Add (pendingMessagesCountLabel);


		}

		public void UpdateCell (string name, UIImage profileImg, string lastMsg, string lastTransactionStatusString, TransactionStatus lastTransactionStatus,  string lastTransactionAmnt, string timeStamp, bool isTherePendingMessages, string pendingMessagesCount )
		{
			nameLabel.Text = name;
			profileImgView.Image = profileImg;
			maskImgView.Image = UIImage.FromFile ("Images/Recents/recents_pic_mask.png");
			counterImageView.Image = UIImage.FromFile ("Images/Recents/recents_counter_img.png");
			lastMsgLabel.Text = lastMsg;
			lastTransactionStatusLabel.Text = lastTransactionStatusString;
			lastTransactionAmntLabel.Text = lastTransactionAmnt;
			timeStampLabel.Text = timeStamp;
			pendingMessagesCountLabel.Text = pendingMessagesCount;
			this.isTherePendingMessages = isTherePendingMessages;
			if (this.isTherePendingMessages == false) 
			{
				pendingMessagesCountLabel.Hidden = true;
				counterImageView.Hidden = true;
			}


			if (lastTransactionStatus == TransactionStatus.Pending) {
				lastTransactionStatusLabel.TextColor = UIColor.FromRGB (14, 43, 216);
				lastTransactionAmntLabel.TextColor = UIColor.FromRGB (14, 43, 216);
			} else if (lastTransactionStatus == TransactionStatus.Sent) {
				lastTransactionStatusLabel.TextColor = UIColor.FromRGB (226, 39, 14);
				lastTransactionAmntLabel.TextColor = UIColor.FromRGB (226, 39, 14);
			}else if (lastTransactionStatus == TransactionStatus.Received) {
				lastTransactionStatusLabel.TextColor = UIColor.FromRGB (12, 244, 18);
				lastTransactionAmntLabel.TextColor = UIColor.FromRGB (12, 244, 18);
			}

		}

		public override void LayoutSubviews ()
		{
			base.LayoutSubviews ();
			nameLabel.Frame = new RectangleF(75, 11, ContentView.Bounds.Width - 200, 25);
			profileImgView.Frame = new RectangleF(ContentView.Bounds.Width - 315, 2, 60, 60);
			maskImgView.Frame = new RectangleF(ContentView.Bounds.Width - 315, 2, 60, 60);
			counterImageView.Frame = new RectangleF(75, 36, 15, 15);
			pendingMessagesCountLabel.Frame = new RectangleF(79, 36, 15, 15);
			lastTransactionStatusLabel.Frame = new RectangleF(205, 30, ContentView.Bounds.Width -30, 25);
			lastTransactionAmntLabel.Frame = new RectangleF(267, 30, ContentView.Bounds.Width -30, 25);
			timeStampLabel.Frame = new RectangleF(205, 11, ContentView.Bounds.Width - 30, 25);

			if (this.isTherePendingMessages == false) {
				lastMsgLabel.Frame = new RectangleF (75, 30, ContentView.Bounds.Width - 220, 25);
			}
			else{
				lastMsgLabel.Frame = new RectangleF (93, 30, ContentView.Bounds.Width - 220, 25);
			}


		}
	}
}

