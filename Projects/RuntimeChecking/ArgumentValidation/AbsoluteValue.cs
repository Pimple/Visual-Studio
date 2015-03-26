using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics.Contracts;

namespace ArgumentValidation
{
    public class AbsoluteValue
    {
        public static int Abs0(int x)
        {
            if (x == Int32.MinValue)
                throw new ArgumentOutOfRangeException();

            if (x < 0)
            {
                return -x;
            }
            else
            {
                return x;
            }
        }

        public static int Abs1(int x)
        {
            Contract.Requires(x != Int32.MinValue);

            if (x < 0)
            {
                return -x;
            }
            else
            {
                return x;
            }
        }

        public static int Abs2(int x)
        {
            Contract.Requires<ArgumentOutOfRangeException>(x != Int32.MinValue);

            if (x < 0)
            {
                return -x;
            }
            else
            {
                return x;
            }
        }

        /*
        public static int Abs3(int x)
        {
            if (x == Int32.MinValue)
                throw new ArgumentOutOfRangeException();
            Contract.EndContractBlock();

            if (x < 0)
            {
                return -x;
            }
            else
            {
                return x;
            }
        }*/

        public static void Main(string[] args)
        {
            Contract.Requires(args.Length == 2);

            int val;
            if (args[1].Equals("min"))
                val = Int32.MinValue;
            else
                val = Int32.Parse(args[1]);

            int res = -1;
            switch (args[0])
            {
                case "0":
                    res = Abs0(val);
                    break;
                case "1":
                    res = Abs1(val);
                    break;
                case "2":
                    res = Abs2(val);
                    break;
                    /*
                case "3":
                    res = Abs3(val);
                    break;
                     * */
            }
            Console.WriteLine("Absolute value of " + val + " is " + res);
        }
    }
}
