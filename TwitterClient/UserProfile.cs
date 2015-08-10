using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using TweetSharp;

namespace TwitterClient
{
    public class UserProfile
    {
        public static string FolderWithData;

        private string _path;

        public Dictionary<long, long> AuthenticatedUserRetweets { get; private set; }

        public TwitterUser TwitterUser { get; private set; }

        private long _maxTweetId;

        public UserProfile(TwitterClient service)
        {
            TwitterUser = service.GetUserProfile(new GetUserProfileOptions());
            var b = service.FullListTweetsOnUserTimeline();
            AuthenticatedUserRetweets = new Dictionary<long, long>();

            foreach (var variable in b.Where(variable => variable.RetweetedStatus != null))
            {
                if (variable.RetweetedStatus.RetweetedStatus != null)
                {
                    AuthenticatedUserRetweets.Add(variable.RetweetedStatus.RetweetedStatus.Id, variable.RetweetedStatus.Id);
                }
                else
                {
                    if(variable.RetweetedStatus != null)
                        AuthenticatedUserRetweets.Add(variable.RetweetedStatus.Id, variable.Id);
                }
            }
        }

        private bool TryGetDataFromFile()
        {
            var sb = new StringBuilder();

            if (!string.IsNullOrEmpty(FolderWithData))
            {
                sb.Append(FolderWithData + "\\");
            }
            sb.Append(TwitterUser.Id);

            StreamReader sr;
            _path = sb.ToString();
            try
            {
                sr = new StreamReader(new FileStream(_path, FileMode.Open));
            }
            catch (IOException)
            {
                return false;
            }

            var str = sr.ReadLine();
            if (string.IsNullOrEmpty(str)) return false;
            _maxTweetId = long.Parse(str);

            AuthenticatedUserRetweets = new Dictionary<long, long>();
            while (!sr.EndOfStream)
            {
                str = sr.ReadLine();
                if (str == null) continue;
                var tmp = str.Split(',');
                AuthenticatedUserRetweets.Add(long.Parse(tmp[0]), long.Parse(tmp[1]));
            }

            return true;
        }
    }
}
