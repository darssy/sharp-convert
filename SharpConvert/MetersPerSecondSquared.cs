using System;

namespace MmiSoft.Core.Math.Units
{
	[Serializable]
	public class MetersPerSecondSquared : AccelerationUnit
	{
		public new static readonly MetersPerSecondSquared Zero = new(0);

		public MetersPerSecondSquared() : this(0) {}

		public MetersPerSecondSquared(double unitValue) : base(unitValue, Conversion.MeterPerSecondSquared) { }

		protected override SpeedUnit GetSpeedUnit() => new MetersPerSecond();

		protected override TimeUnit GetTimeUnit() => new Seconds();

		public static MetersPerSecondSquared operator -(MetersPerSecondSquared x)
		{
			return new MetersPerSecondSquared(-x.unitValue);
		}

		public static MetersPerSecondSquared operator -(MetersPerSecondSquared l, MetersPerSecondSquared r)
		{
			return new MetersPerSecondSquared(l.unitValue - r.unitValue);
		}

		public static MetersPerSecondSquared operator -(MetersPerSecondSquared l, AccelerationUnit r)
		{
			if (r is MetersPerSecondSquared mpss) return l - mpss;
			return new MetersPerSecondSquared(l.Subtract(r));
		}

		public static MetersPerSecondSquared operator +(MetersPerSecondSquared l, MetersPerSecondSquared r)
		{
			return new MetersPerSecondSquared(l.unitValue + r.unitValue);
		}

		public static MetersPerSecondSquared operator +(MetersPerSecondSquared l, AccelerationUnit r)
		{
			if (r is MetersPerSecondSquared mpss) return l + mpss;
			return new MetersPerSecondSquared(l.Add(r));
		}

		public static MetersPerSecond operator *(MetersPerSecondSquared a, TimeUnit t)
		{
			return new MetersPerSecond(a.unitValue * t.To<Seconds>().UnitValue);
		}

		public static MetersPerSecond operator *(MetersPerSecondSquared a, Seconds t)
		{
			return new MetersPerSecond(a.unitValue * t.UnitValue);
		}

		public static MetersPerSecondSquared operator *(MetersPerSecondSquared a, double factor)
		{
			return new MetersPerSecondSquared(a.unitValue * factor);
		}

		public static MetersPerSecondSquared operator *(double factor, MetersPerSecondSquared a)
		{
			return new MetersPerSecondSquared(a.unitValue * factor);
		}

		public static MetersPerSecondSquared operator /(MetersPerSecondSquared a, double y)
		{
			return y == 0 ? null : new MetersPerSecondSquared(a.unitValue / y);
		}

		public static Seconds operator /(MetersPerSecond u, MetersPerSecondSquared a)
		{
			return a.unitValue == 0 ? null : new Seconds(System.Math.Abs(u.UnitValue / a.unitValue));
		}
	}
}
