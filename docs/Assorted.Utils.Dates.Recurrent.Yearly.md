# Recurrent.Yearly Method

> Namespace: [Assorted.Utils.Dates](index.md#assortedutilsdates-namespace)\
> Assembly: [Assorted.Utils](index.md) (Assorted.Utils.dll) version 1.0.1.0

Returns a yearly reoccurring pattern.

Overload | Description
--- | ---
[Yearly(int, int)](Assorted.Utils.Dates.Recurrent.Yearly.md#yearlyint-int) | Returns a yearly reoccurring pattern when events occur on a specific day of the year.
[Yearly(int, int, int)](Assorted.Utils.Dates.Recurrent.Yearly.md#yearlyint-int-int) | Returns a yearly reoccurring pattern when events occur on a specific day of the month and a specific month of the year.
[Yearly(MonthOfYear, int, int)](Assorted.Utils.Dates.Recurrent.Yearly.md#yearlymonthofyear-int-int) | Returns a yearly reoccurring pattern when events occur on a specific day of the month and a specific month of the year.
[Yearly(WeekOfMonth, DayOfWeek, int, int)](Assorted.Utils.Dates.Recurrent.Yearly.md#yearlyweekofmonth-dayofweek-int-int) | Returns a yearly reoccurring pattern when events occur on a specific day of the week and a specific week of a month of the year.
[Yearly(WeekOfMonth, DayOfWeek, MonthOfYear, int)](Assorted.Utils.Dates.Recurrent.Yearly.md#yearlyweekofmonth-dayofweek-monthofyear-int) | Returns a yearly reoccurring pattern when events occur on a specific day of the week and a specific week of a month of the year.
[Yearly(WeekOfMonth, DaysOfTheWeek, int, int)](Assorted.Utils.Dates.Recurrent.Yearly.md#yearlyweekofmonth-daysoftheweek-int-int) | Returns a yearly reoccurring pattern when events occur on one of the specified days of the week and a specific week of a month of the year.
[Yearly(WeekOfMonth, DaysOfTheWeek, MonthOfYear, int)](Assorted.Utils.Dates.Recurrent.Yearly.md#yearlyweekofmonth-daysoftheweek-monthofyear-int) | Returns a yearly reoccurring pattern when events occur on one of the specified days of the week and a specific week of a month of the year.

## Yearly(int, int)

Returns a yearly reoccurring pattern when events occur on a specific day of the year.

### Syntax

```csharp
public static YearlyDayPattern Yearly(int dayOfYear, int interval = 1)
```

#### Parameters

`dayOfYear`: [int](https://docs.microsoft.com/en-us/dotnet/api/system.int32)\
The day of the year when the event occurs.

`interval`: [int](https://docs.microsoft.com/en-us/dotnet/api/system.int32)\
The interval of occurrences in number of years.

#### Return Value

[YearlyDayPattern](Assorted.Utils.Dates.Patterns.YearlyDayPattern.md)\
An instance of [`YearlyDayPattern`](Assorted.Utils.Dates.Patterns.YearlyDayPattern.md) class.

### Exceptions

Exception | Description
--- | ---
[System.ArgumentOutOfRangeException](https://docs.microsoft.com/en-us/dotnet/api/system.argumentoutofrangeexception) | `dayOfYear` is less than 1 or greater than 366. Or, `interval` is less than 1.

### See Also

- [Assorted.Utils.Dates Namespace](index.md#assortedutilsdates-namespace)
- [Recurrent Class](Assorted.Utils.Dates.Recurrent.md)

## Yearly(int, int, int)

Returns a yearly reoccurring pattern when events occur on a specific day of the month and a specific month of the year.

### Syntax

```csharp
public static YearlyMonthPattern Yearly(int monthOfYear, int dayOfMonth, int interval = 1)
```

#### Parameters

`monthOfYear`: [int](https://docs.microsoft.com/en-us/dotnet/api/system.int32)\
The month when the event occurs.

`dayOfMonth`: [int](https://docs.microsoft.com/en-us/dotnet/api/system.int32)\
The day of the month when the event occurs.

`interval`: [int](https://docs.microsoft.com/en-us/dotnet/api/system.int32)\
The interval of occurrences in number of years.

#### Return Value

[YearlyMonthPattern](Assorted.Utils.Dates.Patterns.YearlyMonthPattern.md)\
An instance of [`YearlyMonthPattern`](Assorted.Utils.Dates.Patterns.YearlyMonthPattern.md) class.

### Exceptions

Exception | Description
--- | ---
[System.ArgumentOutOfRangeException](https://docs.microsoft.com/en-us/dotnet/api/system.argumentoutofrangeexception) | `dayOfMonth` is less than 1 or greater than the last day of the month specified by the `monthOfYear` parameter. Or, `interval` is less than 1.

### See Also

- [Assorted.Utils.Dates Namespace](index.md#assortedutilsdates-namespace)
- [Recurrent Class](Assorted.Utils.Dates.Recurrent.md)

## Yearly(MonthOfYear, int, int)

Returns a yearly reoccurring pattern when events occur on a specific day of the month and a specific month of the year.

### Syntax

```csharp
public static YearlyMonthPattern Yearly(MonthOfYear monthOfYear, int dayOfMonth, int interval = 1)
```

#### Parameters

`monthOfYear`: [MonthOfYear](Assorted.Utils.Dates.MonthOfYear.md)\
The month when the event occurs.

`dayOfMonth`: [int](https://docs.microsoft.com/en-us/dotnet/api/system.int32)\
The day of the month when the event occurs.

`interval`: [int](https://docs.microsoft.com/en-us/dotnet/api/system.int32)\
The interval of occurrences in number of years.

#### Return Value

[YearlyMonthPattern](Assorted.Utils.Dates.Patterns.YearlyMonthPattern.md)\
An instance of [`YearlyMonthPattern`](Assorted.Utils.Dates.Patterns.YearlyMonthPattern.md) class.

### Exceptions

Exception | Description
--- | ---
[System.ArgumentOutOfRangeException](https://docs.microsoft.com/en-us/dotnet/api/system.argumentoutofrangeexception) | `dayOfMonth` is less than 1 or greater than the last day of the month specified by the `monthOfYear` parameter. Or, `interval` is less than 1.

### See Also

- [Assorted.Utils.Dates Namespace](index.md#assortedutilsdates-namespace)
- [Recurrent Class](Assorted.Utils.Dates.Recurrent.md)

## Yearly(WeekOfMonth, DayOfWeek, int, int)

Returns a yearly reoccurring pattern when events occur on a specific day of the week and a specific week of a month of the year.

### Syntax

```csharp
public static YearlyWeekPattern Yearly(
    WeekOfMonth weekOfMonth, 
    DayOfWeek dayOfWeek, 
    int monthOfYear, 
    int interval = 1
)
```

#### Parameters

`weekOfMonth`: [WeekOfMonth](Assorted.Utils.Dates.WeekOfMonth.md)\
The week of the month when the event occurs.

`dayOfWeek`: [DayOfWeek](https://docs.microsoft.com/en-us/dotnet/api/system.dayofweek)\
The day of the week when the event occurs.

`monthOfYear`: [int](https://docs.microsoft.com/en-us/dotnet/api/system.int32)\
The month when the event occurs.

`interval`: [int](https://docs.microsoft.com/en-us/dotnet/api/system.int32)\
The interval of occurrences in number of years.

#### Return Value

[YearlyWeekPattern](Assorted.Utils.Dates.Patterns.YearlyWeekPattern.md)\
An instance of [`YearlyWeekPattern`](Assorted.Utils.Dates.Patterns.YearlyWeekPattern.md) class.

### Exceptions

Exception | Description
--- | ---
[System.ArgumentOutOfRangeException](https://docs.microsoft.com/en-us/dotnet/api/system.argumentoutofrangeexception) | `monthOfYear` is less than 1 or greater than 12. Or, `interval` is less than 1.

### See Also

- [Assorted.Utils.Dates Namespace](index.md#assortedutilsdates-namespace)
- [Recurrent Class](Assorted.Utils.Dates.Recurrent.md)

## Yearly(WeekOfMonth, DayOfWeek, MonthOfYear, int)

Returns a yearly reoccurring pattern when events occur on a specific day of the week and a specific week of a month of the year.

### Syntax

```csharp
public static YearlyWeekPattern Yearly(
    WeekOfMonth weekOfMonth, 
    DayOfWeek dayOfWeek, 
    MonthOfYear monthOfYear, 
    int interval = 1
)
```

#### Parameters

`weekOfMonth`: [WeekOfMonth](Assorted.Utils.Dates.WeekOfMonth.md)\
The week of the month when the event occurs.

`dayOfWeek`: [DayOfWeek](https://docs.microsoft.com/en-us/dotnet/api/system.dayofweek)\
The day of the week when the event occurs.

`monthOfYear`: [MonthOfYear](Assorted.Utils.Dates.MonthOfYear.md)\
The month when the event occurs.

`interval`: [int](https://docs.microsoft.com/en-us/dotnet/api/system.int32)\
The interval of occurrences in number of years.

#### Return Value

[YearlyWeekPattern](Assorted.Utils.Dates.Patterns.YearlyWeekPattern.md)\
An instance of [`YearlyWeekPattern`](Assorted.Utils.Dates.Patterns.YearlyWeekPattern.md) class.

### Exceptions

Exception | Description
--- | ---
[System.ArgumentOutOfRangeException](https://docs.microsoft.com/en-us/dotnet/api/system.argumentoutofrangeexception) | `interval` is less than 1.

### See Also

- [Assorted.Utils.Dates Namespace](index.md#assortedutilsdates-namespace)
- [Recurrent Class](Assorted.Utils.Dates.Recurrent.md)

## Yearly(WeekOfMonth, DaysOfTheWeek, int, int)

Returns a yearly reoccurring pattern when events occur on one of the specified days of the week and a specific week of a month of the year.

### Syntax

```csharp
public static YearlyWeekPattern Yearly(
    WeekOfMonth weekOfMonth, 
    DaysOfTheWeek daysOfWeek, 
    int monthOfYear, 
    int interval = 1
)
```

#### Parameters

`weekOfMonth`: [WeekOfMonth](Assorted.Utils.Dates.WeekOfMonth.md)\
The week of the month when the event occurs.

`daysOfWeek`: [DaysOfTheWeek](Assorted.Utils.Dates.DaysOfTheWeek.md)\
The accepted days of the week when the event can occur.

`monthOfYear`: [int](https://docs.microsoft.com/en-us/dotnet/api/system.int32)\
The month when the event occurs.

`interval`: [int](https://docs.microsoft.com/en-us/dotnet/api/system.int32)\
The interval of occurrences in number of years.

#### Return Value

[YearlyWeekPattern](Assorted.Utils.Dates.Patterns.YearlyWeekPattern.md)\
An instance of [`YearlyWeekPattern`](Assorted.Utils.Dates.Patterns.YearlyWeekPattern.md) class.

### Exceptions

Exception | Description
--- | ---
[System.ArgumentOutOfRangeException](https://docs.microsoft.com/en-us/dotnet/api/system.argumentoutofrangeexception) | `monthOfYear` is less than 1 or greater than 12. Or, `interval` is less than 1.

### See Also

- [Assorted.Utils.Dates Namespace](index.md#assortedutilsdates-namespace)
- [Recurrent Class](Assorted.Utils.Dates.Recurrent.md)

## Yearly(WeekOfMonth, DaysOfTheWeek, MonthOfYear, int)

Returns a yearly reoccurring pattern when events occur on one of the specified days of the week and a specific week of a month of the year.

### Syntax

```csharp
public static YearlyWeekPattern Yearly(
    WeekOfMonth weekOfMonth, 
    DaysOfTheWeek daysOfWeek, 
    MonthOfYear monthOfYear, 
    int interval = 1
)
```

#### Parameters

`weekOfMonth`: [WeekOfMonth](Assorted.Utils.Dates.WeekOfMonth.md)\
The week of the month when the event occurs.

`daysOfWeek`: [DaysOfTheWeek](Assorted.Utils.Dates.DaysOfTheWeek.md)\
The accepted days of the week when the event can occur.

`monthOfYear`: [MonthOfYear](Assorted.Utils.Dates.MonthOfYear.md)\
The month when the event occurs.

`interval`: [int](https://docs.microsoft.com/en-us/dotnet/api/system.int32)\
The interval of occurrences in number of years.

#### Return Value

[YearlyWeekPattern](Assorted.Utils.Dates.Patterns.YearlyWeekPattern.md)\
An instance of [`YearlyWeekPattern`](Assorted.Utils.Dates.Patterns.YearlyWeekPattern.md) class.

### Exceptions

Exception | Description
--- | ---
[System.ArgumentOutOfRangeException](https://docs.microsoft.com/en-us/dotnet/api/system.argumentoutofrangeexception) | `interval` is less than 1.

### See Also

- [Assorted.Utils.Dates Namespace](index.md#assortedutilsdates-namespace)
- [Recurrent Class](Assorted.Utils.Dates.Recurrent.md)

---

_This document is generated by [DG](https://github.com/Khojasteh/dg)._
