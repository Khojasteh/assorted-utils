﻿# WeeklyPattern Class

> Namespace: [Assorted.Utils.Dates.Patterns](index.md#assortedutilsdatespatterns-namespace)\
> Assembly: [Assorted.Utils](index.md) (Assorted.Utils.dll) version 1.1.0.0\
> Implements: [IRecurrentPattern](Assorted.Utils.Dates.IRecurrentPattern.md), [IEquatable\<WeeklyPattern>](https://docs.microsoft.com/en-us/dotnet/api/system.iequatable-1)\
> Inheritance: [object](https://docs.microsoft.com/en-us/dotnet/api/system.object) `→` WeeklyPattern

Generates a sequence of [`System.DateTime`](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) values based on a weekly reoccurring pattern when events occur on some specific days of the week.

## Syntax

```csharp
public class WeeklyPattern : IRecurrentPattern, IEquatable<WeeklyPattern>
```

## Constructors

Constructor | Description
--- | ---
[WeeklyPattern(DaysOfTheWeek, int, DayOfWeek)](Assorted.Utils.Dates.Patterns.WeeklyPattern.-ctor.md) | Initializes an instance of [`WeeklyPattern`](Assorted.Utils.Dates.Patterns.WeeklyPattern.md) class.

## Properties

Property | Description
--- | ---
[DaysOfWeek](Assorted.Utils.Dates.Patterns.WeeklyPattern.DaysOfWeek.md) | Gets the days of the week when the event occurs.
[FirstDayOfWeek](Assorted.Utils.Dates.Patterns.WeeklyPattern.FirstDayOfWeek.md) | Gets the first day of the week.
[Interval](Assorted.Utils.Dates.Patterns.WeeklyPattern.Interval.md) | Gets the interval of occurrences in number of weeks.

## Methods

Method | Description
--- | ---
[Equals(object)](Assorted.Utils.Dates.Patterns.WeeklyPattern.Equals.md#equalsobject) | Determines whether this instance and a specified object are equal.
[Equals(WeeklyPattern)](Assorted.Utils.Dates.Patterns.WeeklyPattern.Equals.md#equalsweeklypattern) | Indicates whether the current instance is equal to another object of type [`WeeklyPattern`](Assorted.Utils.Dates.Patterns.WeeklyPattern.md).
[GetHashCode()](Assorted.Utils.Dates.Patterns.WeeklyPattern.GetHashCode.md) | Returns the hash code for this instance.
[GetRecurrencesStartingAt(DateTime)](Assorted.Utils.Dates.Patterns.WeeklyPattern.GetRecurrencesStartingAt.md) | Returns the sequence of recurring dates, starting at a given [`System.DateTime`](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) value.
[GetRelativeDaysOfWeekTo(DateTime)](Assorted.Utils.Dates.Patterns.WeeklyPattern.GetRelativeDaysOfWeekTo.md) | Returns the list of days specified by the [`DaysOfWeek`](Assorted.Utils.Dates.Patterns.WeeklyPattern.DaysOfWeek.md), relative to a given date.

## Thread Safety

Any public member of this type, either static or instance, is thread\-safe.

## See Also

- [Assorted.Utils.Dates.Patterns Namespace](index.md#assortedutilsdatespatterns-namespace)

---

_This document is generated by [DG](https://github.com/Khojasteh/dg)._
