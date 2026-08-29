using System;

namespace MmiSoft.Core.Math.Units
{
	[Serializable]
	public class Kilometers : LengthUnit
	{
		public new static readonly Kilometers Zero = 0.Kilometers();

		public Kilometers()
			: this(0)
		{ }

		public Kilometers(double km)
			: base(km, Conversion.Kilometer)
		{ }

		public static Kilometers operator -(Kilometers x, Kilometers y)
		{
			return new Kilometers(System.Math.Abs(x.unitValue - y.unitValue));
		}

		public static Kilometers operator +(Kilometers x, Kilometers y)
		{
			return new Kilometers(x.unitValue + y.unitValue);
		}

		public static Kilometers operator -(Kilometers x, LengthUnit y)
		{
			if (y is Kilometers km) return x - km;
			return new Kilometers(x.SubtractAbs(y));
		}

		public static Kilometers operator +(Kilometers x, LengthUnit y)
		{
			if (y is Kilometers km) return x + km;
			return new Kilometers(x.Add(y));
		}
	}
}
