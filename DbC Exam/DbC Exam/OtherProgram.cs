using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbC_Exam
{
	class OtherProgram
	{
		static void Main(string[] args)
		{
			Element<string>[] array = new Element<string>[10];
			array[0] = new Element<string>("Element 0", Color.RED);
			array[1] = new Element<string>("Element 1", Color.WHITE);
			array[2] = new Element<string>("Element 2", Color.GREEN);
			array[3] = new Element<string>("Element 3", Color.WHITE);
			array[4] = new Element<string>("Element 4", Color.GREEN);
			array[5] = new Element<string>("Element 5", Color.RED);
			array[6] = new Element<string>("Element 6", Color.GREEN);
			array[7] = new Element<string>("Element 7", Color.WHITE);
			array[8] = new Element<string>("Element 8", Color.RED);
			array[9] = new Element<string>("Element 9", Color.WHITE);

			foreach (Element<string> element in array)
				Console.Out.WriteLine(element.Color + "\t" + element.Value);

			HerpDerpSort(array);
			Console.Out.WriteLine("\nSorting array...\n");

			foreach (Element<string> element in array)
				Console.Out.WriteLine(element.Color + "\t" + element.Value);
		}
		
		private static void HerpDerpSort(Element<string>[] array)
		{
			Contract.Requires(array != null);
			Contract.Ensures(IsSorted(array));

			int i = 0;
			int lengthA = array.Length;

			Contract.Assert(i >= 0 && i <= array.Length);
			Contract.Assert(array.Length == lengthA);

			while (i < array.Length)
			{
				int j = i + 1;
				int lengthB = array.Length;

				Contract.Assert(j > i && j <= array.Length);
				Contract.Assert(lengthB == array.Length);

				while (j < array.Length)
				{
					if (White(array[i]) && Green(array[j]))
					{
						Element<string> temp = array[i];
						array[i] = array[j];
						array[j] = temp;
						break;
					}
					else if (Red(array[i]) && Green(array[j]) || White(array[j]))
					{
						Element<string> temp = array[i];
						array[i] = array[j];
						array[j] = temp;
					}
					j++;
					Contract.Assert(j > i && j <= array.Length);
					Contract.Assert(lengthB == array.Length);
				}
				i++;
				Contract.Assert(i >= 0 && i <= array.Length);
				Contract.Assert(array.Length == lengthA);
			}
		}

		[Pure]
		private static bool IsSorted(Element<string>[] array)
		{
			bool sorted = true;

			for (int i = 1; i < array.Length - 1; i++)
				if (Green(array[i]) && (White(array[i-1]) || Red(array[i-1])))
					sorted = false;
				else if (White(array[i]) && (Red(array[i-1]) || Green(array[i+1])))
					sorted = false;
				else if (Red(array[i]) && (White(array[i+1]) || Green(array[i+1])))
					sorted = false;
			
			return sorted;
		}

		[Pure]
		private static bool Green(Element<string> element)
		{
			Contract.Requires(element != null);
			return element.Color == Color.GREEN;
		}
		[Pure]
		private static bool White(Element<string> element)
		{
			Contract.Requires(element != null);
			return element.Color == Color.WHITE;
		}
		[Pure]
		private static bool Red(Element<string> element)
		{
			Contract.Requires(element != null);
			return element.Color == Color.RED;
		}
	}

	public enum Color
	{
		GREEN, RED, WHITE
	}

	public class Element<T>
	{
		public T Value { get; set; }
		public Color Color { get; set; }

		public Element(T value, Color color)
		{
			Contract.Ensures(Value.Equals(value));
			Contract.Ensures(Color.Equals(color));
			Value = value;
			Color = color;
		}
	}
}
