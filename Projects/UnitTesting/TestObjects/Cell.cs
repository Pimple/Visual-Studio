using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics.Contracts;

namespace TestObjects
{
    public class Cell
    {
        public int value;        

        [Pure]
        public int Get()
        {
            return value;
        }

        public void Inc()
        {
            value++;
        }

        public int Demo()
        {
            Contract.Requires(Get() == 5);
            Contract.Ensures(Contract.Result<int>() == 2);  // should fail

            return 5 / value;
        }
    }
}
