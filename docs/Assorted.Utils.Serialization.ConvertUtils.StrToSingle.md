﻿# ConvertUtils.StrToSingle(string) Method

> Namespace: [Assorted.Utils.Serialization](index.md#assortedutilsserialization-namespace)\
> Assembly: [Assorted.Utils](index.md) (Assorted.Utils.dll) version 1.1.0.0

Converts the specified standard string representation of a real number to its [`System.Single`](https://docs.microsoft.com/en-us/dotnet/api/system.single) equivalent. The leading and trailing white spaces are ignored.

## Syntax

```csharp
public static float? StrToSingle(string value)
```

### Parameters

`value`: [string](https://docs.microsoft.com/en-us/dotnet/api/system.string)\
The string representation of a real value.

### Return Value

[float?](https://docs.microsoft.com/en-us/dotnet/api/system.nullable-1)\
A single-precision floating-point number whose value is represented by `value` if the operation succeeds; otherwise, `null`.

## See Also

- [Assorted.Utils.Serialization Namespace](index.md#assortedutilsserialization-namespace)
- [ConvertUtils Class](Assorted.Utils.Serialization.ConvertUtils.md)

---

_This document is generated by [DG](https://github.com/Khojasteh/dg)._
