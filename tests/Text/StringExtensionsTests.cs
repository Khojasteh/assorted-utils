using Assorted.Utils.Text;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Assorted.Utils.Text.Tests
{
    [TestFixture]
    [TestOf(typeof(StringExtensions))]
    public class StringExtensionsTests
    {
        static readonly string[] LazySplitSamples = new[]
        {
            "",
            "*",
            "**",
            "***",
            "1*2*3",
            "*1*2*3",
            "1*2*3*",
            "11*22*33",
            "*11*22*33",
            "11*22*33*",
            "**1**2**3**",
            "1**2**3**4**",
            "**1**2**3**4",
            "*123**456**789*",
        };

        [Test]
        public void Lazy_Split([ValueSource(nameof(LazySplitSamples))] string s, [Values] StringSplitOptions options)
        {
            var result = s.LazySplit('*', options);
            var expectedResult = s.Split(new[] { '*' }, options);

            Assert.That(result, Is.EqualTo(expectedResult));
        }

        static IEnumerable<TestCaseData> PartitionByCharacterTestCases()
        {
            yield return new TestCaseData("Head:Tail", ':')
                .Returns(("Head", "Tail"));
            yield return new TestCaseData(":Tail", ':')
                .Returns(("", "Tail"));
            yield return new TestCaseData("Head:", ':')
                .Returns(("Head", ""));
            yield return new TestCaseData("Head-Tail", ':')
                .Returns(("Head-Tail", default(string)));
            yield return new TestCaseData("", ':')
                .Returns(("", default(string)));
        }

        [TestCaseSource(nameof(PartitionByCharacterTestCases))]
        public (string, string) Partition_By_Character(string s, char separator)
        {
            return s.Partition(separator);
        }

        static IEnumerable<TestCaseData> PartitionByStringTestCases()
        {
            yield return new TestCaseData("Head<>Tail", "<>")
                .Returns(("Head", "Tail"));
            yield return new TestCaseData("<>Tail", "<>")
                .Returns(("", "Tail"));
            yield return new TestCaseData("Head<>", "<>")
                .Returns(("Head", ""));
            yield return new TestCaseData("Head-Tail", "<>")
                .Returns(("Head-Tail", default(string)));
            yield return new TestCaseData("", "<>")
                .Returns(("", default(string)));
            yield return new TestCaseData("Head<>Tail", "")
                .Returns(("", "Head<>Tail"));
        }

        [TestCaseSource(nameof(PartitionByStringTestCases))]
        public (string, string) Partition_By_String(string s, string separator)
        {
            return s.Partition(separator);
        }

        static IEnumerable<TestCaseData> SubstringAfterCharacterTestCases()
        {
            yield return new TestCaseData("the.test", '.')
                .Returns("test");
            yield return new TestCaseData("the.second.test", '.')
                .Returns("second.test");
            yield return new TestCaseData(".another.test", '.')
                .Returns("another.test");
            yield return new TestCaseData("one.more.test.", '.')
                .Returns("more.test.");
            yield return new TestCaseData("test", '.')
                .Returns(null);
            yield return new TestCaseData("", '.')
                .Returns(null);
        }

        [TestCaseSource(nameof(SubstringAfterCharacterTestCases))]
        public string Substering_After_Character(string s, char value)
        {
            return s.SubstringAfter(value);
        }

        static IEnumerable<TestCaseData> SubstringAfterStringTestCases()
        {
            yield return new TestCaseData("the<>test", "<>")
                .Returns("test");
            yield return new TestCaseData("the<>second<>test", "<>")
                .Returns("second<>test");
            yield return new TestCaseData("<>another<>test", "<>")
                .Returns("another<>test");
            yield return new TestCaseData("one<>more<>test<>", "<>")
                .Returns("more<>test<>");
            yield return new TestCaseData("test", "<>")
                .Returns(null);
            yield return new TestCaseData("", "<>")
                .Returns(null);
        }

        [TestCaseSource(nameof(SubstringAfterStringTestCases))]
        public string Substering_After_String(string s, string value)
        {
            return s.SubstringAfter(value);
        }

        static IEnumerable<TestCaseData> SubstringAfterLastCharacterTestCases()
        {
            yield return new TestCaseData("the.test", '.')
                .Returns("test");
            yield return new TestCaseData("the.second.test", '.')
                .Returns("test");
            yield return new TestCaseData(".another.test", '.')
                .Returns("test");
            yield return new TestCaseData("one.more.test.", '.')
                .Returns("");
            yield return new TestCaseData("test", '.')
                .Returns(null);
            yield return new TestCaseData("", '.')
                .Returns(null);
        }

        [TestCaseSource(nameof(SubstringAfterLastCharacterTestCases))]
        public string Substering_After_Last_Character(string s, char value)
        {
            return s.SubstringAfterLast(value);
        }

        static IEnumerable<TestCaseData> SubstringAfterLastStringTestCases()
        {
            yield return new TestCaseData("the<>test", "<>")
                .Returns("test");
            yield return new TestCaseData("the<>second<>test", "<>")
                .Returns("test");
            yield return new TestCaseData("<>another<>test", "<>")
                .Returns("test");
            yield return new TestCaseData("one<>more<>test<>", "<>")
                .Returns("");
            yield return new TestCaseData("test", "<>")
                .Returns(null);
            yield return new TestCaseData("", "<>")
                .Returns(null);
        }

        [TestCaseSource(nameof(SubstringAfterLastStringTestCases))]
        public string Substering_After_Last_String(string s, string value)
        {
            return s.SubstringAfterLast(value);
        }

        static IEnumerable<TestCaseData> SubstringBeforeCharacterTestCases()
        {
            yield return new TestCaseData("the.test", '.')
                .Returns("the");
            yield return new TestCaseData("the.second.test", '.')
                .Returns("the");
            yield return new TestCaseData(".another.test", '.')
                .Returns("");
            yield return new TestCaseData("one.more.test.", '.')
                .Returns("one");
            yield return new TestCaseData("test", '.')
                .Returns(null);
            yield return new TestCaseData("", '.')
                .Returns(null);
        }

        [TestCaseSource(nameof(SubstringBeforeCharacterTestCases))]
        public string Substering_Before_Character(string s, char value)
        {
            return s.SubstringBefore(value);
        }

        static IEnumerable<TestCaseData> SubstringBeforeStringTestCases()
        {
            yield return new TestCaseData("the<>test", "<>")
                .Returns("the");
            yield return new TestCaseData("the<>second<>test", "<>")
                .Returns("the");
            yield return new TestCaseData("<>another<>test", "<>")
                .Returns("");
            yield return new TestCaseData("one<>more<>test<>", "<>")
                .Returns("one");
            yield return new TestCaseData("test", "<>")
                .Returns(null);
            yield return new TestCaseData("", "<>")
                .Returns(null);
        }

        [TestCaseSource(nameof(SubstringBeforeStringTestCases))]
        public string Substering_Before_String(string s, string value)
        {
            return s.SubstringBefore(value);
        }

        static IEnumerable<TestCaseData> SubstringBeforeLastCharacterTestCases()
        {
            yield return new TestCaseData("the.test", '.')
                .Returns("the");
            yield return new TestCaseData("the.second.test", '.')
                .Returns("the.second");
            yield return new TestCaseData(".another.test", '.')
                .Returns(".another");
            yield return new TestCaseData("one.more.test.", '.')
                .Returns("one.more.test");
            yield return new TestCaseData("test", '.')
                .Returns(null);
            yield return new TestCaseData("", '.')
                .Returns(null);
        }

        [TestCaseSource(nameof(SubstringBeforeLastCharacterTestCases))]
        public string Substering_Before_Last_Character(string s, char value)
        {
            return s.SubstringBeforeLast(value);
        }

        static IEnumerable<TestCaseData> SubstringBeforeLastStringTestCases()
        {
            yield return new TestCaseData("the<>test", "<>")
                .Returns("the");
            yield return new TestCaseData("the<>second<>test", "<>")
                .Returns("the<>second");
            yield return new TestCaseData("<>another<>test", "<>")
                .Returns("<>another");
            yield return new TestCaseData("one<>more<>test<>", "<>")
                .Returns("one<>more<>test");
            yield return new TestCaseData("test", "<>")
                .Returns(null);
            yield return new TestCaseData("", "<>")
                .Returns(null);
        }

        [TestCaseSource(nameof(SubstringBeforeLastStringTestCases))]
        public string Substering_Before_Last_String(string s, string value)
        {
            return s.SubstringBeforeLast(value);
        }

        static IEnumerable<TestCaseData> OuterMatchCountTestCases()
        {
            yield return new TestCaseData("", "")
                .Returns((0, 0));
            yield return new TestCaseData("ABC", "CBA")
                .Returns((0, 0));
            yield return new TestCaseData("ABC", "ABC")
                .Returns((3, 0));
            yield return new TestCaseData("ABC", "ABCABC")
                .Returns((3, 0));
            yield return new TestCaseData("ABCCBA", "CBA")
                .Returns((0, 3));
            yield return new TestCaseData("ABXBA", "ABBA")
                .Returns((2, 2));
        }

        [TestCaseSource(nameof(OuterMatchCountTestCases))]
        public (int, int) Outer_Match_Count(string s1, string s2)
        {
            return s1.MatchingCharsWith(s2);
        }

        [TestCase("", "", ExpectedResult = 1.0)]
        [TestCase("XYZ", "", ExpectedResult = 0.0)]
        [TestCase("XYZ", "XYZ", ExpectedResult = 1.0)]
        [TestCase("DWAYNE", "DUANE", ExpectedResult = 0.667)]
        [TestCase("MARTHA", "MARHTA", ExpectedResult = 0.833)]
        [TestCase("DIXON", "DICKSONX", ExpectedResult = 0.500)]
        [TestCase("JELLYFISH", "SMELLYFISH", ExpectedResult = 0.800)]
        public double Similarity_Damerau_Levenshtein(string s1, string s2)
        {
            var score = s1.DamerauLevenshteinSimilarityTo(s2);

            Assert.That(score, Is.EqualTo(s2.DamerauLevenshteinSimilarityTo(s1)));

            return Math.Round(score, 3, MidpointRounding.AwayFromZero);
        }

        [TestCase("", "", ExpectedResult = 1.0)]
        [TestCase("XYZ", "", ExpectedResult = 0.0)]
        [TestCase("XYZ", "XYZ", ExpectedResult = 1.0)]
        [TestCase("DWAYNE", "DUANE", ExpectedResult = 0.822)]
        [TestCase("MARTHA", "MARHTA", ExpectedResult = 0.944)]
        [TestCase("DIXON", "DICKSONX", ExpectedResult = 0.767)]
        [TestCase("JELLYFISH", "SMELLYFISH", ExpectedResult = 0.896)]
        public double Similarity_Jaro(string s1, string s2)
        {
            var score = s1.JaroSimilarityTo(s2);

            Assert.That(score, Is.EqualTo(s2.JaroSimilarityTo(s1)));

            return Math.Round(score, 3, MidpointRounding.AwayFromZero);
        }

        [TestCase("", "", ExpectedResult = 1.0)]
        [TestCase("XYZ", "", ExpectedResult = 0.0)]
        [TestCase("XYZ", "XYZ", ExpectedResult = 1.0)]
        [TestCase("DWAYNE", "DUANE", ExpectedResult = 0.840)]
        [TestCase("MARTHA", "MARHTA", ExpectedResult = 0.961)]
        [TestCase("DIXON", "DICKSONX", ExpectedResult = 0.813)]
        [TestCase("JELLYFISH", "SMELLYFISH", ExpectedResult = 0.896)]
        public double Similarity_Jaro_Winkler(string s1, string s2)
        {
            var score = s1.JaroWinklerSimilarityTo(s2);

            Assert.That(score, Is.EqualTo(s2.JaroWinklerSimilarityTo(s1)));

            return Math.Round(score, 3, MidpointRounding.AwayFromZero);
        }

    }
}
