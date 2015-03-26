using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics.Contracts;

namespace Demos
{
    public class AbsoluteValue
    {
        public static int Abs(int x)
        {
            Contract.Ensures(0 <= Contract.Result<int>());

            if (x < 0)
            {
                return -x;
            }
            else
            {
                return x;
            }
        }
    }
}
