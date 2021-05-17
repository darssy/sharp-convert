using System;

namespace MmiSoft.Core.Math.Units
{
	[Serializable]
	public abstract class
		SpeedUnit : UnitBase, IComparable<SpeedUnit>
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

		public static SpeedUnit operator /(SpeedUnit u, double factor)
		{
			if (factor == 0) return null;
			SpeedUnit copy = (SpeedUnit)u.MemberwiseClone();
			copy.unitValue /= factor;
			return copy;
		}

		public static LengthUnit operator *(SpeedUnit u, TimeUnit t)
		{
			double s = u.ToSi() * t.ToSi();
			LengthUnit distanceTraveled = u.GetLengthUnit();
			distanceTraveled.FromSi(System.Math.Abs(s));
			return distanceTraveled;
		}

		public static LengthUnit operator *(SpeedUnit u, TimeSpan t)
		{
			return u * new Seconds(t);
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
