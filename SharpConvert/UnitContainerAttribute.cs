using System;
using System.Globalization;

namespace MmiSoft.Core.Math.Units;

/// <summary>
/// Mark your assembly as such if you have declared your own units there and you want SharpConvert to search for units in that
/// assembly. This is useful if you want <see cref="Extensions.ParseUnit(string,CultureInfo)"/> to be able to parse your unit's
/// symbol.
/// </summary>
[AttributeUsage(AttributeTargets.Assembly)]
public class UnitContainerAttribute : Attribute
{
		
}
