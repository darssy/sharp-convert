using System;

namespace MmiSoft.Core.Math.Units
{
	[Serializable]
	public class KnotsPerSecond : AccelerationUnit
	{

		public KnotsPerSecond() : this(0) { }

		public KnotsPerSecond(double unitValue) : base(unitValue, Conversion.KnotPerSecond)
		{
		}

		protected override SpeedUnit GetSpeedUnit() => new Knots();

		protected override TimeUnit GetTimeUnit() => new Seconds();

		public static Knots operator *(KnotsPerSecond a, TimeUnit t)
		{
			double du = a.UnitValue * t.To<Seconds>().UnitValue;
			return new Knots(du);
		}

		public static KnotsPerSecond operator *(KnotsPerSecond a, double factor)
		{
			return new KnotsPerSecond(a.unitValue * factor);
		}

		public static KnotsPerSecond operator -(KnotsPerSecond x)
		{
			return new KnotsPerSecond(-x.unitValue);
		}
	}
}
