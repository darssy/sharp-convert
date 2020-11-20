using System;

namespace MmiSoft.Core.Math.Units
{
	[Serializable]
	public class Radians : AngleUnit
	{
		public Radians() : this(0)
		{ }

		public Radians(double unitValue)
			: base(unitValue, Conversion.Radian)
		{
		}

		public static Radians operator -(Radians x)
		{
			return new Radians(-x.unitValue);
		}

		public static Radians operator -(Radians x, AngleUnit y)
		{
			return Subtract<Radians>(x, y);
		}

		public static Radians operator +(Radians x, AngleUnit y)
		{
			return Add<Radians>(x, y);
		}

	}
}
