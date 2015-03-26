using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics.Contracts;

namespace Warnings
{
    class Cell
    {
        public int val;

        public static void Alias(Cell c1, Cell c2)
        {
            Contract.Requires(c1 != null && c2 != null);

            c1.val = 5;
            c2.val = 7;
            Contract.Assert(c1.val == 5);
        }
    }
}
