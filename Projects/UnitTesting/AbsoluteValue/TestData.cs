using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics.Contracts;

namespace Demos
{
    public class TestData
    {
        public static void Range(int a, int b, int c)
        {
            Contract.Requires(a > 1 && b > 1 && c > 1);
            Contract.Requires(a * a + b * b == c * c);
            Contract.Assert(false);
        }

        public static int Power(int n)
        {
            Contract.Requires(0 <= n);
            Contract.Ensures(Contract.Result<int>() != 128);

            int res = 1;
            for (int i = 0; i < n; i++)
            {
                res = res * 2;
            }
            return res;
        }

        public static void RangeF(float a, float b, float c)
        {
            Contract.Requires(a > 1 && b > 1 && c > 1);
            Contract.Requires(a * a + b * b == c * c);
            Contract.Assert(false);
        }

        public static void Y2kParser(string s)
        {
            Contract.Requires(s != null);
            if (DateTime.Parse(s).Year == 2000)
                throw new Exception("found it");
        }        
    }
}
