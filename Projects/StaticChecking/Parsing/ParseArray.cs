using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics.Contracts;

namespace Parsing
{
    public class ParseArray
    {
        // search for "Foo=VALUE" and return VALUE
        public static string ParseLines(string[] lines)
        {
            Contract.Ensures(Contract.Result<string>() != null);

            for (int i = 0; i < lines.Length; i++)
            {
                string line = lines[i];
                int index = line.IndexOf('=');
                string key = line.Substring(0, index);
                if (key.Equals("Foo"))
                {
                    return line.Substring(index + 1);
                }
            }
            return "??";
        }
    }
}
