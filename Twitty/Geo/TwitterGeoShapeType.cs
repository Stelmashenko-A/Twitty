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
}