using System;

namespace MmiSoft.Core.Math.Units
{
	[Serializable]
	public class Degrees : AngleUnit
	{
		public new static readonly Degrees Zero = new Degrees(0);

		public static readonly Degrees _30 = new Degrees(30);
		public static readonly Degrees _45 = new Degrees(45);
		public static readonly Degrees _60 = new Degrees(60);
		public static readonly Degrees _90 = new Degrees(90);
		public static readonly Degrees _180 = new Degrees(180);
		public static readonly Degrees _360 = new Degrees(360);

		public static readonly Degrees FullCircle = _360;
		public static readonly Degrees HalfCircle = _180;
		public static readonly Degrees RightAngle = _90;
		public static readonly Degrees Thirty = _30;
		public static readonly Degrees FortyFive = _45;
		public static readonly Degrees Sixty = _60;

		public Degrees() :this(0f)
		{ }

		public Degrees(double unitValue)
			: base(unitValue, Conversion.Degree)
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

		public static Degrees operator -(Degrees x, Degrees y)
		{
			return new Degrees(x.unitValue - y.unitValue);
		}

		public static Degrees operator +(Degrees x, Degrees y)
		{
			return new Degrees(x.unitValue + y.unitValue);
		}

		public static Degrees operator -(Degrees x, AngleUnit y)
		{
			return new Degrees(x.Subtract(y));
		}

		public static Degrees operator +(Degrees x, AngleUnit y)
		{
			return new Degrees(x.Add(y));
		}
	}
}
