
namespace MmiSoft.Core.Math.Units
{
	using System;

	[Serializable]
	public abstract class AccelerationUnit : UnitBase
	{
		public static readonly AccelerationUnit Zero = 0.MetersPerSecondSquared();

		protected AccelerationUnit(double unitValue, Conversion conversion) : base(unitValue, conversion)
		{
		}

		protected abstract SpeedUnit GetSpeedUnit();

		protected abstract TimeUnit GetTimeUnit();

		public A To<A>() where A : AccelerationUnit, new()
		{
			return ConvertTo<A, AccelerationUnit>(this);
		}

		public static SpeedUnit operator *(AccelerationUnit a, TimeUnit t)
		{
			double s = a.ToSi() * t.ToSi();
			SpeedUnit changeInSpeed = a.GetSpeedUnit();
			changeInSpeed.FromSi(Math.Abs(s));
			return changeInSpeed;
		}

		public static bool operator <(AccelerationUnit x, AccelerationUnit y)
		{
			return x.ToSi() < y.ToSi();
		}

		public static bool operator >(AccelerationUnit x, AccelerationUnit y)
		{
			return x.ToSi() > y.ToSi();
		}

		public static bool operator <=(AccelerationUnit x, AccelerationUnit y)
		{
			return x.ToSi() <= y.ToSi();
		}

		public static bool operator >=(AccelerationUnit x, AccelerationUnit y)
		{
			return x.ToSi() >= y.ToSi();
		}

		public static TimeUnit operator /(SpeedUnit u, AccelerationUnit a)
		{
			if (a == Zero) return null;
			double t = Math.Abs(u.ToSi()) / Math.Abs(a.ToSi());
			TimeUnit timeToAccomplish = a.GetTimeUnit();
			timeToAccomplish.FromSi(t);
			return timeToAccomplish;
		}

		public static AccelerationUnit operator /(AccelerationUnit a, double y)
		{
			if (y == 0) return null;
			AccelerationUnit a2 = (AccelerationUnit) a.MemberwiseClone();
			a2.FromSi(a.ToSi() / y);
			return a2;
		}

		public static AccelerationUnit operator -(AccelerationUnit x)
		{
			AccelerationUnit cloned = (AccelerationUnit)x.MemberwiseClone();
			cloned.unitValue = -cloned.unitValue;
			return cloned;
		}
	}
}
