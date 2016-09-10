using System;
using System.Collections.Generic;

namespace SandS.Algorithm.Library.Other
{
    public interface ICoupleCollection<TKey, TValue> :
        IEnumerable<KeyValuePair<TKey, TValue>>, ICollection<KeyValuePair<TKey, TValue>>, IComparer<KeyValuePair<TKey, TValue>>
        where TKey : IComparable
        where TValue : IComparable
    {
        TValue this[TKey key] { get; set; }

        int Count { get; }
        ICollection<TKey> Keys { get; }
        ICollection<TValue> Values { get; }

        void Add(KeyValuePair<TKey, TValue> item);
        void Add(TKey key, TValue value);
        void Clear();
        bool Contains(KeyValuePair<TKey, TValue> item);
        bool ContainsKey(TKey key);
        bool ContainsValue(TValue value);
        void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex);
        int FindKeyPosition(TKey item);
        int FindValuePosition(TValue value);
        IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator();
        bool Remove(TKey key);
        bool Remove(KeyValuePair<TKey, TValue> item);
        bool TryGetValue(TKey key, out TValue value);
    }
}