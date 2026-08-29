using System;

namespace MmiSoft.Core.Math.Units
{
	[Serializable]
	public class RadiansPerSecond : AngularVelocity
	{
		public RadiansPerSecond() : this(0) { }

		public RadiansPerSecond(double unitValue)
			: base(unitValue, Conversion.RadianPerSecond)
		{
		}

		protected override AngleUnit GetAngleUnit()
		{
			return new Radians();
		}

		protected override TimeUnit GetTimeUnit()
		{
			return new Seconds();
		}

		public static Radians operator *(RadiansPerSecond omega, TimeUnit t)
		{
			return ((AngularVelocity)omega * t).To<Radians>();
		}

		public static Radians operator *(RadiansPerSecond omega, TimeSpan t)
		{
			return omega * new Seconds(t);
		}

		public static Seconds operator /(AngleUnit a, RadiansPerSecond omega)
		{
			return (a / (AngularVelocity)omega).To<Seconds>();
		}

		public static RadiansPerSecond operator -(RadiansPerSecond x)
		{
			return new RadiansPerSecond(-x.unitValue);
		}

		public static RadiansPerSecond operator -(RadiansPerSecond l, RadiansPerSecond r)
		{
			return new RadiansPerSecond(l.unitValue - r.unitValue);
		}

		public static RadiansPerSecond operator -(RadiansPerSecond l, AngularVelocity r)
		{
			if (r is RadiansPerSecond rps) return l - rps;
			return new RadiansPerSecond(l.Subtract(r));
		}

		public static RadiansPerSecond operator +(RadiansPerSecond l, RadiansPerSecond r)
		{
			return new RadiansPerSecond(l.unitValue + r.unitValue);
		}

		public static RadiansPerSecond operator +(RadiansPerSecond l, AngularVelocity r)
		{
			if (r is RadiansPerSecond rps) return l + rps;
			return new RadiansPerSecond(l.Add(r));
		}

		public static RadiansPerSecond operator *(RadiansPerSecond omega, double f)
		{
			return new RadiansPerSecond(omega.unitValue * f);
		}

		public static RadiansPerSecond operator *(double f, RadiansPerSecond omega)
		{
			return new RadiansPerSecond(omega.unitValue * f);
		}

		public static RadiansPerSecond operator /(RadiansPerSecond omega, double f)
		{
			return f == 0 ? null : new RadiansPerSecond(omega.unitValue / f);
		}

	}
}
