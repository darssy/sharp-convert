using System;

namespace MmiSoft.Core.Math.Units
{
	[Serializable]
	public class MetersPerSecondSquared : AccelerationUnit
	{
		public new static readonly FeetPerMinutePerSecond Zero = 0.FeetPerMinutePerSecond();

		public MetersPerSecondSquared() : this(0) {}

		public MetersPerSecondSquared(double unitValue) : base(unitValue, Conversion.MeterPerSecondSquared) { }

		protected override SpeedUnit GetSpeedUnit() => new MetersPerSecond();

		protected override TimeUnit GetTimeUnit() => new Seconds();

		public static MetersPerSecondSquared operator -(MetersPerSecondSquared x)
		{
			return new MetersPerSecondSquared(-x.unitValue);
		}
	}
}
