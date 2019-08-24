// Copyright (c) 2019 Kambiz Khojasteh
// This file is part of the Assorted.Utils package which is released under the MIT software license.
// See the accompanying file LICENSE.txt or go to http://www.opensource.org/licenses/mit-license.php.

using NUnit.Framework;
using System.Text;

namespace Assorted.Utils.Text.Tests
{
    [TestFixture]
    [TestOf(typeof(StringBuilderPool))]
    public class StringBuilderPoolTests
    {
        [Test]
        public void TestImplicitCacting()
        {
            Assert.That(StringBuilderPool.Instance.Count, Is.Zero);
            using (var proxy = StringBuilderPool.Instance.Acquire())
            {
                AppendSomething(proxy);
                Assert.That(proxy.ToString(), Is.EqualTo("Something"));
            }
            Assert.That(StringBuilderPool.Instance.Count, Is.EqualTo(1));
            StringBuilderPool.Instance.Clear();
            Assert.That(StringBuilderPool.Instance.Count, Is.EqualTo(0));

            void AppendSomething(StringBuilder sb) => sb.Append("Something");
        }

        [Test]
        public void TestUpperBound()
        {
            Assert.That(StringBuilderPool.Instance.Count, Is.Zero);
            Recurse(99);
            Assert.That(StringBuilderPool.Instance.Count, Is.EqualTo(StringBuilderPool.Instance.MaxCapacity));
            StringBuilderPool.Instance.Clear();
            Assert.That(StringBuilderPool.Instance.Count, Is.EqualTo(0));

            void Recurse(int count)
            {
                if (count <= 0)
                    return;

                using (var proxy = StringBuilderPool.Instance.Acquire())
                {
                    proxy.Value.Append($"Test {count}");
                    Recurse(count - 1);
                    Assert.That(proxy.ToString(), Is.EqualTo($"Test {count}"));
                }
                Assert.That(StringBuilderPool.Instance.Count, Is.LessThanOrEqualTo(StringBuilderPool.Instance.MaxCapacity));
            }
        }
    }
}
