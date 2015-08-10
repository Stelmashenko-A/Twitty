using System;
using System.Collections.ObjectModel;
using Newtonsoft.Json;

namespace Twitty.Geo
{
    [Serializable]
    public class TwitterGeo
    {
        [JsonProperty(PropertyName = "type")]
        public TwitterGeoShapeType ShapeType { get; set; }

        [JsonProperty(PropertyName = "coordinates")]
        [JsonConverter(typeof (Coordinate.Converter))]
        public Collection<Coordinate> Coordinates { get; set; }
    }
}
