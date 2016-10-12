
using System;

namespace MmiSoft.Core.Math.Units
{
	public static class Extensions
	{
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
		#endregion

	}
}
