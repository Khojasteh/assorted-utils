// Copyright (c) 2019 Kambiz Khojasteh
// This file is part of the Assorted.Utils package which is released under the MIT software license.
// See the accompanying file LICENSE.txt or go to http://www.opensource.org/licenses/mit-license.php.

using System.Security.Cryptography.X509Certificates;

namespace Assorted.Utils.Crypto
{
    /// <summary>
    /// Provides some helper methods for working with <see cref="X509Certificate2"/> objects.
    /// </summary>
    /// <threadsafety/>
    public static class CertUtils
    {
        /// <summary>
        /// Searches certificates in a specified store using the search criteria specified by the <paramref name="type"/>
        /// enumeration and the <paramref name="value"/> object,
        /// </summary>
        /// <param name="storeLocation"> One of the enumeration values that specifies the location of the X.509 certificate store.</param>
        /// <param name="storeName">One of the enumeration values that specifies the name of the X.509 certificate store.</param>
        /// <param name="type">On of One of the <see cref="X509FindType"/> values.</param>
        /// <param name="value">The search criteria as an object.</param>
        /// <param name="validOnly"><see langword="true"/> to allow only valid certificates to be returned from the search; otherwise, <see langword="false"/>.</param>
        /// <returns>A <see cref="X509Certificate2Collection"/> object containing the result of search.</returns>
        public static X509Certificate2Collection FindCertificates(StoreLocation storeLocation, StoreName storeName, X509FindType type, object value, bool validOnly)
        {
            using (var store = new X509Store(storeName, storeLocation))
            {
                store.Open(OpenFlags.ReadOnly | OpenFlags.OpenExistingOnly);
                return store.Certificates.Find(type, value, validOnly);
            }
        }

        /// <summary>
        /// Searches certificates in a specified store of local machine using the search criteria specified by the <paramref name="type"/>
        /// enumeration and the <paramref name="value"/> object,
        /// </summary>
        /// <param name="type">On of One of the <see cref="X509FindType"/> values.</param>
        /// <param name="value">The search criteria as an object.</param>
        /// <param name="storeName">One of the enumeration values that specifies the name of the X.509 certificate store.</param>
        /// <param name="validOnly"><see langword="true"/> to allow only valid certificates to be returned from the search; otherwise, <see langword="false"/>.</param>
        /// <returns>A <see cref="X509Certificate2Collection"/> object containing the result of search.</returns>
        public static X509Certificate2Collection FindMachineCertificates(X509FindType type, object value, StoreName storeName = StoreName.My, bool validOnly = true)
        {
            return FindCertificates(StoreLocation.LocalMachine, storeName, type, value, validOnly);
        }

        /// <summary>
        /// Searches certificates in a specified store of current user using the search criteria specified by the <paramref name="type"/>
        /// enumeration and the <paramref name="value"/> object,
        /// </summary>
        /// <param name="type">On of One of the <see cref="X509FindType"/> values.</param>
        /// <param name="value">The search criteria as an object.</param>
        /// <param name="storeName">One of the enumeration values that specifies the name of the X.509 certificate store.</param>
        /// <param name="validOnly"><see langword="true"/> to allow only valid certificates to be returned from the search; otherwise, <see langword="false"/>.</param>
        /// <returns>A <see cref="X509Certificate2Collection"/> object containing the result of search.</returns>
        public static X509Certificate2Collection FindUserCertificates(X509FindType type, object value, StoreName storeName = StoreName.My, bool validOnly = true)
        {
            return FindCertificates(StoreLocation.CurrentUser, storeName, type, value, validOnly);
        }
    }
}
