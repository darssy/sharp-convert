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
			: base(unitValue, Conversion.Foot)
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

		public static Feet operator +(Feet x, LengthUnit y)
		{
			if (y is Feet feet) return x + feet;
			return Add<Feet>(x, y);
		}

		public static FeetPerMinute operator /(Feet x, Minutes y)
		{
			return y.UnitValue == 0 ? null : new FeetPerMinute(x.unitValue / y.UnitValue);
		}
	}
}
