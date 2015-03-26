using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics.Contracts;

namespace AbsoluteValue
{
    public class AbsDemo
    {
        /* this requires an invariant
            public int[] a;
            public int index;

            public void Resize()
            {
                Contract.Requires(a != null);
                Contract.Ensures(a != null);
                Contract.Ensures(Contract.OldValue(a.Length) < a.Length);
                int[] res = new int[a.Length * 2];
                Array.Copy(a, res, a.Length);
                a = res;
            }

            public void Add(int x)
            {
                Contract.Requires(a != null);
                Contract.Requires(0 <= index && index <= a.Length);
                if (index == a.Length)
                    Resize();
                a[index] = x;
                index++;
            }
        */

        public static int Average(int[] a)
        {
            Contract.Requires(a != null);
            Contract.Requires(0 < a.Length);
            int sum = 0;
            for (int i = 0; i < a.Length; i++)
            {
                sum += a[i];
            }
            return sum / a.Length;
        }

        public static int Average2(int[] a)
        {
            Contract.Requires(a != null);
            Contract.Requires(0 < a.Length);
            //Contract.Requires(Contract.Exists(0, a.Length, i => a[i] >= 0));
            int sum = 0;
            int count = 0;
            for (int i = 0; i <= a.Length; i++)
            {
                if (a[i] >= 0)
                {
                    sum += a[i];
                    count++;
                }
            }
            // change code to include conditional
            return sum / count;
        }

    

    }

}
