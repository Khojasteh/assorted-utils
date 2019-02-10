# ObjectPool\<T> Class

> Namespace: [Assorted.Utils.Collections](_toc.Assorted.Utils.md#Assorted.Utils.Collections%20Namespace)\
> Assembly: [Assorted.Utils](_toc.Assorted.Utils.md) (Assorted.Utils.dll) version 1.0.0.0\
> Implements: [IDisposable](https://docs.microsoft.com/en-us/dotnet/api/system.idisposable)\
> Inheritance: [object](https://docs.microsoft.com/en-us/dotnet/api/system.object) `→` ObjectPool\<T>

Defines a pool of reusable objects.

## Syntax

```csharp
public class ObjectPool<T> : IDisposable
    where T : class
```

### Type Parameters

`T`\
Specifies the type of objects in the pool.

## Constructors

Constructor | Description
--- | ---
[ObjectPool\<T>()](Assorted.Utils.Collections.ObjectPool-1.-ctor.md#ObjectPool%3CT%3E%28%29) | Initializes a new instance of [`ObjectPool<T>`](Assorted.Utils.Collections.ObjectPool-1.md) class without an upper bound capacity. When a new object needs to be initialized, the default constructor of the target type is used.
[ObjectPool\<T>(Action\<T>)](Assorted.Utils.Collections.ObjectPool-1.-ctor.md#ObjectPool%3CT%3E%28Action%3CT%3E%29) | Initializes a new instance of [`ObjectPool<T>`](Assorted.Utils.Collections.ObjectPool-1.md) class without an upper bound capacity. When a new object needs to be initialized, the default constructor of the target type is used. The specified action is used to reset a consumed object.
[ObjectPool\<T>(Func\<T>)](Assorted.Utils.Collections.ObjectPool-1.-ctor.md#ObjectPool%3CT%3E%28Func%3CT%3E%29) | Initializes a new instance of [`ObjectPool<T>`](Assorted.Utils.Collections.ObjectPool-1.md) class without an upper bound capacity. When a new object needs to be initialized, the specified initialization function is used.
[ObjectPool\<T>(Func\<T>, Action\<T>)](Assorted.Utils.Collections.ObjectPool-1.-ctor.md#ObjectPool%3CT%3E%28Func%3CT%3E%2C%20Action%3CT%3E%29) | Initializes a new instance of [`ObjectPool<T>`](Assorted.Utils.Collections.ObjectPool-1.md) class without an upper bound capacity. When a new object needs to be initialized, the specified initialization function is used. The specified action is used to reset a consumed object.
[ObjectPool\<T>(int)](Assorted.Utils.Collections.ObjectPool-1.-ctor.md#ObjectPool%3CT%3E%28int%29) | Initializes a new instance of [`ObjectPool<T>`](Assorted.Utils.Collections.ObjectPool-1.md) class with an upper bound capacity. When a new object needs to be initialized, the default constructor of the target type is used.
[ObjectPool\<T>(int, Action\<T>)](Assorted.Utils.Collections.ObjectPool-1.-ctor.md#ObjectPool%3CT%3E%28int%2C%20Action%3CT%3E%29) | Initializes a new instance of [`ObjectPool<T>`](Assorted.Utils.Collections.ObjectPool-1.md) class with an upper bound capacity. When a new object needs to be initialized, the default constructor of the target type is used. The specified action is used to reset a consumed object.
[ObjectPool\<T>(int, Func\<T>)](Assorted.Utils.Collections.ObjectPool-1.-ctor.md#ObjectPool%3CT%3E%28int%2C%20Func%3CT%3E%29) | Initializes a new instance of [`ObjectPool<T>`](Assorted.Utils.Collections.ObjectPool-1.md) class with an upper bound capacity. When a new object needs to be initialized, the specified initialization function is used. The specified action is used to reset a consumed object.
[ObjectPool\<T>(int, Func\<T>, Action\<T>)](Assorted.Utils.Collections.ObjectPool-1.-ctor.md#ObjectPool%3CT%3E%28int%2C%20Func%3CT%3E%2C%20Action%3CT%3E%29) | Initializes a new instance of [`ObjectPool<T>`](Assorted.Utils.Collections.ObjectPool-1.md) class with an upper bound capacity. When a new object needs to be initialized, the specified initialization function is used. The specified action is used to reset a consumed object.

## Properties

Property | Description
--- | ---
[Count](Assorted.Utils.Collections.ObjectPool-1.Count.md) | Gets the number of objects which are currently in the pool.
[IsDisposed](Assorted.Utils.Collections.ObjectPool-1.IsDisposed.md) | Gets whether this instance has been disposed.
[MaxCapacity](Assorted.Utils.Collections.ObjectPool-1.MaxCapacity.md) | Gets the maximum number of objects that the pool is allowed to store.

## Methods

Method | Description
--- | ---
[Acquire()](Assorted.Utils.Collections.ObjectPool-1.Acquire.md) | Returns an object from the pool. If the pool is empty, a new object is initialized.
[Clear()](Assorted.Utils.Collections.ObjectPool-1.Clear.md) | Clears the pool and disposes all the disposable objects in it.
[Dispose()](Assorted.Utils.Collections.ObjectPool-1.Dispose.md#Dispose%28%29) | Releases all resources used by the [`ObjectPool<T>`](Assorted.Utils.Collections.ObjectPool-1.md).
[Dispose(bool)](Assorted.Utils.Collections.ObjectPool-1.Dispose.md#Dispose%28bool%29) | Releases the unmanaged resources used by the [`ObjectPool<T>`](Assorted.Utils.Collections.ObjectPool-1.md) and optionally releases the managed resources.
[DisposeObject(T)](Assorted.Utils.Collections.ObjectPool-1.DisposeObject.md) | Disposes the specified object if it implements the [`System.IDisposable`](https://docs.microsoft.com/en-us/dotnet/api/system.idisposable) interface.
[Finalize()](Assorted.Utils.Collections.ObjectPool-1.Finalize.md) | Finalizes the instance of [`ObjectPool<T>`](Assorted.Utils.Collections.ObjectPool-1.md) class.
[Release(Proxy)](Assorted.Utils.Collections.ObjectPool-1.Release.md) | Disposes a proxy object and puts its value back in the pool if the pool's maximum capacity has not been reached; otherwise, disposes the value too.
[ReleaseObject(T)](Assorted.Utils.Collections.ObjectPool-1.ReleaseObject.md) | Puts an object back in the pool if the pool's maximum capacity has not been reached; otherwise, disposes the object.

## Nested Types

Type | Description
--- | ---
[ObjectPool\<T>.Proxy](Assorted.Utils.Collections.ObjectPool-1.Proxy.md) | Wraps an object that has been acquired from an object pool.

## Thread Safety

Any public member of this type, either static or instance, is thread\-safe.

## See Also

- [Assorted.Utils.Collections Namespace](_toc.Assorted.Utils.md#Assorted.Utils.Collections%20Namespace)

---

_This document is generated by [DG](https://github.com/Khojasteh/dg)._
