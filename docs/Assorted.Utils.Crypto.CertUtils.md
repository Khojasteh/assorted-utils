﻿# CertUtils Class

> Namespace: [Assorted.Utils.Crypto](index.md#assortedutilscrypto-namespace)\
> Assembly: [Assorted.Utils](index.md) (Assorted.Utils.dll) version 1.1.0.0\
> Inheritance: [object](https://docs.microsoft.com/en-us/dotnet/api/system.object) `→` CertUtils

Provides some helper methods for working with [`System.Security.Cryptography.X509Certificates.X509Certificate2`](https://docs.microsoft.com/en-us/dotnet/api/system.security.cryptography.x509certificates.x509certificate2) objects.

## Syntax

```csharp
public static class CertUtils
```

## Methods

Method | Description
--- | ---
[FindCertificates(StoreLocation, StoreName, X509FindType, object, bool)](Assorted.Utils.Crypto.CertUtils.FindCertificates.md) | Searches certificates in a specified store using the search criteria specified by the `type` enumeration and the `value` object,
[FindMachineCertificates(X509FindType, object, StoreName, bool)](Assorted.Utils.Crypto.CertUtils.FindMachineCertificates.md) | Searches certificates in a specified store of local machine using the search criteria specified by the `type` enumeration and the `value` object,
[FindUserCertificates(X509FindType, object, StoreName, bool)](Assorted.Utils.Crypto.CertUtils.FindUserCertificates.md) | Searches certificates in a specified store of current user using the search criteria specified by the `type` enumeration and the `value` object,

## Thread Safety

Any public static member of this type is thread\-safe, but instance members are not guaranteed to be thread\-safe.

## See Also

- [Assorted.Utils.Crypto Namespace](index.md#assortedutilscrypto-namespace)

---

_This document is generated by [DG](https://github.com/Khojasteh/dg)._
