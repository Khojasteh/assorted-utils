// Copyright (c) 2019 Kambiz Khojasteh
// This file is part of the Assorted.Utils package which is released under the MIT software license.
// See the accompanying file LICENSE.txt or go to http://www.opensource.org/licenses/mit-license.php.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Assorted.Utils.Text
{
    /// <summary>
    /// Implements Knuth–Morris–Pratt string-search algorithm.
    /// </summary>
    /// <threadsafety static="true" instance="true"/>
    public class KMPSearch
    {
        /// <summary>
        /// Initializes a new instance of <see cref="KMPSearch"/> class.
        /// </summary>
        /// <param name="target">A <see cref="string"/> to search for.</param>
        /// <exception cref="ArgumentNullException"><paramref name="target"/> is <see langword="null"/>.</exception>
        /// <exception cref="ArgumentException"><paramref name="target"/> is empty.</exception>
        public KMPSearch(string target)
        {
            Contract.Requires<ArgumentNullException>(target != null, nameof(target));
            Contract.Requires<ArgumentException>(target.Length != 0, nameof(target));

            Target = target;
            lps = BuildKMPTableFor(target);
        }

        /// <summary>
        /// Gets the string to search for.
        /// </summary>
        public string Target { get; }

        /// <overloads>
        /// Reports the zero-based indexes of all occurrences of the <see cref="Target"/> string in the given text.
        /// </overloads>
        /// <summary>
        /// Reports the zero-based indexes of all occurrences of the <see cref="Target"/> string in a given text.
        /// </summary>
        /// <param name="text">A <see cref="string"/> to search for occurrences of the <see cref="Target"/> string in it.</param>
        /// <returns>
        /// An <see cref="IEnumerable{T}"/> that contains the index of occurrences of <see cref="Target"/>
        /// string in the specified <paramref name="text"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="text"/> is <see langword="null"/>.</exception>
        /// <remarks>
        /// <para>
        /// This method is an <c>O(n)</c> operation, where <c>n</c> is the total length of strings.
        /// </para>
        /// <para>
        /// This method is implemented by using deferred execution. The immediate return value is an object that stores all
        /// the information that is required to perform the action.
        /// </para>
        /// </remarks>
        public IEnumerable<int> SearchIn(string text)
        {
            Contract.Requires<ArgumentNullException>(text != null, nameof(text));

            var targetLength = Target.Length;
            var textLength = text.Length;

            return (targetLength > textLength) ? Enumerable.Empty<int>() : KMP();

            IEnumerable<int> KMP()
            {
                var target = Target;
                for (int i = 0, k = 0; i < textLength; )
                {
                    while (text[i] == target[k])
                    {
                        i++;
                        if (++k == targetLength)
                        {
                            yield return i - k;
                            k = lps[k - 1];
                        }
                        if (i >= textLength)
                        {
                            yield break;
                        }
                    }
                    if (k != 0)
                        k = lps[k - 1];
                    else
                        i++;
                }
            }
        }

        /// <summary>
        /// Reports the zero-based indexes of all occurrences of the <see cref="Target"/> string in the text
        /// contained by a specific <see cref="TextReader"/> object.
        /// </summary>
        /// <param name="reader">
        /// A <see cref="TextReader"/> object to search for occurrences of the <see cref="Target"/> string in it.
        /// </param>
        /// <param name="bufferSize">The size of search buffer.</param>
        /// <returns>
        /// An <see cref="IEnumerable{T}"/> that contains the index of occurrences of <see cref="Target"/>
        /// string in the text contained by the specified <paramref name="reader"/> object.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="reader"/> is <see langword="null"/>.</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="bufferSize"/> is zero or negative.</exception>
        /// <remarks>
        /// <para>
        /// This method is an <c>O(n)</c> operation, where <c>n</c> is the total length of strings.
        /// </para>
        /// <para>
        /// This method is implemented by using deferred execution. The immediate return value is an object that stores all
        /// the information that is required to perform the action.
        /// </para>
        /// </remarks>
        public IEnumerable<int> SearchIn(TextReader reader, int bufferSize = 4096)
        {
            Contract.Requires<ArgumentNullException>(reader != null, nameof(reader));
            Contract.Requires<ArgumentOutOfRangeException>(bufferSize > 0, nameof(bufferSize));

            return KMP();

            IEnumerable<int> KMP()
            {
                var target = Target;
                var targetLength = target.Length;
                var text = new char[bufferSize];
                var textLength = reader.Read(text, 0, bufferSize);
                for (int i = 0, k = 0, index = 0; i < textLength; )
                {
                    while (text[i] == target[k])
                    {
                        i++;
                        if (++k == targetLength)
                        {
                            yield return index + (i - k);
                            k = lps[k - 1];
                        }
                        if (i >= textLength)
                        {
                            index += textLength;
                            textLength = reader.Read(text, i = 0, bufferSize);
                            if (textLength == 0)
                                yield break;
                        }
                    }
                    if (k != 0)
                        k = lps[k - 1];
                    else if (++i >= textLength)
                    {
                        index += textLength;
                        textLength = reader.Read(text, i = 0, bufferSize);
                    }
                }
            }
        }

        /// <summary>
        /// Returns the KMP-Table for the given <paramref name="pattern"/>.
        /// </summary>
        /// <param name="pattern">The string pattern to be analyzed.</param>
        /// <returns>The KMP-Table as an array of integers.</returns>
        private static int[] BuildKMPTableFor(string pattern)
        {
            var table = new int[pattern.Length];

            table[0] = 0;
            for (int i = 1, cnd = 0; i < pattern.Length; )
            {
                if (pattern[i] == pattern[cnd])
                {
                    table[i++] = ++cnd;
                }
                else if (cnd != 0)
                {
                    cnd = table[cnd - 1];
                }
                else
                {
                    table[i++] = cnd;
                }
            }

            return table;
        }

        private readonly int[] lps;
    }
}
