namespace MmiSoft.Core.Math.Units
{
	public class FeetPerMinutePerSecond : AccelerationUnit
	{

		public FeetPerMinutePerSecond() : this(0) {}

		public FeetPerMinutePerSecond(double unitValue) : base(unitValue, Conversion.FootPerMinutePerSecond)
		{
		}

		protected override SpeedUnit GetSpeedUnit() => new FeetPerMinute();

		public override string Symbol => "fpm/s";

		public static FeetPerMinute operator *(FeetPerMinutePerSecond a, TimeUnit t)
		{
			double du = a.UnitValue * t.To<Seconds>().UnitValue;
			return new FeetPerMinute(du);
		}

		public static FeetPerMinutePerSecond operator -(FeetPerMinutePerSecond x)
		{
			return new FeetPerMinutePerSecond(-x.unitValue);
		}
	}

}
