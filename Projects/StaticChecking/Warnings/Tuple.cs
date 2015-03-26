using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics.Contracts;

namespace Warnings
{/*
    class Tuple
    {
        int val1 = 0;
        int val2 = 0;

        [ContractInvariantMethod]
        void ObjectInvariant()
        {
            Contract.Invariant(val1 == val2);
        }

        public void Good()
        {
            this.val1++;
        }

        public void Bad(Tuple t)
        {
            Contract.Requires(t != null);

            t.val1++;
            int x = t.Negate(5);
        }

        public int Negate(int p)
        {
            Contract.Requires(0 <= p);

            int res = p / (val1 - val2 - 1);
            return res;
        }
    }*/
}
