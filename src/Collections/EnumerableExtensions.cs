using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Assorted.Utils.Collections
{
    /// <summary>
    /// Extends the enumerable objects.
    /// </summary>
    /// <threadsafety/>
    public static class EnumerableExtensions
    {
        /// <summary>
        /// Splits the sequence into a fixed-size chunks.
        /// </summary>
        /// <typeparam name="TSource">The type of elements in the <paramref name="source"/>.</typeparam>
        /// <param name="source">A sequence of values.</param>
        /// <param name="size">The size of each chunk.</param>
        /// <returns>An <see cref="IEnumerable{T}"/> where each of its elements are also an <see cref="IEnumerable{T}"/>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> is <see langword="null"/>.</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="size"/> is zero or negative.</exception>
        /// <remarks>
        /// This method is implemented by using deferred execution. The immediate return value is an object that stores all 
        /// the information that is required to perform the action.
        /// </remarks>
        public static IEnumerable<IEnumerable<TSource>> Partition<TSource>(this IEnumerable<TSource> source, int size)
        {
            Contract.Requires<ArgumentNullException>(source != null, nameof(source));
            Contract.Requires<ArgumentOutOfRangeException>(size > 0, nameof(size));

            return (source is IReadOnlyList<TSource> list) ? ListIterator() : GeneralIterator();

            IEnumerable<IEnumerable<TSource>> ListIterator()
            {
                var numberOfPartitions = (list.Count + size - 1) / size;
                for (var i = 0; i < numberOfPartitions; ++i)
                    yield return new ListSegment<TSource>(list, i * size, size);
            }

            IEnumerable<IEnumerable<TSource>> GeneralIterator()
            {
                using (var e = source.GetEnumerator())
                {
                    while (e.MoveNext())
                    {
                        var partition = new List<TSource>(size);
                        do { partition.Add(e.Current); } while (partition.Count < size && e.MoveNext());
                        yield return partition;
                    }
                }
            }
        }

        /// <summary>
        /// Returns the alternative elements of the sequence by a specific interval.
        /// </summary>
        /// <typeparam name="TSource">The type of elements in the <paramref name="source"/>.</typeparam>
        /// <param name="source">A sequence of values.</param>
        /// <param name="interval">The number of alternation.</param>
        /// <returns>An <see cref="IEnumerable{T}"/> where each of its elements are in the input sequence.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> is <see langword="null"/>.</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="interval"/> is zero or negative.</exception>
        /// <remarks>
        /// This method is implemented by using deferred execution. The immediate return value is an object that stores all 
        /// the information that is required to perform the action.
        /// </remarks>
        public static IEnumerable<TSource> Alternate<TSource>(this IEnumerable<TSource> source, int interval)
        {
            Contract.Requires<ArgumentNullException>(source != null, nameof(source));
            Contract.Requires<ArgumentOutOfRangeException>(interval > 0, nameof(interval));

            return Iterator();

            IEnumerable<TSource> Iterator()
            {
                using (var e = source.GetEnumerator())
                {
                    for (var n = 0; e.MoveNext(); --n)
                    {
                        if (n == 0)
                        {
                            yield return e.Current;
                            n = interval;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Repeats the sequence by a specific number of times.
        /// </summary>
        /// <typeparam name="TSource">The type of elements in the <paramref name="source"/>.</typeparam>
        /// <param name="source">A sequence of values.</param>
        /// <param name="times">The number of times to repeat the source sequence.</param>
        /// <returns>An <see cref="IEnumerable{T}"/> where each of its elements are in the input sequence.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> is <see langword="null"/>.</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="times"/> is negative.</exception>
        /// <remarks>
        /// This method is implemented by using deferred execution. The immediate return value is an object that stores all 
        /// the information that is required to perform the action.
        /// </remarks>
        public static IEnumerable<TSource> Cycle<TSource>(this IEnumerable<TSource> source, int times)
        {
            Contract.Requires<ArgumentNullException>(source != null, nameof(source));
            Contract.Requires<ArgumentOutOfRangeException>(times >= 0, nameof(times));

            return Iterator();

            IEnumerable<TSource> Iterator()
            {
                for (var i = 0; i < times; ++i)
                {
                    foreach (var current in source)
                        yield return current;
                }
            }
        }

        /// <summary>
        /// Rotates the sequence by a specific number of elements to left.
        /// </summary>
        /// <typeparam name="TSource">The type of elements in the <paramref name="source"/>.</typeparam>
        /// <param name="source">A sequence of values.</param>
        /// <param name="count">The number of elements to rotate. A negative value rotates the sequence to right.</param>
        /// <returns>An <see cref="IEnumerable{T}"/> where each of its elements are in the input sequence.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> is <see langword="null"/>.</exception>
        /// <remarks>
        /// This method is implemented by using deferred execution. The immediate return value is an object that stores all 
        /// the information that is required to perform the action.
        /// </remarks>
        /// <seealso cref="RotateRight" />
        public static IEnumerable<TSource> RotateLeft<TSource>(this IEnumerable<TSource> source, int count)
        {
            Contract.Requires<ArgumentNullException>(source != null, nameof(source));

            if (count == 0)
                return source;

            if (count < 0)
                return source.RotateRight(-count);

            return (source is IReadOnlyList<TSource> list) ? ListIterator() : GeneralIterator();

            IEnumerable<TSource> ListIterator()
            {
                var totalCount = list.Count;
                if (count > totalCount)
                    count = totalCount;
                for (var i = count; i < totalCount; ++i)
                    yield return list[i];
                for (var i = 0; i < count; ++i)
                    yield return list[i];
            }

            IEnumerable<TSource> GeneralIterator()
            {
                var rest = new TSource[count];
                using (var e = source.GetEnumerator())
                {
                    for (var i = 0; i < count; ++i)
                    {
                        if (!e.MoveNext())
                        {
                            count = i;
                            break;
                        }
                        rest[i] = e.Current;
                    }
                    while (e.MoveNext())
                        yield return e.Current;
                }
                for (var i = 0; i < count; ++i)
                    yield return rest[i];
            }
        }

        /// <summary>
        /// Rotates the sequence by a specific number of elements to right.
        /// </summary>
        /// <typeparam name="TSource">The type of elements in the <paramref name="source"/>.</typeparam>
        /// <param name="source">A sequence of values.</param>
        /// <param name="count">The number of elements to rotate. A negative value rotates the sequence to left.</param>
        /// <returns>An <see cref="IEnumerable{T}"/> where each of its elements are in the input sequence.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> is <see langword="null"/>.</exception>
        /// <remarks>
        /// This method is implemented by using deferred execution. The immediate return value is an object that stores all 
        /// the information that is required to perform the action.
        /// </remarks>
        /// <seealso cref="RotateLeft" />
        public static IEnumerable<TSource> RotateRight<TSource>(this IEnumerable<TSource> source, int count)
        {
            Contract.Requires<ArgumentNullException>(source != null, nameof(source));

            if (count == 0)
                return source;

            if (count < 0)
                return source.RotateLeft(-count);

            return Iterator();

            IEnumerable<TSource> Iterator()
            {
                var list = source.AsList();
                var totalCount = list.Count;
                if (count > totalCount)
                    count = totalCount;
                for (var i = totalCount - count; i < totalCount; ++i)
                    yield return list[i];
                for (var i = 0; i < totalCount - count; ++i)
                    yield return list[i];
            }
        }

        /// <summary>
        /// Shuffles elements of the sequence.
        /// </summary>
        /// <typeparam name="TSource">The type of elements in the <paramref name="source"/>.</typeparam>
        /// <param name="source">A sequence of values.</param>
        /// <returns>An <see cref="IEnumerable{T}"/> where each of its elements are in the input sequence.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> is <see langword="null"/>.</exception>
        /// <remarks>
        /// This method is implemented by using deferred execution. The immediate return value is an object that stores all 
        /// the information that is required to perform the action.
        /// </remarks>
        public static IEnumerable<TSource> Shuffle<TSource>(this IEnumerable<TSource> source)
        {
            Contract.Requires<ArgumentNullException>(source != null, nameof(source));

            return Iterator();

            IEnumerable<TSource> Iterator()
            {
                var random = RandomFactory.Create();
                var list = new List<TSource>(source);
                for (int i = 0, count = list.Count; i < count; ++i)
                {
                    var n = i + random.Next(count - i);
                    yield return list[n];
                    list[n] = list[i];
                }
            }
        }

        /// <summary>
        /// Performs an action (lazy) on each element of the sequence.
        /// </summary>
        /// <typeparam name="TSource">The type of elements in the <paramref name="source"/>.</typeparam>
        /// <param name="source">A sequence of values.</param>
        /// <param name="action">A delegate to perform on each element of the sequence.</param>
        /// <returns>An <see cref="IEnumerable{TSource}"/> where the <paramref name="action"/> is applied on its elements.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> or <paramref name="action"/> is <see langword="null"/>.</exception>
        /// <remarks>
        /// This method is implemented by using deferred execution. The immediate return value is an object that stores all 
        /// the information that is required to perform the action.
        /// </remarks>
        public static IEnumerable<TSource> Apply<TSource>(this IEnumerable<TSource> source, Action<TSource> action)
        {
            Contract.Requires<ArgumentNullException>(source != null, nameof(source));
            Contract.Requires<ArgumentNullException>(action != null, nameof(action));

            return Iterator();

            IEnumerable<TSource> Iterator()
            {
                foreach (var current in source)
                {
                    action(current);
                    yield return current;
                }
            }
        }

        /// <summary>
        /// Performs an action on each element of the sequence.
        /// </summary>
        /// <typeparam name="TSource">The type of elements in the <paramref name="source"/>.</typeparam>
        /// <param name="source">A sequence of values.</param>
        /// <param name="action">A delegate to perform on each element of the sequence.</param>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> or <paramref name="action"/> is <see langword="null"/>.</exception>
        public static void ForEach<TSource>(this IEnumerable<TSource> source, Action<TSource> action)
        {
            Contract.Requires<ArgumentNullException>(source != null, nameof(source));
            Contract.Requires<ArgumentNullException>(action != null, nameof(action));

            foreach (var current in source)
                action(current);
        }

        /// <summary>
        /// Executes the deferred operations of the sequence if there is any, and returns the evaluated sequence
        /// as an array.
        /// </summary>
        /// <typeparam name="TSource">The type of elements in the <paramref name="source"/>.</typeparam>
        /// <param name="source">A sequence of values.</param>
        /// <returns>
        /// The <paramref name="source"/> sequence if it is already an array; 
        /// otherwise, an array that contains values from the input sequence.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> is <see langword="null"/>.</exception>
        public static TSource[] AsArray<TSource>(this IEnumerable<TSource> source)
        {
            Contract.Requires<ArgumentNullException>(source != null, nameof(source));

            return (source as TSource[]) ?? source.ToArray();
        }

        /// <summary>
        /// Executes the deferred operations of the sequence if there is any, and returns the evaluated sequence
        /// as a read-only collection.
        /// </summary>
        /// <typeparam name="TSource">The type of elements in the <paramref name="source"/>.</typeparam>
        /// <param name="source">A sequence of values.</param>
        /// <returns>
        /// The <paramref name="source"/> sequence if it is already a read-only collection; 
        /// otherwise, an <see cref="IReadOnlyCollection{T}"/> that contains values from the input sequence.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> is <see langword="null"/>.</exception>
        public static IReadOnlyCollection<TSource> AsCollection<TSource>(this IEnumerable<TSource> source)
        {
            Contract.Requires<ArgumentNullException>(source != null, nameof(source));

            return (source as IReadOnlyCollection<TSource>) ?? new List<TSource>(source);
        }

        /// <summary>
        /// Executes the deferred operations of the sequence if there is any, and returns the evaluated sequence 
        /// as a read-only list.
        /// </summary>
        /// <typeparam name="TSource">The type of elements in the <paramref name="source"/>.</typeparam>
        /// <param name="source">A sequence of values.</param>
        /// <returns>
        /// The <paramref name="source"/> sequence if it is already a read-only list; 
        /// otherwise, an <see cref="IReadOnlyList{T}"/> that contains values from the input sequence.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> is <see langword="null"/>.</exception>
        public static IReadOnlyList<TSource> AsList<TSource>(this IEnumerable<TSource> source)
        {
            Contract.Requires<ArgumentNullException>(source != null, nameof(source));

            return (source as IReadOnlyList<TSource>) ?? new List<TSource>(source);
        }

        /// <summary>
        /// Executes the deferred operations of the sequence if there is any, and returns the unique elements of 
        /// the evaluated sequence as a set.
        /// </summary>
        /// <typeparam name="TSource">The type of elements in the <paramref name="source"/>.</typeparam>
        /// <param name="source">A sequence of values.</param>
        /// <returns>
        /// The <paramref name="source"/> sequence if it is already a set; 
        /// otherwise, an <see cref="ISet{T}"/> that contains values from the input sequence.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> is <see langword="null"/>.</exception>
        public static ISet<TSource> AsSet<TSource>(this IEnumerable<TSource> source)
        {
            Contract.Requires<ArgumentNullException>(source != null, nameof(source));

            return (source as ISet<TSource>) ?? new HashSet<TSource>(source);
        }

        /// <summary>
        /// Adds elements of the sequence to a specific collection.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements in the sequence and the <paramref name="collection"/>.</typeparam>
        /// <param name="source">A sequence of values.</param>
        /// <param name="collection">The collection which the elements will be added to.</param>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> or <paramref name="collection"/> is <see langword="null"/>.</exception>
        public static void AddTo<TSource>(this IEnumerable<TSource> source, ICollection<TSource> collection)
        {
            Contract.Requires<ArgumentNullException>(source != null, nameof(source));
            Contract.Requires<ArgumentNullException>(collection != null, nameof(collection));

            if (collection is List<TSource> list)
            {
                list.AddRange(source);
            }
            else 
            {
                foreach (var current in source)
                    collection.Add(current);
            }
        }

        /// <summary>
        /// Removes elements of the sequence from a specific collection.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements in the sequence and the <paramref name="collection"/>.</typeparam>
        /// <param name="source">A sequence of values.</param>
        /// <param name="collection">The collection which the elements will be removed from.</param>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> or <paramref name="collection"/> is <see langword="null"/>.</exception>
        public static void RemoveFrom<TSource>(this IEnumerable<TSource> source, ICollection<TSource> collection)
        {
            Contract.Requires<ArgumentNullException>(source != null, nameof(source));
            Contract.Requires<ArgumentNullException>(collection != null, nameof(collection));

            foreach (var current in source)
                collection.Remove(current);
        }

        /// <summary>
        /// Returns the Damerau-Levenshtein distance of this sequence to a specified sequence.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements in the sequences.</typeparam>
        /// <param name="source">A sequence of values.</param>
        /// <param name="other">The sequence to calculate the edit distance to.</param>
        /// <returns>The distance as a non-negative integer where zero indicates that both sequences are equal.</returns>
        /// <remarks>
        /// The Damerau-Levenshtein distance is defined as the minimum number of primitive edit operations 
        /// needed to transform one sequence into the other and these operations are substitution, deletion, 
        /// insertion and the transposition of two adjacent elements.
        /// </remarks>
        public static int DamerauLevenshteinDistance<TSource>(this IEnumerable<TSource> source, IEnumerable<TSource> other)
        {
            Contract.Requires<ArgumentNullException>(source != null, nameof(source));
            Contract.Requires<ArgumentNullException>(other != null, nameof(other));

            var sourceCollection = source as IReadOnlyCollection<TSource>;
            var otherCollection = other as IReadOnlyCollection<TSource>;

            if (sourceCollection != null && otherCollection != null)
                if (sourceCollection.Count >= otherCollection.Count)
                    return CalcDistance(sourceCollection, otherCollection);
                else
                    return CalcDistance(otherCollection, sourceCollection);
            else if (otherCollection != null)
                return CalcDistance(source, otherCollection);
            else if (sourceCollection != null)
                return CalcDistance(other, sourceCollection);
            else
                return CalcDistance(source, other.ToList());

            int CalcDistance(IEnumerable<TSource> enumerable, IReadOnlyCollection<TSource> collection)
            {
                if (collection.Count == 0)
                    return enumerable.Count();

                var costs = new int[collection.Count];
                for (var i = 0; i < costs.Length; ++i)
                    costs[i] = i + 1;

                using (var x = enumerable.GetEnumerator())
                {
                    var xPrevious = default(TSource);
                    for (var i = 0; x.MoveNext(); ++i)
                    {
                        var xCurrent = x.Current;
                        var prvCost = i;
                        var cost = i + 1;
                        using (var y = collection.GetEnumerator())
                        {
                            var yPrevious = default(TSource);
                            for (var k = 0; y.MoveNext(); ++k)
                            {
                                var yCurrent = y.Current;
                                if (Equals(xCurrent, yCurrent) || (i != 0 && k != 0 && Equals(xCurrent, yPrevious) && Equals(xPrevious, yCurrent)))
                                    cost = prvCost;
                                else
                                    cost = 1 + Math.Min(Math.Min(cost, prvCost), costs[k]);
                                prvCost = costs[k];
                                costs[k] = cost;
                                yPrevious = yCurrent;
                            }
                        }
                        xPrevious = xCurrent;
                    }
                }
                return costs[costs.Length - 1];
            }
        }

        #region Helpers

        private static class RandomFactory
        {
            private static int counter;

            public static Random Create()
            {
                var seed = unchecked(Environment.TickCount + Interlocked.Increment(ref counter));
                return new Random(seed);
            }
        }

        private sealed class ListSegment<T> : IEnumerable<T>
        {
            private readonly IReadOnlyList<T> source;
            private readonly int startIndex;
            private readonly int count;

            public ListSegment(IReadOnlyList<T> source, int startIndex, int count)
            {
                this.source = source;
                this.startIndex = startIndex;
                this.count = count;
            }

            public IEnumerator<T> GetEnumerator()
            {
                var endIndex = Math.Min(startIndex + count, source.Count) - 1;
                for (var i = startIndex; i <= endIndex; ++i)
                    yield return source[i];
            }

            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        }

        #endregion
    }
}