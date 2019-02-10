using NUnit.Framework;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Assorted.Utils.Text.Tests
{
    [TestFixture]
    [TestOf(typeof(KMPSearch))]
    public class KMPSearchTests
    {
        [TestCase("XXXX-XXXX", "XX", ExpectedResult = new[] { 0, 1, 2, 5, 6, 7 })]
        [TestCase("AGCATGCTGCAGTCATGCTTAGGCTA", "G", ExpectedResult = new[] { 1, 5, 8, 11, 16, 21, 22 })]
        [TestCase("AGCATGCTGCAGTCATGCTTAGGCTA", "GC", ExpectedResult = new[] { 1, 5, 8, 16, 22 })]
        [TestCase("AGCATGCTGCAGTCATGCTTAGGCTA", "GCT", ExpectedResult = new[] { 5, 16, 22 })]
        [TestCase("AGCATGCTGCAGTCATGCTTAGGCTA", "GCTG", ExpectedResult = new[] { 5 })]
        [TestCase("AGCATGCTGCAGTCATGCTTAGGCTA", "GCTGA", ExpectedResult = new int[0])]
        [TestCase("AGCATGCTGCAGTCATGCTTAGGCTA", "TAC", ExpectedResult = new int[0])]
        public IEnumerable<int> Knuth_Morris_Pratt_String_Search(string haystack, string needle)
        {
            var pattern = new KMPSearch(needle);
            return pattern.SearchIn(haystack).ToArray();
        }

        [TestCase("XXXX-XXXX", "XX", 1, ExpectedResult = new[] { 0, 1, 2, 5, 6, 7 })]
        [TestCase("AGCATGCTGCAGTCATGCTTAGGCTA", "G", 1, ExpectedResult = new[] { 1, 5, 8, 11, 16, 21, 22 })]
        [TestCase("AGCATGCTGCAGTCATGCTTAGGCTA", "GC", 1, ExpectedResult = new[] { 1, 5, 8, 16, 22 })]
        [TestCase("AGCATGCTGCAGTCATGCTTAGGCTA", "GCT", 2, ExpectedResult = new[] { 5, 16, 22 })]
        [TestCase("AGCATGCTGCAGTCATGCTTAGGCTA", "GCTG", 3, ExpectedResult = new[] { 5 })]
        [TestCase("AGCATGCTGCAGTCATGCTTAGGCTA", "GCTGA", 5, ExpectedResult = new int[0])]
        [TestCase("AGCATGCTGCAGTCATGCTTAGGCTA", "TAC", 2, ExpectedResult = new int[0])]
        public IEnumerable<int> Knuth_Morris_Pratt_TextReader_Search(string haystack, string needle, int bufferSize)
        {
            var pattern = new KMPSearch(needle);
            var reader = new StringReader(haystack);
            return pattern.SearchIn(reader, bufferSize).ToArray();
        }
    }
}