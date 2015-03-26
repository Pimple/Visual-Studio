using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2015_03_26_Programming_with_Code_Contract
{
	[ContractClass(typeof(ABag))]
	public interface IBag
	{
		[Pure]
		int Count();
		[Pure]
		int CountElem(int elem);
		[Pure]
		bool Contains(int elem);
		void Add(int elem);
		void Remove(int elem);
	}

	[ContractClassFor(typeof(IBag))]
	public abstract class ABag : IBag
	{
		[ContractInvariantMethod]
		private void ObjectInvariant()
		{
			Contract.Invariant(Count() >= 0);
			Contract.Invariant(CountElem(0) >= 0);
		}
		
		[Pure]
		public int Count()
		{
			Contract.Ensures(Contract.Result<Int32>() >= 0, 
				"There are less elements than 0!");
			return default(int);
		}

		[Pure]
		public int CountElem(int elem)
		{
			Contract.Requires(Contains(elem),
				"This element is not present in the bag!");
			Contract.Ensures(Contract.Result<Int32>() >= 0, 
				"There are less than 0 instances of this element in the bag!");
			return default(int);
		}

		[Pure]
		public bool Contains(int elem)
		{
			Contract.Ensures(Contract.OldValue<Int32>(Count()) == Count());
			return default(bool);
		}

		public void Add(int elem)
		{
			// Contract.Requires(elem != null);
			Contract.Ensures(Contract.OldValue<Int32>(Count()) == Count());
		}

		public void Remove(int elem)
		{
			Contract.Requires(Contains(elem));
			Contract.Ensures(!Contains(elem));
		}
	}

	public class Bag : IBag
	{
		private List<Int32> elements;

		public Bag()
		{
			this.elements = new List<Int32>();
		}
		public Bag(int[] elements)
		{
			this.elements = new List<Int32>();
			foreach (int i in elements)
			{
				this.elements.Add(i);
				Console.WriteLine(Count() + "");
			}
		}

		public int Count()
		{
			return elements.Count;
		}

		public int CountElem(int elem)
		{
			int quantity = 0;
			foreach (int i in elements)
				if (i == elem)
					quantity++;
			return quantity;
		}

		public bool Contains(int elem)
		{
			return elements.Contains(elem);
		}

		public void Add(int elem)
		{
			elements.Add(elem);
		}

		public void Remove(int elem)
		{
			elements.Remove(elem);
		}
	}
}
