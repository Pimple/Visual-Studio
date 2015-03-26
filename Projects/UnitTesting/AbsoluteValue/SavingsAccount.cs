using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics.Contracts;

namespace Demos
{
    public class SavingsAccount
    {
        int balance;

        [ContractInvariantMethod]
        private void ObjectInvariant()
        {
            Contract.Invariant(0 <= balance);
        }

        [Pure]
        public int Balance()
        {
            return balance;
        }

        public SavingsAccount()
        {
            Contract.Ensures(0 == Balance());
        }

        public void Deposit(int amount)
        {
            Contract.Requires(0 <= amount);
            Contract.Ensures(Balance() == Contract.OldValue(Balance()) + amount);

            balance += amount;           
        }

        public void Withdraw(int amount)
        {
            Contract.Requires(0 <= amount);
            Contract.Requires(amount <= Balance());
            Contract.Ensures(Balance() == Contract.OldValue(Balance()) - amount);

            balance -= amount;
        }        
    }
}
