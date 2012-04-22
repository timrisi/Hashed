using System;
using System.Xml;

namespace Hashed
{
	public class User
	{
		public long ID { get; set; }
		public string Name { get; set; }
		public string Screenname { get; set; }
		public string Location { get; set; }
		public string Description { get; set; }
		public string ProfilePicUrl { get; set; }
		public string ProfileImageUrlHttps { get; set; }
		public string Url { get; set; }
		public bool Protected { get; set; }
		public long FollowersCount { get; set; }
		public long FriendsCount { get; set; }
		public string DateCreated { get; set; }
		public long FavoritesCount { get; set; }
		public bool Verified { get; set; }
		public long StatusesCount { get; set; }
		
		public User (XmlNode userNode)
		{
			ID = long.Parse(userNode.SelectSingleNode("id").InnerText);
			Name = userNode.SelectSingleNode("name").InnerText;
			Screenname = userNode.SelectSingleNode("screen_name").InnerText;
			Location = userNode.SelectSingleNode("location").InnerText;
			Description = userNode.SelectSingleNode("description").InnerText;
			ProfilePicUrl = userNode.SelectSingleNode("profile_image_url").InnerText;
			//ProfileImageUrlHttps = userNode.SelectSingleNode("").InnerText;
			Url = userNode.SelectSingleNode("url").InnerText;
			Protected = bool.Parse(userNode.SelectSingleNode("protected").InnerText);
			FollowersCount = long.Parse(userNode.SelectSingleNode("followers_count").InnerText);
			FriendsCount = long.Parse(userNode.SelectSingleNode("friends_count").InnerText);
			DateCreated = userNode.SelectSingleNode("created_at").InnerText;
			FavoritesCount = long.Parse(userNode.SelectSingleNode("favourites_count").InnerText);
			Verified = bool.Parse(userNode.SelectSingleNode("verified").InnerText);
			StatusesCount = long.Parse(userNode.SelectSingleNode("statuses_count").InnerText);
		}
	}
}

