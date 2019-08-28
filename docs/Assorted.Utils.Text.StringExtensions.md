# StringExtensions Class

> Namespace: [Assorted.Utils.Text](index.md#assortedutilstext-namespace)\
> Assembly: [Assorted.Utils](index.md) (Assorted.Utils.dll) version 1.1.0.0\
> Inheritance: [object](https://docs.microsoft.com/en-us/dotnet/api/system.object) `→` StringExtensions

Extends the [`System.String`](https://docs.microsoft.com/en-us/dotnet/api/system.string) type.

## Syntax

```csharp
public static class StringExtensions
```

## Methods

Method | Description
--- | ---
[DamerauLevenshteinSimilarityTo(this string, string)](Assorted.Utils.Text.StringExtensions.DamerauLevenshteinSimilarityTo.md) | Returns the normalized Damerau-Levenshtein distance between two strings.
[JaroSimilarityTo(this string, string)](Assorted.Utils.Text.StringExtensions.JaroSimilarityTo.md) | Returns the normalized Jaro distance between two strings.
[JaroWinklerSimilarityTo(this string, string, int)](Assorted.Utils.Text.StringExtensions.JaroWinklerSimilarityTo.md) | Returns the normalized Jaro-Winkler distance between two strings.
[LastPartition(this string, char)](Assorted.Utils.Text.StringExtensions.LastPartition.md#lastpartitionthis-string-char) | Splits the string at the last occurrence of a specified Unicode character and returns the substrings before and after the separator.
[LastPartition(this string, string)](Assorted.Utils.Text.StringExtensions.LastPartition.md#lastpartitionthis-string-string) | Splits the string at the last occurrence of a specified string and returns the substrings before and after the separator.
[LazySplit(this string, char, StringSplitOptions)](Assorted.Utils.Text.StringExtensions.LazySplit.md) | Returns the substrings in this string that are delimited by a specified Unicode character.
[MatchingCharsWith(this string, string)](Assorted.Utils.Text.StringExtensions.MatchingCharsWith.md) | Returns the number of leading and trailing Unicode characters that appear in both strings.
[Partition(this string, char)](Assorted.Utils.Text.StringExtensions.Partition.md#partitionthis-string-char) | Splits the string at the first occurrence of a specified Unicode character and returns the substrings before and after the separator.
[Partition(this string, string)](Assorted.Utils.Text.StringExtensions.Partition.md#partitionthis-string-string) | Splits the string at the first occurrence of a specified string and returns the substrings before and after the separator.
[SubstringAfter(this string, char)](Assorted.Utils.Text.StringExtensions.SubstringAfter.md#substringafterthis-string-char) | Retrieves a substring from this instance. The substring starts after the first occurrence of a specified Unicode character and continues to the end of the string.
[SubstringAfter(this string, string)](Assorted.Utils.Text.StringExtensions.SubstringAfter.md#substringafterthis-string-string) | Retrieves a substring from this instance. The substring starts after the first occurrence of a specified string and continues to the end of the string.
[SubstringAfterLast(this string, char)](Assorted.Utils.Text.StringExtensions.SubstringAfterLast.md#substringafterlastthis-string-char) | Retrieves a substring from this instance. The substring starts after the last occurrence of a specified Unicode character and continues to the end of the string.
[SubstringAfterLast(this string, string)](Assorted.Utils.Text.StringExtensions.SubstringAfterLast.md#substringafterlastthis-string-string) | Retrieves a substring from this instance. The substring starts after the last occurrence of a specified string and continues to the end of the string.
[SubstringBefore(this string, char)](Assorted.Utils.Text.StringExtensions.SubstringBefore.md#substringbeforethis-string-char) | Retrieves a substring from this instance. The substring starts at the beginning of the string and continues until the first occurrence of a specified Unicode character.
[SubstringBefore(this string, string)](Assorted.Utils.Text.StringExtensions.SubstringBefore.md#substringbeforethis-string-string) | Retrieves a substring from this instance. The substring starts at the beginning of the string and continues until the first occurrence of a specified string.
[SubstringBeforeLast(this string, char)](Assorted.Utils.Text.StringExtensions.SubstringBeforeLast.md#substringbeforelastthis-string-char) | Retrieves a substring from this instance. The substring starts at the beginning of the string and continues until the last occurrence of a specified Unicode character.
[SubstringBeforeLast(this string, string)](Assorted.Utils.Text.StringExtensions.SubstringBeforeLast.md#substringbeforelastthis-string-string) | Retrieves a substring from this instance. The substring starts at the beginning of the string and continues until the last occurrence of a specified string.

## Thread Safety

Any public static member of this type is thread\-safe, but instance members are not guaranteed to be thread\-safe.

## See Also

- [Assorted.Utils.Text Namespace](index.md#assortedutilstext-namespace)

---

_This document is generated by [DG](https://github.com/Khojasteh/dg)._
