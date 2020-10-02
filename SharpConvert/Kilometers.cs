using System;

namespace MmiSoft.Core.Math.Units
{
	[Serializable]
	public class Kilometers : LengthUnit
	{
		public Kilometers()
			: this(0)
		{ }

		public Kilometers(double km)
			: base(km, Conversion.Kilometer)
		{ }

		public static Kilometers operator -(Kilometers x, LengthUnit y)
		{
			return Subtract<Kilometers>(x, y);
		}

		public static Kilometers operator +(Kilometers x, LengthUnit y)
		{
			return Add<Kilometers>(x, y);
		}

		public override string Symbol => "Km";
	}
}
