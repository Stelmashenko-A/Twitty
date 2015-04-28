using System.Collections.ObjectModel;

namespace Twitty.Geo
{
    public interface IGeo
    {
        TwitterGeo Coordinates { get; set; }
    }
}
