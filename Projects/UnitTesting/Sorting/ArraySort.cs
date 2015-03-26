using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics.Contracts;

namespace Sorting
{
    public class ArraySort
    {
        public static void Sort(int[] a)
        {
            Contract.Requires(a != null);
            Contract.Ensures(Contract.ForAll(0, a.Length, i => Contract.ForAll(i + 1, a.Length, j => a[i] <= a[j])));

            if (0 < a.Length)
            {
                q_sort(a, 0, a.Length - 1);
            }
        }

        
        private static void q_sort(int[] a, int left, int right)
        {
            int pivot, l_hold, r_hold;

            l_hold = left;
            r_hold = right;
            pivot = a[left];

            while (left < right)
            {
                while ((a[right] >= pivot) && (left < right))
                {
                    right--;
                }

                if (left != right)
                {
                    a[left] = a[right];
                    left++;
                }

                while ((a[left] <= pivot) && (left < right))
                {
                    left++;
                }

                if (left != right)
                {
                    a[right] = a[left];
                    right--;
                }
            }

            a[left] = pivot;
            pivot = left;
            left = l_hold;
            right = r_hold;

            if (left < pivot)
            {
                q_sort(a, left, pivot - 1);
            }

            if (right > pivot)
            {
                q_sort(a, pivot + 1, right);
            }
        }
    }
}
