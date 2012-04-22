using System;
using System.Collections.Generic;
using System.Linq;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using MonoTouch.Dialog;
using FlyOutNavigation;

namespace Hashed
{
	public class TweetView : DialogViewController
	{
		Tweet tweet;
		FlyOutNavigationController navigation;
		
		public TweetView (Tweet tweet, FlyOutNavigationController navigation) : base(null)
		{
			this.tweet = tweet;
			this.navigation = navigation;
			
			Initialize();
		}
		
		private void Initialize()
		{
			
		}
		
		public override void ViewWillAppear (bool animated)
		{
			base.ViewWillAppear(animated);
			NavigationController.NavigationBar.Hidden = false;
			NavigationItem.Title = tweet.user.Screenname;
		}
	}
}

