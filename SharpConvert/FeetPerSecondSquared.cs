namespace MmiSoft.Core.Math.Units
{
	public class FeetPerSecondSquared : AccelerationUnit
	{
		private static readonly double SiConversionFactor = new FeetPerSecond().ToSiFactor / new Seconds().ToSiFactor;

		public FeetPerSecondSquared() : this(0) {}

		public FeetPerSecondSquared(double unitValue) : base(unitValue, SiConversionFactor)
		{
		}

		protected override SpeedUnit GetSpeedUnit() => new FeetPerSecond();

		public override string Symbol => "ft/s^2";

		public static FeetPerSecond operator *(FeetPerSecondSquared a, TimeUnit t)
		{
			double du = a.UnitValue * t.To<Seconds>().UnitValue;
			return new FeetPerSecond(du);
		}

		public static FeetPerSecondSquared operator -(FeetPerSecondSquared x)
		{
			return new FeetPerSecondSquared(-x.unitValue);
		}
	}
}
