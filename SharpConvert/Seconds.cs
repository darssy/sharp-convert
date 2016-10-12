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
			: base(seconds, 1)
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

		public static implicit operator Seconds(TimeSpan t)
		{
			return new Seconds(t);
		}
	}
}
