using System;
using System.Collections.Generic;
using Twitty.Account;
using Twitty.Commands;
using Twitty.Geo;
using Twitty.Kernel;
using Twitty.OAuth;

namespace Twitty.Tweets
{
    //https://dev.twitter.com/overview/api/tweets
    public class Tweet : ITwitterObject
    {
        //public object Annotation;
        public List<Contributor> Contributors
        {
            get; set;
        }

        public Coordinate Coordinates
        {
            get; set; 
        }
        public String CreatedAt;
        //public object CurrentUserRetweet{get;set;}
        //public Entities entities {get;set;}
        public int FavouriteCount
        {
            get; set;
        }

        public bool Favorited
        {
            get; set; 
        }

        public string FilterLevel
        {
            get; set;
        }

        public Int64 Id
        {
            get; set;            
        }

        public String IdStr
        {
            get; set; 
        }

        public String InReplyToScreenName
        {
            get; set;           
        }

        public Int64 InReplyToStatusId
        {
            get; set;            
        }

        public String InReplyToStatusIdStr
        {
            get; set;            
        }

        public Int64 InReplyToUserId
        {
            get; set;            
        }

        public String InReplyToUserIdStr
        {
            get; set;             
        }

        public String Lang
        {
            get; set;         
        }
        //public Places plase{get;set;}
        public Boolean PossiblySensitive
        {
            get; set;           
        }
        //public Object scopes{get;set;}
        public int RetweetCount
        {
            get; set;            
        }

        public Boolean Retweeted
        {
            get; set;            
        }

        public Tweet RetweetedStatus
        {
            get; set;            
        }

        public String Sourse
        {
            get; set;            
        }

        public String Text
        {
            get; set;            
        }

        public Boolean Truncated
        {
            get; set;           
        }

        public User User
        {
            get; set;            
        }

        public Boolean WithheldCopyright
        {
            get; set;          
        }

        public List<String> WithheldInCountries
        {
            get; set;            
        }

        public String WithheldScope
        {
            get; set;          
        }
        public static Response<Tweet> Update(OAuthTokens tokens, string text)
        {
            var command = new CommandForStatusUpdating(tokens, text);
            return CommandPerfomer.PerformCommand(command);
        }
    }
}