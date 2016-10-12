using System;

namespace MmiSoft.Core.Math.Units
{
	[Serializable]
	public sealed class Feet : LengthUnit
	{
		public Feet()
			: this(0)
		{ }

		public Feet(double feet)
			: base(feet, 0.3048)
		{ }

		public static Feet operator -(Feet x, LengthUnit y)
		{
			return Subtract<Feet>(x, y);
		}

		public static Feet operator +(Feet x, LengthUnit y)
		{
			return Add<Feet>(x, y);
		}
	}
}
