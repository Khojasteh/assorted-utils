// Copyright (c) 2019 Kambiz Khojasteh
// This file is part of the Assorted.Utils package which is released under the MIT software license.
// See the accompanying file LICENSE.txt or go to http://www.opensource.org/licenses/mit-license.php.

using System;
using System.Linq;

namespace Assorted.Utils.Serialization.Tests
{
    [Serializable]
    public class TestGraph: IEquatable<TestGraph>
    {
        public bool Boolean;
        public double Number;
        public string Text;
        public DateTime Date;
        public TestGraph[] Children;

        public bool Equals(TestGraph other)
        {
            return (other != null)
                && (other.Boolean == Boolean)
                && (other.Number == Number)
                && (other.Date == Date)
                && string.Equals(other.Text, Text, StringComparison.Ordinal)
                && EqualChildren(other.Children, Children);

            bool EqualChildren(TestGraph[] x, TestGraph[] y)
            {
                if (ReferenceEquals(x, y))
                    return true;

                if (x == null || y == null || x.Length != y.Length)
                    return false;

                return x.SequenceEqual(y);
            }
        }

        public static TestGraph CreateSample(int numberOfChildren)
        {
            var random = new Random();
            var sample = CreateSample(random);
            if (numberOfChildren > 0)
            {
                sample.Children = new TestGraph[numberOfChildren];
                for (var i = 0; i < numberOfChildren; ++i)
                    sample.Children[i] = CreateSample(random);
            }
            return sample;
        }

        public static TestGraph CreateSample(Random random)
        {
            return new TestGraph
            {
                Boolean = random.Next(2) == 1,
                Number = random.NextDouble(),
                Date = DateTime.UtcNow.Date.AddSeconds(random.Next(24 * 60 * 60)),
                Text = new string(Enumerable.Range(0, random.Next(50)).Select(i => (char)(random.Next(26) + 'A')).ToArray()),
            };
        }
    }
}
