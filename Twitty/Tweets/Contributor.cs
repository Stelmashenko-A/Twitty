using System;
using Newtonsoft.Json;

namespace Twitty.Tweets
{
    public class Contributor
    {
        [JsonProperty(PropertyName = "id")]
        public Int64 Id
        {
            get; set;
        }

        [JsonProperty(PropertyName = "id_str")]
        public String IdStr { get; set; }

        [JsonProperty(PropertyName = "screen_name")]
        public String ScreenName { get; set; }

    }
}
