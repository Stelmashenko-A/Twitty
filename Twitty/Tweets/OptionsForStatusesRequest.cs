using Twitty.Kernel;

namespace Twitty.Tweets
{
    class OptionsForStatusesRequest:Options
    {
        public int UserId
        {
            get; set;
        }

        public string ScreenName
        {
            get; set;
        }

        public int SinceId
        {
            get; set;
        }

        public int Count
        {
            get;
            set;
        }

        public int MaxId
        {
            get;
            set;
        }

        public bool TrimUser
        {
            get;
            set;
        }

        public bool ExcludeReplies 
        {
            get;
            set;
        }

        public bool ContributorDetails 
        {
            get;
            set;
        }

        public bool IncludeRts 
        {
            get;
            set;
        }
    }
}
