﻿# Hasher Class

> Namespace: [Assorted.Utils.Crypto](index.md#assortedutilscrypto-namespace)\
> Assembly: [Assorted.Utils](index.md) (Assorted.Utils.dll) version 1.0.0.0\
> Inheritance: [object](https://docs.microsoft.com/en-us/dotnet/api/system.object) `→` Hasher

Defines an abstract hash algorithm.

## Syntax

```csharp
public abstract class Hasher
```

## Constructors

Constructor | Description
--- | ---
[Hasher()](Assorted.Utils.Crypto.Hasher.-ctor.md) | Initializes a new instance of [Hasher](Assorted.Utils.Crypto.Hasher.md) class.

## Properties

Property | Description
--- | ---
[Size](Assorted.Utils.Crypto.Hasher.Size.md) | Gets the size, in bits, of the computed hash code.

## Methods

Method | Description
--- | ---
[Compute(Byte[])](Assorted.Utils.Crypto.Hasher.Compute.md#computebyte) | Returns the hash code of the specified array of bytes.
[Compute(Stream)](Assorted.Utils.Crypto.Hasher.Compute.md#computestream) | Returns the hash code of content of the specified [`System.IO.Stream`](https://docs.microsoft.com/en-us/dotnet/api/system.io.stream) object.
[Compute(string)](Assorted.Utils.Crypto.Hasher.Compute.md#computestring) | Returns the hash code of the specified string.

## See Also

- [Assorted.Utils.Crypto Namespace](index.md#assortedutilscrypto-namespace)

---

_This document is generated by [DG](https://github.com/Khojasteh/dg)._