using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.Drawing;
using System;

namespace MobiCashiOSNewLayout
{
	public class HistoryTableCell: UITableViewCell
	{
		UILabel recipentLabel;
		UILabel typeLabel;
		UILabel amountLabel;
		UILabel timeStampLabel;



		public HistoryTableCell (NSString cellId) : base (UITableViewCellStyle.Default, cellId)
		{
			SelectionStyle = UITableViewCellSelectionStyle.Gray;

			ContentView.BackgroundColor = UIColor.FromRGB (255, 255, 255);

			recipentLabel = new UILabel () {
				Font = UIFont.FromName("Helvetica", 17f),
				TextColor = UIColor.FromRGB (0, 0, 0),
				BackgroundColor = UIColor.Clear
			};

			typeLabel = new UILabel () {
				Font = UIFont.FromName("Helvetica", 12f),
				TextColor = UIColor.FromRGB (0, 0, 0),
				BackgroundColor = UIColor.Clear
			};

			amountLabel = new UILabel () {
				Font = UIFont.FromName("Helvetica", 17f),
				TextColor = UIColor.FromRGB (0, 0, 0),
				BackgroundColor = UIColor.Clear
			};

			timeStampLabel = new UILabel () {
				Font = UIFont.FromName("Helvetica", 12f),
				TextColor = UIColor.FromRGB (0, 0, 0),
				BackgroundColor = UIColor.Clear
			};


			ContentView.Add (recipentLabel);
			ContentView.Add (typeLabel);
			ContentView.Add (amountLabel);
			ContentView.Add (timeStampLabel);

		}

		public void UpdateCell (string recipent, string type, string amount, DateTime timeStamp, HistoryViewType historyViewType)
		{
			recipentLabel.Text = recipent;
			typeLabel.Text = type;
			amountLabel.Text = amount;
			timeStampLabel.Text = timeStamp.ToString ();
			if (historyViewType == HistoryViewType.Pending)
				typeLabel.TextColor = UIColor.FromRGB (14, 43, 216);
			else if (historyViewType == HistoryViewType.Sent)
				typeLabel.TextColor = UIColor.FromRGB (226, 39, 14);
			if (historyViewType == HistoryViewType.Received)
				typeLabel.TextColor = UIColor.FromRGB (12, 244, 18);

		}

		public override void LayoutSubviews ()
		{
			base.LayoutSubviews ();
			recipentLabel.Frame = new RectangleF(30, 1, ContentView.Bounds.Width - 30, 25);
			timeStampLabel.Frame = new RectangleF(190, 20, ContentView.Bounds.Width -30, 25);

			typeLabel.Frame = new RectangleF(30, 20, ContentView.Bounds.Width - 30, 25);
			amountLabel.Frame = new RectangleF(235, 1, ContentView.Bounds.Width - 30, 25);


		}
	}
}

