#if NET471
using NUnit.Framework;
using System;
using System.Security.Cryptography;

namespace Assorted.Utils.Crypto.Tests
{
    [TestFixture]
    [TestOf(typeof(ECDHKey))]
    public class ECDHKeyTests
    {
        const string TestKeyName = "Assorted.Utils.Crypto.KeyExchange.Test";

        [Test]
        public void EphemeralKey()
        {
            using (var k1 = new ECDHKey())
            using (var k2 = new ECDHKey())
            {
                Assert.That(k1.IsEphemeral, Is.True);
                Assert.That(k2.IsEphemeral, Is.True);

                Assert.That(k1.KeyName, Is.Null);
                Assert.That(k2.KeyName, Is.Null);

                Assert.That(k1.PublicKey, Is.Not.EqualTo(k2.PublicKey));
            }
        }

        [Test]
        public void PersistentKey()
        {
            using (var k1 = new ECDHKey(TestKeyName))
            using (var k2 = new ECDHKey(TestKeyName))
            {
                Assert.That(k1.IsEphemeral, Is.False);
                Assert.That(k2.IsEphemeral, Is.False);

                Assert.That(k1.KeyName, Is.EqualTo(TestKeyName));
                Assert.That(k2.KeyName, Is.EqualTo(TestKeyName));

                Assert.That(k1.PublicKey, Is.EqualTo(k2.PublicKey));
            }
        }

        [Test]
        public void PersistentKey_InvalidAlgorithm()
        {
            Assert.Throws<ArgumentException>(() => new ECDHKey(CngAlgorithm.Rsa));

            using (var k = new ECDHKey(TestKeyName))
                Assert.Throws<InvalidOperationException>(() => new ECDHKey(CngAlgorithm.ECDiffieHellmanP384, TestKeyName));
        }

        [Test]
        public void DeriveSharedKey()
        {
            using (var k1 = new ECDHKey())
            using (var k2 = new ECDHKey())
            {
                var sharedKey1 = k1.DeriveSharedKey(k2.PublicKey);
                var sharedKey2 = k2.DeriveSharedKey(k1.PublicKey);

                Assert.That(sharedKey1, Is.EqualTo(sharedKey2));
            }
        }
    }

}
#endif