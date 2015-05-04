using System;
using System.Collections.Generic;
using TweetSharp;

namespace TwitterClient.Statuses
{
    class TwitterUniqueStatusCollection:TwitterStatusCollection
    {
        private readonly List<string> _statusesText;

        public TwitterUniqueStatusCollection(TwitterStatusCollection statusCollection)
        {
            if (statusCollection == null) throw new ArgumentNullException();
            _statusesText = new List<string>();

            AddRange(statusCollection);
        }

        public new void Add(TwitterStatus item)
        {
            if (item == null) throw new ArgumentNullException();
            var str=item.Text;
            if (TweetAnalizer.IsRetweet(item))
            {
                str = item.RetweetedStatus.Text;
            }

            if (_statusesText.Contains(str)) return;
            base.Add(item);
            _statusesText.Add(str);
        }

        public new void AddRange(IEnumerable<TwitterStatus> collection)
        {
            if (collection == null) throw new ArgumentNullException();
            foreach (var variable in collection)
            {
                Add(variable);
            }
        }
    }
}
