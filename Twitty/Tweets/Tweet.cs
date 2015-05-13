using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Twitty.Account;
using Twitty.Commands;
using Twitty.Geo;
using Twitty.Kernel;
using Twitty.OAuth;

namespace Twitty.Tweets
{
    //https://dev.twitter.com/overview/api/tweets
    [SerializableAttribute]
    public class Tweet : ITwitterObject,IGeo
    {

        [JsonProperty(PropertyName = "contributors")]
        public Collection<Contributor> Contributors { get; set; }

        [DataMember, JsonProperty(PropertyName = "geo")]
        public TwitterGeo Coordinates { get; set; }

        [DataMember, JsonProperty(PropertyName = "created_at")]
        public String CreatedAt;

        [DataMember, JsonProperty(PropertyName = "favorite_count")]
        public int FavouriteCount { get; set; }

        [DataMember, JsonProperty(PropertyName = "favorited")]
        public bool Favorited { get; set; }

        [DataMember, JsonProperty(PropertyName = "filter_level")]
        public string FilterLevel { get; set; }

        [DataMember, JsonProperty(PropertyName = "id")]
        public Int64 Id { get; set; }

        [DataMember, JsonProperty(PropertyName = "id_str")]
        public String IdStr { get; set; }

        [DataMember, JsonProperty(PropertyName = "in_reply_to_screen_name")]
        public String InReplyToScreenName { get; set; }

        [DataMember, JsonProperty(PropertyName = "in_reply_to_status_id")]
        public Int64? InReplyToStatusId { get; set; }

        [DataMember, JsonProperty(PropertyName = "in_reply_to_status_id_str")]
        public String InReplyToStatusIdStr { get; set; }

        [DataMember, JsonProperty(PropertyName = "in_reply_to_user_id")]
        public Int64? InReplyToUserId { get; set; }

        [DataMember, JsonProperty(PropertyName = "in_reply_to_user_id_str")]
        public String InReplyToUserIdStr { get; set; }

        [DataMember, JsonProperty(PropertyName = "lang")]
        public String Lang { get; set; }

        [DataMember, JsonProperty(PropertyName = "possibly_sensitive")]
        public Boolean PossiblySensitive { get; set; }

        [DataMember, JsonProperty(PropertyName = "retweet_count")]
        public int RetweetCount { get; set; }

        [DataMember, JsonProperty(PropertyName = "retweeted")]
        public Boolean Retweeted { get; set; }

        [DataMember, JsonProperty(PropertyName = "retweeted_status")]
        public Tweet RetweetedStatus { get; set; }

        [DataMember, JsonProperty(PropertyName = "source")]
        public String Sourse { get; set; }

        [DataMember, JsonProperty(PropertyName = "text")]
        public String Text { get; set; }

        [DataMember, JsonProperty(PropertyName = "truncated")]
        public Boolean Truncated { get; set; }

        public User User { get; set; }

        [DataMember, JsonProperty(PropertyName = "withheld_copyright")]
        public Boolean WithheldCopyright { get; set; }

        [DataMember, JsonProperty(PropertyName = "withheld_in_countries")]
        public List<String> WithheldInCountries { get; set; }

        [DataMember, JsonProperty(PropertyName = "withheld_scope")]
        public String WithheldScope { get; set; }

        public static Response<Tweet> Update(OAuthTokens tokens, string text)
        {
            var command = new CommandForStatusUpdating(tokens, text);
            return CommandPerfomer.PerformCommand(command);
        }

        public static Response<Tweet> Delete(OAuthTokens tokens, long id)
        {
            var command = new DeleteStatusCommand(tokens, id);
            return CommandPerfomer.PerformCommand(command);
        }

        public static Response<Tweet> UndoFavourite(OAuthTokens tokens, long id)
        {
            var command = new UndoFavoriteCommand(tokens,id);
            return CommandPerfomer.PerformCommand(command);
        }
    }
}