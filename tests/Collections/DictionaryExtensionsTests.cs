using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Assorted.Utils.Collections.Tests
{
    [TestFixture]
    [TestOf(typeof(DictionaryExtensions))]
    public class DictionaryExtensionsTests
    {
        [Test]
        public void Dictionary_GetValueOrDefault_GenericKey_GenericValue_KeyExists()
        {
            var dic = new Dictionary<string, double>()
            {
                { "X", 1.25 },
                { "Y", 1.50 },
            };

            var result = dic.GetValueOrDefault("X");

            Assert.That(result, Is.TypeOf<double>().And.EqualTo(1.25));
        }

        [Test]
        public void Dictionary_GetValueOrDefault_GenericKey_GenericValue_KeyDoesNotExist()
        {
            var dic = new Dictionary<string, double>()
            {
                { "X", 1.25 },
                { "Y", 1.50 },
            };

            var result = dic.GetValueOrDefault("Z", defaultValue: 1.75);

            Assert.That(result, Is.TypeOf<double>().And.EqualTo(1.75));
        }

        [Test]
        public void Dictionary_GetValueOrDefault_GenericKey_GenericValue_KeyIsNull()
        {
            var dic = new Dictionary<string, double>()
            {
                { "X", 1.25 },
                { "Y", 1.50 },
            };

            var result = dic.GetValueOrDefault(null, defaultValue: -1.0);

            Assert.That(result, Is.TypeOf<double>().And.EqualTo(-1.0));
        }

        [Test]
        public void Dictionary_GetValueOrDefault_StringKey_ObjectValue_KeyExist()
        {
            var dic = new Dictionary<string, object>()
            {
                { "X", TimeSpan.FromHours(12.0) },
                { "Y", new List<int>() { 1, 2 } },
            };

            var result = dic.GetValueOrDefault("X", defaultValue: TimeSpan.Zero);

            Assert.That(result, Is.TypeOf<TimeSpan>().And.EqualTo(TimeSpan.FromHours(12.0)));
        }

        [Test]
        public void Dictionary_GetValueOrDefault_StringKey_ObjectValue_KeyExist_But_TypeIsWrong()
        {
            var dic = new Dictionary<string, object>()
            {
                { "X", TimeSpan.FromHours(12.0) },
                { "Y", new List<int>() { 1, 2 } },
            };

            Assert.Throws<InvalidCastException>(() => dic.GetValueOrDefault("X", defaultValue: DateTime.Now));
        }

        [Test]
        public void Dictionary_GetValueOrDefault_StringKey_ObjectValue_KeyDoesNotExist()
        {
            var dic = new Dictionary<string, object>()
            {
                { "X", TimeSpan.FromHours(12.0) },
                { "Y", new List<int>() { 1, 2 } },
            };

            var result = dic.GetValueOrDefault("Z", defaultValue: DateTime.MaxValue);

            Assert.That(result, Is.TypeOf<DateTime>());
            Assert.That(result, Is.EqualTo(DateTime.MaxValue));
        }

        [Test]
        public void Dictionary_GetValueOrDefault_StringKey_ObjectValue_KeyIsNull()
        {
            var dic = new Dictionary<string, object>()
            {
                { "X", TimeSpan.FromHours(12.0) },
                { "Y", new List<int>() { 1, 2 } },
            };

            var result = dic.GetValueOrDefault(null, defaultValue: "DEFAULT");

            Assert.That(result, Is.TypeOf<string>());
            Assert.That(result, Is.EqualTo("DEFAULT"));
        }

        [Test]
        public void Dictionary_GetValuesFor_GivenKeys_WithoutDefault()
        {
            var dic = new Dictionary<string, int>()
            {
                { "X", 1 },
                { "Y", 3 },
                { "Z", 5 },
            };

            var result = dic.GetValuesFor(new[] { "Z", "X", "NOT_EXISTING_KEY" });

            Assert.That(result, Is.EqualTo(new[] { 5, 1 }));
        }

        [Test]
        public void Dictionary_GetValuesFor_GivenKeys_WithDefault()
        {
            var dic = new Dictionary<string, int>()
            {
                { "X", 1 },
                { "Y", 3 },
                { "Z", 5 },
            };

            var result = dic.GetValuesFor(new[] { "Z", "X", "NOT_EXISTING_KEY" }, defaultValue: 0);

            Assert.That(result, Is.EqualTo(new[] { 5, 1, 0 }));
        }

        [Test]
        public void Dictionary_ForEach_FoundKey_WithouDefault()
        {
            var dic = new Dictionary<string, int>()
            {
                { "X", 1 },
                { "Y", 3 },
                { "Z", 5 },
            };

            var foundKeys = new List<string>();
            var sum = 0;

            dic.ForEach(new[] { "Z", "X", "NOT_EXISTING_KEY" }, action: (key, value) =>
            {
                foundKeys.Add(key);
                sum += value;
            });

            Assert.That(foundKeys, Is.EqualTo(new[] { "Z", "X" }));
            Assert.That(sum, Is.EqualTo(6));
        }

        [Test]
        public void Dictionary_ForEach_FoundKey_WithDefault()
        {
            var dic = new Dictionary<string, int>()
            {
                { "X", 1 },
                { "Y", 3 },
                { "Z", 5 },
            };

            var keysFound = new List<string>();
            var keysNotFound = new List<string>();
            var sum = 0;

            dic.ForEach(new[] { "Z", "X", "NOT_EXISTING_KEY" }, 
                hitAction: (key, value) =>
                {
                    keysFound.Add(key);
                    sum += value;
                },
                missAction: (key) =>
                {
                    keysNotFound.Add(key);
                    sum += 100;
                });

            Assert.That(keysFound, Is.EqualTo(new[] { "Z", "X" }));
            Assert.That(keysNotFound, Is.EqualTo(new[] { "NOT_EXISTING_KEY" }));
            Assert.That(sum, Is.EqualTo(106));
        }

        [Test]
        public void Dictionary_RemoveEntries_Where()
        {
            var dic = new Dictionary<string, int>()
            {
                { "A", 1 },
                { "B", 2 },
                { "C", 3 },
                { "D", 4 },
                { "E", 5 },
            };

            dic.RemoveWhere((key, value) => key == "D" || value % 2 == 1);

            Assert.That(dic, Has.Exactly(1).Items);
            Assert.That(dic, Contains.Key("B"));
            Assert.That(dic, Contains.Value(2));
        }
    }
}