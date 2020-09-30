using System;

namespace MmiSoft.Core.Math.Units
{
	[Serializable]
	public abstract class SpeedUnit : UnitBase, IComparable<SpeedUnit>
	{

		protected SpeedUnit(double speed, double siFactor)
			: base(speed, siFactor)
		{
		}

		protected abstract LengthUnit GetLengthUnit();

		protected abstract TimeUnit GetTimeUnit();

		public U To<U>() where U : SpeedUnit, new()
		{
			return ConvertTo<U, SpeedUnit>(this);
		}

		protected bool Equals(SpeedUnit other)
		{
			return EqualsImpl(other);
		}

		public int CompareTo(SpeedUnit other)
		{
			return CompareToImpl(other);
		}

		public override bool Equals(object obj)
		{
			var other = obj as SpeedUnit;
			if (ReferenceEquals(null, other)) return false;
			if (ReferenceEquals(this, other)) return true;
			return Equals(other);
		}

		public override int GetHashCode()
		{
			return ToSi().GetHashCode() * 1000000009;
		}

		public static bool operator ==(SpeedUnit left, SpeedUnit right)
		{
			return Equals(left, right);
		}

		public static bool operator !=(SpeedUnit left, SpeedUnit right)
		{
			return !Equals(left, right);
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

		public static SpeedUnit operator *(SpeedUnit u, double factor)
		{
			SpeedUnit copy = (SpeedUnit)u.MemberwiseClone();
			copy.unitValue *= factor;
			return copy;
		}

		public static SpeedUnit operator /(SpeedUnit u, double factor)
		{
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
			TimeUnit timeToTravel = u.GetTimeUnit();
			timeToTravel.FromSi(System.Math.Abs(t));
			return timeToTravel;
		}

		public static AngularVelocity operator /(SpeedUnit u, LengthUnit s)
		{
			double aV = u.ToSi() / s.ToSi();
			AngularVelocity angular = new RadiansPerSecond(aV);
			angular.FromSi(aV);
			return angular;
		}

		public static LengthUnit operator /(SpeedUnit u, AngularVelocity s)
		{
			double r = u.ToSi() / s.ToSi();
			return r.Meters();
		}

		public static SpeedUnit operator -(SpeedUnit x)
		{
			SpeedUnit cloned = (SpeedUnit) x.MemberwiseClone();
			cloned.unitValue *= -1;
			return cloned;
		}

		public static U Get<U>(LengthUnit s, TimeUnit t)
			where U : SpeedUnit, new()
		{
			double u = s.ToSi() / t.ToSi();
			U speed = new U();
			speed.FromSi(u);
			return speed;
		}
	}
}
