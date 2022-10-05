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

		public static Kilometers operator -(Kilometers x, LengthUnit y)
		{
			return new Kilometers(x.SubtractAbs(y));
		}

		public static Kilometers operator +(Kilometers x, LengthUnit y)
		{
			return new Kilometers(x.Add(y));
		}
	}
}
