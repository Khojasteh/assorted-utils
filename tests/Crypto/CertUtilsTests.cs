// Copyright (c) 2019 Kambiz Khojasteh
// This file is part of the Assorted.Utils package which is released under the MIT software license.
// See the accompanying file LICENSE.txt or go to http://www.opensource.org/licenses/mit-license.php.

using NUnit.Framework;
using System.Security.Cryptography.X509Certificates;

namespace Assorted.Utils.Crypto.Tests
{
    [TestFixture]
    [TestOf(typeof(CertUtils))]
    class CertUtilsTests
    {

        [TestCase(StoreLocation.LocalMachine, StoreName.Root, X509FindType.FindBySubjectName, "GlobalSign")]
        [TestCase(StoreLocation.LocalMachine, StoreName.CertificateAuthority, X509FindType.FindByKeyUsage, X509KeyUsageFlags.DigitalSignature)]
        [TestCase(StoreLocation.CurrentUser, StoreName.CertificateAuthority, X509FindType.FindByKeyUsage, X509KeyUsageFlags.DigitalSignature)]
        public void FindCertificates(StoreLocation storeLocation, StoreName storeName, X509FindType type, object value)
        {
            var certs = CertUtils.FindCertificates(storeLocation, storeName, type, value, validOnly: true);
            Assert.That(certs, Is.Not.Empty);
        }

        [TestCase(StoreName.CertificateAuthority, X509FindType.FindByIssuerName, "GlobalSign")]
        [TestCase(StoreName.CertificateAuthority, X509FindType.FindByKeyUsage, X509KeyUsageFlags.DigitalSignature)]
        public void FindMachineCertificates(StoreName storeName, X509FindType type, object value)
        {
            var certs1 = CertUtils.FindCertificates(StoreLocation.LocalMachine, storeName, type, value, validOnly: true);
            var certs2 = CertUtils.FindMachineCertificates(type, value, storeName, validOnly: true);
            Assert.That(certs1, Is.EqualTo(certs2));
        }

        [TestCase(StoreName.CertificateAuthority, X509FindType.FindByKeyUsage, X509KeyUsageFlags.DataEncipherment)]
        public void FindUserCertificates(StoreName storeName, X509FindType type, object value)
        {
            var certs1 = CertUtils.FindCertificates(StoreLocation.CurrentUser, storeName, type, value, validOnly: true);
            var certs2 = CertUtils.FindUserCertificates(type, value, storeName, validOnly: true);
            Assert.That(certs1, Is.EqualTo(certs2));
        }
    }
}
