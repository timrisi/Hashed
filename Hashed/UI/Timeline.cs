using System;
using System.Collections.Generic;
using System.Linq;
using System.Json;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using MonoTouch.Twitter;
using MonoTouch.Accounts;
using MonoTouch.Dialog;
using System.Net;
using System.IO;
using System.Text;
using System.Web;
using System.Xml;
using System.Xml.Linq;
using FlyOutNavigation;

namespace Hashed
{
	public class Timeline : DialogViewController
	{
		FlyOutNavigationController navigation;
			
		public Timeline (FlyOutNavigationController nav) : base(null)
		{
			navigation = nav;
			Initialize();
		}
		
		private void Initialize()
		{
			Style = UITableViewStyle.Plain;
			
			string url = "https://api.twitter.com/1/statuses/public_timeline.xml";
			
			TWRequest request = new TWRequest(new NSUrl("https://api.twitter.com/1/statuses/friends_timeline.xml"), 
			                                  null, TWRequestMethod.Get);
			request.Account = TwitterAccount.twitterAccount;
			request.PerformRequest((responseData, urlResponse, error) => 
			{
				Root = new RootElement("Timeline");
				XmlDocument doc = new XmlDocument();
				
				doc.LoadXml(responseData.ToString());
				
				Section timeline = new Section("Timeline");
				
				foreach (XmlNode node in doc.DocumentElement.ChildNodes)
					timeline.Add (new TweetElement(new Tweet(node)));
				
				Root.Add (timeline);
				this.ReloadData();
			});
		}
		
		public void requestResponse(NSData responseData, NSData urlResponse, NSData error)
		{
			
		}
		
		
		public static string HttpGet(string url)
		{
			HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
			string result = null;
			
			//XmlDocument doc = new XmlDocument();
			using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
			{
				StreamReader reader = new StreamReader(response.GetResponseStream());
				result = reader.ReadToEnd();
			}
				
			//doc.Load(request.GetResponse().GetResponseStream());
			
			return result;
		}
		
		public static string HttpPost(string url, string[] paramName, string[] paramValue)
		{
			HttpWebRequest request = WebRequest.Create(new Uri(url)) as HttpWebRequest;
			request.Method = "POST";
			request.ContentType = "application/x-www-form-urlencoded";
			//request.Credentials = NetworkCredential("", "");
			
			StringBuilder parameters = new StringBuilder();
			for(int i = 0; i < paramName.Count(); i++)
			{
				parameters.Append(paramName[i]);
				parameters.Append("=");
				parameters.Append(HttpUtility.UrlEncode(paramValue[i]));
				parameters.Append("&");
			}
			
			byte[] formData = UTF8Encoding.UTF8.GetBytes(parameters.ToString());
			request.ContentLength = formData.Length;
			
			using (Stream post = request.GetRequestStream())
			{
				post.Write(formData, 0, formData.Length);
			}
			
			string result = null;
			using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
			{
				StreamReader reader = new StreamReader(response.GetResponseStream());
				result = reader.ReadToEnd();
			}			
			
			return result;
		}
		
		public override void ViewWillAppear (bool animated)
		{
			base.ViewWillAppear(animated);
			NavigationItem.LeftBarButtonItem= new UIBarButtonItem (UIBarButtonSystemItem.Bookmarks, delegate {
					navigation.ToggleMenu ();
				});
			NavigationController.NavigationBar.Hidden = false;
			NavigationItem.Title = "Timeline";
		}
	}
}

