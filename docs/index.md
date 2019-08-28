# Assorted.Utils Assembly (version 1.1.0.0)

The `Assorted.Utils` assembly exports types in the following namespaces.

## Assorted.Utils.Collections Namespace

The `Assorted.Utils.Collections` namespace exposes the following types.

### Classes

Class | Description
--- | ---
[DictionaryExtensions](Assorted.Utils.Collections.DictionaryExtensions.md) | Extends the dictionary collections.
[EnumerableExtensions](Assorted.Utils.Collections.EnumerableExtensions.md) | Extends the enumerable objects.
[ObjectPool\<T>](Assorted.Utils.Collections.ObjectPool-1.md) | Defines a pool of reusable objects.

## Assorted.Utils.Crypto Namespace

The `Assorted.Utils.Crypto` namespace exposes the following types.

### Classes

Class | Description
--- | ---
[ByteConvert](Assorted.Utils.Crypto.ByteConvert.md) | Converts an array of bytes to and from a string of hexadecimal digits.
[BytesExtensions](Assorted.Utils.Crypto.BytesExtensions.md) | Extends the array of bytes objects.
[CertExtenstions](Assorted.Utils.Crypto.CertExtenstions.md) | Extends objects of type [`System.Security.Cryptography.X509Certificates.X509Certificate2`](https://docs.microsoft.com/en-us/dotnet/api/system.security.cryptography.x509certificates.x509certificate2).
[CertUtils](Assorted.Utils.Crypto.CertUtils.md) | Provides some helper methods for working with [`System.Security.Cryptography.X509Certificates.X509Certificate2`](https://docs.microsoft.com/en-us/dotnet/api/system.security.cryptography.x509certificates.x509certificate2) objects.
[Hash](Assorted.Utils.Crypto.Hash.md) | This class provides access to the concrete and singleton instances of the [`Hasher`](Assorted.Utils.Crypto.Hasher.md) class for the most common hashing algorithms.
[Hasher](Assorted.Utils.Crypto.Hasher.md) | Defines an abstract hash algorithm.
[HasherProxy](Assorted.Utils.Crypto.HasherProxy.md) | Wraps a .NET hash algorithm.
[HMAC](Assorted.Utils.Crypto.HMAC.md) | This class provides access to the concrete and singleton instances of the [`KeyedHasher`](Assorted.Utils.Crypto.KeyedHasher.md) class for the most common HMAC hashing algorithms.
[KeyedHasher](Assorted.Utils.Crypto.KeyedHasher.md) | Defines an abstract keyed-hash (HMAC) algorithm.
[KeyedHasherProxy](Assorted.Utils.Crypto.KeyedHasherProxy.md) | Wraps a .NET keyed-hash (HMAC) algorithm.

## Assorted.Utils.Dates Namespace

The `Assorted.Utils.Dates` namespace exposes the following types.

### Classes

Class | Description
--- | ---
[DateTimeExtensions](Assorted.Utils.Dates.DateTimeExtensions.md) | Extends the [`System.DateTime`](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) type.
[DateUtils](Assorted.Utils.Dates.DateUtils.md) | Provides some helper methods for working with [`System.DateTime`](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) values.
[DayOfWeekExtensions](Assorted.Utils.Dates.DayOfWeekExtensions.md) | Extends the [`System.DayOfWeek`](https://docs.microsoft.com/en-us/dotnet/api/system.dayofweek) and [`DaysOfTheWeek`](Assorted.Utils.Dates.DaysOfTheWeek.md) data types.
[Recurrent](Assorted.Utils.Dates.Recurrent.md) | This class provides some factory methods creating concrete instances of the [`IRecurrentPattern`](Assorted.Utils.Dates.IRecurrentPattern.md) interface.

### Interfaces

Interface | Description
--- | ---
[IRecurrentPattern](Assorted.Utils.Dates.IRecurrentPattern.md) | Represents an object that generates a sequence of [`System.DateTime`](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) values based on a pattern.

### Enumerations

Enumeration | Description
--- | ---
[DaysOfTheWeek](Assorted.Utils.Dates.DaysOfTheWeek.md) | Represents days of the week.
[MonthOfYear](Assorted.Utils.Dates.MonthOfYear.md) | Represents months of the year.
[WeekOfMonth](Assorted.Utils.Dates.WeekOfMonth.md) | Represents weeks of the month.

## Assorted.Utils.Dates.Patterns Namespace

The `Assorted.Utils.Dates.Patterns` namespace exposes the following types.

### Classes

Class | Description
--- | ---
[DailyPattern](Assorted.Utils.Dates.Patterns.DailyPattern.md) | Generates a sequence of [`System.DateTime`](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) values based on a daily reoccurring pattern.
[MonthlyDayPattern](Assorted.Utils.Dates.Patterns.MonthlyDayPattern.md) | Generates a sequence of [`System.DateTime`](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) values based on a monthly reoccurring pattern when events occur on a specific day of the month.
[MonthlyWeekPattern](Assorted.Utils.Dates.Patterns.MonthlyWeekPattern.md) | Generates a sequence of [`System.DateTime`](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) values based on a monthly reoccurring pattern when events occur on a specific day of the week and a specific week of the month.
[WeeklyPattern](Assorted.Utils.Dates.Patterns.WeeklyPattern.md) | Generates a sequence of [`System.DateTime`](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) values based on a weekly reoccurring pattern when events occur on some specific days of the week.
[YearlyDayPattern](Assorted.Utils.Dates.Patterns.YearlyDayPattern.md) | Generates a sequence of [`System.DateTime`](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) values based on a yearly reoccurring pattern when events occur on a specific day of the year.
[YearlyMonthPattern](Assorted.Utils.Dates.Patterns.YearlyMonthPattern.md) | Generates a sequence of [`System.DateTime`](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) values based on a monthly reoccurring pattern when events occur on a specific day of a specific month of the year.
[YearlyWeekPattern](Assorted.Utils.Dates.Patterns.YearlyWeekPattern.md) | Generates a sequence of [`System.DateTime`](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) values based on a monthly reoccurring pattern when events occur on a specific day of the week and a specific week of a month of the year.

## Assorted.Utils.Serialization Namespace

The `Assorted.Utils.Serialization` namespace exposes the following types.

### Classes

Class | Description
--- | ---
[BinarySerializer](Assorted.Utils.Serialization.BinarySerializer.md) | Serializes and deserializes objects into and from binary/base-64 format.
[ConvertExtensions](Assorted.Utils.Serialization.ConvertExtensions.md) | Extends primitive data types by adding the `ToStandardString()` method to them. The method returns the string representation of the extended objects in culture independent format.
[ConvertUtils](Assorted.Utils.Serialization.ConvertUtils.md) | Provides some helper methods for converting primitive values from their culture independent string representation.
[JsonSerializer](Assorted.Utils.Serialization.JsonSerializer.md) | Serializes and deserializes objects into and from JSON format.
[Serializer](Assorted.Utils.Serialization.Serializer.md) | This class provides access to the concrete and singleton instances of the [`ISerializer`](Assorted.Utils.Serialization.ISerializer.md) interface.
[Utf8StringWriter](Assorted.Utils.Serialization.Utf8StringWriter.md) | Implements a [`System.IO.StringWriter`](https://docs.microsoft.com/en-us/dotnet/api/system.io.stringwriter) with UTF-8 encoding.
[XmlSerializer](Assorted.Utils.Serialization.XmlSerializer.md) | Serializes and deserializes objects into and from XML documents.

### Interfaces

Interface | Description
--- | ---
[ISerializer](Assorted.Utils.Serialization.ISerializer.md) | Represents an object that can serialize/deserialize other objects.

## Assorted.Utils.Text Namespace

The `Assorted.Utils.Text` namespace exposes the following types.

### Classes

Class | Description
--- | ---
[KMPSearch](Assorted.Utils.Text.KMPSearch.md) | Implements Knuth–Morris–Pratt string-search algorithm.
[StringBuilderPool](Assorted.Utils.Text.StringBuilderPool.md) | Defines a pool of reusable [`System.Text.StringBuilder`](https://docs.microsoft.com/en-us/dotnet/api/system.text.stringbuilder) objects.
[StringExtensions](Assorted.Utils.Text.StringExtensions.md) | Extends the [`System.String`](https://docs.microsoft.com/en-us/dotnet/api/system.string) type.
[StringStream](Assorted.Utils.Text.StringStream.md) | Creates a stream whose backing store is string.

---

_This document is generated by [DG](https://github.com/Khojasteh/dg)._
