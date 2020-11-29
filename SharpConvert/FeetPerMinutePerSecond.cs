using System;

namespace MmiSoft.Core.Math.Units
{
	[Serializable]
	public class FeetPerMinutePerSecond : AccelerationUnit
	{
		public new static readonly FeetPerMinutePerSecond Zero = 0.FeetPerMinutePerSecond();

		public FeetPerMinutePerSecond() : this(0) {}

		public FeetPerMinutePerSecond(double unitValue) : base(unitValue, Conversion.FootPerMinutePerSecond)
		{
		}

		protected override SpeedUnit GetSpeedUnit() => new FeetPerMinute();

		protected override TimeUnit GetTimeUnit() => new Seconds();

		public static FeetPerMinute operator *(FeetPerMinutePerSecond a, TimeUnit t)
		{
			double du = a.unitValue * t.To<Seconds>().UnitValue;
			return new FeetPerMinute(du);
		}

		public static FeetPerMinute operator *(FeetPerMinutePerSecond a, Seconds t)
		{
			return new FeetPerMinute(a.unitValue * t.UnitValue);
		}

		public static Seconds operator /(FeetPerMinute u, FeetPerMinutePerSecond a)
		{
			return a == Zero ? null : new Seconds(u.UnitValue / a.unitValue);
		}

		public static FeetPerMinutePerSecond operator /(FeetPerMinutePerSecond a, double y)
		{
			return y == 0 ? null : new FeetPerMinutePerSecond(a.unitValue / y);
		}

		public static FeetPerMinutePerSecond operator -(FeetPerMinutePerSecond x)
		{
			return new FeetPerMinutePerSecond(-x.unitValue);
		}
	}

}
