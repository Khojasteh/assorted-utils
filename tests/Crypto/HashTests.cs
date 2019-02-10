using NUnit.Framework;

namespace Assorted.Utils.Crypto.Tests
{
    [TestFixture]
    [TestOf(typeof(Hash))]
    public class HashTests
    {
        [TestCase("", ExpectedResult = "d41d8cd98f00b204e9800998ecf8427e")]
        [TestCase("The quick brown fox jumps over the lazy dog", ExpectedResult = "9e107d9d372bb6826bd81d3542a419d6")]
        public string MD5(string data)
        {
            return Hash.MD5.Compute(data).ToHex();
        }

        [TestCase("", ExpectedResult = "da39a3ee5e6b4b0d3255bfef95601890afd80709")]
        [TestCase("The quick brown fox jumps over the lazy dog", ExpectedResult = "2fd4e1c67a2d28fced849ee1bb76e7391b93eb12")]
        public string SHA1(string data)
        {
            return Hash.SHA1.Compute(data).ToHex();
        }

        [TestCase("", ExpectedResult = "e3b0c44298fc1c149afbf4c8996fb92427ae41e4649b934ca495991b7852b855")]
        [TestCase("The quick brown fox jumps over the lazy dog", ExpectedResult = "d7a8fbb307d7809469ca9abcb0082e4f8d5651e46d3cdb762d02d0bf37c9e592")]
        public string SHA256(string data)
        {
            return Hash.SHA256.Compute(data).ToHex();
        }

        [TestCase("", ExpectedResult = "38b060a751ac96384cd9327eb1b1e36a21fdb71114be07434c0cc7bf63f6e1da274edebfe76f65fbd51ad2f14898b95b")]
        [TestCase("The quick brown fox jumps over the lazy dog", ExpectedResult = "ca737f1014a48f4c0b6dd43cb177b0afd9e5169367544c494011e3317dbf9a509cb1e5dc1e85a941bbee3d7f2afbc9b1")]
        public string SHA384(string data)
        {
            return Hash.SHA384.Compute(data).ToHex();
        }

        [TestCase("", ExpectedResult = "cf83e1357eefb8bdf1542850d66d8007d620e4050b5715dc83f4a921d36ce9ce47d0d13c5d85f2b0ff8318d2877eec2f63b931bd47417a81a538327af927da3e")]
        [TestCase("The quick brown fox jumps over the lazy dog", ExpectedResult = "07e547d9586f6a73f73fbac0435ed76951218fb7d0c8d788a309d785436bbb642e93a252a954f23912547d1e8a3b5ed6e1bfd7097821233fa0538f3db854fee6")]
        public string SHA512(string data)
        {
            return Hash.SHA512.Compute(data).ToHex();
        }
    }
}