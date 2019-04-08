using System;
using Factory;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestFactory
{
    [TestClass]
    public class TestFactory
    {
        [TestMethod]
        public void TestMethod1()
        {
            // klient
            ShapeFactory factory = new ShapeFactory();
            IShape square = factory.CreateShape( "Square", 5 );
            // rozszerzenie
            factory.RegisterWorker( new RectangleFactoryWorker() );
            IShape rect = factory.CreateShape( "Rectangle", 3, 5 );
        }
    }
}
