using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.Drawing;
namespace MobiCashiOSNewLayout
{
	public class BillTableCell: UITableViewCell
	{
		UILabel amountLabel;
		UILabel issueDateLabel;
		UILabel dueDateLabel;
	

		public BillTableCell (NSString cellId) : base (UITableViewCellStyle.Default, cellId)
		{
			SelectionStyle = UITableViewCellSelectionStyle.Gray;

			ContentView.BackgroundColor = UIColor.FromRGB (255, 255, 255);

			amountLabel = new UILabel () {
				Font = UIFont.FromName("Helvetica", 15f),
				TextColor = UIColor.FromRGB (173, 172, 172),
				BackgroundColor = UIColor.Clear
			};

			issueDateLabel = new UILabel () {
				Font = UIFont.FromName("Helvetica", 15f),
				TextColor = UIColor.FromRGB (173, 172, 172),
				BackgroundColor = UIColor.Clear
			};
			dueDateLabel = new UILabel () {
				Font = UIFont.FromName("Helvetica", 15f),
				TextColor = UIColor.FromRGB (173, 172, 172),
				BackgroundColor = UIColor.Clear
			};

			ContentView.Add (amountLabel);
			ContentView.Add (issueDateLabel);
			ContentView.Add (dueDateLabel);

		}

		public void UpdateCell (string amount, string issueDate, string dueDate, bool isSettled)
		{
			amountLabel.Text = amount;
			issueDateLabel.Text = issueDate;
			dueDateLabel.Text = dueDate;
			if (isSettled == true) 
			{
				amountLabel.TextColor = UIColor.FromRGB (51, 196, 10);
				issueDateLabel.TextColor = UIColor.FromRGB (51, 196, 10);
				dueDateLabel.TextColor = UIColor.FromRGB (51, 196, 10);
			}

		}

		public override void LayoutSubviews ()
		{
			base.LayoutSubviews ();
			amountLabel.Frame = new RectangleF(30, 8, ContentView.Bounds.Width - 30, 25);
			issueDateLabel.Frame = new RectangleF(100, 8, ContentView.Bounds.Width - 30, 25);
			dueDateLabel.Frame = new RectangleF(185, 8, ContentView.Bounds.Width - 30, 25);

		}
	}
}

