using SandS.Algorithm.Library.SearchNamespace;
using SandS.Algorithm.Library.SortNamespace;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Management;

namespace SandS.Algorithm.Library.Other
{
    public class CoupleCollection<TKey, TValue> : ICoupleCollection<TKey, TValue>
        where TKey : IComparable
        where TValue : IComparable
    {
        public CoupleCollection() : this(32)
        {
        }

        public CoupleCollection(int capacity)
        {
            this.Capacity = capacity;

            this.keys = new List<TKey>(this.Capacity);
            this.values = new List<TValue>(this.Capacity);

            this.Enumerator = new CoupleCollectionEnumerator<TKey, TValue>(this.keys, this.values);
        }

        public int Count
        {
            get
            {
                return this.keys.Count;
            }
        }

        public ICollection<TKey> Keys
        {
            get
            {
                if (this.keys == null)
                {
                    return new TKey[0];
                }

                return this.keys;
            }
        }

        public ICollection<TValue> Values
        {
            get
            {
                if (this.values == null)
                {
                    return new TValue[0];
                }

                return this.values;
            }
        }

        private int Capacity { get; set; }
        private CoupleCollectionEnumerator<TKey, TValue> Enumerator { get; set; }
        private IList<TKey> keys { get; set; }
        private IList<TValue> values { get; set; }

        public bool IsReadOnly
        {
            get
            {
                return false;
            }
        }

        public TValue this[TKey key]
        {
            get
            {
                int position = this.FindKeyPosition(key);

                if (position < 0)
                {
                    throw new KeyNotFoundException($"Can't find key {key} in dictionary.");
                }

                return this.values[position];
            }

            set
            {
                if (key == null)
                {
                    throw new ArgumentNullException();
                }

                int position = this.FindKeyPosition(key);

                if (position < 0)
                {
                    throw new KeyNotFoundException($"Can't find key {key} in dictionary.");
                }

                this.values[position] = value;
            }
        }

        public void Add(KeyValuePair<TKey, TValue> item)
            => this.Add(item.Key, item.Value);

        public void Add(TKey key, TValue value)
        {
            if (key == null)
            {
                throw new ArgumentNullException();
            }

            int position = this.FindKeyPosition(key);

            if (position >= 0)
            {
                throw new InvalidOperationException($"Dictionary already contains key {key}");
            }

            this.keys.Add(key);
            EnsureKeySorted();
            position = this.FindKeyPosition(key);

            if (position == this.values.Count)
            {
                this.values.Add(value);
            }
            else
            {
                this.values.Insert(position, value);
            }

        }

        public void Clear()
        {
            this.keys.Clear();
            this.values.Clear();
        }

        public bool Contains(KeyValuePair<TKey, TValue> item)
        {
            return this.FindKeyPosition(item.Key) >= 0 && this.FindValuePosition(item.Value) >= 0;
        }

        public bool ContainsKey(TKey key)
        {
            return this.FindKeyPosition(key) >= 0;
        }

        public bool ContainsValue(TValue value)
        {
            return this.FindValuePosition(value) >= 0;
        }

        public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public int FindKeyPosition(TKey item)
        {
            return SearchingAlgorithm.Binary(this.keys, item, isPresorted: true);
        }

        public int FindValuePosition(TValue value)
        {
            return SearchingAlgorithm.Binary(this.values, value, isPresorted: true);
        }

        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {
            return this.Enumerator;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.Enumerator;
        }

        public bool Remove(KeyValuePair<TKey, TValue> item)
        {
            return this.keys.Remove(item.Key) && this.values.Remove(item.Value);
        }

        public bool Remove(TKey key)
        {
            int position = this.FindKeyPosition(key);

            if (position < 0)
            {
                throw new KeyNotFoundException($"Can't find key {key} in dictionary.");
            }

            this.keys.Remove(key);
            this.values.RemoveAt(position);

            return true;
        }

        public bool TryGetValue(TKey key, out TValue value)
        {
            int position = this.FindKeyPosition(key);

            if (position < 0)
            {
                value = default(TValue);
                return false;
            }

            value = this.values[position];
            return true;
        }

        private void EnsureKeySorted()
        {
            SortingAlgorithm.InsertSort(this.keys);
        }

        public int Compare(KeyValuePair<TKey, TValue> lhs, KeyValuePair<TKey, TValue> rhs)
        {
            return lhs.Value.CompareTo(rhs.Value);
        }
    }
}