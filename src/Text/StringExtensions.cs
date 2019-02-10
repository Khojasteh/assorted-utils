using System;
using System.Collections.Generic;

namespace Assorted.Utils.Text
{
    /// <summary>
    /// Extends the <see cref="string"/> type.
    /// </summary>
    /// <threadsafety/>
    public static class StringExtensions
    {
        /// <summary>
        /// Returns the substrings in this string that are delimited by a specified Unicode character. 
        /// </summary>
        /// <param name="source">The source string.</param>
        /// <param name="separator">A Unicode character that delimits the substrings in this string.</param>
        /// <param name="options">
        /// <see cref="StringSplitOptions.RemoveEmptyEntries"/> to omit empty substrings from the result; 
        /// or <see cref="StringSplitOptions.None"/> to include empty substring in the result.
        /// </param>
        /// <returns>An <see cref="IEnumerable{T}"/> that contains the substrings.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> is <see langword="null"/>.</exception>
        /// <remarks>
        /// This method is implemented by using deferred execution. The immediate return value is an object that stores all 
        /// the information that is required to perform the action.
        /// </remarks>
        public static IEnumerable<string> LazySplit(this string source, char separator, StringSplitOptions options = StringSplitOptions.None)
        {
            Contract.Requires<ArgumentNullException>(source != null, nameof(source));

            return Iterator();

            IEnumerable<string> Iterator()
            {
                var index = 0;
                var nextIndex = source.IndexOf(separator, index);
                while (nextIndex != -1)
                {
                    if (options != StringSplitOptions.RemoveEmptyEntries || index != nextIndex)
                        yield return source.Substring(index, nextIndex - index);
                    index = nextIndex + 1;
                    nextIndex = source.IndexOf(separator, index);
                }
                if (options != StringSplitOptions.RemoveEmptyEntries || index != source.Length)
                    yield return (index == 0) ? source : source.Substring(index);
            }
        }

        /// <summary>
        /// Splits the string at the first occurrence of a specified Unicode character and returns the 
        /// substrings before and after the separator.
        /// </summary>
        /// <param name="source">The source string.</param>
        /// <param name="separator">The separator Unicode character.</param>
        /// <returns>
        /// A <see cref="Tuple{T1, T2}"/> containing the substring before and after the specified
        /// <paramref name="separator"/> if the separator is found; otherwise, the first item in the tuple
        /// is the <paramref name="source"/> string itself and the second item is <see langword="null"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> is <see langword="null"/>.</exception>
        public static (string Head, string Tail) Partition(this string source, char separator)
        {
            Contract.Requires<ArgumentNullException>(source != null, nameof(source));

            var i = source.IndexOf(separator);
            return (i != -1) ? (source.Substring(0, i), source.Substring(i + 1)) : (source, default(string));
        }

        /// <summary>
        /// Splits the string at the first occurrence of a specified string and returns the substrings before 
        /// and after the separator.
        /// </summary>
        /// <param name="source">The source string.</param>
        /// <param name="separator">The separator string.</param>
        /// <returns>
        /// A <see cref="Tuple{T1, T2}"/> containing the substring before and after the specified
        /// <paramref name="separator"/> if the separator is found; otherwise, the first item in the tuple
        /// is the <paramref name="source"/> string itself and the second item is <see langword="null"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="source"/> or <paramref name="separator"/> is <see langword="null"/>.
        /// </exception>
        public static (string Head, string Tail) Partition(this string source, string separator)
        {
            Contract.Requires<ArgumentNullException>(source != null, nameof(source));
            Contract.Requires<ArgumentNullException>(separator != null, nameof(separator));

            var i = source.IndexOf(separator);
            return (i != -1) ? (source.Substring(0, i), source.Substring(i + separator.Length)) : (source, default(string));
        }

        /// <summary>
        /// Retrieves a substring from this instance. The substring starts after the first occurrence of 
        /// a specified Unicode character and continues to the end of the string.
        /// </summary>
        /// <param name="source">The source string.</param>
        /// <param name="value">A Unicode character to seek.</param>
        /// <returns>
        /// A substring of the original string if the <paramref name="value"/> is found; otherwise, <see langword="null"/>.
        /// </returns>
        public static string SubstringAfter(this string source, char value)
        {
            Contract.Requires<ArgumentNullException>(source != null, nameof(source));

            var i = source.IndexOf(value);
            return (i != -1) ? source.Substring(i + 1) : null;
        }

        /// <summary>
        /// Retrieves a substring from this instance. The substring starts after the first occurrence of 
        /// a specified string and continues to the end of the string.
        /// </summary>
        /// <param name="source">The source string.</param>
        /// <param name="value">A string to seek.</param>
        /// <returns>
        /// A substring of the original string if the <paramref name="value"/> is found; otherwise, <see langword="null"/>.
        /// </returns>
        public static string SubstringAfter(this string source, string value)
        {
            Contract.Requires<ArgumentNullException>(source != null, nameof(source));
            Contract.Requires<ArgumentNullException>(value != null, nameof(value));

            var i = source.IndexOf(value);
            return (i != -1) ? source.Substring(i + value.Length) : null;
        }

        /// <summary>
        /// Retrieves a substring from this instance. The substring starts after the last occurrence of 
        /// a specified Unicode character and continues to the end of the string.
        /// </summary>
        /// <param name="source">The source string.</param>
        /// <param name="value">A Unicode character to seek.</param>
        /// <returns>
        /// A substring of the original string if the <paramref name="value"/> is found; otherwise, <see langword="null"/>.
        /// </returns>
        public static string SubstringAfterLast(this string source, char value)
        {
            Contract.Requires<ArgumentNullException>(source != null, nameof(source));

            var i = source.LastIndexOf(value);
            return (i != -1) ? source.Substring(i + 1) : null;
        }

        /// <summary>
        /// Retrieves a substring from this instance. The substring starts after the last occurrence of 
        /// a specified string and continues to the end of the string.
        /// </summary>
        /// <param name="source">The source string.</param>
        /// <param name="value">A string to seek.</param>
        /// <returns>
        /// A substring of the original string if the <paramref name="value"/> is found; otherwise, <see langword="null"/>.
        /// </returns>
        public static string SubstringAfterLast(this string source, string value)
        {
            Contract.Requires<ArgumentNullException>(source != null, nameof(source));
            Contract.Requires<ArgumentNullException>(value != null, nameof(value));

            var i = source.LastIndexOf(value);
            return (i != -1) ? source.Substring(i + value.Length) : null;
        }

        /// <summary>
        /// Retrieves a substring from this instance. The substring starts at the beginning of the string and
        /// continues until the first occurrence of a specified Unicode character.
        /// </summary>
        /// <param name="source">The source string.</param>
        /// <param name="value">A Unicode character to seek.</param>
        /// <returns>
        /// A substring of the original string if the <paramref name="value"/> is found; otherwise, <see langword="null"/>.
        /// </returns>
        public static string SubstringBefore(this string source, char value)
        {
            Contract.Requires<ArgumentNullException>(source != null, nameof(source));

            var i = source.IndexOf(value);
            return (i != -1) ? source.Substring(0, i) : null;
        }

        /// <summary>
        /// Retrieves a substring from this instance. The substring starts at the beginning of the string and
        /// continues until the first occurrence of a specified string.
        /// </summary>
        /// <param name="source">The source string.</param>
        /// <param name="value">A string to seek.</param>
        /// <returns>
        /// A substring of the original string if the <paramref name="value"/> is found; otherwise, <see langword="null"/>.
        /// </returns>
        public static string SubstringBefore(this string source, string value)
        {
            Contract.Requires<ArgumentNullException>(source != null, nameof(source));
            Contract.Requires<ArgumentNullException>(value != null, nameof(value));

            var i = source.IndexOf(value);
            return (i != -1) ? source.Substring(0, i) : null;
        }

        /// <summary>
        /// Retrieves a substring from this instance. The substring starts at the beginning of the string and
        /// continues until the last occurrence of a specified Unicode character.
        /// </summary>
        /// <param name="source">The source string.</param>
        /// <param name="value">A Unicode character to seek.</param>
        /// <returns>
        /// A substring of the original string if the <paramref name="value"/> is found; otherwise, <see langword="null"/>.
        /// </returns>
        public static string SubstringBeforeLast(this string source, char value)
        {
            Contract.Requires<ArgumentNullException>(source != null, nameof(source));

            var i = source.LastIndexOf(value);
            return (i != -1) ? source.Substring(0, i) : null;
        }

        /// <summary>
        /// Retrieves a substring from this instance. The substring starts at the beginning of the string and
        /// continues until the last occurrence of a specified string.
        /// </summary>
        /// <param name="source">The source string.</param>
        /// <param name="value">A string to seek.</param>
        /// <returns>
        /// A substring of the original string if the <paramref name="value"/> is found; otherwise, <see langword="null"/>.
        /// </returns>
        public static string SubstringBeforeLast(this string source, string value)
        {
            Contract.Requires<ArgumentNullException>(source != null, nameof(source));
            Contract.Requires<ArgumentNullException>(value != null, nameof(value));

            var i = source.LastIndexOf(value);
            return (i != -1) ? source.Substring(0, i) : null;
        }

        /// <summary>
        /// Returns the number of leading and trailing Unicode characters that appear in both strings.
        /// </summary>
        /// <param name="source">The source string.</param>
        /// <param name="other">The other string.</param>
        /// <returns>
        /// A <see cref="Tuple{T1, T2}"/> that contains the number of leading and trailing matched 
        /// Unicode characters.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="source"/> or <paramref name="other"/> is <see langword="null"/>.
        /// </exception>
        public static (int Head, int Tail) MatchingCharsWith(this string source, string other)
        {
            Contract.Requires<ArgumentNullException>(source != null, nameof(source));
            Contract.Requires<ArgumentNullException>(other != null, nameof(other));

            var xCount = source.Length;
            var yCount = other.Length;

            var count = Math.Min(xCount, yCount);
            var start = 0;
            while (start < count && source[start] == other[start])
                start++;

            if ((count -= start) == 0)
                return (start, 0);

            var end = 0;
            while (end < count && source[xCount - end - 1] == other[yCount - end - 1])
                end++;

            return (start, end);
        }

        /// <summary>
        /// Returns the normalized Damerau-Levenshtein distance between two strings.
        /// </summary>
        /// <param name="source">The source string.</param>
        /// <param name="other">The other string.</param>
        /// <returns>
        /// A value between <c>0</c> and <c>1</c> such that <c>0</c> equates to no similarity 
        /// and <c>1</c> is an exact match.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="source"/> or <paramref name="other"/> is <see langword="null"/>.
        /// </exception>
        /// <remarks>
        /// The Damerau-Levenshtein distance is defined as the minimum number of primitive edit operations 
        /// needed to transform one text into the other and these operations are substitution, deletion, 
        /// insertion and the transposition of two adjacent characters.
        /// </remarks>
        /// <seealso cref="JaroSimilarityTo"/>
        /// <seealso cref="JaroWinklerSimilarityTo"/>
        public static double DamerauLevenshteinSimilarityTo(this string source, string other)
        {
            (var start, var end) = MatchingCharsWith(source, other);

            var shorter = source;
            var longer = other;
            if (source.Length > other.Length)
            {
                shorter = other;
                longer = source;
            }

            var shorterSize = shorter.Length - (start + end);
            var longerSize = longer.Length - (start + end);

            if (shorterSize == 0)
                return (longerSize == 0) ? 1.0 : 0.0;

            var costs = new int[shorterSize];
            for (var k = 0; k < costs.Length; ++k)
                costs[k] = k + 1;

            var prvLongerCh = ~shorter[0];
            for (var i = 0; i < longerSize; i++)
            {
                var prvCost = i;
                var cost = i + 1;
                var longerCh = longer[start + i];
                var prvShorterCh = ~longerCh;
                for (var k = 0; k < shorterSize; k++)
                {
                    var shorterCh = shorter[start + k];
                    if (longerCh == shorterCh || (longerCh == prvShorterCh && prvLongerCh == shorterCh))
                        cost = prvCost;
                    else
                    {
                        if (costs[k] < cost)
                            cost = costs[k];
                        if (prvCost < cost)
                            cost = prvCost;
                        cost++;
                    }
                    prvCost = costs[k];
                    costs[k] = cost;
                    prvShorterCh = shorterCh;
                }
                prvLongerCh = longerCh;
            }

            var distance = (double)costs[costs.Length - 1];
            return 1.0 - (distance / longer.Length);
        }

        /// <summary>
        /// Returns the normalized Jaro distance between two strings.
        /// </summary>
        /// <param name="source">The source string.</param>
        /// <param name="other">The other string.</param>
        /// <returns>
        /// A value between <c>0</c> and <c>1</c> such that <c>0</c> equates to no similarity 
        /// and <c>1</c> is an exact match.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="source"/> or <paramref name="other"/> is <see langword="null"/>.
        /// </exception>
        /// <seealso cref="JaroWinklerSimilarityTo"/>
        /// <seealso cref="DamerauLevenshteinSimilarityTo"/>
        public static double JaroSimilarityTo(this string source, string other)
        {
            (var start, var end) = MatchingCharsWith(source, other);

            var matches = start + end;
            var sourceSize = source.Length - matches;
            var otherSize = other.Length - matches;

            if (sourceSize == 0)
                return (otherSize == 0) ? 1.0 : 0.0;

            var sourceMatches = new bool[sourceSize];
            var otherMatches = new bool[otherSize];
            var matchDistance = (Math.Max(sourceSize, otherSize) + matches) / 2 - 1;
            for (var i = 0; i < sourceSize; i++)
            {
                var sourceChar = source[start + i];
                var count = Math.Min(i + matchDistance + 1, otherSize);
                for (var k = Math.Max(0, i - matchDistance); k < count; k++)
                {
                    if (!otherMatches[k] && sourceChar == other[start + k])
                    {
                        sourceMatches[i] = true;
                        otherMatches[k] = true;
                        matches++;
                        break;
                    }
                }
            }
            if (matches == 0)
                return 0.0;

            var transpositions = 0;
            for (int i = 0, k = 0; i < sourceSize; i++)
            {
                if (sourceMatches[i])
                {
                    while (!otherMatches[k])
                        k++;
                    if (source[start + i] != other[start + k++])
                        transpositions++;
                }
            }

            var m = (double)matches;
            var t = 0.5 * transpositions;
            return (m / source.Length + m / other.Length + (m - t) / m) / 3.0;
        }

        /// <summary>
        /// Returns the normalized Jaro-Winkler distance between two strings.
        /// </summary>
        /// <param name="source">The source string.</param>
        /// <param name="other">The other string.</param>
        /// <param name="maxPrefixLength">The maximum length of common prefixes.</param>
        /// <returns>
        /// A value between <c>0</c> and <c>1</c> such that <c>0</c> equates to no similarity 
        /// and <c>1</c> is an exact match.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="source"/> or <paramref name="other"/> is <see langword="null"/>.
        /// </exception>
        /// <seealso cref="JaroSimilarityTo"/>
        /// <seealso cref="DamerauLevenshteinSimilarityTo"/>
        public static double JaroWinklerSimilarityTo(this string source, string other, int maxPrefixLength = 4)
        {
            // The scaling factor for how much the score is adjusted upwards for having common prefixes.
            // This value should not exceed 0.25; otherwise, the result can become larger than 1.
            const double PrefixScale = 0.1;

            var jaroScore = source.JaroSimilarityTo(other);
            return jaroScore + (PrefixLength() * PrefixScale * (1.0 - jaroScore));

            int PrefixLength()
            {
                var maxLength = Math.Min(Math.Min(source.Length, other.Length), maxPrefixLength);
                for (var i = 0; i < maxLength; i++)
                    if (source[i] != other[i])
                        return i;
                return maxLength;
            }
        }

    }
}
