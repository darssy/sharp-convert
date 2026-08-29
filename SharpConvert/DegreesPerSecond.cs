using System;

namespace MmiSoft.Core.Math.Units
{
	[Serializable]
	public class DegreesPerSecond : AngularVelocity
	{
		public DegreesPerSecond() : this(0d)
		{ }

		public DegreesPerSecond(double unitValue)
			: base(unitValue, Conversion.DegreePerSecond)
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

		public static DegreesPerSecond operator -(DegreesPerSecond x)
		{
			return new DegreesPerSecond(-x.unitValue);
		}

		public static DegreesPerSecond operator -(DegreesPerSecond l, DegreesPerSecond r)
		{
			return new DegreesPerSecond(l.unitValue - r.unitValue);
		}

		public static DegreesPerSecond operator -(DegreesPerSecond l, AngularVelocity r)
		{
			if (r is DegreesPerSecond dps) return l - dps;
			return new DegreesPerSecond(l.Subtract(r));
		}

		public static DegreesPerSecond operator +(DegreesPerSecond l, DegreesPerSecond r)
		{
			return new DegreesPerSecond(l.unitValue + r.unitValue);
		}

		public static DegreesPerSecond operator +(DegreesPerSecond l, AngularVelocity r)
		{
			if (r is DegreesPerSecond dps) return l + dps;
			return new DegreesPerSecond(l.Add(r));
		}

		public static DegreesPerSecond operator *(DegreesPerSecond omega, double f)
		{
			return new DegreesPerSecond(omega.unitValue * f);
		}

		public static DegreesPerSecond operator *(double f, DegreesPerSecond omega)
		{
			return new DegreesPerSecond(omega.unitValue * f);
		}

		public static DegreesPerSecond operator /(DegreesPerSecond omega, double f)
		{
			return f == 0 ? null : new DegreesPerSecond(omega.unitValue / f);
		}
	}
}
