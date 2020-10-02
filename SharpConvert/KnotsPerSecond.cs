namespace MmiSoft.Core.Math.Units
{
	public class KnotsPerSecond : AccelerationUnit
	{

		public KnotsPerSecond() : this(0) { }

		public KnotsPerSecond(double unitValue) : base(unitValue, Conversion.KnotPerSecond)
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
