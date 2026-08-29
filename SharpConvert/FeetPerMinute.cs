using System;

namespace MmiSoft.Core.Math.Units
{
	[Serializable]
	public class FeetPerMinute : SpeedUnit
	{
		public static readonly FeetPerMinute Zero = 0.FeetPerMinute();

		public FeetPerMinute()
			: this(0)
		{
		}

		public FeetPerMinute(double fpm)
			: base(fpm, Conversion.FootPerMinute)
		{
		}

		protected override LengthUnit GetLengthUnit()
		{
			return new Feet();
		}

		protected override TimeUnit GetTimeUnit()
		{
			return new Minutes();
		}

		public static FeetPerMinute operator *(FeetPerMinute u, double factor)
		{
			return new FeetPerMinute(u.unitValue * factor);
		}

		public static FeetPerMinute operator *(double factor, FeetPerMinute u)
		{
			return new FeetPerMinute(u.unitValue * factor);
		}

		public static FeetPerMinute operator /(FeetPerMinute u, double factor)
		{
			return factor == 0 ? null : new FeetPerMinute(u.unitValue / factor);
		}

		public static FeetPerMinutePerSecond operator /(FeetPerMinute u, Seconds t)
		{
			return t.UnitValue == 0 ? null : new FeetPerMinutePerSecond(u.unitValue / t.UnitValue);
		}

		public static Feet operator *(FeetPerMinute u, Minutes t)
		{
			return new Feet(System.Math.Abs(u.unitValue * t.UnitValue));
		}

		public static FeetPerMinute operator -(FeetPerMinute x)
		{
			return new FeetPerMinute(-x.unitValue);
		}

		public static FeetPerMinute operator -(FeetPerMinute l, SpeedUnit r)
		{
			if (r is FeetPerMinute fpm) return l - fpm;
			return new FeetPerMinute(l.Subtract(r));
		}

		public static FeetPerMinute operator -(FeetPerMinute l, FeetPerMinute r)
		{
			return new FeetPerMinute(l.unitValue - r.unitValue);
		}

		public static FeetPerMinute operator +(FeetPerMinute l, SpeedUnit r)
		{
			if (r is FeetPerMinute fpm) return l + fpm;
			return new FeetPerMinute(l.Add(r));
		}

		public static FeetPerMinute operator +(FeetPerMinute l, FeetPerMinute r)
		{
			return new FeetPerMinute(l.unitValue + r.unitValue);
		}
	}
}
