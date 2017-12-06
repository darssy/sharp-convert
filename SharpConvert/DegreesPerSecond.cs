using System;

namespace MmiSoft.Core.Math.Units
{
	public class DegreesPerSecond : AngularVelocity
	{
		public DegreesPerSecond() : this(0d)
		{ }

		public DegreesPerSecond(double unitValue)
			: base(unitValue, new Degrees().ToSiFactor / new Seconds().ToSiFactor)
		{
		}

		public DegreesPerSecond(decimal unitValue)
			: this((double)unitValue)
		{
		}

		public DegreesPerSecond(int unitValue)
			: this((double)unitValue)
		{
		}

		protected override AngleUnit GetAngleUnit()
		{
			return new Degrees();
		}

		protected override TimeUnit GetTimeUnit()
		{
			return new Seconds();
		}

		public static Degrees operator *(DegreesPerSecond omega, TimeUnit t)
		{
			return ((AngularVelocity)omega * t).To<Degrees>();
		}

		public static Degrees operator *(DegreesPerSecond omega, TimeSpan t)
		{
			return omega * new Seconds(t);
		}

		public static Seconds operator /(AngleUnit a, DegreesPerSecond omega)
		{
			return (a / (AngularVelocity)omega).To<Seconds>();
		}
	}
}
