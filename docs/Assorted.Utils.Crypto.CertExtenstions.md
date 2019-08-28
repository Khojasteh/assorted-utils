# CertExtenstions Class

> Namespace: [Assorted.Utils.Crypto](index.md#assortedutilscrypto-namespace)\
> Assembly: [Assorted.Utils](index.md) (Assorted.Utils.dll) version 1.1.0.0\
> Inheritance: [object](https://docs.microsoft.com/en-us/dotnet/api/system.object) `→` CertExtenstions

Extends objects of type [`System.Security.Cryptography.X509Certificates.X509Certificate2`](https://docs.microsoft.com/en-us/dotnet/api/system.security.cryptography.x509certificates.x509certificate2).

## Syntax

```csharp
public static class CertExtenstions
```

## Methods

Method | Description
--- | ---
[Decrypt(this X509Certificate2, Byte[])](Assorted.Utils.Crypto.CertExtenstions.Decrypt.md#decryptthis-x509certificate2-byte) | Decrypts the ciphered data using the private key of the certificate and [`System.Security.Cryptography.RSAEncryptionPadding.OaepSHA1`](https://docs.microsoft.com/en-us/dotnet/api/system.security.cryptography.rsaencryptionpadding.oaepsha1) padding mode.
[Decrypt(this X509Certificate2, Byte[], RSAEncryptionPadding)](Assorted.Utils.Crypto.CertExtenstions.Decrypt.md#decryptthis-x509certificate2-byte-rsaencryptionpadding) | Decrypts the ciphered data using the private key of the certificate and a specified padding mode.
[Encrypt(this X509Certificate2, Byte[])](Assorted.Utils.Crypto.CertExtenstions.Encrypt.md#encryptthis-x509certificate2-byte) | Encrypts the specified byte array using the public key of the certificate and [`System.Security.Cryptography.RSAEncryptionPadding.OaepSHA1`](https://docs.microsoft.com/en-us/dotnet/api/system.security.cryptography.rsaencryptionpadding.oaepsha1) padding mode.
[Encrypt(this X509Certificate2, Byte[], RSAEncryptionPadding)](Assorted.Utils.Crypto.CertExtenstions.Encrypt.md#encryptthis-x509certificate2-byte-rsaencryptionpadding) | Encrypts the specified byte array using the public key of the certificate and a specified padding mode.
[Sign(this X509Certificate2, Byte[])](Assorted.Utils.Crypto.CertExtenstions.Sign.md#signthis-x509certificate2-byte) | Computes the hash value of the specified byte array using SHA-256 algorithm and PSS padding mode, and signs the resulting hash value.
[Sign(this X509Certificate2, Byte[], HashAlgorithmName, RSASignaturePadding)](Assorted.Utils.Crypto.CertExtenstions.Sign.md#signthis-x509certificate2-byte-hashalgorithmname-rsasignaturepadding) | Computes the hash value of the specified byte array using the specified hash algorithm and padding mode, and signs the resulting hash value.
[Sign(this X509Certificate2, Stream)](Assorted.Utils.Crypto.CertExtenstions.Sign.md#signthis-x509certificate2-stream) | Computes the hash value of the specified stream using SHA-256 hash algorithm and PSS padding mode, and signs the resulting hash value.
[Sign(this X509Certificate2, Stream, HashAlgorithmName, RSASignaturePadding)](Assorted.Utils.Crypto.CertExtenstions.Sign.md#signthis-x509certificate2-stream-hashalgorithmname-rsasignaturepadding) | Computes the hash value of the specified stream using the specified hash algorithm and padding mode, and signs the resulting hash value.
[Sign(this X509Certificate2, string)](Assorted.Utils.Crypto.CertExtenstions.Sign.md#signthis-x509certificate2-string) | Computes the hash value of the specified string using SHA-256 hash algorithm and PSS padding mode, and signs the resulting hash value.
[Sign(this X509Certificate2, string, HashAlgorithmName, RSASignaturePadding)](Assorted.Utils.Crypto.CertExtenstions.Sign.md#signthis-x509certificate2-string-hashalgorithmname-rsasignaturepadding) | Computes the hash value of the specified string using the specified hash algorithm and padding mode, and signs the resulting hash value.
[VerifySignature(this X509Certificate2, Byte[], Byte[])](Assorted.Utils.Crypto.CertExtenstions.VerifySignature.md#verifysignaturethis-x509certificate2-byte-byte) | Verifies that a digital signature is valid by calculating the hash value of the specified data using SHA-256 hash algorithm and PSS padding mode, and comparing it to the provided signature.
[VerifySignature(this X509Certificate2, Byte[], Byte[], HashAlgorithmName, RSASignaturePadding)](Assorted.Utils.Crypto.CertExtenstions.VerifySignature.md#verifysignaturethis-x509certificate2-byte-byte-hashalgorithmname-rsasignaturepadding) | Verifies that a digital signature is valid by calculating the hash value of the specified data using the specified hash algorithm and padding mode, and comparing it to the provided signature.
[VerifySignature(this X509Certificate2, Stream, Byte[])](Assorted.Utils.Crypto.CertExtenstions.VerifySignature.md#verifysignaturethis-x509certificate2-stream-byte) | Verifies that a digital signature is valid by calculating the hash value of the specified stream using SHA-256 hash algorithm and PSS padding mode, and comparing it to the provided signature.
[VerifySignature(this X509Certificate2, Stream, Byte[], HashAlgorithmName, RSASignaturePadding)](Assorted.Utils.Crypto.CertExtenstions.VerifySignature.md#verifysignaturethis-x509certificate2-stream-byte-hashalgorithmname-rsasignaturepadding) | Verifies that a digital signature is valid by calculating the hash value of the specified stream using the specified hash algorithm and padding mode, and comparing it to the provided signature.
[VerifySignature(this X509Certificate2, string, Byte[])](Assorted.Utils.Crypto.CertExtenstions.VerifySignature.md#verifysignaturethis-x509certificate2-string-byte) | Verifies that a digital signature is valid by calculating the hash value of the specified string using SHA-256 hash algorithm and PSS padding mode, and comparing it to the provided signature.
[VerifySignature(this X509Certificate2, string, Byte[], HashAlgorithmName, RSASignaturePadding)](Assorted.Utils.Crypto.CertExtenstions.VerifySignature.md#verifysignaturethis-x509certificate2-string-byte-hashalgorithmname-rsasignaturepadding) | Verifies that a digital signature is valid by calculating the hash value of the specified string using the specified hash algorithm and padding mode, and comparing it to the provided signature.

## Thread Safety

Any public static member of this type is thread\-safe, but instance members are not guaranteed to be thread\-safe.

## See Also

- [Assorted.Utils.Crypto Namespace](index.md#assortedutilscrypto-namespace)

---

_This document is generated by [DG](https://github.com/Khojasteh/dg)._
