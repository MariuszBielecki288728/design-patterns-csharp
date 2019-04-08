using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Singleton
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    public class Singleton
    {
        private static Singleton instance = null;
        private static readonly object padlock = new object();

        Singleton()
        {
        }

        public static Singleton Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new Singleton();
                    }
                    return instance;
                }
            }
        }
    }

    public class ThreadSingleton
    {
        private static ThreadLocal<ThreadSingleton> _instance = new ThreadLocal<ThreadSingleton>();
        ThreadSingleton()
        {

        }

        public static ThreadSingleton Instance
        {
            get
            {
                if (_instance.IsValueCreated)
                {
                    return _instance.Value;
                }
                else
                {
                    _instance.Value = new ThreadSingleton();
                    return _instance.Value;
                }
            }
        }
    }

    public class FiveMinutesSingleton
    {
        private static FiveMinutesSingleton _instance = null;
        private static readonly object padlock = new object();
        private static Stopwatch stoper = new Stopwatch();
        FiveMinutesSingleton()
        {

        }

        public static FiveMinutesSingleton Instance
        {
            get
            {
                lock (padlock)
                {
                    if (_instance == null || stoper.IsRunning && stoper.ElapsedMilliseconds >= 5000)
                    {
                        stoper.Restart();
                        _instance = new FiveMinutesSingleton();
                    }
                    return _instance;
                }
            }
        }
    }
}
