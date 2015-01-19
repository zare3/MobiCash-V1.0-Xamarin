using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.Drawing;
namespace MobiCashiOSNewLayout
{
	public class RechargeTableCell: UITableViewCell
	{
		UILabel amountLabel;
		UIButton btn;
		public RechargeTableCell (NSString cellId) : base (UITableViewCellStyle.Default, cellId)
		{
			SelectionStyle = UITableViewCellSelectionStyle.Gray;

			ContentView.BackgroundColor = UIColor.FromRGB (255, 255, 255);

			amountLabel = new UILabel () {
				Font = UIFont.FromName("Helvetica", 15f),
				TextColor = UIColor.FromRGB (0, 0, 0),
				BackgroundColor = UIColor.Clear
			};


			ContentView.Add (amountLabel);


		}

		public void UpdateCell (string amount)
		{
			amountLabel.Text = amount;
		}

		public override void LayoutSubviews ()
		{
			base.LayoutSubviews ();
			btn = new UIButton ();
			amountLabel.Frame = new RectangleF(30, 8, ContentView.Bounds.Width - 30, 25);
			btn.Frame = new RectangleF(30, 8, ContentView.Bounds.Width - 80, 25);
	

		}
	}
}

