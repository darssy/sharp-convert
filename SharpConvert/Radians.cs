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

		public static Radians operator *(Radians x, double f)
		{
			return new Radians(x.unitValue * f);
		}

		public static Radians operator *(double f, Radians x)
		{
			return new Radians(x.unitValue * f);
		}

		public static Radians operator /(Radians x, double y)
		{
			return y == 0 ? null : new Radians(x.unitValue / y);
		}

		public static RadiansPerSecond operator /(Radians x, Seconds t)
		{
			return t.UnitValue == 0 ? null : new RadiansPerSecond(x.unitValue / t.UnitValue);
		}

	}
}
