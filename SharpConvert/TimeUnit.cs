using System;

namespace MmiSoft.Core.Math.Units
{
	[Serializable]
	public class TimeUnit : UnitBase
	{
		protected TimeUnit(double time, double toSiFactor)
			: base(time, toSiFactor)
		{ }

		public T To<T>() where T : TimeUnit, new()
		{
			return ConvertTo<T, TimeUnit>(this);
		}

		public TimeSpan TimeSpan
		{
			get { return this; }
		}

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
