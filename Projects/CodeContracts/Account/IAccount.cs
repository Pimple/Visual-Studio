using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics.Contracts;

namespace Account
{
    [ContractClass(typeof(IAccountContracts))]
    public interface IAccount
    {
        [Pure]
        int Balance();

        void Deposit(int amount);
        
        void Withdraw(int amount);
    }

    [ContractClassFor(typeof(IAccount))]
    abstract public class IAccountContracts : IAccount
    {
        [Pure]
        public int Balance()
        {
            Contract.Ensures(0 <= Contract.Result<int>());
            return default(int);
        }

        public void Deposit(int amount)
        {
            Contract.Requires(0 <= amount);
            Contract.Ensures(Balance() == Contract.OldValue(Balance()) + amount);
        }

        public void Withdraw(int amount)
        {
            Contract.Requires(0 <= amount);
            Contract.Requires(amount <= Balance());
            Contract.Ensures(Balance() == Contract.OldValue(Balance()) - amount);
        }
    }

    public class MyAccount : IAccount
    {
        int balance;

        public int Balance()
        {
            return balance;
        }

        public void Deposit(int amount)
        {
            balance += amount;
        }

        public void Withdraw(int amount)
        {          
            balance -= amount;
        }

    }
}
