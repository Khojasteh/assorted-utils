# Utf8StringWriter Constructor

> Namespace: [Assorted.Utils.Serialization](_toc.Assorted.Utils.md#Assorted.Utils.Serialization%20Namespace)\
> Assembly: [Assorted.Utils](_toc.Assorted.Utils.md) (Assorted.Utils.dll) version 1.0.0.0

Initializes a new instance of the [`Utf8StringWriter`](Assorted.Utils.Serialization.Utf8StringWriter.md) class.

Overload | Description
--- | ---
[Utf8StringWriter()](Assorted.Utils.Serialization.Utf8StringWriter.-ctor.md#Utf8StringWriter%28%29) | Initializes a new instance of the [`Utf8StringWriter`](Assorted.Utils.Serialization.Utf8StringWriter.md) class.
[Utf8StringWriter(IFormatProvider)](Assorted.Utils.Serialization.Utf8StringWriter.-ctor.md#Utf8StringWriter%28IFormatProvider%29) | Initializes a new instance of the [`Utf8StringWriter`](Assorted.Utils.Serialization.Utf8StringWriter.md) class with the specified format control.
[Utf8StringWriter(StringBuilder)](Assorted.Utils.Serialization.Utf8StringWriter.-ctor.md#Utf8StringWriter%28StringBuilder%29) | Initializes a new instance of the [`Utf8StringWriter`](Assorted.Utils.Serialization.Utf8StringWriter.md) class that writes to the specified [`System.Text.StringBuilder`](https://docs.microsoft.com/en-us/dotnet/api/system.text.stringbuilder).
[Utf8StringWriter(StringBuilder, IFormatProvider)](Assorted.Utils.Serialization.Utf8StringWriter.-ctor.md#Utf8StringWriter%28StringBuilder%2C%20IFormatProvider%29) | Initializes a new instance of the [`Utf8StringWriter`](Assorted.Utils.Serialization.Utf8StringWriter.md) class that writes to the specified [`System.Text.StringBuilder`](https://docs.microsoft.com/en-us/dotnet/api/system.text.stringbuilder) and has the specified format provider.

## Utf8StringWriter()

Initializes a new instance of the [`Utf8StringWriter`](Assorted.Utils.Serialization.Utf8StringWriter.md) class.

### Syntax

```csharp
public Utf8StringWriter()
```

### See Also

- [Assorted.Utils.Serialization Namespace](_toc.Assorted.Utils.md#Assorted.Utils.Serialization%20Namespace)
- [Utf8StringWriter Class](Assorted.Utils.Serialization.Utf8StringWriter.md)

## Utf8StringWriter(IFormatProvider)

Initializes a new instance of the [`Utf8StringWriter`](Assorted.Utils.Serialization.Utf8StringWriter.md) class with the specified format control.

### Syntax

```csharp
public Utf8StringWriter(IFormatProvider formatProvider)
```

#### Parameters

`formatProvider`: [IFormatProvider](https://docs.microsoft.com/en-us/dotnet/api/system.iformatprovider)\
An [`System.IFormatProvider`](https://docs.microsoft.com/en-us/dotnet/api/system.iformatprovider) object that controls formatting.

### See Also

- [Assorted.Utils.Serialization Namespace](_toc.Assorted.Utils.md#Assorted.Utils.Serialization%20Namespace)
- [Utf8StringWriter Class](Assorted.Utils.Serialization.Utf8StringWriter.md)

## Utf8StringWriter(StringBuilder)

Initializes a new instance of the [`Utf8StringWriter`](Assorted.Utils.Serialization.Utf8StringWriter.md) class that writes to the specified [`System.Text.StringBuilder`](https://docs.microsoft.com/en-us/dotnet/api/system.text.stringbuilder).

### Syntax

```csharp
public Utf8StringWriter(StringBuilder sb)
```

#### Parameters

`sb`: [StringBuilder](https://docs.microsoft.com/en-us/dotnet/api/system.text.stringbuilder)\
The [`System.Text.StringBuilder`](https://docs.microsoft.com/en-us/dotnet/api/system.text.stringbuilder) object to write to.

### Exceptions

Exception | Description
--- | ---
[System.ArgumentNullException](https://docs.microsoft.com/en-us/dotnet/api/system.argumentnullexception) | `sb` is `null`.

### See Also

- [Assorted.Utils.Serialization Namespace](_toc.Assorted.Utils.md#Assorted.Utils.Serialization%20Namespace)
- [Utf8StringWriter Class](Assorted.Utils.Serialization.Utf8StringWriter.md)

## Utf8StringWriter(StringBuilder, IFormatProvider)

Initializes a new instance of the [`Utf8StringWriter`](Assorted.Utils.Serialization.Utf8StringWriter.md) class that writes to the specified [`System.Text.StringBuilder`](https://docs.microsoft.com/en-us/dotnet/api/system.text.stringbuilder) and has the specified format provider.

### Syntax

```csharp
public Utf8StringWriter(StringBuilder sb, IFormatProvider formatProvider)
```

#### Parameters

`sb`: [StringBuilder](https://docs.microsoft.com/en-us/dotnet/api/system.text.stringbuilder)\
The [`System.Text.StringBuilder`](https://docs.microsoft.com/en-us/dotnet/api/system.text.stringbuilder) object to write to.

`formatProvider`: [IFormatProvider](https://docs.microsoft.com/en-us/dotnet/api/system.iformatprovider)\
An [`System.IFormatProvider`](https://docs.microsoft.com/en-us/dotnet/api/system.iformatprovider) object that controls formatting.

### Exceptions

Exception | Description
--- | ---
[System.ArgumentNullException](https://docs.microsoft.com/en-us/dotnet/api/system.argumentnullexception) | `sb` is `null`.

### See Also

- [Assorted.Utils.Serialization Namespace](_toc.Assorted.Utils.md#Assorted.Utils.Serialization%20Namespace)
- [Utf8StringWriter Class](Assorted.Utils.Serialization.Utf8StringWriter.md)

---

_This document is generated by [DG](https://github.com/Khojasteh/dg)._
