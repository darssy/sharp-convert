using System;

namespace MmiSoft.Core.Math.Units
{
	[Serializable]
	internal class FeetInterned : LengthUnit
	{
		public FeetInterned()
			: this(0)
		{ }

		private static readonly FeetInterned[] interned = new FeetInterned[100000];

		static FeetInterned()
		{
			for (var i = 0; i < interned.Length; i++)
			{
				interned[i] = new FeetInterned(i);
			}
		}

		public static FeetInterned Get(int value)
		{
			return value >= interned.Length ? new FeetInterned() : interned[value];
		}

		public FeetInterned(double unitValue)
			: base(unitValue, 0.3048)
		{ }

		public static FeetInterned operator -(FeetInterned x, FeetInterned y)
		{
			int value = (int) System.Math.Abs(x.unitValue - y.unitValue);
			return Get(value);
		}

		public static FeetInterned operator +(FeetInterned x, FeetInterned y)
		{
			int value = (int) System.Math.Abs(x.unitValue - y.unitValue);
			return Get(value);
		}

		public static FeetInterned operator -(FeetInterned x, LengthUnit y)
		{
			if (y is FeetInterned feet) return x - feet;
			return Subtract<FeetInterned>(x, y);
		}

		public static FeetInterned operator +(FeetInterned x, LengthUnit y)
		{
			if (y is FeetInterned feet) return x + feet;
			return Add<FeetInterned>(x, y);
		}

		public override string Symbol => "ft";
	}
}
