using SandS.Algorithm.CommonNamespace;
using SandS.Algorithm.Library.SortNamespace;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using Xunit;

namespace SandS.Algorithm.Library.OtherNamespace
{
    public class PlainDictionaryTest
    {
        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(16)]
        [InlineData(1024)]
        public void CCCtorMustWork_Positive(int capacity)
        {
            var cc = new CoupleCollection<int, int>(capacity);

            Assert.True(cc.Count == 0);
            Assert.NotNull(cc.Keys);
            Assert.NotNull(cc.Values);

            var en = cc.GetEnumerator();

            Assert.Throws(typeof(InvalidOperationException), () => { var a = en.Current; });
            Assert.False(en.MoveNext());

            ////

            var cc3 = new CoupleCollection<string, string>(capacity);

            Assert.True(cc3.Count == 0);
            Assert.NotNull(cc3.Keys);
            Assert.NotNull(cc3.Values);

            var en2 = cc3.GetEnumerator();

            Assert.Throws(typeof(InvalidOperationException), () => { var a = en2.Current; });
            Assert.False(en2.MoveNext());
        }

        [Theory]
        [InlineData(-1)]
        public void CCCtorMustWork_Negative(int capacity)
        {
            Assert.Throws(typeof(ArgumentOutOfRangeException), () => { var cc = new CoupleCollection<int, int>(capacity); });
            Assert.Throws(typeof(ArgumentOutOfRangeException), () => { var cc = new CoupleCollection<string, string>(capacity); });

        }

        [Theory]
        [InlineData(0,0)]
        [InlineData(0, 1)]
        [InlineData(1, 0)]
        [InlineData(19, 17)]
        [InlineData(17, 17)]
        public void CCAddMustAddOneElmnent(int x, int y)
        {
            var cc = new CoupleCollection<int, int>();

            cc.Add(x, y);

            Assert.True(cc.Count == 1, "! cc.Count == 1");
            Assert.True(cc.Keys.Count == 1, "! cc.Keys.Count == 1");
            Assert.True(cc.Values.Count == 1, "! cc.Values.Count == 1");
            Assert.True(cc.Contains(new KeyValuePair<int, int>(x, y)), "! cc.Contains(new KeyValuePair<int, int>(x, y))");
            Assert.True(cc.ContainsKey(x), "! cc.ContainsKey(x)");
            Assert.True(cc.ContainsValue(y), "! cc.ContainsValue(y)");
            Assert.True(cc.FindKeyPosition(x) == 0, "! cc.FindKeyPosition(x) == 0");
            Assert.True(cc.FindValuePosition(y) == 0, "! cc.FindValuePosition(y) == 0");

            int value;

            Assert.True(cc.TryGetValue(x, out value), "! cc.TryGetValue(x, out value)");
            Assert.True(value == y, "! value == y");
            Assert.False(cc.TryGetValue(11, out value), "! cc.TryGetValue(11, out value)"); // 11 must not came as inline data
            Assert.True(value == 0, "! value == 0");

            if (x != y)
            {
                Assert.False(cc.ContainsValue(x), "! cc.ContainsValue(x)");
                Assert.False(cc.ContainsKey(y), "! cc.ContainsKey(y)");
                Assert.True(cc.FindKeyPosition(y) == -1, "! cc.FindKeyPosition(y) == -1");
                Assert.True(cc.FindValuePosition(x) == -1, "! cc.FindValuePosition(x) == -1");
            }
        }

        [Theory]
        [InlineData(19, 17)]
        public void CCAddMustRemoveOneElmnent(int x, int y)
        {
            var cc = new CoupleCollection<int, int>();

            cc.Add(x, y);
            cc.Add(x*2, y*3);
            cc.Add(x*5, y*7);
            cc.Remove(x*2);

            Assert.True(cc.Count == 2, "! cc.Count == 2");
            Assert.True(cc.Keys.Count == 2, "! cc.Keys.Count == 2");
            Assert.True(cc.Values.Count == 2, "! cc.Values.Count == 2");

            Assert.True(cc.Contains(new KeyValuePair<int, int>(x, y)), "! cc.Contains(new KeyValuePair<int, int>(x, y))");
            Assert.True(cc.Contains(new KeyValuePair<int, int>(x*5, y*7)), "! cc.Contains(new KeyValuePair<int, int>(x*5, y*7))");
            Assert.False(cc.Contains(new KeyValuePair<int, int>(x*2, y*3)), "! cc.Contains(new KeyValuePair<int, int>(x*2, y*3))");

            Assert.True(cc.ContainsKey(x), "! cc.ContainsKey(x)");
            Assert.True(cc.ContainsValue(y), "! cc.ContainsValue(y)");
            Assert.True(cc.ContainsKey(x*5), "! cc.ContainsKey(x*5)");
            Assert.True(cc.ContainsValue(y*7), "! cc.ContainsValue(y*7)");
            Assert.False(cc.ContainsKey(x*2), "! cc.ContainsKey(x*2)");
            Assert.False(cc.ContainsValue(y*3), "! cc.ContainsValue(y*3)");

            Assert.True(cc.FindKeyPosition(x) == 0, "! cc.FindKeyPosition(x) == 0");
            Assert.True(cc.FindValuePosition(y) == 0, "! cc.FindValuePosition(y) == 0");
            Assert.True(cc.FindKeyPosition(x*5) == 1, "! cc.FindKeyPosition(x*5) == 1");
            Assert.True(cc.FindValuePosition(y*7) == 1, "! cc.FindValuePosition(y*7) == 1");
            Assert.True(cc.FindKeyPosition(x*2) == -1, "! cc.FindKeyPosition(x*2) == -1");
            Assert.True(cc.FindValuePosition(y*3) == -1, "! cc.FindValuePosition(y*3) == -1");

            int value;

            Assert.True(cc.TryGetValue(x, out value), "! cc.TryGetValue(x, out value)");
            Assert.True(value == y, "! value == y");
            Assert.True(cc.TryGetValue(x*5, out value), "! cc.TryGetValue(x*5, out value)");
            Assert.True(value == y*7, "! value == y*7");
            Assert.False(cc.TryGetValue(11, out value), "! cc.TryGetValue(11, out value)"); // 11 must not came as inline data
            Assert.True(value == 0, "! value == 0");
        }
    }
}
