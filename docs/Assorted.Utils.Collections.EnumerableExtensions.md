﻿# EnumerableExtensions Class

> Namespace: [Assorted.Utils.Collections](index.md#assortedutilscollections-namespace)\
> Assembly: [Assorted.Utils](index.md) (Assorted.Utils.dll) version 1.1.0.0\
> Inheritance: [object](https://docs.microsoft.com/en-us/dotnet/api/system.object) `→` EnumerableExtensions

Extends the enumerable objects.

## Syntax

```csharp
public static class EnumerableExtensions
```

## Methods

Method | Description
--- | ---
[AddTo\<TSource>(this IEnumerable\<TSource>, ICollection\<TSource>)](Assorted.Utils.Collections.EnumerableExtensions.AddTo.md) | Adds elements of the sequence to a specific collection.
[Alternate\<TSource>(this IEnumerable\<TSource>, int)](Assorted.Utils.Collections.EnumerableExtensions.Alternate.md) | Returns the alternative elements of the sequence by a specific interval.
[Apply\<TSource>(this IEnumerable\<TSource>, Action\<TSource>)](Assorted.Utils.Collections.EnumerableExtensions.Apply.md) | Performs an action (lazy) on each element of the sequence.
[AsArray\<TSource>(this IEnumerable\<TSource>)](Assorted.Utils.Collections.EnumerableExtensions.AsArray.md) | Executes the deferred operations of the sequence if there is any, and returns the evaluated sequence as an array.
[AsCollection\<TSource>(this IEnumerable\<TSource>)](Assorted.Utils.Collections.EnumerableExtensions.AsCollection.md) | Executes the deferred operations of the sequence if there is any, and returns the evaluated sequence as a read-only collection.
[AsList\<TSource>(this IEnumerable\<TSource>)](Assorted.Utils.Collections.EnumerableExtensions.AsList.md) | Executes the deferred operations of the sequence if there is any, and returns the evaluated sequence as a read-only list.
[AsSet\<TSource>(this IEnumerable\<TSource>)](Assorted.Utils.Collections.EnumerableExtensions.AsSet.md) | Executes the deferred operations of the sequence if there is any, and returns the unique elements of the evaluated sequence as a set.
[Cycle\<TSource>(this IEnumerable\<TSource>, int)](Assorted.Utils.Collections.EnumerableExtensions.Cycle.md) | Repeats the sequence by a specific number of times.
[DamerauLevenshteinDistance\<TSource>(this IEnumerable\<TSource>, IEnumerable\<TSource>)](Assorted.Utils.Collections.EnumerableExtensions.DamerauLevenshteinDistance.md) | Returns the Damerau-Levenshtein distance of this sequence to a specified sequence.
[ForEach\<TSource>(this IEnumerable\<TSource>, Action\<TSource>)](Assorted.Utils.Collections.EnumerableExtensions.ForEach.md) | Performs an action on each element of the sequence.
[Partition\<TSource>(this IEnumerable\<TSource>, int)](Assorted.Utils.Collections.EnumerableExtensions.Partition.md) | Splits the sequence into a fixed-size chunks.
[RemoveFrom\<TSource>(this IEnumerable\<TSource>, ICollection\<TSource>)](Assorted.Utils.Collections.EnumerableExtensions.RemoveFrom.md) | Removes elements of the sequence from a specific collection.
[RotateLeft\<TSource>(this IEnumerable\<TSource>, int)](Assorted.Utils.Collections.EnumerableExtensions.RotateLeft.md) | Rotates the sequence by a specific number of elements to left.
[RotateRight\<TSource>(this IEnumerable\<TSource>, int)](Assorted.Utils.Collections.EnumerableExtensions.RotateRight.md) | Rotates the sequence by a specific number of elements to right.
[Shuffle\<TSource>(this IEnumerable\<TSource>)](Assorted.Utils.Collections.EnumerableExtensions.Shuffle.md) | Shuffles elements of the sequence.

## Thread Safety

Any public static member of this type is thread\-safe, but instance members are not guaranteed to be thread\-safe.

## See Also

- [Assorted.Utils.Collections Namespace](index.md#assortedutilscollections-namespace)

---

_This document is generated by [DG](https://github.com/Khojasteh/dg)._
