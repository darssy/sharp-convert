using System;

namespace MmiSoft.Core.Math.Units
{
	[Serializable]
	public class Knots : SpeedUnit
	{

		public Knots()
			: this(0)
		{ }

		public Knots(double knots)
			: base(knots, Conversion.Knot)
		{ }

		protected override LengthUnit GetLengthUnit()
		{
			return new NauticalMiles();
		}

		protected override TimeUnit GetTimeUnit()
		{
			return new Hours();
		}

		public static NauticalMiles operator *(Knots u, TimeUnit t)
		{
			return ((SpeedUnit)u * t).To<NauticalMiles>();
		}

		public static LengthUnit operator *(Knots u, TimeSpan t)
		{
			return u * new Seconds(t);
		}

		public static Hours operator /(LengthUnit s, Knots u)
		{
			return u.unitValue == 0 ? null : (s / (SpeedUnit)u).To<Hours>();
		}

		public static Knots operator -(Knots l, SpeedUnit r)
		{
			if (r is Knots fpm) return l - fpm;
			return new Knots(l.Subtract(r));
		}

		public static Knots operator -(Knots l, Knots r)
		{
			return new Knots(l.unitValue - r.unitValue);
		}

		public static Knots operator +(Knots l, SpeedUnit r)
		{
			if (r is Knots fpm) return l - fpm;
			return new Knots(l.Add(r));
		}

		public static Knots operator +(Knots l, Knots r)
		{
			return new Knots(l.unitValue + r.unitValue);
		}
	}
}
