using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.Drawing;

namespace MobiCashiOSNewLayout
{
	public class MainNavControllerTableCell: UITableViewCell
	{
		UILabel headingLabel;


		public MainNavControllerTableCell (NSString cellId) : base (UITableViewCellStyle.Default, cellId)
		{
			SelectionStyle = UITableViewCellSelectionStyle.Gray;

			ContentView.BackgroundColor = UIColor.FromRGB (255, 255, 255);

			headingLabel = new UILabel () {
				Font = UIFont.FromName("Helvetica", 15f),
				TextColor = UIColor.FromRGB (0, 0, 0),
				BackgroundColor = UIColor.Clear
			};

	
			ContentView.Add (headingLabel);
		
		}

		public void UpdateCell (string caption)
		{
			headingLabel.Text = caption;

		}

		public override void LayoutSubviews ()
		{
			base.LayoutSubviews ();
			headingLabel.Frame = new RectangleF(30, 8, ContentView.Bounds.Width - 30, 25);

		}
	}
}

