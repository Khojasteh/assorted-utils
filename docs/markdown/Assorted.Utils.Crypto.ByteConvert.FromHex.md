﻿# ByteConvert.FromHex(string) Method

> Namespace: [Assorted.Utils.Crypto](_toc.Assorted.Utils.md#Assorted.Utils.Crypto%20Namespace)\
> Assembly: [Assorted.Utils](_toc.Assorted.Utils.md) (Assorted.Utils.dll) version 1.0.0.0

Converts a hexadecimal string to its equivalent array of bytes.

## Syntax

```csharp
public static Byte[] FromHex(string hex)
```

### Parameters

`hex`: [string](https://docs.microsoft.com/en-us/dotnet/api/system.string)\
A string of hexadecimal digits.

### Return Value

[Byte[]](https://docs.microsoft.com/en-us/dotnet/api/system.byte)\
An array of bytes.

## Exceptions

Exception | Description
--- | ---
[System.ArgumentNullException](https://docs.microsoft.com/en-us/dotnet/api/system.argumentnullexception) | `hex` is `null`.
[System.FormatException](https://docs.microsoft.com/en-us/dotnet/api/system.formatexception) | `hex` is not in a valid format.

## See Also

- [Assorted.Utils.Crypto Namespace](_toc.Assorted.Utils.md#Assorted.Utils.Crypto%20Namespace)
- [ByteConvert Class](Assorted.Utils.Crypto.ByteConvert.md)

---

_This document is generated by [DG](https://github.com/Khojasteh/dg)._