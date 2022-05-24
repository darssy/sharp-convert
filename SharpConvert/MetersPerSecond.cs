using System;

namespace MmiSoft.Core.Math.Units
{
	[Serializable]
	public class MetersPerSecond : SpeedUnit
	{
		public static readonly MetersPerSecond Zero = 0.MetersPerSecond();

		public MetersPerSecond() : this(0)
		{
			
		}
		public MetersPerSecond(double speed)
			: base(speed, Conversion.MeterPerSecond)
		{
		}

		protected override LengthUnit GetLengthUnit()
		{
			return new Meters();
		}

		protected override TimeUnit GetTimeUnit()
		{
			return new Seconds();
		}

		public static MetersPerSecond operator -(MetersPerSecond x)
		{
			return new MetersPerSecond(-x.unitValue);
		}

		public static MetersPerSecond operator -(MetersPerSecond l, SpeedUnit r)
		{
			if (r is MetersPerSecond mps) return l - mps;
			return new MetersPerSecond(l.unitValue - r.ToSi());
		}

		public static MetersPerSecond operator -(MetersPerSecond l, MetersPerSecond r)
		{
			return new MetersPerSecond(l.unitValue - r.unitValue);
		}

		public static MetersPerSecond operator +(MetersPerSecond l, SpeedUnit r)
		{
			if (r is MetersPerSecond mps) return l - mps;
			return new MetersPerSecond(l.unitValue + r.ToSi());
		}

		public static MetersPerSecond operator +(MetersPerSecond l, MetersPerSecond r)
		{
			return new MetersPerSecond(l.unitValue + r.unitValue);
		}
	}
}
