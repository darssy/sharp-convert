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

		private bool EqualsImpl(UnitBase other)
		{
			//if units are the same, avoid unnecessary math
			if (other.conversion == conversion)
			{
				return System.Math.Abs(unitValue - other.unitValue) <= Threshold;
			}
			if (other.conversion.UnitType != conversion.UnitType) return false;
			double otherSi = other.ToSi();
			double si = ToSi();
			double diff = System.Math.Abs(otherSi - si);
			return diff <= Threshold;
		}

		public override bool Equals(object obj)
		{
			var other = obj as UnitBase;
			if (ReferenceEquals(null, other)) return false;
			if (ReferenceEquals(this, other)) return true;
			return EqualsImpl(other);
		}

		public override int GetHashCode()
		{
			return ToSi().GetHashCode() * conversion.GetHashCode();
		}

		public static bool operator ==(UnitBase left, UnitBase right)
		{
			return Equals(left, right);
		}

		public static bool operator !=(UnitBase left, UnitBase right)
		{
			return !Equals(left, right);
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
