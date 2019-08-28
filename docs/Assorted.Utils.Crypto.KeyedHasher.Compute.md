# KeyedHasher.Compute Method

> Namespace: [Assorted.Utils.Crypto](index.md#assortedutilscrypto-namespace)\
> Assembly: [Assorted.Utils](index.md) (Assorted.Utils.dll) version 1.1.0.0

Returns the keyed-hash code of a specific object with a given secret key.

Overload | Description
--- | ---
[Compute(Byte[], Byte[])](Assorted.Utils.Crypto.KeyedHasher.Compute.md#computebyte-byte) | Returns the keyed-hash code of the specified array of bytes. The secret key is an array of bytes.
[Compute(Byte[], Stream)](Assorted.Utils.Crypto.KeyedHasher.Compute.md#computebyte-stream) | Returns the keyed-hash code of content of the specified stream. The secret key is an array of bytes.
[Compute(Byte[], string)](Assorted.Utils.Crypto.KeyedHasher.Compute.md#computebyte-string) | Returns the keyed-hash code of the specified string. The secret key is an array of bytes.
[Compute(string, Byte[])](Assorted.Utils.Crypto.KeyedHasher.Compute.md#computestring-byte) | Returns the keyed-hash code of the specified array of bytes. The secret key is a string.
[Compute(string, Stream)](Assorted.Utils.Crypto.KeyedHasher.Compute.md#computestring-stream) | Returns the keyed-hash code of the specified [`System.IO.Stream`](https://docs.microsoft.com/en-us/dotnet/api/system.io.stream) object. The secret key is a string.
[Compute(string, string)](Assorted.Utils.Crypto.KeyedHasher.Compute.md#computestring-string) | Returns the keyed-hash code of the specified string. The secret key is a string.

## Compute(Byte[], Byte[])

Returns the keyed-hash code of the specified array of bytes. The secret key is an array of bytes.

### Syntax

```csharp
public virtual Byte[] Compute(Byte[] key, Byte[] bytes)
```

#### Parameters

`key`: [Byte[]](https://docs.microsoft.com/en-us/dotnet/api/system.byte)\
The secret key as an array of bytes.

`bytes`: [Byte[]](https://docs.microsoft.com/en-us/dotnet/api/system.byte)\
An array of bytes to calculate its keyed-hash code.

#### Return Value

[Byte[]](https://docs.microsoft.com/en-us/dotnet/api/system.byte)\
The keyed-hash code of the specified `bytes` as an array of bytes.

### Exceptions

Exception | Description
--- | ---
[System.ArgumentNullException](https://docs.microsoft.com/en-us/dotnet/api/system.argumentnullexception) | `key` or `bytes` is `null`.

### See Also

- [Assorted.Utils.Crypto Namespace](index.md#assortedutilscrypto-namespace)
- [KeyedHasher Class](Assorted.Utils.Crypto.KeyedHasher.md)

## Compute(Byte[], Stream)

Returns the keyed-hash code of content of the specified stream. The secret key is an array of bytes.

### Syntax

```csharp
public abstract Byte[] Compute(Byte[] key, Stream stream)
```

#### Parameters

`key`: [Byte[]](https://docs.microsoft.com/en-us/dotnet/api/system.byte)\
The secret key for encryption.

`stream`: [Stream](https://docs.microsoft.com/en-us/dotnet/api/system.io.stream)\
A [`System.IO.Stream`](https://docs.microsoft.com/en-us/dotnet/api/system.io.stream) object to calculate the keyed-hash code of its content.

#### Return Value

[Byte[]](https://docs.microsoft.com/en-us/dotnet/api/system.byte)\
The keyed-hash code of content of the specified `stream` as an array of bytes.

### Exceptions

Exception | Description
--- | ---
[System.ArgumentNullException](https://docs.microsoft.com/en-us/dotnet/api/system.argumentnullexception) | `key` or `stream` is `null`.

### See Also

- [Assorted.Utils.Crypto Namespace](index.md#assortedutilscrypto-namespace)
- [KeyedHasher Class](Assorted.Utils.Crypto.KeyedHasher.md)

## Compute(Byte[], string)

Returns the keyed-hash code of the specified string. The secret key is an array of bytes.

### Syntax

```csharp
public Byte[] Compute(Byte[] key, string text)
```

#### Parameters

`key`: [Byte[]](https://docs.microsoft.com/en-us/dotnet/api/system.byte)\
The secret phrase.

`text`: [string](https://docs.microsoft.com/en-us/dotnet/api/system.string)\
A string to calculate its keyed-hash code.

#### Return Value

[Byte[]](https://docs.microsoft.com/en-us/dotnet/api/system.byte)\
The keyed-hash code of the specified `text` as an array of bytes.

### Exceptions

Exception | Description
--- | ---
[System.ArgumentNullException](https://docs.microsoft.com/en-us/dotnet/api/system.argumentnullexception) | `key` or `text` is `null`.

### See Also

- [Assorted.Utils.Crypto Namespace](index.md#assortedutilscrypto-namespace)
- [KeyedHasher Class](Assorted.Utils.Crypto.KeyedHasher.md)

## Compute(string, Byte[])

Returns the keyed-hash code of the specified array of bytes. The secret key is a string.

### Syntax

```csharp
public Byte[] Compute(string secret, Byte[] bytes)
```

#### Parameters

`secret`: [string](https://docs.microsoft.com/en-us/dotnet/api/system.string)\
The secret phrase.

`bytes`: [Byte[]](https://docs.microsoft.com/en-us/dotnet/api/system.byte)\
An array of bytes to calculate its keyed-hash code.

#### Return Value

[Byte[]](https://docs.microsoft.com/en-us/dotnet/api/system.byte)\
The keyed-hash code of the specified `bytes` as an array of bytes.

### Exceptions

Exception | Description
--- | ---
[System.ArgumentNullException](https://docs.microsoft.com/en-us/dotnet/api/system.argumentnullexception) | `secret` or `bytes` is `null`.

### See Also

- [Assorted.Utils.Crypto Namespace](index.md#assortedutilscrypto-namespace)
- [KeyedHasher Class](Assorted.Utils.Crypto.KeyedHasher.md)

## Compute(string, Stream)

Returns the keyed-hash code of the specified [`System.IO.Stream`](https://docs.microsoft.com/en-us/dotnet/api/system.io.stream) object. The secret key is a string.

### Syntax

```csharp
public Byte[] Compute(string secret, Stream stream)
```

#### Parameters

`secret`: [string](https://docs.microsoft.com/en-us/dotnet/api/system.string)\
The secret phrase.

`stream`: [Stream](https://docs.microsoft.com/en-us/dotnet/api/system.io.stream)\
A [`System.IO.Stream`](https://docs.microsoft.com/en-us/dotnet/api/system.io.stream) object to calculate the keyed-hash code of its content.

#### Return Value

[Byte[]](https://docs.microsoft.com/en-us/dotnet/api/system.byte)\
The keyed-hash code of content of the specified `stream` content as an array of bytes.

### Exceptions

Exception | Description
--- | ---
[System.ArgumentNullException](https://docs.microsoft.com/en-us/dotnet/api/system.argumentnullexception) | `secret` or `stream` is `null`.

### See Also

- [Assorted.Utils.Crypto Namespace](index.md#assortedutilscrypto-namespace)
- [KeyedHasher Class](Assorted.Utils.Crypto.KeyedHasher.md)

## Compute(string, string)

Returns the keyed-hash code of the specified string. The secret key is a string.

### Syntax

```csharp
public Byte[] Compute(string secret, string text)
```

#### Parameters

`secret`: [string](https://docs.microsoft.com/en-us/dotnet/api/system.string)\
The secret phrase.

`text`: [string](https://docs.microsoft.com/en-us/dotnet/api/system.string)\
A [`System.String`](https://docs.microsoft.com/en-us/dotnet/api/system.string) to calculate its keyed-hash code.

#### Return Value

[Byte[]](https://docs.microsoft.com/en-us/dotnet/api/system.byte)\
The keyed-hash code of the specified `text` as an array of bytes.

### Exceptions

Exception | Description
--- | ---
[System.ArgumentNullException](https://docs.microsoft.com/en-us/dotnet/api/system.argumentnullexception) | `secret` or `text` is `null`.

### See Also

- [Assorted.Utils.Crypto Namespace](index.md#assortedutilscrypto-namespace)
- [KeyedHasher Class](Assorted.Utils.Crypto.KeyedHasher.md)

---

_This document is generated by [DG](https://github.com/Khojasteh/dg)._
