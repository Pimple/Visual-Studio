using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics.Contracts;
using System.Text.RegularExpressions;

namespace Demos
{
    public class ParseArray
    {
        // search for "Foo=VALUE" and return VALUE
        public static string ParseLines(string[] lines)
        {
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


        // search for "bla@bla.bla.ch" and return VALUE
        public static void ParseLinesRegex(string[] lines)
        {
            Contract.Requires(lines != null);
            Contract.Requires(Contract.ForAll<string>(lines, line => line != null));

            string pattern = @"\w+@\w+(\.\w+)*\.ch";
            for (int i = 0; i < lines.Length; i++)
            {
                string line = lines[i];
                if (Regex.IsMatch(line, pattern))
                {
                    Console.WriteLine(line);
                }
            }
        }
    }
}
