// Copyright (c) 2019 Kambiz Khojasteh
// This file is part of the Assorted.Utils package which is released under the MIT software license.
// See the accompanying file LICENSE.txt or go to http://www.opensource.org/licenses/mit-license.php.

using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Assorted.Utils.Text.Tests
{
    [TestFixture]
    [TestOf(typeof(StringStream))]
    public class StringStreamTests
    {
        [DatapointSource]
        static readonly string[] SampleStrings = new[]
        {
            "",
            "The quick brown fox jumps over the lazy dog",
            "روباه قعوه ای چابک بر روی سگ تنبل پرید",
            "敏捷的棕色狐狸跳过一只懒狗",
        };

        [DatapointSource]
        static readonly Encoding[] SampleEncodings = new[]
        {
            Encoding.UTF7,
            Encoding.UTF8,
            Encoding.UTF32,
            Encoding.Unicode,
        };

        [Theory]
        public void Expandable_WithoutInitialValue_DefaultEncoding(string data)
        {
            using (var stream = new StringStream())
            {
                Assert.That(stream.Encoding, Is.EqualTo(Encoding.UTF8));

                var bytes = stream.Encoding.GetBytes(data);
                stream.Write(bytes, 0, bytes.Length);
                Assert.That(stream.ToString(), Is.EqualTo(data));

                bytes = new byte[stream.Position];
                stream.Position = 0;
                stream.Read(bytes, 0, bytes.Length);
                Assert.That(stream.Encoding.GetString(bytes), Is.EqualTo(data));

                var oldCapacity = stream.Capacity;
                stream.Capacity += 100;
                Assert.That(stream.Capacity, Is.EqualTo(oldCapacity + 100));
            }
        }

        [Theory]
        public void Expandable_WithoutInitialValue_SpecificEncoding(string data, Encoding encoding)
        {
            using (var stream = new StringStream(encoding))
            {
                Assert.That(stream.Encoding, Is.EqualTo(encoding));

                var bytes = stream.Encoding.GetBytes(data);
                stream.Write(bytes, 0, bytes.Length);
                Assert.That(stream.ToString(), Is.EqualTo(data));

                bytes = new byte[stream.Position];
                stream.Position = 0;
                stream.Read(bytes, 0, bytes.Length);
                Assert.That(stream.Encoding.GetString(bytes), Is.EqualTo(data));

                var oldCapacity = stream.Capacity;
                stream.Capacity += 100;
                Assert.That(stream.Capacity, Is.EqualTo(oldCapacity + 100));
            }
        }

        [Theory]
        public void NotExpandable_WithInitialValue_DefaultEncoding(string data)
        {
            using (var stream = new StringStream(data))
            {
                Assert.That(stream.Encoding, Is.EqualTo(Encoding.UTF8));
                Assert.That(stream.ToString(), Is.EqualTo(data));

                var bytes = new byte[stream.Length];
                stream.Read(bytes, 0, bytes.Length);
                Assert.That(stream.Encoding.GetString(bytes), Is.EqualTo(data));

                Assert.Throws<NotSupportedException>(() => stream.Capacity += 100);
            }
        }

        [Theory]
        public void NotExpandable_WithInitialValue_SpecificEncoding(string data, Encoding encoding)
        {
            using (var stream = new StringStream(data, encoding))
            {
                Assert.That(stream.Encoding, Is.EqualTo(encoding));
                Assert.That(stream.ToString(), Is.EqualTo(data));

                var bytes = new byte[stream.Length];
                stream.Read(bytes, 0, bytes.Length);
                Assert.That(stream.Encoding.GetString(bytes), Is.EqualTo(data));

                Assert.Throws<NotSupportedException>(() => stream.Capacity += 100);
            }
        }
    }
}