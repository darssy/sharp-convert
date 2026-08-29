using System;

namespace MmiSoft.Core.Math.Units
{
	[Serializable]
	public class KnotsPerSecond : AccelerationUnit
	{

		public KnotsPerSecond() : this(0) { }

		public KnotsPerSecond(double unitValue) : base(unitValue, Conversion.KnotPerSecond)
		{
		}

		protected override SpeedUnit GetSpeedUnit() => new Knots();

		protected override TimeUnit GetTimeUnit() => new Seconds();

		public static Knots operator *(KnotsPerSecond a, TimeUnit t)
		{
			double du = a.UnitValue * t.To<Seconds>().UnitValue;
			return new Knots(du);
		}

		public static KnotsPerSecond operator *(KnotsPerSecond a, double factor)
		{
			return new KnotsPerSecond(a.unitValue * factor);
		}

		public static KnotsPerSecond operator *(double factor, KnotsPerSecond a)
		{
			return new KnotsPerSecond(a.unitValue * factor);
		}

		public static KnotsPerSecond operator /(KnotsPerSecond a, double y)
		{
			return y == 0 ? null : new KnotsPerSecond(a.unitValue / y);
		}

		public static Knots operator *(KnotsPerSecond a, Seconds t)
		{
			return new Knots(a.unitValue * t.UnitValue);
		}

		public static Seconds operator /(Knots u, KnotsPerSecond a)
		{
			return a.unitValue == 0 ? null : new Seconds(System.Math.Abs(u.UnitValue / a.unitValue));
		}

		public static KnotsPerSecond operator -(KnotsPerSecond x)
		{
			return new KnotsPerSecond(-x.unitValue);
		}

		public static KnotsPerSecond operator -(KnotsPerSecond l, KnotsPerSecond r)
		{
			return new KnotsPerSecond(l.unitValue - r.unitValue);
		}

		public static KnotsPerSecond operator -(KnotsPerSecond l, AccelerationUnit r)
		{
			if (r is KnotsPerSecond kps) return l - kps;
			return new KnotsPerSecond(l.Subtract(r));
		}

		public static KnotsPerSecond operator +(KnotsPerSecond l, KnotsPerSecond r)
		{
			return new KnotsPerSecond(l.unitValue + r.unitValue);
		}

		public static KnotsPerSecond operator +(KnotsPerSecond l, AccelerationUnit r)
		{
			if (r is KnotsPerSecond kps) return l + kps;
			return new KnotsPerSecond(l.Add(r));
		}
	}
}
