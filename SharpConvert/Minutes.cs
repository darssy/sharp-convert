using System;

namespace MmiSoft.Core.Math.Units
{
	[Serializable]
	public sealed class Minutes : TimeUnit
	{
		public Minutes()
			: this(0)
		{ }

		public Minutes(double minutes)
			: base(minutes, Conversion.Minute)
		{ }

		public Minutes(TimeSpan time)
			: this(time.TotalMinutes)
		{ }

		public static implicit operator Minutes(TimeSpan t)
		{
			return new Minutes(t);
		}

		public static Minutes operator *(Minutes t, double f)
		{
			return new Minutes(t.unitValue * System.Math.Abs(f));
		}

		public static Minutes operator *(double f, Minutes t)
		{
			return t * f;
		}

		public static Minutes operator /(Minutes t, double f)
		{
			return f == 0 ? null : new Minutes(t.unitValue / System.Math.Abs(f));
		}

		public static Minutes operator -(Minutes x, Minutes y)
		{
			return new Minutes(System.Math.Abs(x.unitValue - y.unitValue));
		}

		public static Minutes operator +(Minutes x, Minutes y)
		{
			return new Minutes(x.unitValue + y.unitValue);
		}

		public static Minutes operator -(Minutes x, TimeUnit y)
		{
			if (y is Minutes m) return x - m;
			return new Minutes(x.SubtractAbs(y));
		}

		public static Minutes operator +(Minutes x, TimeUnit y)
		{
			if (y is Minutes m) return x + m;
			return new Minutes(x.Add(y));
		}
	}
}
