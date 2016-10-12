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
			: base(mile, 1852)
		{ }

		public static NauticalMiles operator -(NauticalMiles x, LengthUnit y)
		{
			return Subtract<NauticalMiles>(x, y);
		}

		public static NauticalMiles operator +(NauticalMiles x, LengthUnit y)
		{
			return Add<NauticalMiles>(x, y);
		}
	}
}
