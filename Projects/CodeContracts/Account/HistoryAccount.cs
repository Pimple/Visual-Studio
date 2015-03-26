using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics.Contracts;

namespace Account
{
    class HistoryAccount
    {
        List<int> actions;

        public HistoryAccount()
        {
            actions = new List<int>();
        }

        public int Balance
        {
            get
            {
                int sum = 0;
                foreach (int a in actions) 
                    sum += a;
                return sum;
            }
        }

        public void Deposit(int amount)
        {
            Contract.Requires(0 <= amount);
            Contract.Ensures(Balance == Contract.OldValue(Balance) + amount);

            actions.Add(amount);
        }

        public void Withdraw(int amount)
        {
            Contract.Requires(0 <= amount);
            Contract.Requires(amount <= Balance);
            Contract.Ensures(Balance == Contract.OldValue(Balance) - amount);

            actions.Add(-amount);
        }
    }
}
