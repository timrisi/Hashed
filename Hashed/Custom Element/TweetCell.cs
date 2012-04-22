using System;
using System.Drawing;
using MonoTouch.UIKit;
using MonoTouch.Foundation;

namespace Hashed
{
	public class TweetCell : UITableViewCell
	{
		TweetCellView tweetView;
		
		public TweetCell (Tweet tweet, string identKey) : base(UITableViewCellStyle.Default, identKey)
		{
			tweetView = new TweetCellView(tweet);
			ContentView.Add(tweetView);
		}
		
		public override void LayoutSubviews ()
		{
			base.LayoutSubviews ();
			tweetView.Frame = ContentView.Bounds;
			tweetView.SetNeedsDisplay();
		}
		
		public void UpdateCell(Tweet newTweet)
		{
			tweetView.Update(newTweet);
		}
		
		public static float GetCellHeight (RectangleF bounds, Tweet tweet)
		{
			bounds.Height = 999;

			// Keep the same as LayoutSubviews
			bounds.X = 0;
			bounds.Width -= 5;

			using (var nss = new NSString (tweet.Text))
			{
				var dim = nss.StringSize (UIFont.SystemFontOfSize(15), bounds.Size, UILineBreakMode.WordWrap);
				return Math.Max (dim.Height + 5 + + 14 + 2*4, 20);
			}
		}

	}
}

