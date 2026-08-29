using System;

namespace MmiSoft.Core.Math.Units
{
	[Serializable]
	public abstract class MassUnit : UnitBase, IComparable<MassUnit>
	{
		protected MassUnit(double mass, Conversion conversion) : base(mass, conversion)
		{
			if (mass < 0)
			{
				throw new ArgumentOutOfRangeException($"Mass should be positive value: {mass}");
			}
		}

		public M To<M>() where M : MassUnit
		{
			return ConvertTo<M, MassUnit>(this);
		}

		public static bool operator <(MassUnit x, MassUnit y)
		{
			return x.ToSi() < y.ToSi();
		}

		public static bool operator >(MassUnit x, MassUnit y)
		{
			return x.ToSi() > y.ToSi();
		}

		public static bool operator <=(MassUnit x, MassUnit y)
		{
			return x.ToSi() <= y.ToSi();
		}

		public static bool operator >=(MassUnit x, MassUnit y)
		{
			return x.ToSi() >= y.ToSi();
		}

		[Obsolete("Superseded by operator overloading; will be removed in 2.0")]
		public static M Add<M>(MassUnit x, MassUnit y) where M : MassUnit, new()
		{
			M dif = new M();
			dif.FromSi(x.ToSi() + y.ToSi());
			return dif;
		}

		[Obsolete("Superseded by operator overloading; will be removed in 2.0")]
		public static M Subtract<M>(MassUnit x, MassUnit y) where M : MassUnit, new()
		{
			M dif = new M();
			dif.FromSi(System.Math.Abs(x.ToSi() - y.ToSi()));
			return dif;
		}

		/// <summary>
		/// Mass can't be negative, so - as with every other mass operation - the absolute value of the difference
		/// is returned.
		/// </summary>
		public static MassUnit operator -(MassUnit l, MassUnit r)
		{
			return new Kilogram(System.Math.Abs(l.ToSi() - r.ToSi()));
		}

		public static MassUnit operator +(MassUnit l, MassUnit r)
		{
			return new Kilogram(l.ToSi() + r.ToSi());
		}

		public static MassUnit operator *(MassUnit m, double factor)
		{
			MassUnit copy = (MassUnit) m.MemberwiseClone();
			copy.unitValue *= System.Math.Abs(factor);
			return copy;
		}

		public static MassUnit operator *(double factor, MassUnit m)
		{
			return m * factor;
		}

		public static MassUnit operator /(MassUnit m, double divisor)
		{
			if (divisor == 0) return null;
			MassUnit copy = (MassUnit) m.MemberwiseClone();
			copy.unitValue /= System.Math.Abs(divisor);
			return copy;
		}

		public static MassUnit operator /(MassUnit m, float divisor)
		{
			return m / (double) divisor;
		}

		public static MassUnit operator /(MassUnit m, int divisor)
		{
			return m / (double) divisor;
		}

		public static double operator /(MassUnit x, MassUnit y)
		{
			return x.ToSi() / y.ToSi();
		}

		public static explicit operator double(MassUnit m)
		{
			return m.unitValue;
		}

		public int CompareTo(MassUnit other)
		{
			return CompareToImpl(other);
		}
	}
}
