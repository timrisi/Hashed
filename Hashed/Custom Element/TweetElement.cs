using System;
using System.Drawing;
using MonoTouch.UIKit;
using MonoTouch.Dialog;
using MonoTouch.Foundation;

namespace Hashed
{
	public class TweetElement : Element, IElementSizing
	{
		static NSString key = new NSString("TweetElement");
		public Tweet tweet;
			
		public TweetElement (Tweet tweet) : base(null)
		{
			this.tweet = tweet;
		}
		
		public override UITableViewCell GetCell (UITableView tv)
		{
			TweetCell cell = tv.DequeueReusableCell(key) as TweetCell;
			if (cell == null)
				cell = new TweetCell(tweet, key);
			else
				cell.UpdateCell(tweet);
			return cell;
		}
		
		public override void Selected (DialogViewController dvc, UITableView tableView, NSIndexPath path)
		{
			dvc.ActivateController(new TweetView(tweet, null));
		}
		
		public float GetHeight(UITableView tableView, NSIndexPath indexPath)
		{
			return TweetCell.GetCellHeight(tableView.Bounds, tweet);
		}
	}
}

