// Copyright (c) 2019 Kambiz Khojasteh
// This file is part of the Assorted.Utils package which is released under the MIT software license.
// See the accompanying file LICENSE.txt or go to http://www.opensource.org/licenses/mit-license.php.

using System;
using System.Runtime.CompilerServices;

namespace Assorted.Utils
{
    /// <summary>
    /// This class workarounds the lack of support for Code Contracts in Visual Studio 2017.
    /// </summary>
    /// <threadsafety/>
    internal static class Contract
    {
        /// <summary>
        /// Specifies a precondition contract for the enclosing method or property, and throws an exception
        /// if the condition for the contract fails.
        /// </summary>
        /// <typeparam name="TException">The exception to throw if the condition is <see langword="false"/>.</typeparam>
        /// <param name="condition">The conditional expression to test.</param>
        /// <param name="parameterName">The name of parameter is being tested.</param>
        /// <param name="message">The message to display if the condition is <see langword="false"/>.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Requires<TException>(bool condition, string parameterName, string message = null)
            where TException : Exception
        {
            if (!condition)
                throw CreateException<TException>(parameterName, message);
        }

        /// <summary>
        /// Returns an exception object.
        /// </summary>
        /// <typeparam name="TException">The exception to create.</typeparam>
        /// <param name="parameterName">The name of parameter causing the exception.</param>
        /// <param name="message">The message to display.</param>
        /// <returns>An exception object of type <typeparamref name="TException"/>.</returns>
        private static Exception CreateException<TException>(string parameterName, string message)
            where TException : Exception
        {
            if (typeof(TException) == typeof(ArgumentNullException))
                return new ArgumentNullException(parameterName, message);
            if (typeof(TException) == typeof(ArgumentOutOfRangeException))
                return new ArgumentOutOfRangeException(parameterName, message);

            return (TException)Activator.CreateInstance(typeof(TException), new[]
            {
                message ?? $"Parameter '{parameterName}' is not valid"
            });
        }
    }
}
