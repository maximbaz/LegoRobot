using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model.Routing;
using lejOS.Routing;

// ReSharper disable InconsistentNaming

namespace lejOSTests
{
    [TestClass]
    public class VectorTest
    {
        #region Static Fields and Constants

        private const int Left = -1;
        private const int Right = 1;

        #endregion

        #region Public Methods

        [TestMethod]
        public void Correctly_Compute_0_Angle() {
            var start = new Vector(new Point(1, 1), new Point(1, 2));
            var finish = new Vector(new Point(2, 1), new Point(2, 2));

            Assert.AreEqual(0, start.AngleBetween(finish));
        }

        [TestMethod]
        public void Correctly_Compute_Left_45_Angle() {
            var start = new Vector(new Point(1, 1), new Point(1, 2));
            var finish = new Vector(new Point(1, 1), new Point(0, 2));

            Assert.AreEqual(45 * Left, start.AngleBetween(finish));
        }

        [TestMethod]
        public void Correctly_Compute_Left_90_Angle() {
            var start = new Vector(new Point(1, 1), new Point(1, 2));
            var finish = new Vector(new Point(1, 1), new Point(0, 1));

            Assert.AreEqual(90 * Left, start.AngleBetween(finish));
        }

        [TestMethod]
        public void Correctly_Compute_Left_135_Angle() {
            var start = new Vector(new Point(1, 1), new Point(1, 2));
            var finish = new Vector(new Point(1, 1), new Point(0, 0));

            Assert.AreEqual(135 * Left, start.AngleBetween(finish));
        }

        [TestMethod]
        public void Correctly_Compute_Right_45_Angle() {
            var start = new Vector(new Point(1, 1), new Point(1, 2));
            var finish = new Vector(new Point(1, 1), new Point(2, 2));

            Assert.AreEqual(45 * Right, start.AngleBetween(finish));
        }

        [TestMethod]
        public void Correctly_Compute_Right_90_Angle() {
            var start = new Vector(new Point(1, 1), new Point(1, 2));
            var finish = new Vector(new Point(1, 1), new Point(2, 1));

            Assert.AreEqual(90 * Right, start.AngleBetween(finish));
        }

        [TestMethod]
        public void Correctly_Compute_Right_135_Angle() {
            var start = new Vector(new Point(1, 1), new Point(1, 2));
            var finish = new Vector(new Point(1, 1), new Point(2, 0));

            Assert.AreEqual(135 * Right, start.AngleBetween(finish));
        }

        [TestMethod]
        public void Correctly_Compute_180_Angle() {
            var start = new Vector(new Point(1, 1), new Point(1, 2));
            var finish = new Vector(new Point(1, 1), new Point(1, 0));

            Assert.AreEqual(180, start.AngleBetween(finish));
        }

        #endregion
    }
}

// ReSharper restore InconsistentNaming