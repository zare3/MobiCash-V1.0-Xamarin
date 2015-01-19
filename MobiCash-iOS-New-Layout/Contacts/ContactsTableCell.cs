using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.Drawing;

namespace MobiCashiOSNewLayout
{
	public class ContactsTableCell: UITableViewCell
	{
		UILabel nameLabel;

		public ContactsTableCell (NSString cellId) : base (UITableViewCellStyle.Default, cellId)
		{
			SelectionStyle = UITableViewCellSelectionStyle.Gray;

			ContentView.BackgroundColor = UIColor.FromRGB (255, 255, 255);

			nameLabel = new UILabel () {
				Font = UIFont.FromName("Helvetica", 17f),
				TextColor = UIColor.FromRGB (0, 0, 0),
				BackgroundColor = UIColor.Clear
			};
					
			ContentView.Add (nameLabel);

		}

		public void UpdateCell (string name)
		{
			nameLabel.Text = name;

		}

		public override void LayoutSubviews ()
		{
			base.LayoutSubviews ();
			nameLabel.Frame = new RectangleF(30, 8, ContentView.Bounds.Width - 30, 25);
		}
	}
}

