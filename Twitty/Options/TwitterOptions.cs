using System.Net;

namespace Twitty.Options
{
    public class TwitterOptions
    {
        public bool UseSsl { get; set; }

        public string ApiBaseAddress { get; set; }

        public WebProxy Proxy { get; set; }

        public TwitterOptions()
        {
            UseSsl = true;
            ApiBaseAddress = "https://api.twitter.com/1.1/";
        }
    }
}
