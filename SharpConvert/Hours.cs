using System;

namespace MmiSoft.Core.Math.Units
{
	[Serializable]
	public class Hours : TimeUnit
	{
		public Hours()
			: this(0)
		{ }

		public Hours(double hours)
			: base(hours, Conversion.Hour)
		{ }

		public Hours(TimeSpan time)
			:this(time.TotalHours)
		{ }

		public static Hours operator *(Hours t, double f)
		{
			return new Hours(t.unitValue * System.Math.Abs(f));
		}

		public static Hours operator *(double f, Hours t)
		{
			return t * f;
		}

		public static Hours operator /(Hours t, double f)
		{
			return f == 0 ? null : new Hours(t.unitValue / System.Math.Abs(f));
		}

		public static Hours operator -(Hours x, Hours y)
		{
			return new Hours(System.Math.Abs(x.unitValue - y.unitValue));
		}

		public static Hours operator +(Hours x, Hours y)
		{
			return new Hours(x.unitValue + y.unitValue);
		}

		public static Hours operator -(Hours x, TimeUnit y)
		{
			if (y is Hours h) return x - h;
			return new Hours(x.SubtractAbs(y));
		}

		public static Hours operator +(Hours x, TimeUnit y)
		{
			if (y is Hours h) return x + h;
			return new Hours(x.Add(y));
		}

		/// <summary>
		/// Explicit on purpose: <see cref="TimeUnit"/> converts implicitly to TimeSpan, so making this direction
		/// implicit too would let TimeSpan's own operators capture a unit operand and every mixed expression
		/// would become ambiguous (CS0034).
		/// </summary>
		public static explicit operator Hours(TimeSpan t)
		{
			return new Hours(t);
		}

	}
}
