using System;
using System.Runtime.CompilerServices;

namespace MmiSoft.Core.Math.Units
{
	[Serializable]
	public abstract class UnitBase : IFormattable
	{
		private const double Threshold = 1e-14;
		protected double unitValue;
		protected readonly Conversion conversion;

		protected UnitBase(double unitValue, Conversion conversion)
		{
			this.unitValue = unitValue;
			this.conversion = conversion;
		}

		public string Symbol => conversion.Symbol;

		public double UnitValue => unitValue;

		public double Round(int decimals = 0)
		{
			return decimals == 0
				? System.Math.Round(unitValue)
				: System.Math.Round(unitValue, decimals);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		protected internal double ToSi()
		{
			return unitValue * conversion.ToSiFactor;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
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
			return ToSi().GetHashCode() + 1000000007 * conversion.GetHashCode();
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

		public string ToString(string format, IFormatProvider formatProvider)
		{
			return $"{unitValue.ToString(format, formatProvider)}{Symbol}";
		}

		protected double Subtract(UnitBase other)
		{
#if DEBUG
			if (conversion.UnitType != other.conversion.UnitType)
			{
				throw new ArgumentException($"{other} and {this} are not of the same unit type");
			}
#endif
			return (ToSi() - other.ToSi()) / conversion.ToSiFactor;
		}

		protected double SubtractAbs(UnitBase other)
		{
#if DEBUG
			if (conversion.UnitType != other.conversion.UnitType)
			{
				throw new ArgumentException($"{other} and {this} are not of the same unit type");
			}
#endif
			return System.Math.Abs(ToSi() - other.ToSi()) / conversion.ToSiFactor;
		}

		protected double Add(UnitBase other)
		{
#if DEBUG
			if (conversion.UnitType != other.conversion.UnitType)
			{
				throw new ArgumentException($"{other} and {this} are not of the same unit type");
			}
#endif
			return (ToSi() + other.ToSi()) / conversion.ToSiFactor;
		}

		public static T Abs<T>(T unit) where T : UnitBase
		{
			if (unit.unitValue >= 0) return unit;
			T abs = (T) unit.MemberwiseClone();
			abs.unitValue = -abs.unitValue;
			return abs;
		}

		public static U1 ConvertTo<U1, U2>(U2 l)
			where U2 : UnitBase
			where U1 : U2
		{
			if (l is U1 u2) return u2;
			Func<double, UnitBase> func = ReflectionHelper.GetConstructor<U1>();
			UnitBase unitBase = func.Invoke(0);
			unitBase.FromSi(l.ToSi());
			return (U1) unitBase;
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
