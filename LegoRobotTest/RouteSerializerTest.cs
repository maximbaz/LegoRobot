using System;
using System.Collections.Generic;
using System.Linq;
using LegoRobot.JavaServer.Route;
using LegoRobot.Model.Routing;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// ReSharper disable InconsistentNaming
namespace LegoRobotTest
{
    [TestClass]
    public class RouteSerializerTest
    {
        private readonly Route route = new Route {
            Id = Guid.NewGuid(),
            Scale = 10
        };

        public RouteSerializerTest() {
            route.Points = new List<PointRoutes> {
                new PointRoutes {Point = new Point(0, 2)  {Id = Guid.NewGuid()}, Route = route},
                new PointRoutes {Point = new Point(1, 3)  {Id = Guid.NewGuid()}, Route = route},
                new PointRoutes {Point = new Point(4, 3)  {Id = Guid.NewGuid()}, Route = route},
                new PointRoutes {Point = new Point(4, 6)  {Id = Guid.NewGuid()}, Route = route},
                new PointRoutes {Point = new Point(2, 8)  {Id = Guid.NewGuid()}, Route = route},
                new PointRoutes {Point = new Point(0, 8)  {Id = Guid.NewGuid()}, Route = route},
                new PointRoutes {Point = new Point(0, 10) {Id = Guid.NewGuid()}, Route = route}
            };
        }

        [TestMethod]
        public void Serialize_Takes_Route_Returns_Queue_of_String() {
            var serializer = new RouteSerializer();

            var result = serializer.Serialize(new Route());

            Assert.IsInstanceOfType(result, typeof(Queue<string>));
        }

        [TestMethod]
        public void Correctly_Serializes_Route_Started_From_0_0() {
            var serializer = new RouteSerializer();
            route.Start = new Start {
                Position = new Point(0, 0),
                Offset = new Point(1, 1)
            };

            var result = serializer.Serialize(route);

            Assert.AreEqual(14, result.Count);
            Assert.IsTrue(result.EqualsTo(ExpectedRouteStartedFrom_0_0));
        }

        [TestMethod]
        public void Correctly_Serializes_Route_Started_From_Point_Inside_Map() {
            var serializer = new RouteSerializer();
            route.Start = new Start {
                Position = new Point(5, 2),
                Offset = new Point(4, 1)
            };

            var result = serializer.Serialize(route);

            Assert.AreEqual(14, result.Count);
            Assert.IsTrue(result.EqualsTo(ExpectedRouteStartedFromPointInsideMap));
        }

        private Queue<string> ExpectedRouteStartedFrom_0_0 {
            get 
            {
                var i = 0;
                var expected = new Queue<string>();
                expected.Enqueue("SRT=-45.0 | Route="   + route.Id + " | Point=" + route.Start.Id + "\n");
                expected.Enqueue("SRD=20000.0 | Route=" + route.Id + " | Point=" + route.Start.Id + "\n");
                expected.Enqueue("SRT=45.0 | Route=" + route.Id + " | Point=" + route.Points[i].Point.Id + "\n");
                expected.Enqueue("SRD=14142.1 | Route=" + route.Id + " | Point=" + route.Points[i++].Point.Id + "\n");
                expected.Enqueue("SRT=45.0 | Route=" + route.Id + " | Point=" + route.Points[i].Point.Id + "\n");
                expected.Enqueue("SRD=30000.0 | Route=" + route.Id + " | Point=" + route.Points[i++].Point.Id + "\n");
                expected.Enqueue("SRT=-90.0 | Route=" + route.Id + " | Point=" + route.Points[i].Point.Id + "\n");
                expected.Enqueue("SRD=30000.0 | Route=" + route.Id + " | Point=" + route.Points[i++].Point.Id + "\n");
                expected.Enqueue("SRT=-45.0 | Route=" + route.Id + " | Point=" + route.Points[i].Point.Id + "\n");
                expected.Enqueue("SRD=28284.3 | Route=" + route.Id + " | Point=" + route.Points[i++].Point.Id + "\n");
                expected.Enqueue("SRT=-45.0 | Route=" + route.Id + " | Point=" + route.Points[i].Point.Id + "\n");
                expected.Enqueue("SRD=20000.0 | Route=" + route.Id + " | Point=" + route.Points[i++].Point.Id + "\n");
                expected.Enqueue("SRT=90.0 | Route=" + route.Id + " | Point=" + route.Points[i].Point.Id + "\n");
                expected.Enqueue("SRD=20000.0 | Route=" + route.Id + " | Point=" + route.Points[i].Point.Id + "\n");
                return expected;
            }
        }

        private Queue<string> ExpectedRouteStartedFromPointInsideMap
        {
            get 
            {
                var i = 0;
                var expected = new Queue<string>();
                expected.Enqueue("SRT=45.0 | Route=" + route.Id + " | Point=" + route.Start.Id + "\n");
                expected.Enqueue("SRD=50000.0 | Route=" + route.Id + " | Point=" + route.Start.Id + "\n");
                expected.Enqueue("SRT=135.0 | Route=" + route.Id + " | Point=" + route.Points[i].Point.Id + "\n");
                expected.Enqueue("SRD=14142.1 | Route=" + route.Id + " | Point=" + route.Points[i++].Point.Id + "\n");
                expected.Enqueue("SRT=45.0 | Route=" + route.Id + " | Point=" + route.Points[i].Point.Id + "\n");
                expected.Enqueue("SRD=30000.0 | Route=" + route.Id + " | Point=" + route.Points[i++].Point.Id + "\n");
                expected.Enqueue("SRT=-90.0 | Route=" + route.Id + " | Point=" + route.Points[i].Point.Id + "\n");
                expected.Enqueue("SRD=30000.0 | Route=" + route.Id + " | Point=" + route.Points[i++].Point.Id + "\n");
                expected.Enqueue("SRT=-45.0 | Route=" + route.Id + " | Point=" + route.Points[i].Point.Id + "\n");
                expected.Enqueue("SRD=28284.3 | Route=" + route.Id + " | Point=" + route.Points[i++].Point.Id + "\n");
                expected.Enqueue("SRT=-45.0 | Route=" + route.Id + " | Point=" + route.Points[i].Point.Id + "\n");
                expected.Enqueue("SRD=20000.0 | Route=" + route.Id + " | Point=" + route.Points[i++].Point.Id + "\n");
                expected.Enqueue("SRT=90.0 | Route=" + route.Id + " | Point=" + route.Points[i].Point.Id + "\n");
                expected.Enqueue("SRD=20000.0 | Route=" + route.Id + " | Point=" + route.Points[i].Point.Id + "\n");
                return expected;
            }
        }
    }
}
// ReSharper restore InconsistentNaming

public static class QueueExtensions
{
    public static bool EqualsTo(this IEnumerable<string> expected, Queue<string> actual) {
        return !(from e in expected where !actual.Contains(e) select e).Any();
    }
}