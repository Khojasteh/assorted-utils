# ObjectPool\<T> Constructor

> Namespace: [Assorted.Utils.Collections](index.md#assortedutilscollections-namespace)\
> Assembly: [Assorted.Utils](index.md) (Assorted.Utils.dll) version 1.0.0.0

Initializes a new instance of [`ObjectPool<T>`](Assorted.Utils.Collections.ObjectPool-1.md) class.

Overload | Description
--- | ---
[ObjectPool\<T>()](Assorted.Utils.Collections.ObjectPool-1.-ctor.md#objectpoolt) | Initializes a new instance of [`ObjectPool<T>`](Assorted.Utils.Collections.ObjectPool-1.md) class without an upper bound capacity. When a new object needs to be initialized, the default constructor of the target type is used.
[ObjectPool\<T>(Action\<T>)](Assorted.Utils.Collections.ObjectPool-1.-ctor.md#objectpooltactiont) | Initializes a new instance of [`ObjectPool<T>`](Assorted.Utils.Collections.ObjectPool-1.md) class without an upper bound capacity. When a new object needs to be initialized, the default constructor of the target type is used. The specified action is used to reset a consumed object.
[ObjectPool\<T>(Func\<T>)](Assorted.Utils.Collections.ObjectPool-1.-ctor.md#objectpooltfunct) | Initializes a new instance of [`ObjectPool<T>`](Assorted.Utils.Collections.ObjectPool-1.md) class without an upper bound capacity. When a new object needs to be initialized, the specified initialization function is used.
[ObjectPool\<T>(Func\<T>, Action\<T>)](Assorted.Utils.Collections.ObjectPool-1.-ctor.md#objectpooltfunct-actiont) | Initializes a new instance of [`ObjectPool<T>`](Assorted.Utils.Collections.ObjectPool-1.md) class without an upper bound capacity. When a new object needs to be initialized, the specified initialization function is used. The specified action is used to reset a consumed object.
[ObjectPool\<T>(int)](Assorted.Utils.Collections.ObjectPool-1.-ctor.md#objectpooltint) | Initializes a new instance of [`ObjectPool<T>`](Assorted.Utils.Collections.ObjectPool-1.md) class with an upper bound capacity. When a new object needs to be initialized, the default constructor of the target type is used.
[ObjectPool\<T>(int, Action\<T>)](Assorted.Utils.Collections.ObjectPool-1.-ctor.md#objectpooltint-actiont) | Initializes a new instance of [`ObjectPool<T>`](Assorted.Utils.Collections.ObjectPool-1.md) class with an upper bound capacity. When a new object needs to be initialized, the default constructor of the target type is used. The specified action is used to reset a consumed object.
[ObjectPool\<T>(int, Func\<T>)](Assorted.Utils.Collections.ObjectPool-1.-ctor.md#objectpooltint-funct) | Initializes a new instance of [`ObjectPool<T>`](Assorted.Utils.Collections.ObjectPool-1.md) class with an upper bound capacity. When a new object needs to be initialized, the specified initialization function is used. The specified action is used to reset a consumed object.
[ObjectPool\<T>(int, Func\<T>, Action\<T>)](Assorted.Utils.Collections.ObjectPool-1.-ctor.md#objectpooltint-funct-actiont) | Initializes a new instance of [`ObjectPool<T>`](Assorted.Utils.Collections.ObjectPool-1.md) class with an upper bound capacity. When a new object needs to be initialized, the specified initialization function is used. The specified action is used to reset a consumed object.

## ObjectPool\<T>()

Initializes a new instance of [`ObjectPool<T>`](Assorted.Utils.Collections.ObjectPool-1.md) class without an upper bound capacity. When a new object needs to be initialized, the default constructor of the target type is used.

### Syntax

```csharp
public ObjectPool<T>()
```

### See Also

- [Assorted.Utils.Collections Namespace](index.md#assortedutilscollections-namespace)
- [ObjectPool\<T> Class](Assorted.Utils.Collections.ObjectPool-1.md)

## ObjectPool\<T>(Action\<T>)

Initializes a new instance of [`ObjectPool<T>`](Assorted.Utils.Collections.ObjectPool-1.md) class without an upper bound capacity. When a new object needs to be initialized, the default constructor of the target type is used. The specified action is used to reset a consumed object.

### Syntax

```csharp
public ObjectPool<T>(Action<T> valueReset)
```

#### Parameters

`valueReset`: [Action\<T>](https://docs.microsoft.com/en-us/dotnet/api/system.action-1)\
A delegate to reset a used instance before putting it back in the pool.

### See Also

- [Assorted.Utils.Collections Namespace](index.md#assortedutilscollections-namespace)
- [ObjectPool\<T> Class](Assorted.Utils.Collections.ObjectPool-1.md)

## ObjectPool\<T>(Func\<T>)

Initializes a new instance of [`ObjectPool<T>`](Assorted.Utils.Collections.ObjectPool-1.md) class without an upper bound capacity. When a new object needs to be initialized, the specified initialization function is used.

### Syntax

```csharp
public ObjectPool<T>(Func<T> valueFactory)
```

#### Parameters

`valueFactory`: [Func\<T>](https://docs.microsoft.com/en-us/dotnet/api/system.func-1)\
The delegate invoked to produce a new instance of type `T` when it is needed.

### Exceptions

Exception | Description
--- | ---
[System.ArgumentNullException](https://docs.microsoft.com/en-us/dotnet/api/system.argumentnullexception) | `valueFactory` is `null`.

### See Also

- [Assorted.Utils.Collections Namespace](index.md#assortedutilscollections-namespace)
- [ObjectPool\<T> Class](Assorted.Utils.Collections.ObjectPool-1.md)

## ObjectPool\<T>(Func\<T>, Action\<T>)

Initializes a new instance of [`ObjectPool<T>`](Assorted.Utils.Collections.ObjectPool-1.md) class without an upper bound capacity. When a new object needs to be initialized, the specified initialization function is used. The specified action is used to reset a consumed object.

### Syntax

```csharp
public ObjectPool<T>(Func<T> valueFactory, Action<T> valueReset)
```

#### Parameters

`valueFactory`: [Func\<T>](https://docs.microsoft.com/en-us/dotnet/api/system.func-1)\
The delegate invoked to produce a new instance of type `T` when it is needed.

`valueReset`: [Action\<T>](https://docs.microsoft.com/en-us/dotnet/api/system.action-1)\
A delegate to reset a used instance before putting it back in the pool.

### Exceptions

Exception | Description
--- | ---
[System.ArgumentNullException](https://docs.microsoft.com/en-us/dotnet/api/system.argumentnullexception) | `valueFactory` is `null`.

### See Also

- [Assorted.Utils.Collections Namespace](index.md#assortedutilscollections-namespace)
- [ObjectPool\<T> Class](Assorted.Utils.Collections.ObjectPool-1.md)

## ObjectPool\<T>(int)

Initializes a new instance of [`ObjectPool<T>`](Assorted.Utils.Collections.ObjectPool-1.md) class with an upper bound capacity. When a new object needs to be initialized, the default constructor of the target type is used.

### Syntax

```csharp
public ObjectPool<T>(int maxCapacity)
```

#### Parameters

`maxCapacity`: [int](https://docs.microsoft.com/en-us/dotnet/api/system.int32)\
The maximum number of objects that the pool is allowed to store.

### See Also

- [Assorted.Utils.Collections Namespace](index.md#assortedutilscollections-namespace)
- [ObjectPool\<T> Class](Assorted.Utils.Collections.ObjectPool-1.md)

## ObjectPool\<T>(int, Action\<T>)

Initializes a new instance of [`ObjectPool<T>`](Assorted.Utils.Collections.ObjectPool-1.md) class with an upper bound capacity. When a new object needs to be initialized, the default constructor of the target type is used. The specified action is used to reset a consumed object.

### Syntax

```csharp
public ObjectPool<T>(int maxCapacity, Action<T> valueReset)
```

#### Parameters

`maxCapacity`: [int](https://docs.microsoft.com/en-us/dotnet/api/system.int32)\
The maximum number of objects that the pool is allowed to store.

`valueReset`: [Action\<T>](https://docs.microsoft.com/en-us/dotnet/api/system.action-1)\
A delegate to reset a used instance before putting it back in the pool.

### See Also

- [Assorted.Utils.Collections Namespace](index.md#assortedutilscollections-namespace)
- [ObjectPool\<T> Class](Assorted.Utils.Collections.ObjectPool-1.md)

## ObjectPool\<T>(int, Func\<T>)

Initializes a new instance of [`ObjectPool<T>`](Assorted.Utils.Collections.ObjectPool-1.md) class with an upper bound capacity. When a new object needs to be initialized, the specified initialization function is used. The specified action is used to reset a consumed object.

### Syntax

```csharp
public ObjectPool<T>(int maxCapacity, Func<T> valueFactory)
```

#### Parameters

`maxCapacity`: [int](https://docs.microsoft.com/en-us/dotnet/api/system.int32)\
The maximum number of objects that the pool is allowed to store.

`valueFactory`: [Func\<T>](https://docs.microsoft.com/en-us/dotnet/api/system.func-1)\
The delegate invoked to produce a new instance of type `T` when it is needed.

### Exceptions

Exception | Description
--- | ---
[System.ArgumentNullException](https://docs.microsoft.com/en-us/dotnet/api/system.argumentnullexception) | `valueFactory` is `null`.

### See Also

- [Assorted.Utils.Collections Namespace](index.md#assortedutilscollections-namespace)
- [ObjectPool\<T> Class](Assorted.Utils.Collections.ObjectPool-1.md)

## ObjectPool\<T>(int, Func\<T>, Action\<T>)

Initializes a new instance of [`ObjectPool<T>`](Assorted.Utils.Collections.ObjectPool-1.md) class with an upper bound capacity. When a new object needs to be initialized, the specified initialization function is used. The specified action is used to reset a consumed object.

### Syntax

```csharp
public ObjectPool<T>(int maxCapacity, Func<T> valueFactory, Action<T> valueReset)
```

#### Parameters

`maxCapacity`: [int](https://docs.microsoft.com/en-us/dotnet/api/system.int32)\
The maximum number of objects that the pool is allowed to store.

`valueFactory`: [Func\<T>](https://docs.microsoft.com/en-us/dotnet/api/system.func-1)\
The delegate invoked to produce a new instance of type `T` when it is needed.

`valueReset`: [Action\<T>](https://docs.microsoft.com/en-us/dotnet/api/system.action-1)\
A delegate to reset a used instance before putting it back in the pool.

### Exceptions

Exception | Description
--- | ---
[System.ArgumentNullException](https://docs.microsoft.com/en-us/dotnet/api/system.argumentnullexception) | `valueFactory` is `null`.

### See Also

- [Assorted.Utils.Collections Namespace](index.md#assortedutilscollections-namespace)
- [ObjectPool\<T> Class](Assorted.Utils.Collections.ObjectPool-1.md)

---

_This document is generated by [DG](https://github.com/Khojasteh/dg)._
