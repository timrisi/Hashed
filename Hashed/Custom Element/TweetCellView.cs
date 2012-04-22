using System;
using System.Drawing;
using System.Collections.Generic;
using MonoTouch.UIKit;
using MonoTouch.Foundation;
using MonoTouch.CoreGraphics;

namespace Hashed
{
	public class TweetCellView : UIView
	{
		Tweet tweet;
		
		public TweetCellView(Tweet tweet)
		{
			Update(tweet);
			Opaque = true;
			BackgroundColor = UIColor.White;
		}
		
		public void Update(Tweet tweet)
		{
			this.tweet = tweet;
			
			SetNeedsDisplay();
		}
		
		 public override void Draw (RectangleF rect)
		{
			DrawString (tweet.user.Screenname, new PointF(5, 5), UIFont.BoldSystemFontOfSize(14));
			DrawString (tweet.Text, new RectangleF(5, 23, rect.Width - 10, rect.Height + 28), UIFont.SystemFontOfSize(15), UILineBreakMode.WordWrap);
		}
	}
}

