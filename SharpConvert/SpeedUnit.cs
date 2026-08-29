using System;

namespace MmiSoft.Core.Math.Units
{
	[Serializable]
	public abstract class SpeedUnit : UnitBase, IComparable<SpeedUnit>
	{

		protected SpeedUnit(double speed, Conversion conversion)
			: base(speed, conversion)
		{
		}

		protected abstract LengthUnit GetLengthUnit();

		protected abstract TimeUnit GetTimeUnit();

		public U To<U>() where U : SpeedUnit
		{
			return ConvertTo<U, SpeedUnit>(this);
		}

		public int CompareTo(SpeedUnit other)
		{
			return CompareToImpl(other);
		}

		public static bool operator <(SpeedUnit x, SpeedUnit y)
		{
			return x.ToSi() < y.ToSi();
		}

		public static bool operator >(SpeedUnit x, SpeedUnit y)
		{
			return x.ToSi() > y.ToSi();
		}

		public static bool operator <=(SpeedUnit x, SpeedUnit y)
		{
			return x.ToSi() <= y.ToSi();
		}

		public static bool operator >=(SpeedUnit x, SpeedUnit y)
		{
			return x.ToSi() >= y.ToSi();
		}

		public static SpeedUnit operator -(SpeedUnit l, SpeedUnit r)
		{
			return new MetersPerSecond(l.ToSi() - r.ToSi());
		}

		public static SpeedUnit operator +(SpeedUnit l, SpeedUnit r)
		{
			return new MetersPerSecond(l.ToSi() + r.ToSi());
		}

		public static SpeedUnit operator *(SpeedUnit u, double factor)
		{
			SpeedUnit copy = (SpeedUnit)u.MemberwiseClone();
			copy.unitValue *= factor;
			return copy;
		}

		public static SpeedUnit operator *(double factor, SpeedUnit u)
		{
			return u * factor;
		}

		public static SpeedUnit operator /(SpeedUnit u, double factor)
		{
			if (factor == 0) return null;
			SpeedUnit copy = (SpeedUnit)u.MemberwiseClone();
			copy.unitValue /= factor;
			return copy;
		}

		public static SpeedUnit operator /(SpeedUnit u, float factor)
		{
			return u / (double) factor;
		}

		public static SpeedUnit operator /(SpeedUnit u, int factor)
		{
			return u / (double) factor;
		}

		public static double operator /(SpeedUnit x, SpeedUnit y)
		{
			return x.ToSi() / y.ToSi();
		}

		public static LengthUnit operator *(SpeedUnit u, TimeUnit t)
		{
			double s = u.ToSi() * t.ToSi();
			LengthUnit distanceTraveled = u.GetLengthUnit();
			distanceTraveled.FromSi(System.Math.Abs(s));
			return distanceTraveled;
		}

		public static LengthUnit operator *(TimeUnit t, SpeedUnit u)
		{
			return u * t;
		}

		public static LengthUnit operator *(SpeedUnit u, TimeSpan t)
		{
			return u * new Seconds(t);
		}

		public static LengthUnit operator *(TimeSpan t, SpeedUnit u)
		{
			return u * new Seconds(t);
		}

		public static AccelerationUnit operator /(SpeedUnit u, TimeUnit t)
		{
			return t == TimeUnit.Zero ? null : new MetersPerSecondSquared(u.ToSi() / t.ToSi());
		}

		public static TimeUnit operator /(LengthUnit s, SpeedUnit u)
		{
			double t = s.ToSi() / u.ToSi();
			if (double.IsInfinity(t)) return null;
			TimeUnit timeToTravel = u.GetTimeUnit();
			timeToTravel.FromSi(System.Math.Abs(t));
			return timeToTravel;
		}

		public static AngularVelocity operator /(SpeedUnit u, LengthUnit s)
		{
			double aV = u.ToSi() / s.ToSi();
			if (double.IsInfinity(aV)) return null;
			AngularVelocity angular = new RadiansPerSecond(aV);
			angular.FromSi(aV);
			return angular;
		}

		public static LengthUnit operator /(SpeedUnit u, AngularVelocity s)
		{
			double r = u.ToSi() / s.ToSi();
			return double.IsInfinity(r) ? null : r.Meters();
		}

		public static SpeedUnit operator -(SpeedUnit x)
		{
			SpeedUnit cloned = (SpeedUnit) x.MemberwiseClone();
			cloned.unitValue *= -1;
			return cloned;
		}

		public static explicit operator double(SpeedUnit u)
		{
			return u.unitValue;
		}

		public static U Get<U>(LengthUnit s, TimeUnit t)
			where U : SpeedUnit
		{
			double u = s.ToSi() / t.ToSi();
			U speed = (U) ReflectionHelper.GetConstructor<U>().Invoke(0);
			speed.FromSi(u);
			return speed;
		}
	}
}
