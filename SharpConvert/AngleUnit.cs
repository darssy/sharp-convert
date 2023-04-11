﻿using System;
using System.ComponentModel;
using MmiSoft.Core.Math.Units.ComponentModel;

namespace MmiSoft.Core.Math.Units
{
	[Serializable]
	[TypeConverter(typeof(UnitsConverter))]
	public abstract class AngleUnit : UnitBase, IComparable<AngleUnit>
	{
		public static readonly AngleUnit Zero = 0.Radians();

		protected AngleUnit(double unitValue, Conversion conversion)
			: base(unitValue, conversion)
		{
		}

		public A To<A>() where A : AngleUnit
		{
			return ConvertTo<A, AngleUnit>(this);
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

		[Obsolete("Superseded by operator overloading; will be removed in 2.0")]
		public static A Add<A>(AngleUnit x, AngleUnit y) where A : AngleUnit, new()
		{
			A dif = new A();
			dif.FromSi(x.ToSi() + y.ToSi());
			return dif;
		}

		[Obsolete("Superseded by operator overloading; will be removed in 2.0")]
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
	}
}
