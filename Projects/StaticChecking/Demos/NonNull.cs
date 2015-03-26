using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics.Contracts;

namespace Demos
{
    public class NonNull
    {
        public static void MyAssert(bool cond, string msg)
        {
            string log;
            if (cond)
                log = "OK";
            else
                log = msg;

            log = log.Trim();
            Console.WriteLine(log);
        }
    }
}
