namespace MmiSoft.Core.Math.Units
{
	public class KnotsPerSecond : AccelerationUnit
	{
		private static readonly double SiConversionFactor = new Knots().ToSiFactor / new Seconds().ToSiFactor;

		public KnotsPerSecond(double unitValue) : base(unitValue, SiConversionFactor)
		{
		}

		protected override SpeedUnit GetSpeedUnit() => new Knots();

		public override string Symbol => "kt/s";

		public static Knots operator *(KnotsPerSecond a, TimeUnit t)
		{
			double du = a.UnitValue * t.To<Seconds>().UnitValue;
			return new Knots(du);
		}

		public static KnotsPerSecond operator -(KnotsPerSecond x)
		{
			return new KnotsPerSecond(-x.unitValue);
		}
	}
}
