// Copyright (c) 2019 Kambiz Khojasteh
// This file is part of the Assorted.Utils package which is released under the MIT software license.
// See the accompanying file LICENSE.txt or go to http://www.opensource.org/licenses/mit-license.php.

using NUnit.Framework;
using System.Text;

namespace Assorted.Utils.Collections.Tests
{
    [TestFixture]
    [TestOf(typeof(ObjectPool<>))]
    public class ObjectPoolTests
    {
        [Test]
        public void TestImplicitCacting()
        {
            using (var pool = new ObjectPool<StringBuilder>(() => new StringBuilder(), sb => sb.Length = 0))
            {
                Assert.That(pool.Count, Is.Zero);
                using (var proxy = pool.Acquire())
                {
                    AppendSomething(proxy);
                    Assert.That(proxy.ToString(), Is.EqualTo("Something"));
                }
                Assert.That(pool.Count, Is.EqualTo(1));
            }

            void AppendSomething(StringBuilder sb) => sb.Append("Something");
        }

        [Test]
        public void TestDefaultConstructor()
        {
            using (var pool = new ObjectPool<StringBuilder>(sb => sb.Length = 0))
            {
                Assert.That(pool.Count, Is.Zero);
                using (var proxy = pool.Acquire())
                {
                    proxy.Value.Append("Test");
                    Assert.That(proxy.ToString(), Is.EqualTo("Test"));
                }
                Assert.That(pool.Count, Is.EqualTo(1));
            }
        }

        [Test]
        public void TestWithoutUpperBound()
        {
            using (var pool = new ObjectPool<StringBuilder>(() => new StringBuilder(), sb => sb.Length = 0))
            {
                Assert.That(pool.Count, Is.Zero);
                Recurse(pool, 99);
                Assert.That(pool.Count, Is.EqualTo(99));
                pool.Clear();
                Assert.That(pool.Count, Is.EqualTo(0));
            }

            void Recurse(ObjectPool<StringBuilder> pool, int count)
            {
                if (count <= 0)
                    return;

                using (var proxy = pool.Acquire())
                {
                    proxy.Value.Append($"Test {count}");
                    Recurse(pool, count - 1);
                    Assert.That(proxy.ToString(), Is.EqualTo($"Test {count}"));
                }
                Assert.That(pool.Count, Is.EqualTo(count));
            }
        }

        [Test]
        public void TestWithUpperBound()
        {
            using (var pool = new ObjectPool<StringBuilder>(2, () => new StringBuilder(), sb => sb.Length = 0))
            {
                Assert.That(pool.Count, Is.Zero);
                Recurse(pool, 99);
                Assert.That(pool.Count, Is.EqualTo(pool.MaxCapacity));
                pool.Clear();
                Assert.That(pool.Count, Is.EqualTo(0));
            }

            void Recurse(ObjectPool<StringBuilder> pool, int count)
            {
                if (count <= 0)
                    return;

                using (var proxy = pool.Acquire())
                {
                    proxy.Value.Append($"Test {count}");
                    Recurse(pool, count - 1);
                    Assert.That(proxy.ToString(), Is.EqualTo($"Test {count}"));
                }
                Assert.That(pool.Count, Is.LessThanOrEqualTo(pool.MaxCapacity));
            }
        }
    }
}
