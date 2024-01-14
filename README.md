[![Build status](https://img.shields.io/appveyor/ci/darssy/sharp-convert.svg)](https://ci.appveyor.com/project/darssy/sharp-convert)

# Sharp Convert
## Purpose - disclaimer
The purpose of this library is to handle conversions between [units of measurement](https://en.wikipedia.org/wiki/Conversion_of_units) in an object oriented manner. Although I recognize the library is not complete, the intention is neither to describe every know unit, nor describe all possible physics equations that involve units.

For some background for the inspiration, you can have a look at this [relevant question in stackoverflow](https://stackoverflow.com/questions/348853/units-of-measure-in-c-sharp-almost). Basically the goal was to have something similar to F# units of measure which unfortunately is not even remotely possible. There is no way to get dimensional analysis in compile time and creating derivative units (like the example right below) is simply impossible. 

```fs
[<Measure>] type N = kg m/sec^2
```

Regardless if you are still interested and find some value into knowing _what_ is the number you see in your code then read on.

## Introduction
I realized the importance of an object oriented units conversion library while I was developing [DARSSY](http://darssy.com/). There I had to deal with nautical miles, feet, knots and feet per minute all at the same time. That was easy at first, but when the project scaled up, I was searching for bugs the root of which was units conversion.
For example, when calculating ILS glide paths I had to calculate the tangent of the glide triangle, and that was altitude in feet divided by distance in nautical miles. Before I had to do:
```cs
double distance = ...;
double tan = aircraft.Altitude * 0.3048 / (distance * 1852);
double glideSlopeDegrees = Math.Atan(tan) / Math.PI * 180;
```
Now I can do:
```cs
LengthUnit distance = ...;
double tan = aircraft.Altitude / distance;
Degrees = glideSlope = Math.Atan(tan).Radians().To<Degrees>();
```
and the library takes care of the rest.

## Characteristics
### Fluent interface
Sharp Units approaches object creation by utilizing a [fluent interface](https://en.wikipedia.org/wiki/Fluent_interface). For example:

`Meters distance = 150.Meters();`

And for conversions you can use:

`Feet ft = distance.To<Feet>();`

### Compile time type safety
SharpConvert is type safe. This isn't implied unfortunately as there are libraries out there handling the checks in runtime. Unfortunately. In SharpConvert, every unit type is a class by itself. Each time you know that you are handling distance or angle and not some cryptic double or float value. You won't end up adding up acceleration to temperature by mistake.

### Performance
Type safety comes at a cost. New object allocation is expensive and this is what you do each time you create a unit. In fact this

`30.Meters() < 2.Meters();`

is (approximately) twice as slow as checking for

`30.Meters().UnitValue < 2;`

Problem is that 2 can be anything and you won't always know what's on the left side of the operator.

#### Benchmarking
The only *realistic* answer to the "how fast (or slow) is it?" question can be **"Measure it!"**. The first benchmarks (as of April 2023) run with Benchmark.net are quite interesting and they prove that well optimized **classes can be faster than non optimized structs.** Once the benchmarks are quite mature they will be committed along with the rest of the code.

### Accuracy
As it's already known, floating point arithmetic has rounding errors. For example 0.1 is not stored as exactly 0.1. To deal with the problem, Sharp Convert has an error margin of 10<sup>-15</sup> when performing equality operations.

### Parsing
Parsing is based on the unit symbol and is case sensitive. For example `12NM` will result in 12 nautical miles while `12nm` will be 12 nanometers. Clearly, several orders of magnitude different. You don't have to worry for it now as I don't have any nanometers in the library. But future can be unpredictable. Space is allowed between the number and the unit symbol, but it's not advised as this might change in the future.

### Preparation for 2.0

After some years of maintaining this library and some quick research on other "competing" libraries, I realized that when it comes to a units system modeling in C#, there is a tradeoff between the speed of structs and the "reusability through inheritance" of classes.

In order to evaluate the two approaches, I added a new `Structs` namespace that will mirror the existing functionality with value types. **This should be considered experimental until further notice.**

One other important aspect is the _pluralism_ of the library. If you have a look into the next section you will immediately realize that this library is quite poor in terms of supported units when compared to other libraries. This is because each unit has **a lot** of boilerplate code that a) it has to be copied and tested by hand all the time (and we know how error prone could that be) and b) this boilerplate **can't be reduced with metaprogramming.** Unfortunately. As a result, the evolution of SharpConvert to a source generated library looks like a oneway road at the moment. Source generation is implemented using T4 with promising results so far.

#### Preliminary benchmark results
Here are some benchmark results comparing some of the implementations in SharpConvert and some popular units libraries. Result are from my development machine and are indicative. Benchmark code has not been released yet as it's quite messy.

```
BenchmarkDotNet=v0.13.5, OS=Windows 10 (10.0.19045.3930/22H2/2022Update)
Intel Core i7-7500U CPU 2.70GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
[Host]     : .NET Framework 4.8.1 (4.8.9181.0), X64 RyuJIT VectorSize=256
DefaultJob : .NET Framework 4.8.1 (4.8.9181.0), X64 RyuJIT VectorSize=256
```

| Method                                                    |       Mean |     Error |    StdDev |  Ratio | RatioSD |   Gen0 | Allocated | Alloc Ratio |
|-----------------------------------------------------------|-----------:|----------:|----------:|-------:|--------:|-------:|----------:|------------:|
| PlainOlDivision                                           |   2.503 ns | 0.0333 ns | 0.0260 ns |   1.00 |    0.00 |      - |         - |          NA |
| SharpConvertUglyStruct                                    |   4.889 ns | 0.0962 ns | 0.1581 ns |   1.92 |    0.06 |      - |         - |          NA |
| SharpConvertStruct                                        |   5.345 ns | 0.0918 ns | 0.1093 ns |   2.13 |    0.04 |      - |         - |          NA |
| SharpConvertClass                                         |  62.212 ns | 0.5740 ns | 0.4793 ns |  24.85 |    0.30 | 0.0305 |      64 B |          NA |
| [UnitsNet 5.11.0](https://github.com/angularsen/UnitsNet) | 276.748 ns | 2.8840 ns | 2.2516 ns | 110.58 |    1.74 | 0.0229 |      48 B |          NA |
| [GuUnits 0.10.7](https://github.com/GuOrg/Gu.Units)       |   7.190 ns | 0.0588 ns | 0.0521 ns |   2.87 |    0.04 |      - |         - |          NA |

* The reference is the "plain ol' division". At the end, units conversion is just that, a simple math operation.
* Ugly struct is an experimentation inspired by [my answer on StackOverflow](https://stackoverflow.com/a/67511063/1303323) based on what the OP suggested. It's the next fastest thing to plain math but it's as the name suggests... ugly.
* Struct is the under development version 2 of the library. It's difference is quite marginal compared to the ugly version. So I would keep the beautiful one :)
* Class is the current version if it. _Only_ 25 time slower. Could be worse I guess.
* UnitsNet is one of the most popular libraries for .net out there if not _the_ most popular. 110 times though slower than plain math can be ouch. I don't know the reason, I didn't dive into it. It might just be one small detail that could make the difference. My take out from this is that the "struct vs class" battle for performance might be a fallacy if you are not carefully designing your code.
* Gu Units is quite fast, my only remark on it is that it's not a _unit_ framework per se, but a conversion framework.

The above list is not exhaustive. If you think that there is another library that is worth benchmarking create an issue and let me know.

### Available units

#### Length
* `Meters`
* `Feet`
* `Kilometers`
* `NauticalMiles`

#### Time
* `Second`
* `Minute`
* `Hour`

#### Speed
* `MetersPerSecond`
* `FeetPerSecond`
* `FeetPerMinute`
* `Knots`

#### Acceleration
* `MetersPerSecondSquared`
* `FeetPerSecondSquared`
* `FeetPerMinutePerSecond`
* `KnotsPerSecond`

#### Angle
* `Radians`
* `Degrees`

#### Angular velocity
* `RadiansPerSecond`
* `DegreesPerSecond`

#### Mass
* `Kilograms`
