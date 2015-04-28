using System;
using System.Collections.ObjectModel;
using Newtonsoft.Json;

namespace Twitty.Geo
{
    public enum TwitterGeoShapeType
    {
        /// <summary>
        /// A single point. Expect one coordinate.
        /// </summary>
        Point,

        /// <summary>
        /// A line, or multiple lines joined end-to-end.
        /// </summary>
        LineString,

        /// <summary>
        /// A polygon-shaped area.
        /// </summary>
        Polygon,

        /// <summary>
        /// A circle represented by a single point (the center) and the radius.
        /// </summary>
        CircleByCenterPoint
    }
    [Serializable]
    public class TwitterGeo
    {
        [JsonProperty(PropertyName = "type")]
        public TwitterGeoShapeType ShapeType { get; set; }

       [JsonProperty(PropertyName = "coordinates")]
       [JsonConverter(typeof(Coordinate.Converter))]
       public Collection<Coordinate> Coordinates { get; set; }
    }
}
