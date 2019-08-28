// Copyright (c) 2019 Kambiz Khojasteh
// This file is part of the Assorted.Utils package which is released under the MIT software license.
// See the accompanying file LICENSE.txt or go to http://www.opensource.org/licenses/mit-license.php.

using NUnit.Framework;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Assorted.Utils.Crypto.Tests
{
    [TestFixture]
    [TestOf(typeof(CertExtenstions))]
    class CertExtensionsTests
    {
        private static readonly X509Certificate2 cryptoCert
            = LoadCertificateFromResource("Assorted.Utils.Tests.Crypto.test-cert-encryption-pfx", "bingo");
        private static readonly X509Certificate2 signingCert
            = LoadCertificateFromResource("Assorted.Utils.Tests.Crypto.test-cert-signature-pfx", "bingo");

        private static X509Certificate2 LoadCertificateFromResource(string resourceName, string password)
        {
            using (var memStream = new MemoryStream())
            { 
                using (var resStream = Assembly.GetExecutingAssembly().GetManifestResourceStream(resourceName))
                    resStream.CopyTo(memStream);

                return new X509Certificate2(memStream.ToArray(), password);
            }
        }

        [TestCase("")]
        [TestCase("The quick brown fox jumps over the lazy dog")]
        public void EncryptionAndDecryption(string text)
        {
            var plainData = Encoding.UTF8.GetBytes(text);

            var cipheredData = cryptoCert.Encrypt(plainData);
            Assert.That(plainData, Is.Not.EqualTo(cipheredData));

            var decipheredData = cryptoCert.Decrypt(cipheredData);
            Assert.That(plainData, Is.EqualTo(decipheredData));
        }

        [TestCase(new byte[] { })]
        [TestCase(new byte[] { 1, 2, 3, 4, 5 })]
        public void SigningArray(byte[] data)
        {
            var signature = signingCert.Sign(data);
            Assert.That(signingCert.VerifySignature(data, signature), Is.True);

            var temperedSignature = signature.ToArray(); temperedSignature[0] = (byte)~signature[0];
            Assert.That(signingCert.VerifySignature(data, temperedSignature), Is.False);

            if (data.Length != 0)
            {
                var temperedData = data.ToArray(); temperedData[0] = (byte)~data[0];
                Assert.That(signingCert.VerifySignature(temperedData, signature), Is.False);
            }
        }

        [TestCase("")]
        [TestCase("The quick brown fox jumps over the lazy dog")]
        public void SigningString(string text)
        {
            var signature = signingCert.Sign(text);
            Assert.That(signingCert.VerifySignature(text, signature), Is.True);

            var temperedSignature = signature.ToArray(); temperedSignature[0] = (byte)~signature[0];
            Assert.That(signingCert.VerifySignature(text, temperedSignature), Is.False);

            if (text.Contains(' '))
            {
                var temperedText = text.Replace(' ', '-');
                Assert.That(signingCert.VerifySignature(temperedText, signature), Is.False);
            }
        }

        [TestCase(new byte[] { })]
        [TestCase(new byte[] { 1, 2, 3, 4, 5 })]
        public void SigningStream(byte[] data)
        {
            using (var stream = new MemoryStream(data))
            {
                var signature = signingCert.Sign(stream);
                stream.Seek(0, SeekOrigin.Begin);
                Assert.That(signingCert.VerifySignature(stream, signature), Is.True);

                var temperedSignature = signature.ToArray(); temperedSignature[0] = (byte)~signature[0];
                stream.Seek(0, SeekOrigin.Begin);
                Assert.That(signingCert.VerifySignature(stream, temperedSignature), Is.False);
            }
        }
    }
}
