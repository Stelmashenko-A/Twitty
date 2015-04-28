using System;
using Newtonsoft.Json;

namespace Twitty.Tweets
{
    public class Contributor
    {
        [JsonProperty(PropertyName = "id")]
        public long Id
        {
            get; set;
        }

        [JsonProperty(PropertyName = "id_str")]
        public string IdStr { get; set; }

        [JsonProperty(PropertyName = "screen_name")]
        public string ScreenName { get; set; }

    }
}
