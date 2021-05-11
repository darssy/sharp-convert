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

		public int CompareTo(MassUnit other)
		{
			return CompareToImpl(other);
		}
	}
}
