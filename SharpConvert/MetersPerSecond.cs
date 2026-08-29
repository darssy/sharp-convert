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
			if (r is MetersPerSecond mps) return l + mps;
			return new MetersPerSecond(l.unitValue + r.ToSi());
		}

		public static MetersPerSecond operator +(MetersPerSecond l, MetersPerSecond r)
		{
			return new MetersPerSecond(l.unitValue + r.unitValue);
		}

		public static MetersPerSecond operator *(MetersPerSecond u, double factor)
		{
			return new MetersPerSecond(u.unitValue * factor);
		}

		public static MetersPerSecond operator *(double factor, MetersPerSecond u)
		{
			return new MetersPerSecond(u.unitValue * factor);
		}

		public static MetersPerSecond operator /(MetersPerSecond u, double factor)
		{
			return factor == 0 ? null : new MetersPerSecond(u.unitValue / factor);
		}

		public static MetersPerSecondSquared operator /(MetersPerSecond u, Seconds t)
		{
			return t.UnitValue == 0 ? null : new MetersPerSecondSquared(u.unitValue / t.UnitValue);
		}

		public static Meters operator *(MetersPerSecond u, Seconds t)
		{
			return new Meters(System.Math.Abs(u.unitValue * t.UnitValue));
		}
	}
}
