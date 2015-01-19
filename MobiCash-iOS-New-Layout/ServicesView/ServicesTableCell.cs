using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.Drawing;
using System;

namespace MobiCashiOSNewLayout
{
	public class ServicesTableCell: UITableViewCell
	{
		UILabel headingLabel;
		UIImageView imageView;
		ServicesViewType servicesViewType;


		public ServicesTableCell (NSString cellId) : base (UITableViewCellStyle.Default, cellId)
		{
			SelectionStyle = UITableViewCellSelectionStyle.None;

			ContentView.BackgroundColor = UIColor.FromRGB (255, 255, 255);

			headingLabel = new UILabel () {
				Font = UIFont.FromName("Helvetica", 17f),
				TextColor = UIColor.FromRGB (0, 0, 0),
				BackgroundColor = UIColor.Clear
			};
			imageView = new UIImageView();

			ContentView.Add (headingLabel);
			ContentView.Add (imageView);

		}

		public void UpdateCell (string caption, UIImage image, ServicesViewType servicesViewType)
		{
			headingLabel.Text = caption;
			imageView.Image = image;
			this.servicesViewType = servicesViewType;
		}

		public override void LayoutSubviews ()
		{
			base.LayoutSubviews ();
			headingLabel.Frame = new RectangleF(70, 10, ContentView.Bounds.Width, 25);
			if (servicesViewType==ServicesViewType.InternetBill)
				imageView.Frame = new RectangleF(ContentView.Bounds.Width - 300, 2, 40, 40);
			else if (servicesViewType==ServicesViewType.MobileBill)
				imageView.Frame = new RectangleF(ContentView.Bounds.Width - 295, 2, 40, 40);


		}
	}
}

