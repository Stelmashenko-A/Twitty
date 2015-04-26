
using System;
using Twitty.Entities;
using Twitty.Tweets;

namespace Twitty.Account
{
    [SerializableAttribute]
    //https://dev.twitter.com/overview/api/users
    public class User
    {
        public Boolean ContributorsEnabled { get; set; }
        public String CreatedAt { get; set; }
        public Boolean DefaultProfile { get; set; }
        public Boolean DefaultProfileImage { get; set; }
        public String Description { get; set; }
        public Entity Entities{get;set;}
        public int FavouritesCount { get; set; }
        //public Type (bool???) FollowRequesSent{get;set;}
        //public Type (bool???) Following{get;set;}
        public int FollowerCount { get; set; }
        public int FriendsCount { get; set; }
        public Boolean GeoEnabled { get; set; }
        public Int64 Id { get; set; }
        public String IdStr { get; set; }
        public Boolean IsTranslator { get; set; }
        public String Lang { get; set; }
        public int ListedCount { get; set; }
        public String Location { get; set; }
        public String Name { get; set; }
        public Boolean Notification { get; set; }
        public String ProfileBackgroundColor { get; set; }
        public String ProfileBackgroundImagUrl { get; set; }
        public String ProfileBackgroundImageUrlHttps { get; set; }
        public Boolean ProfileBackgroundTile { get; set; }
        public String ProfileBannerUrl { get; set; }
        public String ProfileImageUrl { get; set; }
        public String ProfileImagesUrlHttps { get; set; }
        public String ProfileLinkColor { get; set; }
        public String ProfileSidebarBorderColor { get; set; }
        public String ProfileSidebarFillColor { get; set; }
        public String ProfileTextColor { get; set; }
        public Boolean ProfileUseBackgroundImage { get; set; }
        public Boolean Protected { get; set; }
        public String ScreenName { get; set; }
        public Boolean ShowAllInlineMedia { get; set; }
        public Tweet Status { get; set; }
        public int StatusCount { get; set; }
        public String TimeZone { get; set; }
        public String Url { get; set; }
        public int UtcOffset { get; set; }
        public Boolean Verified { get; set; }
        public String WithheldIntCountries { get; set; }
        public String WithheldScope { get; set; }

    }
}
