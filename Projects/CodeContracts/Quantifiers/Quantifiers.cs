using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics.Contracts;

namespace Quantifiers
{
    public class Quantifiers
    {
        public static int Max(int[] a)
        {
            Contract.Requires(a != null && 0 < a.Length);
            Contract.Ensures(Contract.ForAll(0, a.Length, i => a[i] <= Contract.Result<int>()));
            Contract.Ensures(Contract.Exists(0, a.Length, i => a[i] == Contract.Result<int>()));

            int res = Int32.MinValue;
            for (int i = 0; i < a.Length; i++)
                if (a[i] > res)
                    res = a[i];

            return res;
        }

        public static bool Contains(ICollection<string> students, string name)
        {
            Contract.Requires(students != null && name != null);
            Contract.Requires(Contract.ForAll<string>(students, s => s != null));
            Contract.Ensures(Contract.Result<bool>() == Contract.Exists<string>(students, s => s.Equals(name)));

            foreach (string s in students)
                if (s.Equals(name))
                    return true;

            return false;
        }
    }
}
