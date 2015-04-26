using System;

namespace Twitty.Geo
{
    [SerializableAttribute]
    public class Coordinate
    {
        public float Longitude { get; set; }

        public float Latitude { get; set; }
    }
}
