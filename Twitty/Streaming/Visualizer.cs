using System.Drawing;
using Twitty.Geo;

namespace Twitty.Streaming
{
    public class Visualizer<T> where T : IGeo
    {
        private readonly Bitmap _map;

        private readonly IGetter<T> _getter;

        public Visualizer(Bitmap map, IGetter<T> getter)
        {
            _map = map;
            _getter = getter;
        }

        public void Start()
        {
            while (true)
            {
                T data;
                _getter.TryGet(out data);
                if (data == null || data.Coordinates == null) continue;
                if (data.Coordinates.ShapeType != TwitterGeoShapeType.Point) continue;
                var x =
                    (int)(data.Coordinates.Coordinates[0].Longitude / 180 * _map.Width / 2 + (double)_map.Width / 2);
                var y =
                    (int)(-data.Coordinates.Coordinates[0].Latitude / 90 * _map.Height / 2 + (double)_map.Height / 2);
                _map.SetPixel(x, y, Color.Black);
                if (OnCount != null) OnCount(_map);
            }
            // ReSharper disable once FunctionNeverReturns
        }

        public delegate void MethodContainer(Bitmap bitmap);

        public event MethodContainer OnCount;
    }
}