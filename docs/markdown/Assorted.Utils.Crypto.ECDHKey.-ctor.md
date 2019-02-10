﻿# ECDHKey Constructor

> Namespace: [Assorted.Utils.Crypto](_toc.Assorted.Utils.md#Assorted.Utils.Crypto%20Namespace)\
> Assembly: [Assorted.Utils](_toc.Assorted.Utils.md) (Assorted.Utils.dll) version 1.0.0.0

Initializes a new instance of [`ECDHKey`](Assorted.Utils.Crypto.ECDHKey.md) class.

Overload | Description
--- | ---
[ECDHKey(CngAlgorithm, string)](Assorted.Utils.Crypto.ECDHKey.-ctor.md#ECDHKey%28CngAlgorithm%2C%20string%29) | Initializes a new instance of [`ECDHKey`](Assorted.Utils.Crypto.ECDHKey.md) class, using the specified curve algorithm.
[ECDHKey(string)](Assorted.Utils.Crypto.ECDHKey.-ctor.md#ECDHKey%28string%29) | Initializes a new instance of [`ECDHKey`](Assorted.Utils.Crypto.ECDHKey.md) class, using Elliptic Curve Diffie-Hellmann P-256.

## ECDHKey(CngAlgorithm, string)

Initializes a new instance of [`ECDHKey`](Assorted.Utils.Crypto.ECDHKey.md) class, using the specified curve algorithm.

### Syntax

```csharp
public ECDHKey(CngAlgorithm algorithm, string keyName = null)
```

#### Parameters

`algorithm`: [CngAlgorithm](https://docs.microsoft.com/en-us/dotnet/api/system.security.cryptography.cngalgorithm)\
The algorithm the key will be used with.

`keyName`: [string](https://docs.microsoft.com/en-us/dotnet/api/system.string)\
The name of the key, if the key should be persisted.

### Exceptions

Exception | Description
--- | ---
[System.ArgumentNullException](https://docs.microsoft.com/en-us/dotnet/api/system.argumentnullexception) | `algorithm` is `null`.
[System.ArgumentException](https://docs.microsoft.com/en-us/dotnet/api/system.argumentexception) | `algorithm` is not a valid curve algorithm.
[System.InvalidOperationException](https://docs.microsoft.com/en-us/dotnet/api/system.invalidoperationexception) | The key specified by `keyName` is not using the specified `algorithm`.

### See Also

- [Assorted.Utils.Crypto Namespace](_toc.Assorted.Utils.md#Assorted.Utils.Crypto%20Namespace)
- [ECDHKey Class](Assorted.Utils.Crypto.ECDHKey.md)

## ECDHKey(string)

Initializes a new instance of [`ECDHKey`](Assorted.Utils.Crypto.ECDHKey.md) class, using Elliptic Curve Diffie-Hellmann P-256.

### Syntax

```csharp
public ECDHKey(string keyName = null)
```

#### Parameters

`keyName`: [string](https://docs.microsoft.com/en-us/dotnet/api/system.string)\
The name of the key, if the key should be persisted.

### See Also

- [Assorted.Utils.Crypto Namespace](_toc.Assorted.Utils.md#Assorted.Utils.Crypto%20Namespace)
- [ECDHKey Class](Assorted.Utils.Crypto.ECDHKey.md)

---

_This document is generated by [DG](https://github.com/Khojasteh/dg)._