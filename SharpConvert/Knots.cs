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
	}
}
