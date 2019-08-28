﻿# CertExtenstions.Decrypt Method

> Namespace: [Assorted.Utils.Crypto](index.md#assortedutilscrypto-namespace)\
> Assembly: [Assorted.Utils](index.md) (Assorted.Utils.dll) version 1.1.0.0

Overload | Description
--- | ---
[Decrypt(this X509Certificate2, Byte[])](Assorted.Utils.Crypto.CertExtenstions.Decrypt.md#decryptthis-x509certificate2-byte) | Decrypts the ciphered data using the private key of the certificate and [`System.Security.Cryptography.RSAEncryptionPadding.OaepSHA1`](https://docs.microsoft.com/en-us/dotnet/api/system.security.cryptography.rsaencryptionpadding.oaepsha1) padding mode.
[Decrypt(this X509Certificate2, Byte[], RSAEncryptionPadding)](Assorted.Utils.Crypto.CertExtenstions.Decrypt.md#decryptthis-x509certificate2-byte-rsaencryptionpadding) | Decrypts the ciphered data using the private key of the certificate and a specified padding mode.

## Decrypt(this X509Certificate2, Byte[])

Decrypts the ciphered data using the private key of the certificate and [`System.Security.Cryptography.RSAEncryptionPadding.OaepSHA1`](https://docs.microsoft.com/en-us/dotnet/api/system.security.cryptography.rsaencryptionpadding.oaepsha1) padding mode.

### Syntax

```csharp
public static Byte[] Decrypt(this X509Certificate2 cert, Byte[] cipher)
```

#### Parameters

`cert`: [X509Certificate2](https://docs.microsoft.com/en-us/dotnet/api/system.security.cryptography.x509certificates.x509certificate2)\
A certificate object with private key.

`cipher`: [Byte[]](https://docs.microsoft.com/en-us/dotnet/api/system.byte)\
The ciphered data as an array of bytes.

#### Return Value

[Byte[]](https://docs.microsoft.com/en-us/dotnet/api/system.byte)\
The plain data as an array of bytes.

### Exceptions

Exception | Description
--- | ---
[System.ArgumentNullException](https://docs.microsoft.com/en-us/dotnet/api/system.argumentnullexception) | `cert` or `cipher` is `null`.
[System.InvalidOperationException](https://docs.microsoft.com/en-us/dotnet/api/system.invalidoperationexception) | The certificate does not have an RSA private key.

### See Also

- [Assorted.Utils.Crypto Namespace](index.md#assortedutilscrypto-namespace)
- [CertExtenstions Class](Assorted.Utils.Crypto.CertExtenstions.md)

## Decrypt(this X509Certificate2, Byte[], RSAEncryptionPadding)

Decrypts the ciphered data using the private key of the certificate and a specified padding mode.

### Syntax

```csharp
public static Byte[] Decrypt(
    this X509Certificate2 cert, 
    Byte[] cipher, 
    RSAEncryptionPadding padding
)
```

#### Parameters

`cert`: [X509Certificate2](https://docs.microsoft.com/en-us/dotnet/api/system.security.cryptography.x509certificates.x509certificate2)\
A certificate object with private key.

`cipher`: [Byte[]](https://docs.microsoft.com/en-us/dotnet/api/system.byte)\
The ciphered data as an array of bytes.

`padding`: [RSAEncryptionPadding](https://docs.microsoft.com/en-us/dotnet/api/system.security.cryptography.rsaencryptionpadding)\
The padding mode of the decryption.

#### Return Value

[Byte[]](https://docs.microsoft.com/en-us/dotnet/api/system.byte)\
The plain data as an array of bytes.

### Exceptions

Exception | Description
--- | ---
[System.ArgumentNullException](https://docs.microsoft.com/en-us/dotnet/api/system.argumentnullexception) | `cert`, `cipher`, or `padding` is `null`.
[System.InvalidOperationException](https://docs.microsoft.com/en-us/dotnet/api/system.invalidoperationexception) | The certificate does not have an RSA private key.

### See Also

- [Assorted.Utils.Crypto Namespace](index.md#assortedutilscrypto-namespace)
- [CertExtenstions Class](Assorted.Utils.Crypto.CertExtenstions.md)

---

_This document is generated by [DG](https://github.com/Khojasteh/dg)._