using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2015_03_26_Programming_with_Code_Contract
{
	class Program
	{
		static void Main(string[] args)
		{
			int[] integers = { 1, 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, 144 };
			IBag bag = new Bag(integers);
			bag.Remove(13);

			Console.Read();
		}
	}
}
