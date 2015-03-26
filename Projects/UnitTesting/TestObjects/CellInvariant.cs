using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics.Contracts;

namespace TestObjectsInvariant
{
    public class Cell 
    {
        private int value;

        [ContractInvariantMethod]
        private void ObjectInvariant()
        {
            Contract.Invariant(0 <= value);
        }

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
