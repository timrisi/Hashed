using System;
using System.Xml;

namespace Hashed
{
	public class Tweet
	{
		public string DateCreated { get; set; }
		public long ID { get; set; }
		public string Text { get; set; }
		public string Source { get; set; }
		public bool Truncated { get; set; }
		public bool Favorited { get; set; }
		public long ReplyToStatusID { get; set; }
		public long ReplyToUserID { get; set; }
		public string ReplyToScreenName { get; set; }
		public long RetweetCount { get; set; }
		public bool Retweeted { get; set; }
		public User user { get; set; }
		
		public Tweet (XmlNode statusNode)
		{
			DateCreated = statusNode.SelectSingleNode("created_at").InnerText;
			ID = long.Parse(statusNode.SelectSingleNode("id").InnerText);
			Text = statusNode.SelectSingleNode("text").InnerText;
			Source = statusNode.SelectSingleNode("source").InnerText;
			Truncated = bool.Parse(statusNode.SelectSingleNode("truncated").InnerText);
			Favorited = bool.Parse(statusNode.SelectSingleNode("favorited").InnerText);
			string replyToStatusId = statusNode.SelectSingleNode("in_reply_to_status_id").InnerText;
				ReplyToStatusID = !string.IsNullOrEmpty(replyToStatusId) ? long.Parse(replyToStatusId) : -1;
			string replyToUserId = statusNode.SelectSingleNode("in_reply_to_user_id").InnerText;
				ReplyToUserID = !string.IsNullOrEmpty(replyToUserId) ? long.Parse(replyToUserId) : -1;
			ReplyToScreenName = statusNode.SelectSingleNode("in_reply_to_screen_name").InnerText;
			//RetweetCount = long.Parse(statusNode.SelectSingleNode("").InnerText);
			Retweeted = bool.Parse(statusNode.SelectSingleNode("retweeted").InnerText);
			user = new User(statusNode.SelectSingleNode("user"));
		}
	}
}

