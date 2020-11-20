using System;

namespace MmiSoft.Core.Math.Units
{
	/// <summary>
	/// An attempt to create an interned version of Feet. That will be helpful to represent altitude or depth, where the
	/// fractional part is not important, allocations might have impact on performance and values are finite. This class
	/// is experimental.
	/// </summary>
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

		//declared private to avoid inclusion in Extensions.Parse
		private FeetInterned(double unitValue)
			: base(unitValue, Conversion.Foot)
		{ }

		public static FeetInterned operator -(FeetInterned x, FeetInterned y)
		{
			int value = (int) System.Math.Abs(x.unitValue - y.unitValue);
			return Get(value);
		}

		public static FeetInterned operator +(FeetInterned x, FeetInterned y)
		{
			int value = (int) (x.unitValue + y.unitValue);
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
	}
}
