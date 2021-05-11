using System;

namespace MmiSoft.Core.Math.Units
{
	[Serializable]
	public class NauticalMiles : LengthUnit
	{
		public NauticalMiles()
			:this(0)
		{ }

		public NauticalMiles(double mile)
			: base(mile, Conversion.NauticalMile)
		{ }

		public static NauticalMiles operator -(NauticalMiles x, NauticalMiles y)
		{
			return new NauticalMiles(System.Math.Abs(x.unitValue - y.unitValue));
		}

		public static NauticalMiles operator +(NauticalMiles x, NauticalMiles y)
		{
			return new NauticalMiles(x.unitValue + y.unitValue);
		}

		public static NauticalMiles operator -(NauticalMiles x, LengthUnit y)
		{
			if (y is NauticalMiles miles) return x - miles;
			return new NauticalMiles(x.SubtractAbs(y));
		}

		public static NauticalMiles operator +(NauticalMiles x, LengthUnit y)
		{
			if (y is NauticalMiles miles) return x + miles;
			return new NauticalMiles(x.Add(y));
		}
	}
}
