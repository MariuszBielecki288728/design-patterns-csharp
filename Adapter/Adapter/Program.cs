using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adapter
{
    class Program
    {
        public static object Assert { get; private set; }

        /* this is the Comparison<int> to be converted */
        static int IntComparer(int x, int y)
        {
            return x.CompareTo(y );
        }
        class IntComparerAdapter : IComparer
        {
            private Comparison<int> intComparer;
            public IntComparerAdapter(Comparison<int> intComparer)
            {
               this.intComparer = intComparer;
            }

            public int Compare(object x, object y)
            {
                return intComparer((int)x, (int)y);
            }
        }
        static void Main(string[] args)
        {
            ArrayList a = new ArrayList() { 1, 5, 3, 3, 2, 4, 3 };
            /* the ArrayList's Sort method accepts ONLY an IComparer */
            IComparer comp = new IntComparerAdapter(IntComparer);
            a.Sort(comp);
            Console.ReadLine();
        }
    }
}
