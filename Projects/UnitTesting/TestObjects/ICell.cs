using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics.Contracts;

namespace TestObjects
{
    [ContractClass(typeof(IContracts))]
    public interface ICell
    {
        [Pure]
        int Get();
    }



    [ContractClassFor(typeof(ICell))]
    abstract public class IContracts : ICell
    {
        public int Get()
        {
            return default(int);
        }
    }


    public class Client
    {
        public static int Demo(ICell c)
        {
            Contract.Requires(c != null);
            Contract.Requires(c.Get() == 5);
            Contract.Ensures(Contract.Result<int>() == 2);  // should fail

            return 5 / c.Get();

        }
    }    
}
