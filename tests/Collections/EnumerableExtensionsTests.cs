// Copyright (c) 2019 Kambiz Khojasteh
// This file is part of the Assorted.Utils package which is released under the MIT software license.
// See the accompanying file LICENSE.txt or go to http://www.opensource.org/licenses/mit-license.php.

using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Assorted.Utils.Collections.Tests
{
    [TestFixture]
    [TestOf(typeof(EnumerableExtensions))]
    public class EnumerableExtensionsTests
    {
        [Test]
        public void Partition_Enumerable_But_InvalidParam([Range(-2, 0)] int partitionSize)
        {
            var source = Enumerable.Range(1, 1);

            Assert.Throws<ArgumentOutOfRangeException>(() => source.Partition(partitionSize));
        }

        [Test]
        public void Partition_Enumerable([Range(1, 6)] int partitionSize, [Range(0, 5)] int size)
        {
            var source = Enumerable.Range(1, size);
            var partitions = source.Partition(partitionSize);

            var expectedNumberOfPartitions = (source.Count() + partitionSize - 1) / partitionSize;
            var expectedPartitions = Enumerable.Range(0, expectedNumberOfPartitions).Select(i =>
                Enumerable.Range(i * partitionSize + 1, Math.Min(partitionSize, source.Count() - i * partitionSize)));

            Assert.That(partitions, Has.Exactly(expectedNumberOfPartitions).Items);
            Assert.That(partitions, Is.EqualTo(expectedPartitions));
        }

        [Test]
        public void Partition_List([Range(1, 6)] int partitionSize, [Range(0, 5)] int size)
        {
            var source = Enumerable.Range(1, size).ToList();
            var partitions = source.Partition(partitionSize);

            var expectedNumberOfPartitions = (source.Count + partitionSize - 1) / partitionSize;
            var expectedPartitions = Enumerable.Range(0, expectedNumberOfPartitions).Select(i =>
                Enumerable.Range(i * partitionSize + 1, Math.Min(partitionSize, source.Count - i * partitionSize)));

            Assert.That(partitions, Has.Exactly(expectedNumberOfPartitions).Items);
            Assert.That(partitions, Is.EqualTo(expectedPartitions));
        }

        [Test]
        public void Alternate_Enummerable_But_InvalidParam([Range(-2, 0)] int interval)
        {
            var source = Enumerable.Range(1, 1);

            Assert.Throws<ArgumentOutOfRangeException>(() => source.Alternate(interval));
        }

        [Test]
        public void Alternate_Enumerable([Range(1, 6)] int interval, [Range(0, 5)] int size)
        {
            var source = Enumerable.Range(1, size);
            var alternatedSource = source.Alternate(interval);

            Assert.That(alternatedSource, Is.SubsetOf(source));
            Assert.That(alternatedSource, Has.Exactly((source.Count() + interval - 1) / interval).Items);
            Assert.That(alternatedSource, Is.EqualTo(source.Where((value, index) => index % interval == 0)));
        }

        [Test]
        public void Cycle_Enumerable_But_InvalidParam([Range(-2, -1)] int times)
        {
            var source = Enumerable.Range(1, 1);

            Assert.Throws<ArgumentOutOfRangeException>(() => source.Cycle(times));
        }

        [Test]
        public void Cycle_Enumerable([Range(0, 6)] int times, [Range(0, 5)] int size)
        {
            var source = Enumerable.Range(1, size);
            var repeatedSource = source.Cycle(times);

            Assert.That(repeatedSource, Has.Exactly(times * source.Count()).Items);
            Assert.That(repeatedSource, Is.EqualTo(Enumerable.Range(1, times).SelectMany(i => source)));
        }

        [Test]
        public void Rotate_Enumerable_Left([Range(0, 6)] int count, [Range(0, 5)] int size)
        {
            var source = Enumerable.Range(1, size);
            var rotatedSource = source.RotateLeft(count);

            Assert.That(rotatedSource, Is.EquivalentTo(source));
            Assert.That(rotatedSource, Is.EqualTo(source.Skip(count).Concat(source.Take(count))));
        }

        [Test]
        public void Rotate_List_Left([Range(0, 6)] int count, [Range(0, 5)] int size)
        {
            var source = Enumerable.Range(1, size).ToList();
            var rotatedSource = source.RotateLeft(count);

            Assert.That(rotatedSource, Is.EquivalentTo(source));
            Assert.That(rotatedSource, Is.EqualTo(source.Skip(count).Concat(source.Take(count))));
        }

        [Test]
        public void Rotate_Enumerable_Right([Range(0, 6)] int count, [Range(0, 5)] int size)
        {
            var source = Enumerable.Range(1, size);
            var rotatedSource = source.RotateRight(count);

            Assert.That(rotatedSource, Is.EquivalentTo(source));
            Assert.That(rotatedSource, Is.EqualTo(source.Skip(source.Count() - count).Concat(source.Take(source.Count() - count))));
        }

        [Test]
        public void Rotate_List_Right([Range(0, 6)] int count, [Range(0, 5)] int size)
        {
            var source = Enumerable.Range(1, size).ToList();
            var rotatedSource = source.RotateRight(count);

            Assert.That(rotatedSource, Is.EquivalentTo(source));
            Assert.That(rotatedSource, Is.EqualTo(source.Skip(source.Count() - count).Concat(source.Take(source.Count() - count))));
        }

        [Test]
        public void Shuffle_Enumerable([Range(0, 6)] int size)
        {
            var source = Enumerable.Range(1, size);
            var shuffled1 = source.Shuffle();
            var shuffled2 = source.Shuffle();

            Assert.That(shuffled1, Is.EquivalentTo(source));
            Assert.That(shuffled2, Is.EquivalentTo(source));

            if (size > 2)
                Assert.That(shuffled1, Is.Not.EqualTo(shuffled2));
        }

        [Test]
        public void ForEach_Element_Of_Enumerable_As_Lazy([Range(0, 5)] int size)
        {
            var source = Enumerable.Range(1, size);

            var sum = 0;
            var result = source.Apply(i => sum += i).Select(i => -i);

            Assert.That(sum, Is.Zero);
            Assert.That(result, Is.EqualTo(source.Select(i => -i)));
            Assert.That(sum, Is.EqualTo(source.Sum()));
        }

        [Test]
        public void ForEach_Element_Of_Enumerable_As_Eager([Range(0, 5)] int size)
        {
            var source = Enumerable.Range(1, size);

            var sum = 0;
            source.ForEach(i => sum += i);

            Assert.That(sum, Is.EqualTo(source.Sum()));
        }

        [Test]
        public void As_Array_From_Enumerable([Range(0, 5)] int size)
        {
            var source = Enumerable.Range(1, size);
            var array = source.AsArray();

            Assert.That(array, Is.AssignableTo<int[]>());
            Assert.That(array, Is.EqualTo(source).And.Not.SameAs(source));
        }

        [Test]
        public void As_Array_From_Array([Range(0, 5)] int size)
        {
            var source = Enumerable.Range(1, size).ToArray();
            var array = source.AsArray();

            Assert.That(array, Is.AssignableTo<int[]>());
            Assert.That(array, Is.SameAs(source));
        }

        [Test]
        public void As_Collection_From_Enumerable([Range(0, 5)] int size)
        {
            var source = Enumerable.Range(1, size);
            var collection = source.AsCollection();

            Assert.That(collection, Is.AssignableTo<IReadOnlyCollection<int>>());
            Assert.That(collection, Is.EqualTo(source).And.Not.SameAs(source));
        }

        [Test]
        public void As_Collection_From_Collection([Range(0, 5)] int size)
        {
            var source = Enumerable.Range(1, size).ToList();
            var collection = source.AsCollection();

            Assert.That(collection, Is.AssignableTo<IReadOnlyCollection<int>>());
            Assert.That(collection, Is.SameAs(source));
        }

        [Test]
        public void As_List_From_Enumerable([Range(0, 5)] int size)
        {
            var source = Enumerable.Range(1, size);
            var collection = source.AsCollection();

            Assert.That(collection, Is.AssignableTo<IReadOnlyList<int>>());
            Assert.That(collection, Is.EqualTo(source).And.Not.SameAs(source));
        }

        [Test]
        public void As_List_From_List([Range(0, 5)] int size)
        {
            var source = Enumerable.Range(1, size).ToList();
            var collection = source.AsCollection();

            Assert.That(collection, Is.AssignableTo<IReadOnlyList<int>>());
            Assert.That(collection, Is.SameAs(source));
        }

        [Test]
        public void As_Set_From_Enumerable([Range(0, 5)] int size)
        {
            var source = Enumerable.Range(1, size).SelectMany(i => Enumerable.Repeat(i, 2));
            var theSet = source.AsSet();

            Assert.That(theSet, Is.AssignableTo<ISet<int>>());
            Assert.That(theSet, Is.EquivalentTo(Enumerable.Range(1, size)));
        }

        [Test]
        public void As_Set_From_Set([Range(0, 5)] int size)
        {
            var source = new HashSet<int>(Enumerable.Range(1, size));
            var theSet = source.AsSet();

            Assert.That(theSet, Is.AssignableTo<ISet<int>>());
            Assert.That(theSet, Is.SameAs(source));
        }

        [Test]
        public void Add_Enummerable_To_Collection()
        {
            var source = new[] { 2, 4 };
            var targetCollection = new HashSet<int>(new[] { 1, 3, 5 });

            source.AddTo(targetCollection);

            Assert.That(targetCollection, Is.EquivalentTo(new[] { 1, 2, 3, 4, 5 }));
        }

        [Test]
        public void Add_Enumerable_To_List()
        {
            var source = new[] { 2, 4 };
            var targetList = new List<int>(new[] { 1, 3, 5 });

            source.AddTo(targetList);

            Assert.That(targetList, Is.EqualTo(new[] { 1, 3, 5, 2, 4 }));
        }

        [Test]
        public void Remove_Enumerable_From_Collection()
        {
            var source = new[] { 1, 3, 5 };
            var target = new HashSet<int>(new[] { 1, 2, 3, 4, 5 });

            source.RemoveFrom(target);

            Assert.That(target, Is.EquivalentTo(new[] { 2, 4 }));
        }


        [TestCase(new int[] { }, new int[] { }, ExpectedResult = 0)]
        [TestCase(new int[] { }, new int[] { 1 }, ExpectedResult = 1)]
        [TestCase(new int[] { 1 }, new int[] { }, ExpectedResult = 1)]
        [TestCase(new int[] { 1 }, new int[] { 1 }, ExpectedResult = 0)]
        [TestCase(new int[] { 1 }, new int[] { 2 }, ExpectedResult = 1)]
        [TestCase(new int[] { 1, 2 }, new int[] { 1 }, ExpectedResult = 1)]
        [TestCase(new int[] { 1, 2 }, new int[] { 2, 1 }, ExpectedResult = 1)]
        [TestCase(new int[] { 1, 2, 3 }, new int[] { 1, 3 }, ExpectedResult = 1)]
        [TestCase(new int[] { 1, 3 }, new int[] { 1, 2, 3 }, ExpectedResult = 1)]
        [TestCase(new int[] { 1, 2, 3 }, new int[] { 1, 2, 3 }, ExpectedResult = 0)]
        [TestCase(new int[] { 1, 3, 2 }, new int[] { 1, 2, 3 }, ExpectedResult = 1)]
        [TestCase(new int[] { 1, 2, 3, 4 }, new int[] { 2, 1, 4, 3 }, ExpectedResult = 2)]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, new int[] { 2, 1, 5 }, ExpectedResult = 3)]
        public int Damerau_Levenshtein_Distance(IEnumerable<int> s1, IEnumerable<int> s2)
        {
            return s1.DamerauLevenshteinDistance(s2);
        }
    }
}