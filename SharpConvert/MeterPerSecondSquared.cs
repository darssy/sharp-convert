namespace MmiSoft.Core.Math.Units
{
	public class MeterPerSecondSquared : AccelerationUnit
	{
		public MeterPerSecondSquared(double unitValue) : base(unitValue, 1)
		{
		}

		public override string Symbol => "m/s^2";

		protected override SpeedUnit GetSpeedUnit() => new MetersPerSecond();

		public static MeterPerSecondSquared operator -(MeterPerSecondSquared x)
		{
			return new MeterPerSecondSquared(-x.unitValue);
		}
	}
}
