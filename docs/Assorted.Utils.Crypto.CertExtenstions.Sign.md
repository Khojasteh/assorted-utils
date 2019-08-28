# CertExtenstions.Sign Method

> Namespace: [Assorted.Utils.Crypto](index.md#assortedutilscrypto-namespace)\
> Assembly: [Assorted.Utils](index.md) (Assorted.Utils.dll) version 1.1.0.0

Overload | Description
--- | ---
[Sign(this X509Certificate2, Byte[])](Assorted.Utils.Crypto.CertExtenstions.Sign.md#signthis-x509certificate2-byte) | Computes the hash value of the specified byte array using SHA-256 algorithm and PSS padding mode, and signs the resulting hash value.
[Sign(this X509Certificate2, Byte[], HashAlgorithmName, RSASignaturePadding)](Assorted.Utils.Crypto.CertExtenstions.Sign.md#signthis-x509certificate2-byte-hashalgorithmname-rsasignaturepadding) | Computes the hash value of the specified byte array using the specified hash algorithm and padding mode, and signs the resulting hash value.
[Sign(this X509Certificate2, Stream)](Assorted.Utils.Crypto.CertExtenstions.Sign.md#signthis-x509certificate2-stream) | Computes the hash value of the specified stream using SHA-256 hash algorithm and PSS padding mode, and signs the resulting hash value.
[Sign(this X509Certificate2, Stream, HashAlgorithmName, RSASignaturePadding)](Assorted.Utils.Crypto.CertExtenstions.Sign.md#signthis-x509certificate2-stream-hashalgorithmname-rsasignaturepadding) | Computes the hash value of the specified stream using the specified hash algorithm and padding mode, and signs the resulting hash value.
[Sign(this X509Certificate2, string)](Assorted.Utils.Crypto.CertExtenstions.Sign.md#signthis-x509certificate2-string) | Computes the hash value of the specified string using SHA-256 hash algorithm and PSS padding mode, and signs the resulting hash value.
[Sign(this X509Certificate2, string, HashAlgorithmName, RSASignaturePadding)](Assorted.Utils.Crypto.CertExtenstions.Sign.md#signthis-x509certificate2-string-hashalgorithmname-rsasignaturepadding) | Computes the hash value of the specified string using the specified hash algorithm and padding mode, and signs the resulting hash value.

## Sign(this X509Certificate2, Byte[])

Computes the hash value of the specified byte array using SHA-256 algorithm and PSS padding mode, and signs the resulting hash value.

### Syntax

```csharp
public static Byte[] Sign(this X509Certificate2 cert, Byte[] data)
```

#### Parameters

`cert`: [X509Certificate2](https://docs.microsoft.com/en-us/dotnet/api/system.security.cryptography.x509certificates.x509certificate2)\
A certificate object with private key.

`data`: [Byte[]](https://docs.microsoft.com/en-us/dotnet/api/system.byte)\
The input data for which to compute the hash.

#### Return Value

[Byte[]](https://docs.microsoft.com/en-us/dotnet/api/system.byte)\
The RSA signature for the specified data.

### Exceptions

Exception | Description
--- | ---
[System.ArgumentNullException](https://docs.microsoft.com/en-us/dotnet/api/system.argumentnullexception) | `cert` or `data` is `null`.
[System.InvalidOperationException](https://docs.microsoft.com/en-us/dotnet/api/system.invalidoperationexception) | The certificate does not have an RSA private key.

### See Also

- [Assorted.Utils.Crypto Namespace](index.md#assortedutilscrypto-namespace)
- [CertExtenstions Class](Assorted.Utils.Crypto.CertExtenstions.md)

## Sign(this X509Certificate2, Byte[], HashAlgorithmName, RSASignaturePadding)

Computes the hash value of the specified byte array using the specified hash algorithm and padding mode, and signs the resulting hash value.

### Syntax

```csharp
public static Byte[] Sign(
    this X509Certificate2 cert, 
    Byte[] data, 
    HashAlgorithmName hashAlgorithm, 
    RSASignaturePadding padding
)
```

#### Parameters

`cert`: [X509Certificate2](https://docs.microsoft.com/en-us/dotnet/api/system.security.cryptography.x509certificates.x509certificate2)\
A certificate object with private key.

`data`: [Byte[]](https://docs.microsoft.com/en-us/dotnet/api/system.byte)\
The input data for which to compute the hash.

`hashAlgorithm`: [HashAlgorithmName](https://docs.microsoft.com/en-us/dotnet/api/system.security.cryptography.hashalgorithmname)\
The hash algorithm to use to create the hash value.

`padding`: [RSASignaturePadding](https://docs.microsoft.com/en-us/dotnet/api/system.security.cryptography.rsasignaturepadding)\
The padding mode.

#### Return Value

[Byte[]](https://docs.microsoft.com/en-us/dotnet/api/system.byte)\
The RSA signature for the specified data.

### Exceptions

Exception | Description
--- | ---
[System.ArgumentNullException](https://docs.microsoft.com/en-us/dotnet/api/system.argumentnullexception) | `cert`, `data`, or `padding` is `null`.

### See Also

- [Assorted.Utils.Crypto Namespace](index.md#assortedutilscrypto-namespace)
- [CertExtenstions Class](Assorted.Utils.Crypto.CertExtenstions.md)

## Sign(this X509Certificate2, Stream)

Computes the hash value of the specified stream using SHA-256 hash algorithm and PSS padding mode, and signs the resulting hash value.

### Syntax

```csharp
public static Byte[] Sign(this X509Certificate2 cert, Stream stream)
```

#### Parameters

`cert`: [X509Certificate2](https://docs.microsoft.com/en-us/dotnet/api/system.security.cryptography.x509certificates.x509certificate2)\
A certificate object with private key.

`stream`: [Stream](https://docs.microsoft.com/en-us/dotnet/api/system.io.stream)\
The input stream for which to compute the hash.

#### Return Value

[Byte[]](https://docs.microsoft.com/en-us/dotnet/api/system.byte)\
The RSA signature for the specified data.

### Exceptions

Exception | Description
--- | ---
[System.ArgumentNullException](https://docs.microsoft.com/en-us/dotnet/api/system.argumentnullexception) | `cert` or `stream` is `null`.
[System.InvalidOperationException](https://docs.microsoft.com/en-us/dotnet/api/system.invalidoperationexception) | The certificate does not have an RSA private key.

### See Also

- [Assorted.Utils.Crypto Namespace](index.md#assortedutilscrypto-namespace)
- [CertExtenstions Class](Assorted.Utils.Crypto.CertExtenstions.md)

## Sign(this X509Certificate2, Stream, HashAlgorithmName, RSASignaturePadding)

Computes the hash value of the specified stream using the specified hash algorithm and padding mode, and signs the resulting hash value.

### Syntax

```csharp
public static Byte[] Sign(
    this X509Certificate2 cert, 
    Stream stream, 
    HashAlgorithmName hashAlgorithm, 
    RSASignaturePadding padding
)
```

#### Parameters

`cert`: [X509Certificate2](https://docs.microsoft.com/en-us/dotnet/api/system.security.cryptography.x509certificates.x509certificate2)\
A certificate object with private key.

`stream`: [Stream](https://docs.microsoft.com/en-us/dotnet/api/system.io.stream)\
The input stream for which to compute the hash.

`hashAlgorithm`: [HashAlgorithmName](https://docs.microsoft.com/en-us/dotnet/api/system.security.cryptography.hashalgorithmname)\
The hash algorithm to use to create the hash value.

`padding`: [RSASignaturePadding](https://docs.microsoft.com/en-us/dotnet/api/system.security.cryptography.rsasignaturepadding)\
The padding mode.

#### Return Value

[Byte[]](https://docs.microsoft.com/en-us/dotnet/api/system.byte)\
The RSA signature for the specified data.

### Exceptions

Exception | Description
--- | ---
[System.ArgumentNullException](https://docs.microsoft.com/en-us/dotnet/api/system.argumentnullexception) | `cert`, `stream`, or `padding` is `null`.
[System.InvalidOperationException](https://docs.microsoft.com/en-us/dotnet/api/system.invalidoperationexception) | The certificate does not have an RSA private key.

### See Also

- [Assorted.Utils.Crypto Namespace](index.md#assortedutilscrypto-namespace)
- [CertExtenstions Class](Assorted.Utils.Crypto.CertExtenstions.md)

## Sign(this X509Certificate2, string)

Computes the hash value of the specified string using SHA-256 hash algorithm and PSS padding mode, and signs the resulting hash value.

### Syntax

```csharp
public static Byte[] Sign(this X509Certificate2 cert, string text)
```

#### Parameters

`cert`: [X509Certificate2](https://docs.microsoft.com/en-us/dotnet/api/system.security.cryptography.x509certificates.x509certificate2)\
A certificate object with private key.

`text`: [string](https://docs.microsoft.com/en-us/dotnet/api/system.string)\
The input string for which to compute the hash.

#### Return Value

[Byte[]](https://docs.microsoft.com/en-us/dotnet/api/system.byte)\
The RSA signature for the specified data.

### Exceptions

Exception | Description
--- | ---
[System.ArgumentNullException](https://docs.microsoft.com/en-us/dotnet/api/system.argumentnullexception) | `cert` or `text` is `null`.
[System.InvalidOperationException](https://docs.microsoft.com/en-us/dotnet/api/system.invalidoperationexception) | The certificate does not have an RSA private key.

### See Also

- [Assorted.Utils.Crypto Namespace](index.md#assortedutilscrypto-namespace)
- [CertExtenstions Class](Assorted.Utils.Crypto.CertExtenstions.md)

## Sign(this X509Certificate2, string, HashAlgorithmName, RSASignaturePadding)

Computes the hash value of the specified string using the specified hash algorithm and padding mode, and signs the resulting hash value.

### Syntax

```csharp
public static Byte[] Sign(
    this X509Certificate2 cert, 
    string text, 
    HashAlgorithmName hashAlgorithm, 
    RSASignaturePadding padding
)
```

#### Parameters

`cert`: [X509Certificate2](https://docs.microsoft.com/en-us/dotnet/api/system.security.cryptography.x509certificates.x509certificate2)\
A certificate object with private key.

`text`: [string](https://docs.microsoft.com/en-us/dotnet/api/system.string)\
The input string for which to compute the hash.

`hashAlgorithm`: [HashAlgorithmName](https://docs.microsoft.com/en-us/dotnet/api/system.security.cryptography.hashalgorithmname)\
The hash algorithm to use to create the hash value.

`padding`: [RSASignaturePadding](https://docs.microsoft.com/en-us/dotnet/api/system.security.cryptography.rsasignaturepadding)\
The padding mode.

#### Return Value

[Byte[]](https://docs.microsoft.com/en-us/dotnet/api/system.byte)\
The RSA signature for the specified data.

### Exceptions

Exception | Description
--- | ---
[System.ArgumentNullException](https://docs.microsoft.com/en-us/dotnet/api/system.argumentnullexception) | `cert`, `text`, or `padding` is `null`.
[System.InvalidOperationException](https://docs.microsoft.com/en-us/dotnet/api/system.invalidoperationexception) | The certificate does not have an RSA private key.

### See Also

- [Assorted.Utils.Crypto Namespace](index.md#assortedutilscrypto-namespace)
- [CertExtenstions Class](Assorted.Utils.Crypto.CertExtenstions.md)

---

_This document is generated by [DG](https://github.com/Khojasteh/dg)._
