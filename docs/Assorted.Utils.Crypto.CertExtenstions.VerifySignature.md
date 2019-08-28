# CertExtenstions.VerifySignature Method

> Namespace: [Assorted.Utils.Crypto](index.md#assortedutilscrypto-namespace)\
> Assembly: [Assorted.Utils](index.md) (Assorted.Utils.dll) version 1.1.0.0

Overload | Description
--- | ---
[VerifySignature(this X509Certificate2, Byte[], Byte[])](Assorted.Utils.Crypto.CertExtenstions.VerifySignature.md#verifysignaturethis-x509certificate2-byte-byte) | Verifies that a digital signature is valid by calculating the hash value of the specified data using SHA-256 hash algorithm and PSS padding mode, and comparing it to the provided signature.
[VerifySignature(this X509Certificate2, Byte[], Byte[], HashAlgorithmName, RSASignaturePadding)](Assorted.Utils.Crypto.CertExtenstions.VerifySignature.md#verifysignaturethis-x509certificate2-byte-byte-hashalgorithmname-rsasignaturepadding) | Verifies that a digital signature is valid by calculating the hash value of the specified data using the specified hash algorithm and padding mode, and comparing it to the provided signature.
[VerifySignature(this X509Certificate2, Stream, Byte[])](Assorted.Utils.Crypto.CertExtenstions.VerifySignature.md#verifysignaturethis-x509certificate2-stream-byte) | Verifies that a digital signature is valid by calculating the hash value of the specified stream using SHA-256 hash algorithm and PSS padding mode, and comparing it to the provided signature.
[VerifySignature(this X509Certificate2, Stream, Byte[], HashAlgorithmName, RSASignaturePadding)](Assorted.Utils.Crypto.CertExtenstions.VerifySignature.md#verifysignaturethis-x509certificate2-stream-byte-hashalgorithmname-rsasignaturepadding) | Verifies that a digital signature is valid by calculating the hash value of the specified stream using the specified hash algorithm and padding mode, and comparing it to the provided signature.
[VerifySignature(this X509Certificate2, string, Byte[])](Assorted.Utils.Crypto.CertExtenstions.VerifySignature.md#verifysignaturethis-x509certificate2-string-byte) | Verifies that a digital signature is valid by calculating the hash value of the specified string using SHA-256 hash algorithm and PSS padding mode, and comparing it to the provided signature.
[VerifySignature(this X509Certificate2, string, Byte[], HashAlgorithmName, RSASignaturePadding)](Assorted.Utils.Crypto.CertExtenstions.VerifySignature.md#verifysignaturethis-x509certificate2-string-byte-hashalgorithmname-rsasignaturepadding) | Verifies that a digital signature is valid by calculating the hash value of the specified string using the specified hash algorithm and padding mode, and comparing it to the provided signature.

## VerifySignature(this X509Certificate2, Byte[], Byte[])

Verifies that a digital signature is valid by calculating the hash value of the specified data using SHA-256 hash algorithm and PSS padding mode, and comparing it to the provided signature.

### Syntax

```csharp
public static bool VerifySignature(this X509Certificate2 cert, Byte[] data, Byte[] signature)
```

#### Parameters

`cert`: [X509Certificate2](https://docs.microsoft.com/en-us/dotnet/api/system.security.cryptography.x509certificates.x509certificate2)\
A certificate object with public key.

`data`: [Byte[]](https://docs.microsoft.com/en-us/dotnet/api/system.byte)\
The signed data.

`signature`: [Byte[]](https://docs.microsoft.com/en-us/dotnet/api/system.byte)\
The signature data to be verified.

#### Return Value

[bool](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)\
`true` if the signature is valid; otherwise, `false`.

### Exceptions

Exception | Description
--- | ---
[System.ArgumentNullException](https://docs.microsoft.com/en-us/dotnet/api/system.argumentnullexception) | `cert`, `data`, or `signature` is `null`.
[System.InvalidOperationException](https://docs.microsoft.com/en-us/dotnet/api/system.invalidoperationexception) | The certificate does not have an RSA public key.

### See Also

- [Assorted.Utils.Crypto Namespace](index.md#assortedutilscrypto-namespace)
- [CertExtenstions Class](Assorted.Utils.Crypto.CertExtenstions.md)

## VerifySignature(this X509Certificate2, Byte[], Byte[], HashAlgorithmName, RSASignaturePadding)

Verifies that a digital signature is valid by calculating the hash value of the specified data using the specified hash algorithm and padding mode, and comparing it to the provided signature.

### Syntax

```csharp
public static bool VerifySignature(
    this X509Certificate2 cert, 
    Byte[] data, 
    Byte[] signature, 
    HashAlgorithmName hashAlgorithm, 
    RSASignaturePadding padding
)
```

#### Parameters

`cert`: [X509Certificate2](https://docs.microsoft.com/en-us/dotnet/api/system.security.cryptography.x509certificates.x509certificate2)\
A certificate object with public key.

`data`: [Byte[]](https://docs.microsoft.com/en-us/dotnet/api/system.byte)\
The signed data.

`signature`: [Byte[]](https://docs.microsoft.com/en-us/dotnet/api/system.byte)\
The signature data to be verified.

`hashAlgorithm`: [HashAlgorithmName](https://docs.microsoft.com/en-us/dotnet/api/system.security.cryptography.hashalgorithmname)\
The hash algorithm used to create the hash value of the data.

`padding`: [RSASignaturePadding](https://docs.microsoft.com/en-us/dotnet/api/system.security.cryptography.rsasignaturepadding)\
The padding mode.

#### Return Value

[bool](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)\
`true` if the signature is valid; otherwise, `false`.

### Exceptions

Exception | Description
--- | ---
[System.ArgumentNullException](https://docs.microsoft.com/en-us/dotnet/api/system.argumentnullexception) | `cert`, `data`, `signature`, or `padding` is `null`.
[System.InvalidOperationException](https://docs.microsoft.com/en-us/dotnet/api/system.invalidoperationexception) | The certificate does not have an RSA public key.

### See Also

- [Assorted.Utils.Crypto Namespace](index.md#assortedutilscrypto-namespace)
- [CertExtenstions Class](Assorted.Utils.Crypto.CertExtenstions.md)

## VerifySignature(this X509Certificate2, Stream, Byte[])

Verifies that a digital signature is valid by calculating the hash value of the specified stream using SHA-256 hash algorithm and PSS padding mode, and comparing it to the provided signature.

### Syntax

```csharp
public static bool VerifySignature(this X509Certificate2 cert, Stream stream, Byte[] signature)
```

#### Parameters

`cert`: [X509Certificate2](https://docs.microsoft.com/en-us/dotnet/api/system.security.cryptography.x509certificates.x509certificate2)\
A certificate object with public key.

`stream`: [Stream](https://docs.microsoft.com/en-us/dotnet/api/system.io.stream)\
The signed data.

`signature`: [Byte[]](https://docs.microsoft.com/en-us/dotnet/api/system.byte)\
The signature data to be verified.

#### Return Value

[bool](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)\
`true` if the signature is valid; otherwise, `false`.

### Exceptions

Exception | Description
--- | ---
[System.ArgumentNullException](https://docs.microsoft.com/en-us/dotnet/api/system.argumentnullexception) | `cert`, `stream`, or `signature` is `null`.
[System.InvalidOperationException](https://docs.microsoft.com/en-us/dotnet/api/system.invalidoperationexception) | The certificate does not have an RSA public key.

### See Also

- [Assorted.Utils.Crypto Namespace](index.md#assortedutilscrypto-namespace)
- [CertExtenstions Class](Assorted.Utils.Crypto.CertExtenstions.md)

## VerifySignature(this X509Certificate2, Stream, Byte[], HashAlgorithmName, RSASignaturePadding)

Verifies that a digital signature is valid by calculating the hash value of the specified stream using the specified hash algorithm and padding mode, and comparing it to the provided signature.

### Syntax

```csharp
public static bool VerifySignature(
    this X509Certificate2 cert, 
    Stream stream, 
    Byte[] signature, 
    HashAlgorithmName hashAlgorithm, 
    RSASignaturePadding padding
)
```

#### Parameters

`cert`: [X509Certificate2](https://docs.microsoft.com/en-us/dotnet/api/system.security.cryptography.x509certificates.x509certificate2)\
A certificate object with public key.

`stream`: [Stream](https://docs.microsoft.com/en-us/dotnet/api/system.io.stream)\
The signed data.

`signature`: [Byte[]](https://docs.microsoft.com/en-us/dotnet/api/system.byte)\
The signature data to be verified.

`hashAlgorithm`: [HashAlgorithmName](https://docs.microsoft.com/en-us/dotnet/api/system.security.cryptography.hashalgorithmname)\
The hash algorithm used to create the hash value of the stream.

`padding`: [RSASignaturePadding](https://docs.microsoft.com/en-us/dotnet/api/system.security.cryptography.rsasignaturepadding)\
The padding mode.

#### Return Value

[bool](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)\
`true` if the signature is valid; otherwise, `false`.

### Exceptions

Exception | Description
--- | ---
[System.ArgumentNullException](https://docs.microsoft.com/en-us/dotnet/api/system.argumentnullexception) | `cert`, `stream`, `signature`, or `padding` is `null`.
[System.InvalidOperationException](https://docs.microsoft.com/en-us/dotnet/api/system.invalidoperationexception) | The certificate does not have an RSA public key.

### See Also

- [Assorted.Utils.Crypto Namespace](index.md#assortedutilscrypto-namespace)
- [CertExtenstions Class](Assorted.Utils.Crypto.CertExtenstions.md)

## VerifySignature(this X509Certificate2, string, Byte[])

Verifies that a digital signature is valid by calculating the hash value of the specified string using SHA-256 hash algorithm and PSS padding mode, and comparing it to the provided signature.

### Syntax

```csharp
public static bool VerifySignature(this X509Certificate2 cert, string text, Byte[] signature)
```

#### Parameters

`cert`: [X509Certificate2](https://docs.microsoft.com/en-us/dotnet/api/system.security.cryptography.x509certificates.x509certificate2)\
A certificate object with public key.

`text`: [string](https://docs.microsoft.com/en-us/dotnet/api/system.string)\
The signed string.

`signature`: [Byte[]](https://docs.microsoft.com/en-us/dotnet/api/system.byte)\
The signature data to be verified.

#### Return Value

[bool](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)\
`true` if the signature is valid; otherwise, `false`.

### Exceptions

Exception | Description
--- | ---
[System.ArgumentNullException](https://docs.microsoft.com/en-us/dotnet/api/system.argumentnullexception) | `cert`, `text`, or `signature` is `null`.
[System.InvalidOperationException](https://docs.microsoft.com/en-us/dotnet/api/system.invalidoperationexception) | The certificate does not have an RSA public key.

### See Also

- [Assorted.Utils.Crypto Namespace](index.md#assortedutilscrypto-namespace)
- [CertExtenstions Class](Assorted.Utils.Crypto.CertExtenstions.md)

## VerifySignature(this X509Certificate2, string, Byte[], HashAlgorithmName, RSASignaturePadding)

Verifies that a digital signature is valid by calculating the hash value of the specified string using the specified hash algorithm and padding mode, and comparing it to the provided signature.

### Syntax

```csharp
public static bool VerifySignature(
    this X509Certificate2 cert, 
    string text, 
    Byte[] signature, 
    HashAlgorithmName hashAlgorithm, 
    RSASignaturePadding padding
)
```

#### Parameters

`cert`: [X509Certificate2](https://docs.microsoft.com/en-us/dotnet/api/system.security.cryptography.x509certificates.x509certificate2)\
A certificate object with public key.

`text`: [string](https://docs.microsoft.com/en-us/dotnet/api/system.string)\
The signed string.

`signature`: [Byte[]](https://docs.microsoft.com/en-us/dotnet/api/system.byte)\
The signature data to be verified.

`hashAlgorithm`: [HashAlgorithmName](https://docs.microsoft.com/en-us/dotnet/api/system.security.cryptography.hashalgorithmname)\
The hash algorithm used to create the hash value of the string.

`padding`: [RSASignaturePadding](https://docs.microsoft.com/en-us/dotnet/api/system.security.cryptography.rsasignaturepadding)\
The padding mode.

#### Return Value

[bool](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)\
`true` if the signature is valid; otherwise, `false`.

### Exceptions

Exception | Description
--- | ---
[System.ArgumentNullException](https://docs.microsoft.com/en-us/dotnet/api/system.argumentnullexception) | `cert`, `text`, `signature`, or `padding` is `null`.
[System.InvalidOperationException](https://docs.microsoft.com/en-us/dotnet/api/system.invalidoperationexception) | The certificate does not have an RSA public key.

### See Also

- [Assorted.Utils.Crypto Namespace](index.md#assortedutilscrypto-namespace)
- [CertExtenstions Class](Assorted.Utils.Crypto.CertExtenstions.md)

---

_This document is generated by [DG](https://github.com/Khojasteh/dg)._
