using System;
using System.Runtime.Serialization;
using TwitterClient.Decorator;

namespace TwitterClient.Filter
{
    [Serializable]
    
    public class TextSpamFilter:TwitterTextFilter
    {
        public override bool IsValid(DecoratedTwitterStatus item)
        {
            if (InvalidParams.Contains(item.Base.Text))
            {
                return false;
            }

            InvalidParams.Add(item.Base.Text);
            return true;
        }
    }
}
