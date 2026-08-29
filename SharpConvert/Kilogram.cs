using System;

namespace MmiSoft.Core.Math.Units
{
	[Serializable]
	public class Kilogram : MassUnit
	{

		public Kilogram() : this(0){}

		public Kilogram(double mass) : base(mass, Conversion.Kilogram)
		{
		}

		public static Kilogram operator -(Kilogram x, Kilogram y)
		{
			return new Kilogram(System.Math.Abs(x.unitValue - y.unitValue));
		}

		public static Kilogram operator +(Kilogram x, Kilogram y)
		{
			return new Kilogram(x.unitValue + y.unitValue);
		}

		public static Kilogram operator -(Kilogram x, MassUnit y)
		{
			if (y is Kilogram k) return x - k;
			return new Kilogram(x.unitValue - y.ToSi());
		}

		public static Kilogram operator +(Kilogram x, MassUnit y)
		{
			if (y is Kilogram k) return x + k;
			return new Kilogram(x.unitValue + y.ToSi());
		}

		public static Kilogram operator *(Kilogram x, double f)
		{
			return new Kilogram(x.unitValue * System.Math.Abs(f));
		}

		public static Kilogram operator *(double f, Kilogram x)
		{
			return new Kilogram(x.unitValue * System.Math.Abs(f));
		}

		public static Kilogram operator /(Kilogram x, double f)
		{
			return f == 0 ? null : new Kilogram(x.unitValue / System.Math.Abs(f));
		}
	}
}
