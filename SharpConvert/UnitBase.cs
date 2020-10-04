using System;

namespace MmiSoft.Core.Math.Units
{
	[Serializable]
	public abstract class UnitBase
	{
		private const double Threshold = 1e-14;
		protected double unitValue;
		private readonly Conversion conversion;

		protected UnitBase(double unitValue, Conversion conversion)
		{
			this.unitValue = unitValue;
			this.conversion = conversion;
		}

		public abstract string Symbol { get; }

		public double UnitValue => unitValue;

		public double Round(int decimals = 0)
		{
			return decimals == 0
				? System.Math.Round(unitValue)
				: System.Math.Round(unitValue, decimals);
		}

		protected internal double ToSi()
		{
			return unitValue * conversion.ToSiFactor;
		}

		protected internal double FromSi(double siValue)
		{
			return unitValue = siValue / conversion.ToSiFactor;
		}

		/// <summary>
		/// Should be used wisely and from subclasses only; it does not support type checking,
		/// therefore it might be comparing distance to time or anything else
		/// </summary>
		/// <param name="other"></param>
		/// <returns></returns>
		protected bool EqualsImpl(UnitBase other)
		{
			//if units are the same, avoid unnecessary math
			if (other.conversion == conversion)
			{
				return System.Math.Abs(unitValue - other.unitValue) <= Threshold;
			}
			double otherSi = other.ToSi();
			double si = ToSi();
			double diff = System.Math.Abs(otherSi - si);
			return diff <= Threshold;
		}

		public override string ToString()
		{
			return $"{unitValue}{Symbol}";
		}

		public string ToString(string format)
		{
			return $"{unitValue.ToString(format)}{Symbol}";
		}

		public static U1 ConvertTo<U1, U2>(U2 l)
			where U2 : UnitBase
			where U1 : U2, new()
		{
			if (l is U1 u2) return u2;
			U1 converted = new U1();
			converted.FromSi(l.ToSi());
			return converted;
		}

		public static T Max<T>(T u1, T u2) where T : UnitBase
		{
			return u1.ToSi() > u2.ToSi() ? u1 : u2;
		}

		// protected in order to avoid comparison between apples and oranges
		protected int CompareToImpl(UnitBase other)
		{
			return other.conversion == conversion
				? Compare(unitValue - other.unitValue)
				: Compare(ToSi() - other.ToSi());
		}

		private int Compare(double diff)
		{
			return diff < -Threshold
				? -1
				: diff > Threshold ? 1 : 0;
		}
	}
}
