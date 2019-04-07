// Copyright (c) 2019 Kambiz Khojasteh
// This file is part of the Assorted.Utils package which is released under the MIT software license.
// See the accompanying file LICENSE.txt or go to http://www.opensource.org/licenses/mit-license.php.

using NUnit.Framework;

namespace Assorted.Utils.Crypto.Tests
{
    [TestFixture]
    [TestOf(typeof(KeyedHasher))]
    public class KeyedHashTests
    {
        [TestCase("", "", ExpectedResult = "74e6f7298a9c2d168935f58c001bad88")]
        [TestCase("key", "The quick brown fox jumps over the lazy dog", ExpectedResult = "80070713463e7749b90c2dc24911e275")]
        public string HMACMD5(string key, string data)
        {
            return HMAC.MD5.Compute(key, data).ToHex();
        }

        [TestCase("", "", ExpectedResult = "fbdb1d1b18aa6c08324b7d64b71fb76370690e1d")]
        [TestCase("key", "The quick brown fox jumps over the lazy dog", ExpectedResult = "de7c9b85b8b78aa6bc8a7a36f70a90701c9db4d9")]
        public string HMACSHA1(string key, string data)
        {
            return HMAC.SHA1.Compute(key, data).ToHex();
        }

        [TestCase("", "", ExpectedResult = "b613679a0814d9ec772f95d778c35fc5ff1697c493715653c6c712144292c5ad")]
        [TestCase("key", "The quick brown fox jumps over the lazy dog", ExpectedResult = "f7bc83f430538424b13298e6aa6fb143ef4d59a14946175997479dbc2d1a3cd8")]
        public string HMACSHA256(string key, string data)
        {
            return HMAC.SHA256.Compute(key, data).ToHex();
        }

        [TestCase("", "", ExpectedResult = "6c1f2ee938fad2e24bd91298474382ca218c75db3d83e114b3d4367776d14d3551289e75e8209cd4b792302840234adc")]
        [TestCase("key", "The quick brown fox jumps over the lazy dog", ExpectedResult = "d7f4727e2c0b39ae0f1e40cc96f60242d5b7801841cea6fc592c5d3e1ae50700582a96cf35e1e554995fe4e03381c237")]
        public string HMACSHA384(string key, string data)
        {
            return HMAC.SHA384.Compute(key, data).ToHex();
        }

        [TestCase("", "", ExpectedResult = "b936cee86c9f87aa5d3c6f2e84cb5a4239a5fe50480a6ec66b70ab5b1f4ac6730c6c515421b327ec1d69402e53dfb49ad7381eb067b338fd7b0cb22247225d47")]
        [TestCase("key", "The quick brown fox jumps over the lazy dog", ExpectedResult = "b42af09057bac1e2d41708e48a902e09b5ff7f12ab428a4fe86653c73dd248fb82f948a549f7b791a5b41915ee4d1ec3935357e4e2317250d0372afa2ebeeb3a")]
        public string HMACSHA512(string key, string data)
        {
            return HMAC.SHA512.Compute(key, data).ToHex();
        }
    }
}