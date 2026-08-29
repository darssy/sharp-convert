using System;

namespace MmiSoft.Core.Math.Units
{
	[Serializable]
	public class Meters : LengthUnit
	{
		public new static readonly Meters Zero = 0.Meters();

		public Meters()
			: this(0)
		{ }
		public Meters(double meters)
			:base (meters, Conversion.Meter)
		{ }

		public static Meters operator -(Meters x, Meters y)
		{
			return new Meters(System.Math.Abs(x.unitValue - y.unitValue));
		}

		public static Meters operator +(Meters x, Meters y)
		{
			return new Meters(x.unitValue + y.unitValue);
		}

		public static Meters operator -(Meters x, LengthUnit y)
		{
			return new Meters(System.Math.Abs(x.unitValue - y.ToSi()));
		}

		public static Meters operator +(Meters x, LengthUnit y)
		{
			return new Meters(x.unitValue + y.ToSi());
		}

		public static MetersPerSecond operator /(Meters x, Seconds y)
		{
			return y.UnitValue == 0 ? null : new MetersPerSecond(x.unitValue / y.UnitValue);
		}
	}
}
