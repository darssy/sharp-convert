using System;

namespace MmiSoft.Core.Math.Units
{
	public abstract class AngularVelocity : UnitBase
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
	}
}
