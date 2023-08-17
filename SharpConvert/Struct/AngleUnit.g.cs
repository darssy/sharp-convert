
using System;

namespace MmiSoft.Core.Math.Units.Struct;

[Serializable]
public readonly partial struct Radians : IAngle
{
	public static readonly Radians Zero = new();

	private readonly double unitValue;

	public Radians(double radians)
	{
		unitValue = radians;
	}

	#region minus operators


	public static Radians operator -(Radians x, Radians y)
	{
		return new Radians(x.unitValue - y.unitValue);
	}

	public static Radians operator -(Radians x, Degrees y)
	{
		return x - y.To(AngleConversions.Radian);
	}
	#endregion

	#region plus operators

	public static Radians operator +(Radians x, Radians y)
	{
		return new Radians(x.unitValue + y.unitValue);
	}

	public static Radians operator +(Radians x, Degrees y)
	{
		return x + y.To(AngleConversions.Radian);
	}

	#endregion

	#region conversion operators


	public static implicit operator Radians(Degrees other)
	{
		return other.To(AngleConversions.Radian);
	}

	#endregion

	#region Equality overloads and operators

	public override bool Equals(object obj)
	{
		return obj switch
		{
			Radians r => Equals(r),
			IAngle length => Equals(length.To(AngleConversions.Radian)),
			_ => false
		};
	}

	public bool Equals(Radians other) => System.Math.Abs(UnitValue - other.UnitValue) <= 1e-14;

	public override int GetHashCode() => 7 * UnitValue.GetHashCode();

	public static bool operator ==(Radians l, Radians r) => l.Equals(r);

	public static bool operator ==(Radians l, Degrees r) => l.Equals(r.To(AngleConversions.Radian));

	public static bool operator !=(Radians l, Radians r) => !l.Equals(r);
	public static bool operator !=(Radians l, Degrees r) => !l.Equals(r.To(AngleConversions.Radian));

	#endregion

	public static Radians operator *(Radians m, double f) => new Radians(m.unitValue * f);
	public static Radians operator *(double f, Radians m) => new Radians(m.unitValue * f);

	public static double operator /(Radians x, Radians y) => x.unitValue / y.unitValue;

	public static Radians operator /(Radians x, double y) => new Radians(x.unitValue / y);
	public static Radians operator /(Radians x, float y) => new Radians(x.unitValue / y);
	public static Radians operator /(Radians x, int y) => new Radians(x.unitValue / y);

	public double UnitValue => unitValue;

	ILinearConversion IAngle.Conversion => AngleConversions.Radian;

	double IAngle.SiValue => unitValue ;

	public int CompareTo(IAngle other) => UnitValue.CompareTo(other.To(AngleConversions.Radian).UnitValue);

	public static bool operator <(Radians l, Radians r) => l.UnitValue < r.UnitValue;
	public static bool operator <(Radians l, Degrees r) => l < r.To(AngleConversions.Radian);

	public static bool operator <=(Radians l, Radians r) => l.UnitValue <= r.UnitValue;
	public static bool operator <=(Radians l, Degrees r) => l <= r.To(AngleConversions.Radian);

	public static bool operator >(Radians l, Radians r) => l.UnitValue > r.UnitValue;
	public static bool operator >(Radians l, Degrees r) => l > r.To(AngleConversions.Radian);

	public static bool operator >=(Radians l, Radians r) => l.UnitValue >= r.UnitValue;
	public static bool operator >=(Radians l, Degrees r) => l >= r.To(AngleConversions.Radian);

}

[Serializable]
public readonly partial struct Degrees : IAngle
{
	public static readonly Degrees Zero = new();

	private readonly double unitValue;

	public Degrees(double degrees)
	{
		unitValue = degrees;
	}

	#region minus operators


	public static Degrees operator -(Degrees x, Degrees y)
	{
		return new Degrees(x.unitValue - y.unitValue);
	}

	public static Degrees operator -(Degrees x, Radians y)
	{
		return x - y.To(AngleConversions.Degree);
	}
	#endregion

	#region plus operators

	public static Degrees operator +(Degrees x, Degrees y)
	{
		return new Degrees(x.unitValue + y.unitValue);
	}

	public static Degrees operator +(Degrees x, Radians y)
	{
		return x + y.To(AngleConversions.Degree);
	}

	#endregion

	#region conversion operators


	public static implicit operator Degrees(Radians other)
	{
		return other.To(AngleConversions.Degree);
	}

	#endregion

	#region Equality overloads and operators

	public override bool Equals(object obj)
	{
		return obj switch
		{
			Degrees d => Equals(d),
			IAngle length => Equals(length.To(AngleConversions.Degree)),
			_ => false
		};
	}

	public bool Equals(Degrees other) => System.Math.Abs(UnitValue - other.UnitValue) <= 1e-14;

	public override int GetHashCode() => 7 * UnitValue.GetHashCode();

	public static bool operator ==(Degrees l, Degrees r) => l.Equals(r);

	public static bool operator ==(Degrees l, Radians r) => l.Equals(r.To(AngleConversions.Degree));

	public static bool operator !=(Degrees l, Degrees r) => !l.Equals(r);
	public static bool operator !=(Degrees l, Radians r) => !l.Equals(r.To(AngleConversions.Degree));

	#endregion

	public static Degrees operator *(Degrees m, double f) => new Degrees(m.unitValue * f);
	public static Degrees operator *(double f, Degrees m) => new Degrees(m.unitValue * f);

	public static double operator /(Degrees x, Degrees y) => x.unitValue / y.unitValue;

	public static Degrees operator /(Degrees x, double y) => new Degrees(x.unitValue / y);
	public static Degrees operator /(Degrees x, float y) => new Degrees(x.unitValue / y);
	public static Degrees operator /(Degrees x, int y) => new Degrees(x.unitValue / y);

	public double UnitValue => unitValue;

	ILinearConversion IAngle.Conversion => AngleConversions.Degree;

	double IAngle.SiValue => unitValue * AngleConversions.Degree.ToSiFactor;

	public int CompareTo(IAngle other) => UnitValue.CompareTo(other.To(AngleConversions.Degree).UnitValue);

	public static bool operator <(Degrees l, Degrees r) => l.UnitValue < r.UnitValue;
	public static bool operator <(Degrees l, Radians r) => l < r.To(AngleConversions.Degree);

	public static bool operator <=(Degrees l, Degrees r) => l.UnitValue <= r.UnitValue;
	public static bool operator <=(Degrees l, Radians r) => l <= r.To(AngleConversions.Degree);

	public static bool operator >(Degrees l, Degrees r) => l.UnitValue > r.UnitValue;
	public static bool operator >(Degrees l, Radians r) => l > r.To(AngleConversions.Degree);

	public static bool operator >=(Degrees l, Degrees r) => l.UnitValue >= r.UnitValue;
	public static bool operator >=(Degrees l, Radians r) => l >= r.To(AngleConversions.Degree);

}

