using System;

namespace MmiSoft.Core.Math.Units
{
	[Serializable]
	public class Seconds : TimeUnit
	{
		public Seconds()
			: this(0)
		{ }

		public Seconds(double seconds)
			: base(seconds, Conversion.Second)
		{ }

		public Seconds(TimeSpan time)
			:this(time.TotalSeconds)
		{ }

		public static Seconds operator *(Seconds t, double f)
		{
			return new Seconds(t.ToSi() * f);
		}

		public static Seconds operator *(double f, Seconds t)
		{
			return new Seconds(t.ToSi() * f);
		}

		public static Seconds operator /(Seconds t, double f)
		{
			return f == 0 ? null : new Seconds(t.unitValue / System.Math.Abs(f));
		}

		public static Seconds operator -(Seconds x, Seconds y)
		{
			return new Seconds(System.Math.Abs(x.unitValue - y.unitValue));
		}

		public static Seconds operator +(Seconds x, Seconds y)
		{
			return new Seconds(x.unitValue + y.unitValue);
		}

		public static Seconds operator -(Seconds x, TimeUnit y)
		{
			if (y is Seconds s) return x - s;
			return new Seconds(System.Math.Abs(x.unitValue - y.ToSi()));
		}

		public static Seconds operator +(Seconds x, TimeUnit y)
		{
			if (y is Seconds s) return x + s;
			return new Seconds(x.unitValue + y.ToSi());
		}
		
		public static implicit operator Seconds(TimeSpan t)
		{
			return new Seconds(t);
		}

	}
}
