﻿# ConvertUtils.StrToInt64(string) Method

> Namespace: [Assorted.Utils.Serialization](index.md#assortedutilsserialization-namespace)\
> Assembly: [Assorted.Utils](index.md) (Assorted.Utils.dll) version 1.1.0.0

Converts the specified standard string representation of an integer number to its [`System.Int64`](https://docs.microsoft.com/en-us/dotnet/api/system.int64) equivalent. The leading and trailing white spaces are ignored.

## Syntax

```csharp
public static long? StrToInt64(string value)
```

### Parameters

`value`: [string](https://docs.microsoft.com/en-us/dotnet/api/system.string)\
The string representation of an integer value.

### Return Value

[long?](https://docs.microsoft.com/en-us/dotnet/api/system.nullable-1)\
A 64-bit signed integer number whose value is represented by `value` if the operation succeeds; otherwise, `null`.

## See Also

- [Assorted.Utils.Serialization Namespace](index.md#assortedutilsserialization-namespace)
- [ConvertUtils Class](Assorted.Utils.Serialization.ConvertUtils.md)

---

_This document is generated by [DG](https://github.com/Khojasteh/dg)._
