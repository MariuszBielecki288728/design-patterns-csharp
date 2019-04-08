using System;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestSingleton
{
    [TestClass]
    public class TestSingleton
    {
        [TestMethod]
        public void TestMethod1()
        {
            Singleton.Singleton instance1 = null;
            Singleton.Singleton instance2 = null;
            Thread t1 = new Thread(() => instance1 = Singleton.Singleton.Instance);
            Thread t2 = new Thread(() => instance2 = Singleton.Singleton.Instance);
            t1.Start(); t2.Start();
            t1.Join(); t2.Join();
            Assert.AreSame(instance1, instance2);
        }
    }
    [TestClass]
    public class TestThreadSingleton
    {
        [TestMethod]
        public void TestMethod1()
        {
            Singleton.ThreadSingleton instance1 = null;
            Singleton.ThreadSingleton instance2 = null;
            Thread t1 = new Thread(() => instance1 = Singleton.ThreadSingleton.Instance);
            Thread t2 = new Thread(() => instance2 = Singleton.ThreadSingleton.Instance);
            t1.Start(); t2.Start();
            t1.Join(); t2.Join();

            Assert.AreNotSame(instance1, instance2);
        }
    }

    [TestClass]
    public class TestFiveMinutesSingleton
    {
        [TestMethod]
        public void TestMethod1()
        {
            Singleton.FiveMinutesSingleton instance1 = Singleton.FiveMinutesSingleton.Instance;
            Singleton.FiveMinutesSingleton instance2 = Singleton.FiveMinutesSingleton.Instance;

            Assert.AreSame(instance1, instance2);
        }
        [TestMethod]
        public void TestMethod2()
        {
            Singleton.FiveMinutesSingleton instance1 = Singleton.FiveMinutesSingleton.Instance;
            Thread.Sleep(5001);
            Singleton.FiveMinutesSingleton instance2 = Singleton.FiveMinutesSingleton.Instance;

            Assert.AreNotSame(instance1, instance2);
        }
    }
}
