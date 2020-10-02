namespace MmiSoft.Core.Math.Units
{
	public class MetersPerSecondSquared : AccelerationUnit
	{
		public MetersPerSecondSquared() : this(0) {}

		public MetersPerSecondSquared(double unitValue) : base(unitValue, Conversion.MeterPerSecondSquared) { }

		public override string Symbol => "m/s^2";

		protected override SpeedUnit GetSpeedUnit() => new MetersPerSecond();

		public static MetersPerSecondSquared operator -(MetersPerSecondSquared x)
		{
			return new MetersPerSecondSquared(-x.unitValue);
		}
	}
}
