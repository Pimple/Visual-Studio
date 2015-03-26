using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics.Contracts;

namespace Warnings
{
    public class SpuriousErrors
    {
        public static void Content(string msg)
        {
            string s = "Hello World";
            Contract.Assert(s.Contains("Hello"));
        }

        /*
        public static void Loop()
        {
            int i = 0;
            while (i < 200)
            {
                i += 10;
            }
            Contract.Assert(i == 200);
        }*/

        /*
        public static bool Contains(int[] a, int x)
        {
            Contract.Requires(a != null);
            //Contract.Requires(Contract.ForAll(0, a.Length, i => Contract.ForAll(i+1, a.Length, j => a[i] <= a[j])));

            int from = 0;      // inclusive
            int to = a.Length; // exclusive

            while (from < to)
            {
                int split = (from + to) / 2;
                if (a[split] == x)
                    return true;
                if (a[split] < x)
                    from = split + 1;
                else
                    to = split;
            }
            return false;
        }*/
    }
}
