﻿# YearlyWeekPattern.YearlyWeekPattern(WeekOfMonth, DaysOfTheWeek, int, int) Constructor

> Namespace: [Assorted.Utils.Dates.Patterns](index.md#assortedutilsdatespatterns-namespace)\
> Assembly: [Assorted.Utils](index.md) (Assorted.Utils.dll) version 1.1.0.0

Initializes an instance of [`YearlyWeekPattern`](Assorted.Utils.Dates.Patterns.YearlyWeekPattern.md) class.

## Syntax

```csharp
public YearlyWeekPattern(
    WeekOfMonth weekOfMonth, 
    DaysOfTheWeek daysOfWeek, 
    int monthOfYear, 
    int interval = 1
)
```

### Parameters

`weekOfMonth`: [WeekOfMonth](Assorted.Utils.Dates.WeekOfMonth.md)\
The week of the month when the event occurs.

`daysOfWeek`: [DaysOfTheWeek](Assorted.Utils.Dates.DaysOfTheWeek.md)\
The accepted days of the week when the event can occurs.

`monthOfYear`: [int](https://docs.microsoft.com/en-us/dotnet/api/system.int32)\
The month when the event occurs.

`interval`: [int](https://docs.microsoft.com/en-us/dotnet/api/system.int32)\
The interval of occurrences in number of years.

## Exceptions

Exception | Description
--- | ---
[System.ArgumentOutOfRangeException](https://docs.microsoft.com/en-us/dotnet/api/system.argumentoutofrangeexception) | `monthOfYear` is less than 1 or greater than 12. Or, `interval` is less than 1.

## See Also

- [Assorted.Utils.Dates.Patterns Namespace](index.md#assortedutilsdatespatterns-namespace)
- [YearlyWeekPattern Class](Assorted.Utils.Dates.Patterns.YearlyWeekPattern.md)

---

_This document is generated by [DG](https://github.com/Khojasteh/dg)._
