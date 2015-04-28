using System;
using System.Collections.Generic;
using System.Drawing;
using Twitty.Geo;


namespace TwitterAnalyzer
{
    public class Visualizer<T> where T : IGeo
    {

        public Image Visualiz(Image map, T data)
        {
            var bm = new Bitmap(map);
            int x;
            int y;
            if (data.Coordinates.ShapeType == TwitterGeoShapeType.Point)
            {
                //data.Coordinates.Coordinates[0].Latitude = 53;
                //data.Coordinates.Coordinates[0].Longitude = 24;

                x = (int) (data.Coordinates.Coordinates[0].Longitude/180*map.Width/2 + (double) map.Width/2);
                y = (int) (-data.Coordinates.Coordinates[0].Latitude/90*map.Height/2 + (double) map.Height/2);
                //x = 500;
                //y = 250;
                bm.SetPixel(x, y, Color.Black);

            }
           
            return bm;
        }
    }
}
