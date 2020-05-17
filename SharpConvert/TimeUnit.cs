using System;

namespace MmiSoft.Core.Math.Units
{
	[Serializable]
	public abstract class TimeUnit : UnitBase, IComparable<TimeUnit>
	{
		public static readonly TimeUnit Zero = 0.Seconds();

		protected TimeUnit(double time, double toSiFactor)
			: base(time, toSiFactor)
		{ }

		public T To<T>() where T : TimeUnit, new()
		{
			return ConvertTo<T, TimeUnit>(this);
		}

		public TimeSpan TimeSpan => this;

		public override bool Equals(object obj)
		{
			var other = obj as TimeUnit;
			if (ReferenceEquals(null, other)) return false;
			if (ReferenceEquals(this, other)) return true;
			return EqualsImpl(other);
		}

		public override int GetHashCode()
		{
			return ToSi().GetHashCode() * 1000000017;
		}

		public int CompareTo(TimeUnit other)
		{
			return ToSi().CompareTo(other.ToSi());
		}

		public static TimeUnit operator -(TimeUnit l, TimeUnit r)
		{
			return new Seconds(System.Math.Abs(l.ToSi() - r.ToSi()));
		}

		public static TimeUnit operator +(TimeUnit l, TimeUnit r)
		{
			return new Seconds(l.ToSi() + r.ToSi());
		}

		public static implicit operator double(TimeUnit t)
		{
			return t.unitValue;
		}

		public static implicit operator TimeSpan(TimeUnit t)
		{
			return TimeSpan.FromSeconds(t.ToSi());
		}
	}
}
