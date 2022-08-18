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

            CreatePolygonFromCentroid(0, 0, 4, 2);
            CreatePolygonFromCentroid(65.5, 68.5, 4, 2);

            Console.ReadKey();
        }
        static void CreatePolygonFromCentroid(double polygonLatCentroid, double polygonLongCentroid, double polygonLength, double polygonHeight)
        {
            var bottomLat = polygonLatCentroid - polygonHeight / 2;
            var topLat = polygonLatCentroid + polygonHeight / 2;
            var leftLong = polygonLongCentroid - polygonLength / 2;
            var rightLong = polygonLongCentroid + polygonLength / 2;

            var lowerLeft = new NetTopologySuite.Geometries.Coordinate(leftLong, bottomLat);
            var lowerRight = new NetTopologySuite.Geometries.Coordinate(rightLong, bottomLat);
            var topLeft = new NetTopologySuite.Geometries.Coordinate(leftLong, topLat);
            var topRight = new NetTopologySuite.Geometries.Coordinate(rightLong, topLat);

            var gf = NetTopologySuite.NtsGeometryServices.Instance.CreateGeometryFactory(4326);

            List<NetTopologySuite.Geometries.Coordinate> coordinates = new List<NetTopologySuite.Geometries.Coordinate>();
            coordinates.Add(lowerLeft);
            coordinates.Add(lowerRight);
            coordinates.Add(topLeft);
            coordinates.Add(topRight);
            coordinates.Add(lowerLeft);

            var polygon = gf.CreatePolygon(coordinates.ToArray());

            Console.WriteLine(polygon.Centroid);
            Console.ReadKey();
        }
    }
}
