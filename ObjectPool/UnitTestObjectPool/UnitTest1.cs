using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ObjectPool;

namespace UnitTestObjectPool
{
    [TestClass]
    public class UnitTestAirport
    {
        [TestMethod]
        public void TestMethod1()
        {
            Airport airport = new Airport(2);
            Plane plane1 = airport.AcquirePlane();
            Plane plane2 = airport.AcquirePlane();
            Plane plane3 = airport.AcquirePlane();

            Assert.IsNull(plane3);
            Assert.IsNotNull(plane2);
            Assert.IsNotNull(plane1);
            Assert.AreNotSame(plane1, plane2);

            bool b = airport.ReleasePlane(plane1);
            Assert.IsTrue(b);

            Plane plane4 = airport.AcquirePlane();
            Assert.AreSame(plane1, plane4);
        }
    }
}
