
namespace MmiSoft.Core.Math.Units
{
	using System;

	[Serializable]
	public abstract class AccelerationUnit : UnitBase, IComparable<AccelerationUnit>
	{
		public static readonly AccelerationUnit Zero = 0.MetersPerSecondSquared();

		protected AccelerationUnit(double unitValue, Conversion conversion) : base(unitValue, conversion)
		{
		}

		protected abstract SpeedUnit GetSpeedUnit();

		protected abstract TimeUnit GetTimeUnit();

		public A To<A>() where A : AccelerationUnit
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

		public static SpeedUnit operator *(TimeUnit t, AccelerationUnit a)
		{
			return a * t;
		}

		public static SpeedUnit operator *(AccelerationUnit a, TimeSpan t)
		{
			return a * new Seconds(t);
		}

		public static SpeedUnit operator *(TimeSpan t, AccelerationUnit a)
		{
			return a * new Seconds(t);
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

		public static AccelerationUnit operator -(AccelerationUnit l, AccelerationUnit r)
		{
			return new MetersPerSecondSquared(l.ToSi() - r.ToSi());
		}

		public static AccelerationUnit operator +(AccelerationUnit l, AccelerationUnit r)
		{
			return new MetersPerSecondSquared(l.ToSi() + r.ToSi());
		}

		public static AccelerationUnit operator *(AccelerationUnit a, double factor)
		{
			AccelerationUnit copy = (AccelerationUnit) a.MemberwiseClone();
			copy.unitValue *= factor;
			return copy;
		}

		public static AccelerationUnit operator *(double factor, AccelerationUnit a)
		{
			return a * factor;
		}

		public static double operator /(AccelerationUnit x, AccelerationUnit y)
		{
			return x.ToSi() / y.ToSi();
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

		public static AccelerationUnit operator /(AccelerationUnit a, float y)
		{
			return a / (double) y;
		}

		public static AccelerationUnit operator /(AccelerationUnit a, int y)
		{
			return a / (double) y;
		}

		public static AccelerationUnit operator -(AccelerationUnit x)
		{
			AccelerationUnit cloned = (AccelerationUnit)x.MemberwiseClone();
			cloned.unitValue = -cloned.unitValue;
			return cloned;
		}

		public static explicit operator double(AccelerationUnit a)
		{
			return a.unitValue;
		}

		public int CompareTo(AccelerationUnit other)
		{
			return CompareToImpl(other);
		}
	}
}
