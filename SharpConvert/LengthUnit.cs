using System;

namespace MmiSoft.Core.Math.Units
{
	[Serializable]
	public abstract class LengthUnit : UnitBase, IComparable<LengthUnit>
	{
		public static readonly LengthUnit Zero = 0.Meters();

		protected LengthUnit(double length, Conversion conversion)
			: base (length, conversion)
		{
			if (length < 0)
			{
				throw new ArgumentOutOfRangeException("Length should be positive value: " + length);
			}
		}

		public L To<L>() where L : LengthUnit, new()
		{
			return ConvertTo<L, LengthUnit>(this);
		}

		public int CompareTo(LengthUnit other)
		{
			return CompareToImpl(other);
		}

		public static bool operator <(LengthUnit x, LengthUnit y)
		{
			return x.ToSi() < y.ToSi();
		}

		public static bool operator >(LengthUnit x, LengthUnit y)
		{
			return x.ToSi() > y.ToSi();
		}

		public static bool operator <=(LengthUnit x, LengthUnit y)
		{
			return x.ToSi() <= y.ToSi();
		}

		public static bool operator >=(LengthUnit x, LengthUnit y)
		{
			return x.ToSi() >= y.ToSi();
		}

		public static L Add<L>(LengthUnit x, LengthUnit y) where L : LengthUnit, new()
		{
			L dif = new L();
			dif.FromSi(x.ToSi() + y.ToSi());
			return dif;
		}

		public static L Subtract<L>(LengthUnit x, LengthUnit y) where L : LengthUnit, new()
		{
			L dif = new L();
			dif.FromSi(System.Math.Abs(x.ToSi() - y.ToSi()));
			return dif;
		}

		public static LengthUnit operator -(LengthUnit l, LengthUnit r)
		{
			return new Meters(System.Math.Abs(l.ToSi() - r.ToSi()));
		}

		public static LengthUnit operator +(LengthUnit l, LengthUnit r)
		{
			return new Meters(l.ToSi() + r.ToSi());
		}

		public static LengthUnit operator *(LengthUnit t, double f)
		{
			LengthUnit copy = (LengthUnit)t.MemberwiseClone();
			copy.unitValue *= System.Math.Abs(f);
			return copy;
		}

		public static LengthUnit operator *(double f, LengthUnit t)
		{
			LengthUnit copy = (LengthUnit)t.MemberwiseClone();
			copy.unitValue *= System.Math.Abs(f);
			return copy;
		}

		public static double operator /(LengthUnit x, LengthUnit y)
		{
			return x.ToSi() / y.ToSi();
		}

		public static LengthUnit operator /(LengthUnit x, double y)
		{
			if (y == 0) return null;
			LengthUnit l = (LengthUnit) x.MemberwiseClone();
			double result = x.ToSi() / System.Math.Abs(y);
			l.FromSi(System.Math.Abs(result));
			return l;
		}

		public static LengthUnit operator /(LengthUnit x, float y)
		{
			return x / (double) y;
		}

		public static LengthUnit operator /(LengthUnit x, int y)
		{
			return x / (double) y;
		}

		[Obsolete("That's needed for angular velocity calculations")]
		public static LengthUnit operator /(LengthUnit x, AngleUnit y)
		{
			double meters = x.ToSi() / System.Math.Abs(y.ToSi());
			return double.IsInfinity(meters) ? null : new Meters(meters);
		}

		public static implicit operator double(LengthUnit x)
		{
			return x.unitValue;
		}

		public static explicit operator float(LengthUnit x)
		{
			return (float)x.unitValue;
		}

		public static explicit operator int(LengthUnit x)
		{
			return (int)System.Math.Round(x.unitValue);
		}

		//Restored min and max, this time only for length
		public static T Max<T>(T u1, T u2) where T : LengthUnit
		{
			return u1.ToSi() > u2.ToSi() ? u1 : u2;
		}

		public static T Min<T>(T u1, T u2) where T : LengthUnit
		{
			return u1.ToSi() < u2.ToSi() ? u1 : u2;
		}
	}
}
