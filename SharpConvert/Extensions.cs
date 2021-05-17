using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace MmiSoft.Core.Math.Units
{
	public static class Extensions
	{
		private static List<string> registeredUnitSymbols = new List<string>();
		private static Dictionary<string, Func<double, UnitBase>> registeredUnitConstructors
			= new Dictionary<string, Func<double, UnitBase>>();

		static Extensions()
		{
			foreach (Func<double,UnitBase> ctor in ReflectionHelper.All())
			{
				UnitBase unit = ctor.Invoke(0);
				registeredUnitConstructors[unit.Symbol] = ctor;
			}
			registeredUnitSymbols.AddRange(registeredUnitConstructors.Keys);
		}

		[Obsolete("Replaced by ParseUnit. Imagine what would happen if everyone was providing a Parse extension " +
		          "method on string. Exactly. Chaos. Will be deprecated in 2.0")]
		public static UnitBase Parse(this string text, CultureInfo culture = null)
		{
			return ParseUnit(text, culture);
		}

		public static UnitBase ParseUnit(this string text, CultureInfo culture = null)
		{
			text = text.Trim();
			string unit = registeredUnitSymbols.FirstOrDefault(text.EndsWith);
			if (unit == null) throw new FormatException($"Unknown unit for input: '{text}'");

			double value = double.Parse(text.Replace(unit, ""), culture ?? CultureInfo.CurrentCulture);
			return registeredUnitConstructors[unit].Invoke(value);
		}

		public static T Abs<T>(this T unit) where T : UnitBase
		{
			return UnitBase.Abs(unit);
		}

		#region Length Units
		public static Feet Feet(this double d)
		{
			return new Feet(d);
		}

		public static Feet Feet(this float d)
		{
			return new Feet(d);
		}

		public static Feet Feet(this int d)
		{
			return new Feet(d);
		}

		public static Meters Meters(this double d)
		{
			return new Meters(d);
		}

		public static Meters Meters(this float d)
		{
			return new Meters(d);
		}

		public static Meters Meters(this int d)
		{
			return new Meters(d);
		}

		public static Kilometers Kilometers(this double d)
		{
			return new Kilometers(d);
		}

		public static Kilometers Kilometers(this float d)
		{
			return new Kilometers(d);
		}

		public static Kilometers Kilometers(this int d)
		{
			return new Kilometers(d);
		}

		public static NauticalMiles NauticalMiles(this double d)
		{
			return new NauticalMiles(d);
		}

		public static NauticalMiles NauticalMiles(this float d)
		{
			return new NauticalMiles(d);
		}

		public static NauticalMiles NauticalMiles(this int d)
		{
			return new NauticalMiles(d);
		}
		#endregion

		#region Time
		public static Hours Hours(this double t)
		{
			return new Hours(t);
		}

		public static Hours Hours(this float t)
		{
			return new Hours(t);
		}

		public static Hours Hours(this int t)
		{
			return new Hours(t);
		}

		public static Minutes Minutes(this double t)
		{
			return new Minutes(t);
		}

		public static Minutes Minutes(this float t)
		{
			return new Minutes(t);
		}

		public static Minutes Minutes(this int t)
		{
			return new Minutes(t);
		}

		public static Seconds Seconds(this double t)
		{
			return new Seconds(t);
		}

		public static Seconds Seconds(this float t)
		{
			return new Seconds(t);
		}

		public static Seconds Seconds(this int t)
		{
			return new Seconds(t);
		}
		#endregion

		#region Speed Units
		public static Knots Knots(this double d)
		{
			return new Knots(d);
		}

		public static Knots Knots(this float d)
		{
			return new Knots(d);
		}

		public static Knots Knots(this int d)
		{
			return new Knots(d);
		}

		public static FeetPerMinute FeetPerMinute(this double d)
		{
			return new FeetPerMinute(d);
		}

		public static FeetPerMinute FeetPerMinute(this float d)
		{
			return new FeetPerMinute(d);
		}

		public static FeetPerMinute FeetPerMinute(this int d)
		{
			return new FeetPerMinute(d);
		}

		public static MetersPerSecond MetersPerSecond(this int mps)
		{
			return new MetersPerSecond(mps);
		}
		#endregion
		
		#region Angle Units

		public static Degrees Degrees(this int d)
		{
			return new Degrees(d);
		}

		public static Degrees Degrees(this float d)
		{
			return new Degrees(d);
		}

		public static Degrees Degrees(this double d)
		{
			return new Degrees(d);
		}

		public static Degrees Degrees(this decimal d)
		{
			return new Degrees((double)d);
		}

		public static Radians Radians(this int r)
		{
			return new Radians(r);
		}

		public static Radians Radians(this float r)
		{
			return new Radians(r);
		}

		public static Radians Radians(this double r)
		{
			return new Radians(r);
		}

		public static Radians Radians(this decimal r)
		{
			return new Radians((double)r);
		}
		#endregion

		#region Angular Velocity
		public static DegreesPerSecond DegreesPerSecond(this int d)
		{
			return new DegreesPerSecond(d);
		}

		public static DegreesPerSecond DegreesPerSecond(this float d)
		{
			return new DegreesPerSecond(d);
		}

		public static DegreesPerSecond DegreesPerSecond(this double d)
		{
			return new DegreesPerSecond(d);
		}

		public static RadiansPerSecond RadiansPerSecond(this int d)
		{
			return new RadiansPerSecond(d);
		}

		public static RadiansPerSecond RadiansPerSecond(this float d)
		{
			return new RadiansPerSecond(d);
		}

		public static RadiansPerSecond RadiansPerSecond(this double d)
		{
			return new RadiansPerSecond(d);
		}
		#endregion


		#region Mass

		public static Kilogram Kilogram(this int kg) => new Kilogram(kg);
		public static Kilogram Kilogram(this float kg) => new Kilogram(kg);
		public static Kilogram Kilogram(this double kg) => new Kilogram(kg);

		#endregion

		#region Acceleration

		public static MetersPerSecondSquared MetersPerSecondSquared(this int mpsPerSec) => new MetersPerSecondSquared(mpsPerSec);
		public static MetersPerSecondSquared MetersPerSecondSquared(this float mpsPerSec) => new MetersPerSecondSquared(mpsPerSec);
		public static MetersPerSecondSquared MetersPerSecondSquared(this double mpsPerSec) => new MetersPerSecondSquared(mpsPerSec);

		public static KnotsPerSecond KnotsPerSecond(this int ktsPerSec) => new KnotsPerSecond(ktsPerSec);
		public static KnotsPerSecond KnotsPerSecond(this float ktsPerSec) => new KnotsPerSecond(ktsPerSec);
		public static KnotsPerSecond KnotsPerSecond(this double ktsPerSec) => new KnotsPerSecond(ktsPerSec);

		public static FeetPerMinutePerSecond FeetPerMinutePerSecond(this int fpsPerSec) => new FeetPerMinutePerSecond(fpsPerSec);
		public static FeetPerMinutePerSecond FeetPerMinutePerSecond(this float fpsPerSec) => new FeetPerMinutePerSecond(fpsPerSec);
		public static FeetPerMinutePerSecond FeetPerMinutePerSecond(this double fpsPerSec) => new FeetPerMinutePerSecond(fpsPerSec);

		#endregion
	}
}
