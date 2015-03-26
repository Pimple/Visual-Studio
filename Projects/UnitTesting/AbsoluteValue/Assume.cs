using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics.Contracts;

namespace Demos
{
    public class Assume
    {
        public static int Div0(int p)
        {
            int x = p - 1;
            Contract.Assert(x != 0);
            return 5 / x;
        }

        public static int Div1(int p)
        {
            int x = p - 1;
            Contract.Assume(x != 0);
            return 5 / x;
        }
    }
}
