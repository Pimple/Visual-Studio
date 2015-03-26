using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics.Contracts;

namespace Invariants
{
    class Tuple
    {
        int val1;
        int val2;

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
            t.val1++;
        }

        public int Negate(int p)
        {
            int res = p / (val1 - val2 - 1);
            return res;
        }

        public void Bad()
        {
            this.val1++;
            int x = this.Negate(5);
            this.val2++;
        }

        static void Main(string[] args)
        {
            Contract.Requires(args.Length == 1);

            Tuple t1, t2;

            switch (args[0])
            {
                case "0":
                    t1 = new Tuple();
                    t1.Good();
                    break;
                case "1":
                    t1 = new Tuple();
                    t2 = new Tuple();
                    t1.Bad(t2);
                    int x = t2.Negate(5);
                    break;
                case "2":
                    t1 = new Tuple();
                    t1.Bad();
                    break;
            }
        }
    }
}
