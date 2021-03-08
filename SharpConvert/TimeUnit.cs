using System;

namespace MmiSoft.Core.Math.Units
{
	[Serializable]
	public abstract class TimeUnit : UnitBase, IComparable<TimeUnit>
	{
		public static readonly TimeUnit Zero = 0.Seconds();

		protected TimeUnit(double time, Conversion conversion)
			: base(time, conversion)
		{ }

		public T To<T>() where T : TimeUnit, new()
		{
			return ConvertTo<T, TimeUnit>(this);
		}

		public TimeSpan TimeSpan => this;

		public int CompareTo(TimeUnit other)
		{
			return ToSi().CompareTo(other.ToSi());
		}

		public static bool operator <(TimeUnit x, TimeUnit y)
		{
			return x.ToSi() < y.ToSi();
		}

		public static bool operator >(TimeUnit x, TimeUnit y)
		{
			return x.ToSi() > y.ToSi();
		}

		public static bool operator <=(TimeUnit x, TimeUnit y)
		{
			return x.ToSi() <= y.ToSi();
		}

		public static bool operator >=(TimeUnit x, TimeUnit y)
		{
			return x.ToSi() >= y.ToSi();
		}

		public static TimeUnit operator -(TimeUnit l, TimeUnit r)
		{
			return new Seconds(System.Math.Abs(l.ToSi() - r.ToSi()));
		}

		public static TimeUnit operator +(TimeUnit l, TimeUnit r)
		{
			return new Seconds(l.ToSi() + r.ToSi());
		}

		public static double operator /(TimeUnit l, TimeUnit r)
		{
			return l.ToSi() / r.ToSi();
		}

		public static explicit operator double(TimeUnit t)
		{
			return t.unitValue;
		}

		public static implicit operator TimeSpan(TimeUnit t)
		{
			return TimeSpan.FromSeconds(t.ToSi());
		}
	}
}
