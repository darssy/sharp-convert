using System;

namespace MmiSoft.Core.Math.Units
{
	[Serializable]
	public class Feet : LengthUnit
	{
		public Feet()
			: this(0)
		{ }

		public Feet(double unitValue)
			: base(unitValue, 0.3048)
		{ }

		public static Feet operator -(Feet x, Feet y)
		{
			return new Feet(System.Math.Abs(x.unitValue - y.unitValue));
		}

		public static Feet operator +(Feet x, Feet y)
		{
			return new Feet(x.unitValue + y.unitValue);
		}

		public static Feet operator -(Feet x, LengthUnit y)
		{
			if (y is Feet feet) return x - feet;
			return Subtract<Feet>(x, y);
		}

		public static Feet operator -(LengthUnit x, Feet y)
		{
			if (x is Feet feet) return feet - y;
			return Subtract<Feet>(x, y);
		}

		public static Feet operator +(Feet x, LengthUnit y)
		{
			if (y is Feet feet) return x + feet;
			return Add<Feet>(x, y);
		}

		public static Feet operator +(LengthUnit x, Feet y)
		{
			if (x is Feet feet) return feet + y;
			return Add<Feet>(x, y);
		}

		public override string Symbol => "ft";
	}
}
