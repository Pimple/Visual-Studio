using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbC_Exam
{
	class Program
	{
		static void Main(string[] args)
		{
			PriorityQueue<string> queue = new PriorityQueue<string>();
			
			queue.Insert("Dasher", 4);
			queue.Insert("Dancer", 2);
			queue.Insert("Prancer", 8);
			queue.Insert("Vixen", 5);
			queue.Insert("Comet", 5);
			queue.Insert("Cupid", 6);
			queue.Insert("Dunder", 4);
			queue.Insert("Blixem", 1);
			queue.Insert("Rudolph", 9001);
			queue.Insert("Santa", 0);

			int deletions = 5;
			for (int i = 0; i < deletions; i++)
				queue.Remove();

			queue.PrintQueue();
		}
	}

	public class PriorityQueue<T>
	{
		private Item<T>[] items;
		private int quantity;

		public PriorityQueue()
		{
			Contract.Ensures(quantity == 0);
			Contract.Ensures(items != null && items.Length == 10);

			items = new Item<T>[10];
			quantity = 0;
		}

		private class Item<E>
		{
			public int Priority { get; set; }
			public E Value { get; set; }

			public Item(E value, int priority)
			{
				Contract.Requires(value != null);
				Contract.Ensures(Value.Equals(value));
				Contract.Ensures(Priority == priority);
				Priority = priority;
				Value = value;
			}
		}

		public void Insert(T newValue, int priority)
		{
			// it would probably be a good idea for newValue not to be null, but 
			// the way I have implemented it, one could just add a null value with 
			// a priority... Since priority is an int and ints are easily 
			// comparable, it doesn't matter what int is specified.

			Contract.Ensures(quantity == Contract.OldValue<int>(quantity) + 1);
			Contract.Ensures(items[quantity-1].Value.Equals(newValue) 
				&& items[quantity-1].Priority == priority);

			if (items.Length == quantity)
			{
				Item<T>[] oldNumbers = items;
				items = new Item<T>[quantity * 2];
				for (int i = 0; i < quantity; i++)
					items[i] = oldNumbers[i];
			}
			items[quantity] = new Item<T>(newValue, priority);
			
			quantity++;
		}

		public void Remove()
		{
			// If empty, you can still run this but it won't do anything. Therefore, 
			// it requires nothing that isn't ensured by the constructor.

			Contract.Ensures(quantity == Contract.OldValue<int>(quantity) - 1 || quantity == 0);

			if (quantity > 0)
			{
				int indexToRemove = -1;
				for (int i = 0; i < quantity; i++)
					if (indexToRemove == -1 && items[i] != null)
						indexToRemove = i;
					else if (items[i] != null)
						if (items[indexToRemove].Priority < items[i].Priority)
							indexToRemove = i;
				items[indexToRemove] = null;

				// Defragmentation
				for (int i = indexToRemove; i < quantity-1; i++)
				{
					items[i] = items[i+1];
					items[i+1] = null;
				}
				if (quantity > 0)
					quantity--;
			}
		}

		[Pure]
		public bool IsEmpty()
		{
			bool isEmpty = true;
			foreach (Item<T> item in items)
				if (item != null)
					return false;
			return isEmpty;
		}

		[Pure]
		public void PrintQueue()
		{
			if (quantity > 0)
			{
				foreach (Item<T> item in items)
					if (item != null)
						Console.Out.WriteLine(item.Priority + "\t" + item.Value);
			}
			else
				Console.Out.WriteLine("The queue is empty.");
		}

		[ContractInvariantMethod]
		private void ObjectInvariant()
		{
			Contract.Invariant(quantity >= 0);
			Contract.Invariant(items != null);
			Contract.Invariant(items.Length >= quantity);
		}
	}
}
