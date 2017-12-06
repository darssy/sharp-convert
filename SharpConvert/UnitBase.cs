using System;

namespace MmiSoft.Core.Math.Units
{
	[Serializable]
	public abstract class UnitBase
	{
		protected double unitValue;
		protected readonly double toSiFactor;

		protected UnitBase(double unitValue, double toSiFactor)
		{
			this.unitValue = unitValue;
			this.toSiFactor = toSiFactor;
		}

		public double ToSiFactor
		{
			get { return toSiFactor; }
		}

		public double UnitValue
		{
			get { return unitValue; }
		}

		public double Round(int decimals = 0)
		{
			return decimals == 0
				? System.Math.Round(unitValue)
				: System.Math.Round(unitValue, decimals);
		}

		protected internal double ToSi()
		{
			return unitValue * toSiFactor;
		}

		protected internal double FromSi(double siValue)
		{
			return unitValue = siValue / toSiFactor;
		}

		/// <summary>
		/// Should be used wisely and from subclasses only; it does not support type checking,
		/// therefore it migth be comparing distance to time or anything else
		/// </summary>
		/// <param name="other"></param>
		/// <returns></returns>
		protected bool EqualsImpl(UnitBase other)
		{
			double otherSi = other.ToSi();
			double si = ToSi();
			double diff = System.Math.Abs(otherSi - si);
			return otherSi == si || diff < 1e-14;
		}

		public override string ToString()
		{
			return unitValue + "";
		}

		public string ToString(string format)
		{
			return unitValue.ToString(format);
		}

		public static U1 ConvertTo<U1, U2>(U2 l)
			where U2 : UnitBase
			where U1 : U2, new()
		{
			if (l is U1) return (U1)l;
			U1 converted = new U1();
			converted.FromSi(l.ToSi());
			return converted;
		}

		public static T Max<T>(T u1, T u2) where T : UnitBase
		{
			return u1.ToSi() > u2.ToSi() ? u1 : u2;
		}
	}
}
