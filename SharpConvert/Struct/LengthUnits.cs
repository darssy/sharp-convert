using System;

namespace MmiSoft.Core.Math.Units.Struct;

public interface ILength : IComparable<ILength>
{
	double UnitValue { get; }
	internal ILinearConversion Conversion { get; }

	internal double SiValue { get; }
	//internal double SiValue => UnitValue * Conversion.ToSiFactor;
}

[Serializable]
public readonly struct Meters : ILength
{
	public static readonly Meters Zero = new();

	private readonly double unitValue;

	public Meters(double meters)
	{
		unitValue = meters;
	}

	public static Meters operator -(Meters x, Meters y)
	{
		return new Meters(System.Math.Abs(x.unitValue - y.unitValue));
	}

	public static Meters operator -(Meters x, Feet y)
	{
		return x - y.To(LengthConversions.Meter);
	}

	public static Meters operator +(Meters x, Meters y)
	{
		return new Meters(x.unitValue + y.unitValue);
	}

	public static Meters operator +(Meters x, Feet y)
	{
		return x + y.To(LengthConversions.Meter);
	}

	#region conversion operators

	public static implicit operator Meters(Feet ft)
	{
		return ft.To(LengthConversions.Meter);
	}

	public static implicit operator Meters(Kilometers ft)
	{
		return ft.To(LengthConversions.Meter);
	}

	public static implicit operator Meters(NauticalMiles ft)
	{
		return ft.To(LengthConversions.Meter);
	}

	#endregion

	public double UnitValue => unitValue;

	ILinearConversion ILength.Conversion => LengthConversions.Meter;

	//we can cheat here as ToSiFactor is 1 (one)
	double ILength.SiValue => unitValue /* * LengthConversions.Meter.ToSiFactor*/;

	public int CompareTo(ILength other) => UnitValue.CompareTo(other.To(LengthConversions.Meter).UnitValue);
}

[Serializable]
public struct Kilometers : ILength, IComparable<ILength>
{
	public static readonly Kilometers Zero = new();

	private readonly double unitValue;

	public Kilometers(double unitValue)
	{
		this.unitValue = unitValue;
	}

	#region minus operators

	public static Kilometers operator -(Kilometers x, Kilometers y)
	{
		return new Kilometers(System.Math.Abs(x.unitValue - y.unitValue));
	}

	public static Kilometers operator -(Kilometers x, Meters y)
	{
		return x - y.To(LengthConversions.Kilometer);
	}

	public static Kilometers operator -(Kilometers x, Feet y)
	{
		return x - y.To(LengthConversions.Kilometer);
	}

	public static Kilometers operator -(Kilometers x, NauticalMiles y)
	{
		return x - y.To(LengthConversions.Kilometer);
	}

	#endregion

	#region plus operators

	public static Kilometers operator +(Kilometers x, Kilometers y)
	{
		return new Kilometers(x.unitValue + y.unitValue);
	}

	public static Kilometers operator +(Kilometers x, Meters y)
	{
		return x + y.To(LengthConversions.Kilometer);
	}

	public static Kilometers operator +(Kilometers x, Feet y)
	{
		return x + y.To(LengthConversions.Kilometer);
	}

	public static Kilometers operator +(Kilometers x, NauticalMiles y)
	{
		return x + y.To(LengthConversions.Kilometer);
	}

	#endregion

	#region conversion operators

	public static implicit operator Meters(Kilometers ft)
	{
		return ft.To(LengthConversions.Meter);
	}

	public static implicit operator Feet(Kilometers ft)
	{
		return ft.To(LengthConversions.Foot);
	}

	public static implicit operator NauticalMiles(Kilometers ft)
	{
		return ft.To(LengthConversions.NauticalMile);
	}

	#endregion

	public double UnitValue => unitValue;

	ILinearConversion ILength.Conversion => LengthConversions.Kilometer;

	double ILength.SiValue => unitValue * LengthConversions.Kilometer.ToSiFactor;

	public int CompareTo(ILength other) => throw new NotImplementedException();
}

[Serializable]
public struct Feet : ILength
{
	public static readonly Feet Zero = new();

	public Feet(double unitValue)
	{
		this.UnitValue = unitValue;
	}

	#region minus operators

	public static Feet operator -(Feet x, Feet y)
	{
		return new Feet(System.Math.Abs(x.UnitValue - y.UnitValue));
	}

	public static Feet operator -(Feet x, Meters y)
	{
		return x - y.To(LengthConversions.Foot);
	}

	public static Feet operator -(Feet x, Kilometers y)
	{
		return x - y.To(LengthConversions.Foot);
	}

	public static Feet operator -(Feet x, NauticalMiles y)
	{
		return x - y.To(LengthConversions.Foot);
	}

	#endregion

	#region plus operators

	public static Feet operator +(Feet x, Feet y)
	{
		return new Feet(x.UnitValue + y.UnitValue);
	}

	public static Feet operator +(Feet x, Meters y)
	{
		return x + y.To(LengthConversions.Foot);
	}

	public static Feet operator +(Feet x, Kilometers y)
	{
		return x + y.To(LengthConversions.Foot);
	}

	public static Feet operator +(Feet x, NauticalMiles y)
	{
		return x + y.To(LengthConversions.Foot);
	}

	#endregion

	#region conversion operators

	public static implicit operator Feet(Meters ft)
	{
		return ft.To(LengthConversions.Foot);
	}

	public static implicit operator Feet(Kilometers ft)
	{
		return ft.To(LengthConversions.Foot);
	}

	public static implicit operator Feet(NauticalMiles ft)
	{
		return ft.To(LengthConversions.Foot);
	}

	#endregion

	#region divide operators (distance by time equals speed)

	public static FeetPerMinute? operator /(Feet x, Minutes y)
	{
		return y == Minutes.Zero ? null : new FeetPerMinute(x.UnitValue / y.UnitValue);
	}

	public static FeetPerMinute? operator /(Feet x, Hours y)
	{
		return x / y.To(TimeConversions.Minute);
	}

	public static FeetPerMinute? operator /(Feet x, Seconds y)
	{
		return x / y.To(TimeConversions.Minute);
	}

	#endregion

	public double UnitValue { get; }

	ILinearConversion ILength.Conversion => LengthConversions.Foot;

	double ILength.SiValue => UnitValue * LengthConversions.Foot.ToSiFactor;

	public int CompareTo(ILength other) => UnitValue.CompareTo(other.To(LengthConversions.Foot).UnitValue);
}

[Serializable]
public struct NauticalMiles : ILength, IComparable<ILength>
{
	public static readonly NauticalMiles Zero = new();

	private readonly double unitValue;

	public NauticalMiles(double unitValue)
	{
		this.unitValue = unitValue;
	}

	#region minus operators

	public static NauticalMiles operator -(NauticalMiles x, NauticalMiles y)
	{
		return new NauticalMiles(System.Math.Abs(x.unitValue - y.unitValue));
	}

	public static NauticalMiles operator -(NauticalMiles x, Meters y)
	{
		return x - y.To(LengthConversions.NauticalMile);
	}

	public static NauticalMiles operator -(NauticalMiles x, Feet y)
	{
		return x - y.To(LengthConversions.NauticalMile);
	}

	#endregion

	#region plus operators

	public static NauticalMiles operator +(NauticalMiles x, NauticalMiles y)
	{
		return new NauticalMiles(x.unitValue + y.unitValue);
	}

	public static NauticalMiles operator +(NauticalMiles x, Meters y)
	{
		return x + y.To(LengthConversions.NauticalMile);
	}

	public static NauticalMiles operator +(NauticalMiles x, Feet y)
	{
		return x + y.To(LengthConversions.NauticalMile);
	}

	#endregion

	#region conversion operators

	public static implicit operator Meters(NauticalMiles ft)
	{
		return ft.To(LengthConversions.Meter);
	}

	public static implicit operator Feet(NauticalMiles ft)
	{
		return ft.To(LengthConversions.Foot);
	}

	#endregion

	public double UnitValue => unitValue;

	ILinearConversion ILength.Conversion => LengthConversions.NauticalMile;

	double ILength.SiValue => unitValue * LengthConversions.NauticalMile.ToSiFactor;

	public int CompareTo(ILength other) => throw new NotImplementedException();
}
