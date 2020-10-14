using System;

namespace MmiSoft.Core.Math.Units
{
	public abstract class AngularVelocity : UnitBase, IComparable<AngularVelocity>
	{
		protected AngularVelocity(double unitValue, Conversion conversion)
			: base(unitValue, conversion)
		{
		}

		protected abstract AngleUnit GetAngleUnit();

		protected abstract TimeUnit GetTimeUnit();

		public U To<U>()
			where U : AngularVelocity, new()
		{
			return ConvertTo<U, AngularVelocity>(this);
		}

		public static bool operator <(AngularVelocity x, AngularVelocity y)
		{
			return x.ToSi() < y.ToSi();
		}

		public static bool operator >(AngularVelocity x, AngularVelocity y)
		{
			return x.ToSi() > y.ToSi();
		}

		public static bool operator <=(AngularVelocity x, AngularVelocity y)
		{
			return x.ToSi() <= y.ToSi();
		}

		public static bool operator >=(AngularVelocity x, AngularVelocity y)
		{
			return x.ToSi() >= y.ToSi();
		}

		public static AngularVelocity operator -(AngularVelocity l, AngularVelocity r)
		{
			return new RadiansPerSecond(l.ToSi() - r.ToSi());
		}

		public static AngularVelocity operator +(AngularVelocity l, AngularVelocity r)
		{
			return new RadiansPerSecond(l.ToSi() + r.ToSi());
		}

		public static AngleUnit operator *(AngularVelocity omega, TimeUnit t)
		{
			double s = omega.ToSi() * t.ToSi();
			AngleUnit distanceTraveled = omega.GetAngleUnit();
			distanceTraveled.FromSi(s);
			return distanceTraveled;
		}

		public static AngleUnit operator *(AngularVelocity omega, TimeSpan t)
		{
			return omega * new Seconds(t);
		}

		public static TimeUnit operator /(AngleUnit a, AngularVelocity omega)
		{
			double t = a.ToSi() / omega.ToSi();
			TimeUnit timeToTravel = omega.GetTimeUnit();
			timeToTravel.FromSi(t);
			return timeToTravel;
		}

		public static U Get<U>(AngleUnit s, TimeUnit t)
			where U : AngularVelocity, new()
		{
			double u = s.ToSi() / t.ToSi();
			U speed = new U();
			speed.FromSi(u);
			return speed;
		}

		public int CompareTo(AngularVelocity other)
		{
			return CompareToImpl(other);
		}
	}
}
