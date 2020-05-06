[![Codacy Badge](https://api.codacy.com/project/badge/Grade/9fd842845e954fa1a4036088002b5b1c)](https://www.codacy.com/manual/adamstyl/sharp-convert?utm_source=github.com&amp;utm_medium=referral&amp;utm_content=adamstyl/sharp-convert&amp;utm_campaign=Badge_Grade)
[![Build status](https://img.shields.io/appveyor/ci/adamstyl/sharp-convert.svg)](https://ci.appveyor.com/project/adamstyl/sharp-convert)

# Sharp Units
## Purpose - disclaimer
The purpose of this library is to handle conversions between [units of measurement](https://en.wikipedia.org/wiki/Conversion_of_units) in an object oriented manner. Although I recognize the library is not complete, the intention of this library is neither to describe every know unit, nor describe all possible physics equations that involve units.

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
Degrees = glideSlope = Math.Atan(tan).Radians.To<Degrees>();
```
and the library takes care of the rest.

## Characteristics
### Fluent interface
Sharp Units approaches object creation by utilizing a [fluent interface](https://en.wikipedia.org/wiki/Fluent_interface). For example:

`Meters distance = 150.Meters();`

And for conversions you can use:

`Feet ft = distance.To<Feet>();`

### Type safety
SharpConvert is type safe. Each unit type is a class by itself. Each time you know that you are handling distance or angle and not some cryptic double or float value. You won't end up adding up acceleration to temperature by mistake.

### Performance
Type safety comes at a cost. New object allocation is expensive and this is what you do each time you create a unit. In fact this

`30.Meters() < 2.Meters();`

is (approximately) twice as slow as checking for

`30.Meters().UnitValue < 2;`

Problem is that 2 can be anything and you won't always know what's on the left side of the operator.

### Accuracy
As it's already known, floating point arithmetic has rounding errors. For example 0.1 is not stored as exactly 0.1. To deal with the problem, Sharp Convert has an error margin of 10<sup>-15</sup> when performing equality operations.
