using System;

namespace MmiSoft.Core.Math.Units
{
	[Serializable]
	public abstract class AngleUnit : UnitBase, IComparable<AngleUnit>
	{
		public static readonly AngleUnit Zero = 0.Radians();

		protected AngleUnit(double unitValue, Conversion conversion)
			: base(unitValue, conversion)
		{
		}

		public A To<A>() where A : AngleUnit, new()
		{
			return ConvertTo<A, AngleUnit>(this);
		}

		public override bool Equals(object obj)
		{
			var other = obj as AngleUnit;
			if (ReferenceEquals(null, other)) return false;
			if (ReferenceEquals(this, other)) return true;
			return EqualsImpl(other);
		}

		public override int GetHashCode()
		{
			return ToSi().GetHashCode() * 1000000021;
		}

		public static bool operator ==(AngleUnit left, AngleUnit right)
		{
			return Equals(left, right);
		}

		public static bool operator !=(AngleUnit left, AngleUnit right)
		{
			return !Equals(left, right);
		}

		public static bool operator <(AngleUnit x, AngleUnit y)
		{
			return x.ToSi() < y.ToSi();
		}

		public static bool operator >(AngleUnit x, AngleUnit y)
		{
			return x.ToSi() > y.ToSi();
		}

		public static bool operator <=(AngleUnit x, AngleUnit y)
		{
			return x.ToSi() <= y.ToSi();
		}

		public static bool operator >=(AngleUnit x, AngleUnit y)
		{
			return x.ToSi() >= y.ToSi();
		}

		public static A Add<A>(AngleUnit x, AngleUnit y) where A : AngleUnit, new()
		{
			A dif = new A();
			dif.FromSi(x.ToSi() + y.ToSi());
			return dif;
		}

		public static A Subtract<A>(AngleUnit x, AngleUnit y) where A : AngleUnit, new()
		{
			A dif = new A();
			dif.FromSi(x.ToSi() - y.ToSi());
			return dif;
		}

		public static AngleUnit operator -(AngleUnit l, AngleUnit r)
		{
			return new Radians(l.ToSi() - r.ToSi());
		}

		public static AngleUnit operator +(AngleUnit l, AngleUnit r)
		{
			return new Radians(l.ToSi() + r.ToSi());
		}

		public static AngleUnit operator *(AngleUnit t, double f)
		{
			return f * t;
		}

		public static AngleUnit operator *(double factor, AngleUnit t)
		{
			AngleUnit copy = (AngleUnit)t.MemberwiseClone();
			copy.unitValue *= factor;
			return copy;
		}

		public static AngleUnit operator /(AngleUnit x, int y)
		{
			return x / (double) y;
		}

		public static AngleUnit operator /(AngleUnit x, float y)
		{
			return x / (double) y;
		}

		public static AngleUnit operator /(AngleUnit x, double y)
		{
			if (y == 0) return null;
			AngleUnit a = (AngleUnit) x.MemberwiseClone();
			a.FromSi(x.ToSi() / y);
			return a;
		}

		public double Sin()
		{
			return System.Math.Sin(ToSi());
		}

		public double Cos()
		{
			return System.Math.Cos(ToSi());
		}

		public double Tan()
		{
			return System.Math.Tan(ToSi());
		}

		public bool IsNegative => unitValue < 0;

		public int CompareTo(AngleUnit other)
		{
			return CompareToImpl(other);
		}

		public override string ToString() => $"{unitValue} {GetType().Name}";
	}
}
