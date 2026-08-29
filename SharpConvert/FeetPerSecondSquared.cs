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

		protected override TimeUnit GetTimeUnit() => new Seconds();

		public static FeetPerSecond operator *(FeetPerSecondSquared a, TimeUnit t)
		{
			double du = a.unitValue * t.To<Seconds>().UnitValue;
			return new FeetPerSecond(du);
		}

		public static Seconds operator /(FeetPerSecond u, FeetPerSecondSquared a)
		{
			return a.unitValue == 0 ? null : new Seconds(System.Math.Abs(u.UnitValue / a.unitValue));
		}

		public static Seconds operator /(SpeedUnit u, FeetPerSecondSquared a)
		{
			if (a.unitValue == 0) return null;
			if (u is FeetPerSecond fps) return fps / a;
			return new Seconds(System.Math.Abs(u.To<FeetPerSecond>().UnitValue / a.UnitValue));
		}

		public static FeetPerSecondSquared operator -(FeetPerSecondSquared x)
		{
			return new FeetPerSecondSquared(-x.unitValue);
		}

		public static FeetPerSecondSquared operator -(FeetPerSecondSquared l, FeetPerSecondSquared r)
		{
			return new FeetPerSecondSquared(l.unitValue - r.unitValue);
		}

		public static FeetPerSecondSquared operator -(FeetPerSecondSquared l, AccelerationUnit r)
		{
			if (r is FeetPerSecondSquared fpss) return l - fpss;
			return new FeetPerSecondSquared(l.Subtract(r));
		}

		public static FeetPerSecondSquared operator +(FeetPerSecondSquared l, FeetPerSecondSquared r)
		{
			return new FeetPerSecondSquared(l.unitValue + r.unitValue);
		}

		public static FeetPerSecondSquared operator +(FeetPerSecondSquared l, AccelerationUnit r)
		{
			if (r is FeetPerSecondSquared fpss) return l + fpss;
			return new FeetPerSecondSquared(l.Add(r));
		}

		public static FeetPerSecond operator *(FeetPerSecondSquared a, Seconds t)
		{
			return new FeetPerSecond(a.unitValue * t.UnitValue);
		}

		public static FeetPerSecondSquared operator *(FeetPerSecondSquared a, double factor)
		{
			return new FeetPerSecondSquared(a.unitValue * factor);
		}

		public static FeetPerSecondSquared operator *(double factor, FeetPerSecondSquared a)
		{
			return new FeetPerSecondSquared(a.unitValue * factor);
		}

		public static FeetPerSecondSquared operator /(FeetPerSecondSquared a, double y)
		{
			return y == 0 ? null : new FeetPerSecondSquared(a.unitValue / y);
		}
	}
}
