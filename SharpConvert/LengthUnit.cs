using System;

namespace MmiSoft.Core.Math.Units
{
	[Serializable]
	public abstract class LengthUnit : UnitBase, IComparable<LengthUnit>
	{
		protected LengthUnit(double length, double toSiFactor)
			: base (length, toSiFactor)
		{
			if (length < 0)
			{
				throw new ArgumentOutOfRangeException("Length should be positive value: " + length);
			}
			if (ToSiFactor <= 0)
			{
				throw new ArgumentOutOfRangeException("SI Factor should be positive value: " + ToSiFactor);
			}
		}

		public L To<L>() where L : LengthUnit, new()
		{
			return ConvertTo<L, LengthUnit>(this);
		}

		public int CompareTo(LengthUnit other)
		{
			return ToSi().CompareTo(other.ToSi());
		}

		public override bool Equals(object obj)
		{
			var other = obj as LengthUnit;
			if (ReferenceEquals(null, other)) return false;
			if (ReferenceEquals(this, other)) return true;
			return EqualsImpl(other);
		}

		public override int GetHashCode()
		{
			return ToSi().GetHashCode() * 1000000007;
		}

		public static bool operator ==(LengthUnit left, LengthUnit right)
		{
			return Equals(left, right);
		}

		public static bool operator !=(LengthUnit left, LengthUnit right)
		{
			return !Equals(left, right);
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
			LengthUnit l = (LengthUnit) x.MemberwiseClone();
			l.FromSi(System.Math.Abs(x.ToSi() / System.Math.Abs(y)));
			return l;
		}

		public static LengthUnit operator /(LengthUnit x, float y)
		{
			LengthUnit l = (LengthUnit)x.MemberwiseClone();
			l.FromSi(System.Math.Abs(x.ToSi() / System.Math.Abs(y)));
			return l;
		}

		public static LengthUnit operator /(LengthUnit x, int y)
		{
			LengthUnit l = (LengthUnit)x.MemberwiseClone();
			l.FromSi(System.Math.Abs(x.ToSi() / System.Math.Abs(y)));
			return l;
		}

		[Obsolete("That's needed for angular velocity calculations")]
		public static LengthUnit operator /(LengthUnit x, AngleUnit y)
		{
			return new Meters(x.ToSi() / System.Math.Abs(y.ToSi()));
		}

		public static implicit operator float(LengthUnit x)
		{
			return (float)x.unitValue;
		}

		public static explicit operator int(LengthUnit x)
		{
			return (int)System.Math.Round(x.unitValue);
		}
	}
}
