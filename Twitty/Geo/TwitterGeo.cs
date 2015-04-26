using System;
using System.Collections.ObjectModel;

namespace Twitty.Geo
{
    [Serializable]
    public class TwitterGeo
    {
       public Collection<Coordinate> Coordinates { get; set; }
    }
}
