using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2
{
    class Program
    {
        static void Main(string[] args)
        {
            // Console.WriteLine(Methods.GetRandomFromRangeContracted(1, 10));
            // Violation: Console.WriteLine(Randomizer.GetRandomFromRangeContracted(10, 1)); 
            
			Product banana = new Product("Banana", 1.99);
			Product chocolate = new Product("Chocolate", 42);
			Product goldenToiletSeat = new Product("Golden Toilet Seat", 90.01);

			ShoppingCart cart = new ShoppingCart();
			Customer customer = cart.SetCustomer("Henrik", "ferociouscookiemonster@gmail.com");
			
			cart.AddProduct(banana, 7);
			cart.AddProduct(chocolate, 9);
			cart.AddProduct(goldenToiletSeat, 13);

			Dictionary<string, double> receipt = cart.Receipt();
			foreach (KeyValuePair<string, double> entry in receipt)
				Console.WriteLine(entry.Value + "\t" + entry.Key);
			
			Console.ReadLine();
        }
    }

    public class Methods
    {
        public static int GetRandomFromRangeContracted(int min, int max)
        {
            Contract.Requires<ArgumentOutOfRangeException>(
                min < max,
                "Min must be less than max"
            );

            Contract.Ensures(
                Contract.Result<int>() >= min &&
                Contract.Result<int>() <= max,
                "Return value is out of range"
            );

            var rnd = new Random();
            return rnd.Next(min, max);
        }
    }
}
