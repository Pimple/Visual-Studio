using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics.Contracts;

namespace Demos
{
    class ArrayContents
    {
        public string[] Create(int n)
        {
            Contract.Requires(0 <= n);
            Contract.Ensures(Contract.ForAll(Contract.Result<string[]>(), s => s != null));

            string[] res = new string[n];
            for (int i = 0; i < n; i++)
                res[i] = "Init";
            return res;
        }
    }
}
