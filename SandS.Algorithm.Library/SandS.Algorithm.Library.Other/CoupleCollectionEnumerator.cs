using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SandS.Algorithm.Library.Other
{
    public class CoupleCollectionEnumerator<TKey, TValue> : IEnumerator<KeyValuePair<TKey, TValue>>
    {
        private IList<TKey> Keys { get; set; }
        private IList<TValue> Values { get; set; }

        public CoupleCollectionEnumerator(IEnumerable<TKey> keys, IEnumerable<TValue> values)
        {
            this.Keys = keys.ToList();
            this.Values = values.ToList();

            if (this.Keys.Count != this.Values.Count)
            {
                throw new InvalidOperationException();
            }
        }

        private int position = -1;

        public KeyValuePair<TKey, TValue> Current
        {
            get
            {
                if (position < 0 || position > this.Keys.Count)
                {
                    throw new InvalidOperationException($"At position {position} Current is undefined");
                }

                return new KeyValuePair<TKey, TValue>(this.Keys[this.position],
                                                        this.Values[this.position]);
            }
        }

        object IEnumerator.Current
        {
            get
            {
                return this.Current;
            }
        }

        public void Dispose() { }

        public bool MoveNext()
        {
            if (this.position >= 0 &&
                    this.position < this.Keys.Count)
            {
                ++this.position;
                return true;
            }

            return false;
        }

        public void Reset()
        {
            this.position = -1;
        }
    }
}
