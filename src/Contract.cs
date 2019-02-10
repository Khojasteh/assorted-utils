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
        /// <param name="parametterName">The name of parameter is being tested.</param>
        /// <param name="message">The message to display if the condition is <see langword="false"/>.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Requires<TException>(bool condition, string parametterName, string message = null)
            where TException : Exception
        {
            if (!condition)
                throw CreateException<TException>(parametterName, message);
        }

        /// <summary>
        /// Returns an exception object.
        /// </summary>
        /// <typeparam name="TException">The exception to create.</typeparam>
        /// <param name="parametterName">The name of parameter causing the exception.</param>
        /// <param name="message">The message to display.</param>
        /// <returns>An exception object of type <typeparamref name="TException"/>.</returns>
        private static Exception CreateException<TException>(string parametterName, string message) 
            where TException : Exception
        {
            if (typeof(TException) == typeof(ArgumentNullException))
                return new ArgumentNullException(parametterName, message);
            if (typeof(TException) == typeof(ArgumentOutOfRangeException))
                return new ArgumentOutOfRangeException(parametterName, message);

            return (TException)Activator.CreateInstance(typeof(TException), new[] 
            {
                message ?? $"Parameter '{parametterName}' is not valid"
            });
        }
    }
}
