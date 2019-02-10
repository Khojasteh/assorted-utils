﻿# StringExtensions.JaroWinklerSimilarityTo(this string, string, int) Method

> Namespace: [Assorted.Utils.Text](_toc.Assorted.Utils.md#Assorted.Utils.Text%20Namespace)\
> Assembly: [Assorted.Utils](_toc.Assorted.Utils.md) (Assorted.Utils.dll) version 1.0.0.0

Returns the normalized Jaro-Winkler distance between two strings.

## Syntax

```csharp
public static double JaroWinklerSimilarityTo(
    this string source, 
    string other, 
    int maxPrefixLength = 4
)
```

### Parameters

`source`: [string](https://docs.microsoft.com/en-us/dotnet/api/system.string)\
The source string.

`other`: [string](https://docs.microsoft.com/en-us/dotnet/api/system.string)\
The other string.

`maxPrefixLength`: [int](https://docs.microsoft.com/en-us/dotnet/api/system.int32)\
The maximum length of common prefixes.

### Return Value

[double](https://docs.microsoft.com/en-us/dotnet/api/system.double)\
A value between `0` and `1` such that `0` equates to no similarity and `1` is an exact match.

## Exceptions

Exception | Description
--- | ---
[System.ArgumentNullException](https://docs.microsoft.com/en-us/dotnet/api/system.argumentnullexception) | `source` or `other` is `null`.

## See Also

- [Assorted.Utils.Text Namespace](_toc.Assorted.Utils.md#Assorted.Utils.Text%20Namespace)
- [StringExtensions Class](Assorted.Utils.Text.StringExtensions.md)
- [JaroSimilarityTo(this string, string)](Assorted.Utils.Text.StringExtensions.JaroSimilarityTo.md)
- [DamerauLevenshteinSimilarityTo(this string, string)](Assorted.Utils.Text.StringExtensions.DamerauLevenshteinSimilarityTo.md)

---

_This document is generated by [DG](https://github.com/Khojasteh/dg)._