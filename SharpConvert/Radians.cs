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

		public static Radians operator -(Radians x, Radians y)
		{
			return new Radians(x.unitValue - y.unitValue);
		}

		public static Radians operator +(Radians x, Radians y)
		{
			return new Radians(x.unitValue + y.unitValue);
		}

		public static Radians operator -(Radians x, AngleUnit y)
		{
			return new Radians(x.unitValue - y.ToSi());
		}

		public static Radians operator +(Radians x, AngleUnit y)
		{
			return new Radians(x.unitValue + y.ToSi());
		}

	}
}
