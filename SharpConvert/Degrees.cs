using System;

namespace MmiSoft.Core.Math.Units
{
	[Serializable]
	public class Degrees : AngleUnit
	{
		public static readonly Degrees FullCircle = new Degrees(360);
		public static readonly Degrees RightAngle = new Degrees(90);

		public Degrees() :this(0f)
		{ }

		public Degrees(double unitValue)
			: base(unitValue, System.Math.PI / 180)
		{
		}

		public Degrees(decimal unitValue) : this((float)unitValue)
		{ }

		public Degrees(int unitValue)
			: this((float)unitValue)
		{ }

		public static Degrees operator -(Degrees x)
		{
			return new Degrees(-x.unitValue);
		}

		public static Degrees operator -(Degrees x, AngleUnit y)
		{
			return Subtract<Degrees>(x, y);
		}

		public static Degrees operator +(Degrees x, AngleUnit y)
		{
			return Add<Degrees>(x, y);
		}

		public override string Symbol => "\u00B0";
	}
}
