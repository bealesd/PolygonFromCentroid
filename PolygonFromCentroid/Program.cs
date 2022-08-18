using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolygonFromCentroid
{
    internal class Program
    {
        static void Main(string[] args)
        {

            createPolygonFromCentroid(0, 0, 4, 2);

            createPolygonFromCentroid(65.5, 68.5, 4, 2);

            Console.ReadKey();
        }
        static void createPolygonFromCentroid(double polygon_lat_centroid, double polygon_long_centroid, double polygon_length, double polygon_height)
        {
            var bottom_lat = polygon_lat_centroid - polygon_height / 2;
            var top_lat = polygon_lat_centroid + polygon_height / 2;
            var left_long = polygon_long_centroid - polygon_length / 2;
            var right_long = polygon_long_centroid + polygon_length / 2;

            var lowerleft = new NetTopologySuite.Geometries.Coordinate(left_long, bottom_lat);
            var lowerright = new NetTopologySuite.Geometries.Coordinate(right_long, bottom_lat);
            var topleft = new NetTopologySuite.Geometries.Coordinate(left_long, top_lat);
            var topright = new NetTopologySuite.Geometries.Coordinate(right_long, top_lat);

            var gf = NetTopologySuite.NtsGeometryServices.Instance.CreateGeometryFactory(4326);

            List<NetTopologySuite.Geometries.Coordinate> coordinates = new List<NetTopologySuite.Geometries.Coordinate>();
            coordinates.Add(lowerleft);
            coordinates.Add(lowerright);
            coordinates.Add(topleft);
            coordinates.Add(topright);
            coordinates.Add(lowerleft);

            var polygon = gf.CreatePolygon(coordinates.ToArray());

            Console.WriteLine(polygon.Centroid);
            Console.ReadKey();
        }
    }
}
