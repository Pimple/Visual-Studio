using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2
{
	public class ShoppingCart
	{
		private int priceLimit = 10000;
		private List<ProductLine> cart;
		private Customer customer;
		private CreditCard paymentStatus;

		public Customer Customer
		{
			get { return customer; }
			set { customer = value; }
		}

		public ShoppingCart()
		{
			cart = new List<ProductLine>();
		}

		[ContractInvariantMethod]
		private void ObjectInvariant()
		{
			Contract.Invariant(TotalPrice() <= priceLimit);
		}

		[Pure]
		private double TotalPrice()
		{
			double totalPrice = 0;
			foreach (ProductLine productLine in cart)
				totalPrice += productLine.TotalPrice();
			return totalPrice;
		}

		public ProductLine AddProduct(Product product, int quantity)
		{
			ProductLine productLine = new ProductLine(product, quantity);
			double newTotalPrice = TotalPrice() + productLine.TotalPrice();
			cart.Add(productLine);
			return productLine;
		}

		public Customer SetCustomer (string name, string email)
		{
			Customer newCustomer = new Customer(name, email);
			return newCustomer;
		}

		private string ForkOverTheCash(CreditCard status)
		{
			paymentStatus = status;
			switch (paymentStatus)
			{
				case (CreditCard.ACCEPTED):
					return "Your credit card was accepted!";
				case (CreditCard.REJECTED):
					return "Your credit card was rejected.";
				case (CreditCard.UNKNOWN):
					return "Your credit was was UNKNOWN'd. Better find out what that means.";
				default:
					return "I hope this is never returned."; // WHY?!
			}
		}

		private string Submit()
		{
			if (paymentStatus == CreditCard.ACCEPTED)
				if (customer != null)
					return "Your order has been completed. Congratulations on your choice of cash "
						 + "disposal. Please bring more money and come again.";
				else
					return "You forgot to tell us who you are, so we won't be delivering anything. "
						 + "Try again. However, your payment went through. Thanks!";
			else if (paymentStatus == CreditCard.REJECTED)
				return "Your credit card was rejected. Away with you, peasant!";
			else
				return "Your credit card was neither accepted or rejected. This makes no sense but "
					 + "please blame someone else. Good day.";
		}

		public Dictionary<string, double> Receipt()
		{
			Dictionary<string, double> receipt = new Dictionary<string,double>();
			foreach (ProductLine product in cart)
			{
				string products = product.Quantity + " " + product.Product.Name + "s";
				double price = product.TotalPrice();
				receipt.Add(products, price);
			}
			return receipt;
		}
	}

	public class ProductLine
	{
		private Product product;
		public Product Product
		{
			get { return product; }
			set { product = value; }
		}

		private int quantity;
		public int Quantity
		{
			get { return quantity; }
			set { quantity = value; }
		}

		public ProductLine(Product product, int newQuantity)
		{
			Product = product;
			Quantity = newQuantity;
		}

		public double TotalPrice()
		{
			return product.Price * quantity;
		}
	}

	public class Product
	{
		private string name;
		public string Name
		{
			get { return name; }
			set { name = value; }
		}

		private double price;
		public double Price
		{
			get { return price; }
			set { price = value; }
		}
		
		public Product(string newName, double newPrice)
		{
			Name = newName;
			Price = newPrice;
		}
	}
	
	public class Customer
	{
		private string name;
		public string Name
		{
			get { return name; }
			set { name = value; }
		}

		private string email;
		public string Email
		{
			get { return email; }
			set { email = value; }
		}

		public Customer(string newName, string newEmail)
		{
			Name = newName;
			Email = newEmail;
		}
	}

	public enum CreditCard
	{
		UNKNOWN, ACCEPTED, REJECTED
	}
}
