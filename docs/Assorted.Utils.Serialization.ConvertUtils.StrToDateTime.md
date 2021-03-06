﻿# ConvertUtils.StrToDateTime(string) Method

> Namespace: [Assorted.Utils.Serialization](index.md#assortedutilsserialization-namespace)\
> Assembly: [Assorted.Utils](index.md) (Assorted.Utils.dll) version 1.1.0.0

Converts the specified standard string representation of a date and time to its [`System.DateTime`](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) equivalent. The leading and trailing white spaces are ignored.

## Syntax

```csharp
public static DateTime? StrToDateTime(string value)
```

### Parameters

`value`: [string](https://docs.microsoft.com/en-us/dotnet/api/system.string)\
The string representation of a date and time in one of these formats: 

- `"yyyy'-'MM'-'dd'T'HH':'mm':'ss'.'FFFFFFFK"`

- `"yyyy'-'MM'-'dd'T'HH':'mm':'ssK"`

- `"yyyy'-'MM'-'dd'T'HH':'mm':'ss"`

- `"yyyy'-'MM'-'dd HH':'mm':'ss"`

- `"r"` (RFC1123)



### Return Value

[DateTime?](https://docs.microsoft.com/en-us/dotnet/api/system.nullable-1)\
A [`System.DateTime`](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) whose value is represented by `value` if the operation succeeds; otherwise, `null`.

## See Also

- [Assorted.Utils.Serialization Namespace](index.md#assortedutilsserialization-namespace)
- [ConvertUtils Class](Assorted.Utils.Serialization.ConvertUtils.md)

---

_This document is generated by [DG](https://github.com/Khojasteh/dg)._
