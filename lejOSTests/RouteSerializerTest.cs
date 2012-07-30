using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model.Routing;
using lejOS.Routing;

// ReSharper disable InconsistentNaming

namespace lejOSTests
{
    [TestClass]
    public class RouteSerializerTest
    {
        #region Properties and Indexers

        private Queue<string> ExpectedRouteStartedFrom_0_0 {
            get {
                var i = 0;
                var expected = new Queue<string>();
                expected.Enqueue("SRT=-45.0 | Route=" + route.Id + " | Point=" + route.Start.Id + "\n");
                expected.Enqueue("SRD=2000.0 | Route=" + route.Id + " | Point=" + route.Start.Id + "\n");
                expected.Enqueue("SRT=45.0 | Route=" + route.Id + " | Point=" + route.Steps[i].Point.Id + "\n");
                expected.Enqueue("SRD=1414.2 | Route=" + route.Id + " | Point=" + route.Steps[i++].Point.Id + "\n");
                expected.Enqueue("SRT=45.0 | Route=" + route.Id + " | Point=" + route.Steps[i].Point.Id + "\n");
                expected.Enqueue("SRD=3000.0 | Route=" + route.Id + " | Point=" + route.Steps[i++].Point.Id + "\n");
                expected.Enqueue("SRT=-90.0 | Route=" + route.Id + " | Point=" + route.Steps[i].Point.Id + "\n");
                expected.Enqueue("SRD=3000.0 | Route=" + route.Id + " | Point=" + route.Steps[i++].Point.Id + "\n");
                expected.Enqueue("SRT=-45.0 | Route=" + route.Id + " | Point=" + route.Steps[i].Point.Id + "\n");
                expected.Enqueue("SRD=2828.4 | Route=" + route.Id + " | Point=" + route.Steps[i++].Point.Id + "\n");
                expected.Enqueue("SRT=-45.0 | Route=" + route.Id + " | Point=" + route.Steps[i].Point.Id + "\n");
                expected.Enqueue("SRD=2000.0 | Route=" + route.Id + " | Point=" + route.Steps[i++].Point.Id + "\n");
                expected.Enqueue("SRT=90.0 | Route=" + route.Id + " | Point=" + route.Steps[i].Point.Id + "\n");
                expected.Enqueue("SRD=2000.0 | Route=" + route.Id + " | Point=" + route.Steps[i].Point.Id + "\n");
                return expected;
            }
        }

        private Queue<string> ExpectedRouteStartedFromPointInsideMap {
            get {
                var i = 0;
                var expected = new Queue<string>();
                expected.Enqueue("SRT=45.0 | Route=" + route.Id + " | Point=" + route.Start.Id + "\n");
                expected.Enqueue("SRD=5000.0 | Route=" + route.Id + " | Point=" + route.Start.Id + "\n");
                expected.Enqueue("SRT=135.0 | Route=" + route.Id + " | Point=" + route.Steps[i].Point.Id + "\n");
                expected.Enqueue("SRD=1414.2 | Route=" + route.Id + " | Point=" + route.Steps[i++].Point.Id + "\n");
                expected.Enqueue("SRT=45.0 | Route=" + route.Id + " | Point=" + route.Steps[i].Point.Id + "\n");
                expected.Enqueue("SRD=3000.0 | Route=" + route.Id + " | Point=" + route.Steps[i++].Point.Id + "\n");
                expected.Enqueue("SRT=-90.0 | Route=" + route.Id + " | Point=" + route.Steps[i].Point.Id + "\n");
                expected.Enqueue("SRD=3000.0 | Route=" + route.Id + " | Point=" + route.Steps[i++].Point.Id + "\n");
                expected.Enqueue("SRT=-45.0 | Route=" + route.Id + " | Point=" + route.Steps[i].Point.Id + "\n");
                expected.Enqueue("SRD=2828.4 | Route=" + route.Id + " | Point=" + route.Steps[i++].Point.Id + "\n");
                expected.Enqueue("SRT=-45.0 | Route=" + route.Id + " | Point=" + route.Steps[i].Point.Id + "\n");
                expected.Enqueue("SRD=2000.0 | Route=" + route.Id + " | Point=" + route.Steps[i++].Point.Id + "\n");
                expected.Enqueue("SRT=90.0 | Route=" + route.Id + " | Point=" + route.Steps[i].Point.Id + "\n");
                expected.Enqueue("SRD=2000.0 | Route=" + route.Id + " | Point=" + route.Steps[i].Point.Id + "\n");
                return expected;
            }
        }

        #endregion

        #region Fields

        private readonly Route route = new Route {
            Id = Guid.NewGuid(),
            Scale = 10
        };

        #endregion

        #region Constructors and Destructor

        public RouteSerializerTest() {
            route.Steps = new List<Step> {
                new Step {Point = new Point(0, 2) {Id = Guid.NewGuid()},  Route = route, Order = 1},
                new Step {Point = new Point(1, 3) {Id = Guid.NewGuid()},  Route = route, Order = 2},
                new Step {Point = new Point(4, 3) {Id = Guid.NewGuid()},  Route = route, Order = 3},
                new Step {Point = new Point(4, 6) {Id = Guid.NewGuid()},  Route = route, Order = 4},
                new Step {Point = new Point(2, 8) {Id = Guid.NewGuid()},  Route = route, Order = 5},
                new Step {Point = new Point(0, 8) {Id = Guid.NewGuid()},  Route = route, Order = 6},
                new Step {Point = new Point(0, 10) {Id = Guid.NewGuid()}, Route = route, Order = 7}
            };
        }

        #endregion

        #region Public Methods

        [TestMethod]
        public void Serialize_Takes_Route_Returns_Queue_of_String() {
            var result = RouteSerializer.Serialize(new Route());

            Assert.IsInstanceOfType(result, typeof (Queue<string>));
        }

        [TestMethod]
        public void Correctly_Serializes_Route_Started_From_0_0() {
            route.Start = new Start {
                Position = new Point(0, 0),
                Offset = new Point(1, 1)
            };

            var result = RouteSerializer.Serialize(route);

            Assert.AreEqual(14, result.Count);
            Assert.IsTrue(result.EqualsTo(ExpectedRouteStartedFrom_0_0));
        }

        [TestMethod]
        public void Correctly_Serializes_Route_Started_From_Point_Inside_Map() {
            route.Start = new Start {
                Position = new Point(5, 2),
                Offset = new Point(4, 1)
            };

            var result = RouteSerializer.Serialize(route);

            Assert.AreEqual(14, result.Count);
            Assert.IsTrue(result.EqualsTo(ExpectedRouteStartedFromPointInsideMap));
        }

        #endregion
    }
}

// ReSharper restore InconsistentNaming

public static class QueueExtensions
{
    #region Public Methods

    public static bool EqualsTo(this IEnumerable<string> expected, Queue<string> actual) {
        return !(from e in expected where !actual.Contains(e) select e).Any();
    }

    #endregion
}