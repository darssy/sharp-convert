using System;

namespace MmiSoft.Core.Math.Units
{
	[Serializable]
	public class MetersPerSecondSquared : AccelerationUnit
	{
		public MetersPerSecondSquared() : this(0) {}

		public MetersPerSecondSquared(double unitValue) : base(unitValue, Conversion.MeterPerSecondSquared) { }

		protected override SpeedUnit GetSpeedUnit() => new MetersPerSecond();

		public static MetersPerSecondSquared operator -(MetersPerSecondSquared x)
		{
			return new MetersPerSecondSquared(-x.unitValue);
		}
	}
}
