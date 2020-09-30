using System;

namespace MmiSoft.Core.Math.Units
{
	public abstract class MassUnit : UnitBase, IComparable<MassUnit>
	{
		protected MassUnit(double mass, double toSiFactor) : base(mass, toSiFactor)
		{
			if (mass < 0)
			{
				throw new ArgumentOutOfRangeException($"Mass should be positive value: {mass}");
			}
			if (ToSiFactor <= 0)
			{
				throw new ArgumentOutOfRangeException($"SI Factor should be positive value: {ToSiFactor}");
			}
		}

		public static bool operator ==(MassUnit left, MassUnit right)
		{
			return Equals(left, right);
		}

		public static bool operator !=(MassUnit left, MassUnit right)
		{
			return !Equals(left, right);
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

		public static M Add<M>(MassUnit x, MassUnit y) where M : MassUnit, new()
		{
			M dif = new M();
			dif.FromSi(x.ToSi() + y.ToSi());
			return dif;
		}

		public static M Subtract<M>(MassUnit x, MassUnit y) where M : MassUnit, new()
		{
			M dif = new M();
			dif.FromSi(System.Math.Abs(x.ToSi() - y.ToSi()));
			return dif;
		}

		public int CompareTo(MassUnit other)
		{
			return CompareToImpl(other);
		}

		public override bool Equals(object obj)
		{
			if (!(obj is MassUnit other)) return false;
			if (ReferenceEquals(this, other)) return true;
			return EqualsImpl(other);
		}

		public override int GetHashCode()
		{
			return ToSi().GetHashCode() * 17;
		}
	}
}
