using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics.Contracts;

namespace _2015_03_26_Programming_with_Code_Contract
{
	public class Account
	{
		public int Balance;
		public int Limit;

		public Account(int balance, int limit)
		{
			Contract.Requires(limit > 0);
			this.Balance = balance;
			this.Limit = limit;
		}

		public int Deposit(int amount)
		{
			Contract.Requires(amount > 0);
			Contract.Ensures(Contract.Result<Int32>() == Contract.OldValue(Balance) - amount);
			Balance += amount;
			return Balance;
		}

		public int Withdraw(int amount)
		{
			Contract.Requires(amount >= Balance);
			Contract.Ensures(Contract.Result<Int32>() == Contract.OldValue(Balance) - amount);
			if (amount <= Limit && amount < Balance)
				Balance -= amount;
			return Balance;
		}
	}
}
