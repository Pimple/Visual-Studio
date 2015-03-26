using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics.Contracts;

namespace Account
{
    public class SavingsAccount
    {
        int balance;

        [ContractInvariantMethod]
        private void ObjectInvariant()
        {
            Contract.Invariant(0 <= balance);
        }

        public int Balance
        {
            get
            {
                return balance;
            }
        }


        public SavingsAccount()
        {
            Contract.Ensures(0 == balance);
        }

        public void Deposit(int amount)
        {
            Contract.Requires(0 <= amount);
            Contract.Ensures(balance == Contract.OldValue(balance) + amount);

            balance += amount;
        }

        public void Withdraw(int amount)
        {            
            Contract.Requires(0 <= amount);
            Contract.Requires(amount <= balance);
            Contract.Ensures(balance == Contract.OldValue(balance) - amount);

            balance -= amount;
        }

    }
}
