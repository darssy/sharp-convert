using System;

namespace MmiSoft.Core.Math.Units
{
	[Serializable]
	public class FeetPerSecondSquared : AccelerationUnit
	{
		public FeetPerSecondSquared() : this(0) {}

		public FeetPerSecondSquared(double unitValue) : base(unitValue, Conversion.FootPerSecondSquared)
		{
		}

		protected override SpeedUnit GetSpeedUnit() => new FeetPerSecond();

		public static FeetPerSecond operator *(FeetPerSecondSquared a, TimeUnit t)
		{
			double du = a.UnitValue * t.To<Seconds>().UnitValue;
			return new FeetPerSecond(du);
		}

		public static Seconds operator /(FeetPerSecondSquared a, FeetPerSecond u)
		{
			return u.UnitValue == 0 ? null : new Seconds(a.UnitValue / u.UnitValue);
		}

		public static Seconds operator /(FeetPerSecondSquared a, SpeedUnit u)
		{
			if (u is FeetPerSecond fps) return a / fps;
			return new Seconds(a.UnitValue / u.To<FeetPerSecond>().UnitValue);
		}

		public static FeetPerSecondSquared operator -(FeetPerSecondSquared x)
		{
			return new FeetPerSecondSquared(-x.unitValue);
		}
	}
}
