
namespace MmiSoft.Core.Math.Units
{
	using System;

	[Serializable]
	public abstract class AngularVelocity : UnitBase, IComparable<AngularVelocity>
	{
		protected AngularVelocity(double unitValue, Conversion conversion)
			: base(unitValue, conversion)
		{
		}

		protected abstract AngleUnit GetAngleUnit();

		protected abstract TimeUnit GetTimeUnit();

		public U To<U>()
			where U : AngularVelocity
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
			return DivideByTimeImpl(omega, t.ToSi());
		}

		public static AngleUnit operator *(AngularVelocity omega, TimeSpan t)
		{
			return DivideByTimeImpl(omega, t.TotalSeconds);
		}

		private static AngleUnit DivideByTimeImpl(AngularVelocity omega, double tInSeconds)
		{
			double s = omega.ToSi() * tInSeconds;
			AngleUnit distanceTraveled = omega.GetAngleUnit();
			distanceTraveled.FromSi(Math.Abs(s));
			return distanceTraveled;
		}

		public static TimeUnit operator /(AngleUnit a, AngularVelocity omega)
		{
			double t = a.ToSi() / omega.ToSi();
			TimeUnit timeToTravel = omega.GetTimeUnit();
			timeToTravel.FromSi(Math.Abs(t));
			return timeToTravel;
		}

		public static U Get<U>(AngleUnit s, TimeUnit t)
			where U : AngularVelocity
		{
			double u = s.ToSi() / t.ToSi();
			U speed = (U) ReflectionHelper.GetConstructor<U>().Invoke(0);
			speed.FromSi(u);
			return speed;
		}

		public int CompareTo(AngularVelocity other)
		{
			return CompareToImpl(other);
		}
	}
}
