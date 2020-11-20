using System;

namespace MmiSoft.Core.Math.Units
{
	[Serializable]
	public class Meters : LengthUnit
	{
		public Meters()
			: this(0)
		{ }
		public Meters(double meters)
			:base (meters, Conversion.Meter)
		{ }

		public static Meters operator -(Meters x, LengthUnit y)
		{
			return Subtract<Meters>(x, y);
		}

		public static Meters operator +(Meters x, LengthUnit y)
		{
			return Add<Meters>(x, y);
		}
	}
}
