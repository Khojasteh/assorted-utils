﻿# StringExtensions.SubstringBefore Method

> Namespace: [Assorted.Utils.Text](index.md#assortedutilstext-namespace)\
> Assembly: [Assorted.Utils](index.md) (Assorted.Utils.dll) version 1.1.0.0

Overload | Description
--- | ---
[SubstringBefore(this string, char)](Assorted.Utils.Text.StringExtensions.SubstringBefore.md#substringbeforethis-string-char) | Retrieves a substring from this instance. The substring starts at the beginning of the string and continues until the first occurrence of a specified Unicode character.
[SubstringBefore(this string, string)](Assorted.Utils.Text.StringExtensions.SubstringBefore.md#substringbeforethis-string-string) | Retrieves a substring from this instance. The substring starts at the beginning of the string and continues until the first occurrence of a specified string.

## SubstringBefore(this string, char)

Retrieves a substring from this instance. The substring starts at the beginning of the string and continues until the first occurrence of a specified Unicode character.

### Syntax

```csharp
public static string SubstringBefore(this string source, char value)
```

#### Parameters

`source`: [string](https://docs.microsoft.com/en-us/dotnet/api/system.string)\
The source string.

`value`: [char](https://docs.microsoft.com/en-us/dotnet/api/system.char)\
A Unicode character to seek.

#### Return Value

[string](https://docs.microsoft.com/en-us/dotnet/api/system.string)\
A substring of the original string if the `value` is found; otherwise, `null`.

### See Also

- [Assorted.Utils.Text Namespace](index.md#assortedutilstext-namespace)
- [StringExtensions Class](Assorted.Utils.Text.StringExtensions.md)

## SubstringBefore(this string, string)

Retrieves a substring from this instance. The substring starts at the beginning of the string and continues until the first occurrence of a specified string.

### Syntax

```csharp
public static string SubstringBefore(this string source, string value)
```

#### Parameters

`source`: [string](https://docs.microsoft.com/en-us/dotnet/api/system.string)\
The source string.

`value`: [string](https://docs.microsoft.com/en-us/dotnet/api/system.string)\
A string to seek.

#### Return Value

[string](https://docs.microsoft.com/en-us/dotnet/api/system.string)\
A substring of the original string if the `value` is found; otherwise, `null`.

### See Also

- [Assorted.Utils.Text Namespace](index.md#assortedutilstext-namespace)
- [StringExtensions Class](Assorted.Utils.Text.StringExtensions.md)

---

_This document is generated by [DG](https://github.com/Khojasteh/dg)._
