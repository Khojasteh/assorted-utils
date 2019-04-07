// Copyright (c) 2019 Kambiz Khojasteh
// This file is part of the Assorted.Utils package which is released under the MIT software license.
// See the accompanying file LICENSE.txt or go to http://www.opensource.org/licenses/mit-license.php.

using System;
using System.Collections.Generic;

namespace Assorted.Utils.Collections
{
    /// <summary>
    /// Extends the dictionary collections.
    /// </summary>
    /// <threadsafety/>
    public static class DictionaryExtensions
    {
        /// <overloads>
        /// Gets the value that is associated with a specified key.
        /// </overloads>
        /// <summary>
        /// Gets the value that is associated with a specified key. Returns a specific value if the key
        /// is not found.
        /// </summary>
        /// <typeparam name="TKey">The type of keys in the dictionary.</typeparam>
        /// <typeparam name="TValue">The type of values in the dictionary.</typeparam>
        /// <param name="source">The source dictionary.</param>
        /// <param name="key">The key to locate.</param>
        /// <param name="defaultValue">If the key is not found, this value will be returned.</param>
        /// <returns>
        /// <paramref name="defaultValue"/> if the value associated with the specified <paramref name="key"/>
        /// is not found; otherwise, the found value.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> is <see langword="null"/>.</exception>
        public static TValue GetValueOrDefault<TKey, TValue>(this IReadOnlyDictionary<TKey, TValue> source,
            TKey key, TValue defaultValue = default)
        {
            Contract.Requires<ArgumentNullException>(source != null, nameof(source));

            return (key != null && source.TryGetValue(key, out var value)) ? value : defaultValue;
        }

        /// <summary>
        /// Gets the value of a specified type that is associated with a specified key. Returns a specific value if
        /// the key is not found.
        /// </summary>
        /// <typeparam name="TValue">The type of values in the dictionary.</typeparam>
        /// <param name="source">The source dictionary.</param>
        /// <param name="key">The key to locate.</param>
        /// <param name="defaultValue">If the key is not found, this value will be returned.</param>
        /// <returns>
        /// <paramref name="defaultValue"/> if the value associated with the specified <paramref name="key"/>
        /// is not found; otherwise, the found value.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> is <see langword="null"/>.</exception>
        /// <exception cref="InvalidCastException">
        /// The specified <paramref name="key"/> is found, but its associated value is not type of <typeparamref name="TValue"/>.
        /// </exception>
        public static TValue GetValueOrDefault<TValue>(this IDictionary<string, object> source, string key, TValue defaultValue = default)
        {
            Contract.Requires<ArgumentNullException>(source != null, nameof(source));

            return (key != null && source.TryGetValue(key, out var value)) ? (TValue)value : defaultValue;
        }

        /// <overloads>
        /// Returns values of the source dictionary with the specified keys.
        /// </overloads>
        /// <summary>
        /// Returns values of the source dictionary with the specified keys. The missing keys are ignored.
        /// </summary>
        /// <typeparam name="TKey">The type of keys in the dictionary.</typeparam>
        /// <typeparam name="TValue">The type of values in the dictionary.</typeparam>
        /// <param name="source">The source dictionary.</param>
        /// <param name="keys">The sequence of keys to locate.</param>
        /// <returns>
        /// A <see cref="IEnumerable{T}"/> that contains the values associated with the specified <paramref name="keys"/>.
        /// The returned sequence does not contain value for the keys that are not found.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> or <paramref name="keys"/> is <see langword="null"/>.</exception>
        /// <remarks>
        /// This method is implemented by using deferred execution. The immediate return value is an object that stores all
        /// the information that is required to perform the action.
        /// </remarks>
        public static IEnumerable<TValue> GetValuesFor<TKey, TValue>(this IReadOnlyDictionary<TKey, TValue> source, IEnumerable<TKey> keys)
        {
            Contract.Requires<ArgumentNullException>(source != null, nameof(source));
            Contract.Requires<ArgumentNullException>(keys != null, nameof(keys));

            return Iterator();

            IEnumerable<TValue> Iterator()
            {
                foreach (var key in keys)
                {
                    if (key != null && source.TryGetValue(key, out var value))
                        yield return value;
                }
            }
        }

        /// <summary>
        /// Returns values of the source dictionary with the specified keys. Returns a specific value for any
        /// missing key in the dictionary.
        /// </summary>
        /// <typeparam name="TKey">The type of keys in the dictionary.</typeparam>
        /// <typeparam name="TValue">The type of values in the dictionary.</typeparam>
        /// <param name="source">The source dictionary.</param>
        /// <param name="keys">The sequence of keys to locate.</param>
        /// <param name="defaultValue">For any key that is not found, this value will be returned.</param>
        /// <returns>A <see cref="IEnumerable{T}"/> that contains the values associated with the specified <paramref name="keys"/>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> or <paramref name="keys"/> is <see langword="null"/>.</exception>
        /// <remarks>
        /// This method is implemented by using deferred execution. The immediate return value is an object that stores all
        /// the information that is required to perform the action.
        /// </remarks>
        public static IEnumerable<TValue> GetValuesFor<TKey, TValue>(this IReadOnlyDictionary<TKey, TValue> source,
            IEnumerable<TKey> keys, TValue defaultValue)
        {
            Contract.Requires<ArgumentNullException>(source != null, nameof(source));
            Contract.Requires<ArgumentNullException>(keys != null, nameof(keys));

            return Iterator();

            IEnumerable<TValue> Iterator()
            {
                foreach (var key in keys)
                {
                    if (key != null && source.TryGetValue(key, out var value))
                        yield return value;
                    else
                        yield return defaultValue;
                }
            }
        }

        /// <overloads>
        /// Performs an action on each value in the dictionary with the specified keys.
        /// </overloads>
        /// <summary>
        /// Performs an action on each value in the dictionary with the specified keys. The missing keys are ignored.
        /// </summary>
        /// <typeparam name="TKey">The type of keys in the dictionary.</typeparam>
        /// <typeparam name="TValue">The type of values in the dictionary.</typeparam>
        /// <param name="source">The source dictionary.</param>
        /// <param name="keys">The sequence of keys to locate.</param>
        /// <param name="action">A delegate to perform on each found value.</param>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="source"/>, <paramref name="keys"/>, or <paramref name="action"/> is <see langword="null"/>.
        /// </exception>
        public static void ForEach<TKey, TValue>(this IReadOnlyDictionary<TKey, TValue> source, IEnumerable<TKey> keys,
            Action<TKey, TValue> action)
        {
            Contract.Requires<ArgumentNullException>(source != null, nameof(source));
            Contract.Requires<ArgumentNullException>(keys != null, nameof(keys));
            Contract.Requires<ArgumentNullException>(action != null, nameof(action));

            foreach (var key in keys)
            {
                if (key != null && source.TryGetValue(key, out var value))
                    action(key, value);
            }
        }

        /// <summary>
        /// Performs an action on each value in the dictionary with the specified keys. The existing and missing keys
        /// have their own actions.
        /// </summary>
        /// <typeparam name="TKey">The type of keys in the dictionary.</typeparam>
        /// <typeparam name="TValue">The type of values in the dictionary.</typeparam>
        /// <param name="source">The source dictionary.</param>
        /// <param name="keys">The sequence of keys to locate.</param>
        /// <param name="hitAction">
        /// A delegate to perform on each found value. A <see langword="null"/> reference can be passed as this parameter.
        /// </param>
        /// <param name="missAction">
        /// A delegate to perform on each not found key. A <see langword="null"/> reference can be passed as this parameter.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="source"/> or <paramref name="keys"/> is <see langword="null"/>.
        /// </exception>
        public static void ForEach<TKey, TValue>(this IReadOnlyDictionary<TKey, TValue> source, IEnumerable<TKey> keys,
            Action<TKey, TValue> hitAction, Action<TKey> missAction)
        {
            Contract.Requires<ArgumentNullException>(source != null, nameof(source));
            Contract.Requires<ArgumentNullException>(keys != null, nameof(keys));

            foreach (var key in keys)
            {
                if (key != null && source.TryGetValue(key, out var value))
                    hitAction?.Invoke(key, value);
                else
                    missAction?.Invoke(key);
            }
        }

        /// <summary>
        /// Removes entries from the dictionary based on a predicate.
        /// </summary>
        /// <typeparam name="TKey">The type of keys in the dictionary.</typeparam>
        /// <typeparam name="TValue">The type of values in the dictionary.</typeparam>
        /// <param name="source">The source dictionary.</param>
        /// <param name="predicate">A function to test each value of the dictionary for a condition.</param>
        /// <exception cref="ArgumentNullException"><paramref name="source"/>, or <paramref name="predicate"/> is <see langword="null"/>.</exception>
        public static void RemoveWhere<TKey, TValue>(this IDictionary<TKey, TValue> source, Func<TKey, TValue, bool> predicate)
        {
            Contract.Requires<ArgumentNullException>(source != null, nameof(source));
            Contract.Requires<ArgumentNullException>(predicate != null, nameof(predicate));

            var obsoleteKeys = new LinkedList<TKey>();
            foreach (var entry in source)
            {
                if (predicate(entry.Key, entry.Value))
                    obsoleteKeys.AddFirst(entry.Key);
            }

            foreach (var key in obsoleteKeys)
                source.Remove(key);
        }
    }
}
