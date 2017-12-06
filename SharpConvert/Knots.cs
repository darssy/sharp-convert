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
			: base(knots, new NauticalMiles().ToSiFactor / new Hours().ToSiFactor)
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
			return (s / (SpeedUnit)u).To<Hours>();
		}
	}
}
