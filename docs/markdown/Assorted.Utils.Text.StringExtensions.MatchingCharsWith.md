﻿# StringExtensions.MatchingCharsWith(this string, string) Method

> Namespace: [Assorted.Utils.Text](_toc.Assorted.Utils.md#Assorted.Utils.Text%20Namespace)\
> Assembly: [Assorted.Utils](_toc.Assorted.Utils.md) (Assorted.Utils.dll) version 1.0.0.0

Returns the number of leading and trailing Unicode characters that appear in both strings.

## Syntax

```csharp
public static ValueTuple<int, int> MatchingCharsWith(this string source, string other)
```

### Parameters

`source`: [string](https://docs.microsoft.com/en-us/dotnet/api/system.string)\
The source string.

`other`: [string](https://docs.microsoft.com/en-us/dotnet/api/system.string)\
The other string.

### Return Value

[ValueTuple\<int, int>](https://docs.microsoft.com/en-us/dotnet/api/system.valuetuple-2,)\
A [`System.Tuple<T1, T2>`](https://docs.microsoft.com/en-us/dotnet/api/system.tuple-2) that contains the number of leading and trailing matched Unicode characters.

## Exceptions

Exception | Description
--- | ---
[System.ArgumentNullException](https://docs.microsoft.com/en-us/dotnet/api/system.argumentnullexception) | `source` or `other` is `null`.

## See Also

- [Assorted.Utils.Text Namespace](_toc.Assorted.Utils.md#Assorted.Utils.Text%20Namespace)
- [StringExtensions Class](Assorted.Utils.Text.StringExtensions.md)

---

_This document is generated by [DG](https://github.com/Khojasteh/dg)._