using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics.Contracts;

namespace Map
{
    public class NoSuchElementException : Exception
    {
    }

    public class Map<K, V> where K : class
    {
        K[] keys = new K[32];
        V[] values = new V[32];
        int count;

        [Pure]
        public bool Contains(K key)
        {
            for (int i = 0; i < count; i++)
                if (keys[i] == key)
                    return true;
            return false;
        }

        public V Get0(K key)
        {
            Contract.Requires(Contains(key));

            for (int i = 0; i < count; i++)
                if (keys[i] == key)
                    return values[i];

            Contract.Assert(false);
            return default(V);
        }


        public V Get1(K key)
        {
            Contract.Ensures(Contract.OldValue(Contains(key)));
            Contract.EnsuresOnThrow<NoSuchElementException>(!Contract.OldValue(Contains(key)));

            for (int i = 0; i < count; i++)
                if (keys[i] == key)
                    return values[i];
            throw new NoSuchElementException();
        }

        public V Get2(K key, out bool present)
        {
            Contract.Ensures(Contract.ValueAtReturn(out present) == Contract.OldValue(Contains(key)));

            for (int i = 0; i < count; i++)
            {
                if (keys[i] == key)
                {
                    present = true;
                    return values[i];
                }
            }
            present = false;
            return default(V);
        }

        public void Add(K key, V value)
        {
            Contract.Assume(count < 32);  // this method is just there to suppress a compiler warning

            for (int i = 0; i < count; i++)
                if (keys[i] == key)
                {
                    values[i] = value;
                    return;
                }
            values[count] = value;
            count++;
        }
    }
}
