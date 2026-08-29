using System;

namespace MmiSoft.Core.Math.Units
{

	[Serializable]
	public class FeetPerSecond : SpeedUnit
	{

		public FeetPerSecond()
			: this(0)
		{
		}

		public FeetPerSecond(double fps)
			: base(fps, Conversion.FootPerSecond)
		{
		}

		protected override LengthUnit GetLengthUnit()
		{
			return new Feet();
		}

		protected override TimeUnit GetTimeUnit()
		{
			return new Seconds();
		}

		public static FeetPerSecond operator -(FeetPerSecond x)
		{
			return new FeetPerSecond(-x.unitValue);
		}

		public static FeetPerSecond operator -(FeetPerSecond l, FeetPerSecond r)
		{
			return new FeetPerSecond(l.unitValue - r.unitValue);
		}

		public static FeetPerSecond operator -(FeetPerSecond l, SpeedUnit r)
		{
			if (r is FeetPerSecond fps) return l - fps;
			return new FeetPerSecond(l.Subtract(r));
		}

		public static FeetPerSecond operator +(FeetPerSecond l, FeetPerSecond r)
		{
			return new FeetPerSecond(l.unitValue + r.unitValue);
		}

		public static FeetPerSecond operator +(FeetPerSecond l, SpeedUnit r)
		{
			if (r is FeetPerSecond fps) return l + fps;
			return new FeetPerSecond(l.Add(r));
		}

		public static FeetPerSecond operator *(FeetPerSecond u, double factor)
		{
			return new FeetPerSecond(u.unitValue * factor);
		}

		public static FeetPerSecond operator *(double factor, FeetPerSecond u)
		{
			return new FeetPerSecond(u.unitValue * factor);
		}

		public static FeetPerSecond operator /(FeetPerSecond u, double factor)
		{
			return factor == 0 ? null : new FeetPerSecond(u.unitValue / factor);
		}

		public static FeetPerSecondSquared operator /(FeetPerSecond u, Seconds t)
		{
			return t.UnitValue == 0 ? null : new FeetPerSecondSquared(u.unitValue / t.UnitValue);
		}

		public static Feet operator *(FeetPerSecond u, Seconds t)
		{
			return new Feet(System.Math.Abs(u.unitValue * t.UnitValue));
		}
	}
}
