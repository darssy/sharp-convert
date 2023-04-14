using System;

namespace MmiSoft.Core.Math.Units.Struct;

[Serializable]
public readonly struct Meters : ILength
{
	public static readonly Meters Zero = new();

	private readonly double unitValue;

	public Meters(double meters)
	{
		unitValue = meters;
	}

	#region minus operators

	public static Meters operator -(Meters x, Meters y)
	{
		return new Meters(System.Math.Abs(x.unitValue - y.unitValue));
	}

	public static Meters operator -(Meters x, Inches y)
	{
		return x - y.To(LengthConversions.Meter);
	}

	public static Meters operator -(Meters x, Feet y)
	{
		return x - y.To(LengthConversions.Meter);
	}

	public static Meters operator -(Meters x, Kilometers y)
	{
		return x - y.To(LengthConversions.Meter);
	}

	public static Meters operator -(Meters x, NauticalMiles y)
	{
		return x - y.To(LengthConversions.Meter);
	}
	#endregion

	#region plus operators

	public static Meters operator +(Meters x, Meters y)
	{
		return new Meters(x.unitValue + y.unitValue);
	}

	public static Meters operator +(Meters x, Inches y)
	{
		return x + y.To(LengthConversions.Meter);
	}

	public static Meters operator +(Meters x, Feet y)
	{
		return x + y.To(LengthConversions.Meter);
	}

	public static Meters operator +(Meters x, Kilometers y)
	{
		return x + y.To(LengthConversions.Meter);
	}

	public static Meters operator +(Meters x, NauticalMiles y)
	{
		return x + y.To(LengthConversions.Meter);
	}

	#endregion

	#region conversion operators


	public static implicit operator Meters(Inches other)
	{
		return other.To(LengthConversions.Meter);
	}

	public static implicit operator Meters(Feet other)
	{
		return other.To(LengthConversions.Meter);
	}

	public static implicit operator Meters(Kilometers other)
	{
		return other.To(LengthConversions.Meter);
	}

	public static implicit operator Meters(NauticalMiles other)
	{
		return other.To(LengthConversions.Meter);
	}

	#endregion

	#region Equality overloads and operators

	public override bool Equals(object obj)
	{
		return obj switch
		{
			Meters kts => Equals(kts),
			ILength length => Equals(length.To(LengthConversions.Meter)),
			_ => false
		};
	}

	public bool Equals(Meters other) => System.Math.Abs(UnitValue - other.UnitValue) <= 1e-14;

	public override int GetHashCode() => 7 * UnitValue.GetHashCode();

	public static bool operator ==(Meters l, Meters r) => l.Equals(r);

	public static bool operator ==(Meters l, Inches r) => l.Equals(r.To(LengthConversions.Meter));
	public static bool operator ==(Meters l, Feet r) => l.Equals(r.To(LengthConversions.Meter));
	public static bool operator ==(Meters l, Kilometers r) => l.Equals(r.To(LengthConversions.Meter));
	public static bool operator ==(Meters l, NauticalMiles r) => l.Equals(r.To(LengthConversions.Meter));

	public static bool operator !=(Meters l, Meters r) => !l.Equals(r);
	public static bool operator !=(Meters l, Inches r) => !l.Equals(r.To(LengthConversions.Meter));
	public static bool operator !=(Meters l, Feet r) => !l.Equals(r.To(LengthConversions.Meter));
	public static bool operator !=(Meters l, Kilometers r) => !l.Equals(r.To(LengthConversions.Meter));
	public static bool operator !=(Meters l, NauticalMiles r) => !l.Equals(r.To(LengthConversions.Meter));

	#endregion

	public double UnitValue => unitValue;

	ILinearConversion ILength.Conversion => LengthConversions.Meter;

	double ILength.SiValue => unitValue ;

	public int CompareTo(ILength other) => UnitValue.CompareTo(other.To(LengthConversions.Meter).UnitValue);

	public static bool operator <(Meters l, Meters r) => l.UnitValue < r.UnitValue;
	public static bool operator <(Meters l, Inches r) => l < r.To(LengthConversions.Meter);
	public static bool operator <(Meters l, Feet r) => l < r.To(LengthConversions.Meter);
	public static bool operator <(Meters l, Kilometers r) => l < r.To(LengthConversions.Meter);
	public static bool operator <(Meters l, NauticalMiles r) => l < r.To(LengthConversions.Meter);

	public static bool operator <=(Meters l, Meters r) => l.UnitValue <= r.UnitValue;
	public static bool operator <=(Meters l, Inches r) => l <= r.To(LengthConversions.Meter);
	public static bool operator <=(Meters l, Feet r) => l <= r.To(LengthConversions.Meter);
	public static bool operator <=(Meters l, Kilometers r) => l <= r.To(LengthConversions.Meter);
	public static bool operator <=(Meters l, NauticalMiles r) => l <= r.To(LengthConversions.Meter);

	public static bool operator >(Meters l, Meters r) => l.UnitValue > r.UnitValue;
	public static bool operator >(Meters l, Inches r) => l > r.To(LengthConversions.Meter);
	public static bool operator >(Meters l, Feet r) => l > r.To(LengthConversions.Meter);
	public static bool operator >(Meters l, Kilometers r) => l > r.To(LengthConversions.Meter);
	public static bool operator >(Meters l, NauticalMiles r) => l > r.To(LengthConversions.Meter);

	public static bool operator >=(Meters l, Meters r) => l.UnitValue >= r.UnitValue;
	public static bool operator >=(Meters l, Inches r) => l >= r.To(LengthConversions.Meter);
	public static bool operator >=(Meters l, Feet r) => l >= r.To(LengthConversions.Meter);
	public static bool operator >=(Meters l, Kilometers r) => l >= r.To(LengthConversions.Meter);
	public static bool operator >=(Meters l, NauticalMiles r) => l >= r.To(LengthConversions.Meter);

}

[Serializable]
public readonly struct Inches : ILength
{
	public static readonly Inches Zero = new();

	private readonly double unitValue;

	public Inches(double inches)
	{
		unitValue = inches;
	}

	#region minus operators

	public static Inches operator -(Inches x, Inches y)
	{
		return new Inches(System.Math.Abs(x.unitValue - y.unitValue));
	}

	public static Inches operator -(Inches x, Meters y)
	{
		return x - y.To(LengthConversions.Inch);
	}

	public static Inches operator -(Inches x, Feet y)
	{
		return x - y.To(LengthConversions.Inch);
	}

	public static Inches operator -(Inches x, Kilometers y)
	{
		return x - y.To(LengthConversions.Inch);
	}

	public static Inches operator -(Inches x, NauticalMiles y)
	{
		return x - y.To(LengthConversions.Inch);
	}
	#endregion

	#region plus operators

	public static Inches operator +(Inches x, Inches y)
	{
		return new Inches(x.unitValue + y.unitValue);
	}

	public static Inches operator +(Inches x, Meters y)
	{
		return x + y.To(LengthConversions.Inch);
	}

	public static Inches operator +(Inches x, Feet y)
	{
		return x + y.To(LengthConversions.Inch);
	}

	public static Inches operator +(Inches x, Kilometers y)
	{
		return x + y.To(LengthConversions.Inch);
	}

	public static Inches operator +(Inches x, NauticalMiles y)
	{
		return x + y.To(LengthConversions.Inch);
	}

	#endregion

	#region conversion operators


	public static implicit operator Inches(Meters other)
	{
		return other.To(LengthConversions.Inch);
	}

	public static implicit operator Inches(Feet other)
	{
		return other.To(LengthConversions.Inch);
	}

	public static implicit operator Inches(Kilometers other)
	{
		return other.To(LengthConversions.Inch);
	}

	public static implicit operator Inches(NauticalMiles other)
	{
		return other.To(LengthConversions.Inch);
	}

	#endregion

	#region Equality overloads and operators

	public override bool Equals(object obj)
	{
		return obj switch
		{
			Inches kts => Equals(kts),
			ILength length => Equals(length.To(LengthConversions.Inch)),
			_ => false
		};
	}

	public bool Equals(Inches other) => System.Math.Abs(UnitValue - other.UnitValue) <= 1e-14;

	public override int GetHashCode() => 7 * UnitValue.GetHashCode();

	public static bool operator ==(Inches l, Inches r) => l.Equals(r);

	public static bool operator ==(Inches l, Meters r) => l.Equals(r.To(LengthConversions.Inch));
	public static bool operator ==(Inches l, Feet r) => l.Equals(r.To(LengthConversions.Inch));
	public static bool operator ==(Inches l, Kilometers r) => l.Equals(r.To(LengthConversions.Inch));
	public static bool operator ==(Inches l, NauticalMiles r) => l.Equals(r.To(LengthConversions.Inch));

	public static bool operator !=(Inches l, Inches r) => !l.Equals(r);
	public static bool operator !=(Inches l, Meters r) => !l.Equals(r.To(LengthConversions.Inch));
	public static bool operator !=(Inches l, Feet r) => !l.Equals(r.To(LengthConversions.Inch));
	public static bool operator !=(Inches l, Kilometers r) => !l.Equals(r.To(LengthConversions.Inch));
	public static bool operator !=(Inches l, NauticalMiles r) => !l.Equals(r.To(LengthConversions.Inch));

	#endregion

	public double UnitValue => unitValue;

	ILinearConversion ILength.Conversion => LengthConversions.Inch;

	double ILength.SiValue => unitValue * LengthConversions.Inch.ToSiFactor;

	public int CompareTo(ILength other) => UnitValue.CompareTo(other.To(LengthConversions.Inch).UnitValue);

	public static bool operator <(Inches l, Inches r) => l.UnitValue < r.UnitValue;
	public static bool operator <(Inches l, Meters r) => l < r.To(LengthConversions.Inch);
	public static bool operator <(Inches l, Feet r) => l < r.To(LengthConversions.Inch);
	public static bool operator <(Inches l, Kilometers r) => l < r.To(LengthConversions.Inch);
	public static bool operator <(Inches l, NauticalMiles r) => l < r.To(LengthConversions.Inch);

	public static bool operator <=(Inches l, Inches r) => l.UnitValue <= r.UnitValue;
	public static bool operator <=(Inches l, Meters r) => l <= r.To(LengthConversions.Inch);
	public static bool operator <=(Inches l, Feet r) => l <= r.To(LengthConversions.Inch);
	public static bool operator <=(Inches l, Kilometers r) => l <= r.To(LengthConversions.Inch);
	public static bool operator <=(Inches l, NauticalMiles r) => l <= r.To(LengthConversions.Inch);

	public static bool operator >(Inches l, Inches r) => l.UnitValue > r.UnitValue;
	public static bool operator >(Inches l, Meters r) => l > r.To(LengthConversions.Inch);
	public static bool operator >(Inches l, Feet r) => l > r.To(LengthConversions.Inch);
	public static bool operator >(Inches l, Kilometers r) => l > r.To(LengthConversions.Inch);
	public static bool operator >(Inches l, NauticalMiles r) => l > r.To(LengthConversions.Inch);

	public static bool operator >=(Inches l, Inches r) => l.UnitValue >= r.UnitValue;
	public static bool operator >=(Inches l, Meters r) => l >= r.To(LengthConversions.Inch);
	public static bool operator >=(Inches l, Feet r) => l >= r.To(LengthConversions.Inch);
	public static bool operator >=(Inches l, Kilometers r) => l >= r.To(LengthConversions.Inch);
	public static bool operator >=(Inches l, NauticalMiles r) => l >= r.To(LengthConversions.Inch);

}

[Serializable]
public readonly struct Feet : ILength
{
	public static readonly Feet Zero = new();

	private readonly double unitValue;

	public Feet(double feet)
	{
		unitValue = feet;
	}

	#region minus operators

	public static Feet operator -(Feet x, Feet y)
	{
		return new Feet(System.Math.Abs(x.unitValue - y.unitValue));
	}

	public static Feet operator -(Feet x, Meters y)
	{
		return x - y.To(LengthConversions.Foot);
	}

	public static Feet operator -(Feet x, Inches y)
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
		return new Feet(x.unitValue + y.unitValue);
	}

	public static Feet operator +(Feet x, Meters y)
	{
		return x + y.To(LengthConversions.Foot);
	}

	public static Feet operator +(Feet x, Inches y)
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


	public static implicit operator Feet(Meters other)
	{
		return other.To(LengthConversions.Foot);
	}

	public static implicit operator Feet(Inches other)
	{
		return other.To(LengthConversions.Foot);
	}

	public static implicit operator Feet(Kilometers other)
	{
		return other.To(LengthConversions.Foot);
	}

	public static implicit operator Feet(NauticalMiles other)
	{
		return other.To(LengthConversions.Foot);
	}

	#endregion

	#region Equality overloads and operators

	public override bool Equals(object obj)
	{
		return obj switch
		{
			Feet kts => Equals(kts),
			ILength length => Equals(length.To(LengthConversions.Foot)),
			_ => false
		};
	}

	public bool Equals(Feet other) => System.Math.Abs(UnitValue - other.UnitValue) <= 1e-14;

	public override int GetHashCode() => 7 * UnitValue.GetHashCode();

	public static bool operator ==(Feet l, Feet r) => l.Equals(r);

	public static bool operator ==(Feet l, Meters r) => l.Equals(r.To(LengthConversions.Foot));
	public static bool operator ==(Feet l, Inches r) => l.Equals(r.To(LengthConversions.Foot));
	public static bool operator ==(Feet l, Kilometers r) => l.Equals(r.To(LengthConversions.Foot));
	public static bool operator ==(Feet l, NauticalMiles r) => l.Equals(r.To(LengthConversions.Foot));

	public static bool operator !=(Feet l, Feet r) => !l.Equals(r);
	public static bool operator !=(Feet l, Meters r) => !l.Equals(r.To(LengthConversions.Foot));
	public static bool operator !=(Feet l, Inches r) => !l.Equals(r.To(LengthConversions.Foot));
	public static bool operator !=(Feet l, Kilometers r) => !l.Equals(r.To(LengthConversions.Foot));
	public static bool operator !=(Feet l, NauticalMiles r) => !l.Equals(r.To(LengthConversions.Foot));

	#endregion

	public double UnitValue => unitValue;

	ILinearConversion ILength.Conversion => LengthConversions.Foot;

	double ILength.SiValue => unitValue * LengthConversions.Foot.ToSiFactor;

	public int CompareTo(ILength other) => UnitValue.CompareTo(other.To(LengthConversions.Foot).UnitValue);

	public static bool operator <(Feet l, Feet r) => l.UnitValue < r.UnitValue;
	public static bool operator <(Feet l, Meters r) => l < r.To(LengthConversions.Foot);
	public static bool operator <(Feet l, Inches r) => l < r.To(LengthConversions.Foot);
	public static bool operator <(Feet l, Kilometers r) => l < r.To(LengthConversions.Foot);
	public static bool operator <(Feet l, NauticalMiles r) => l < r.To(LengthConversions.Foot);

	public static bool operator <=(Feet l, Feet r) => l.UnitValue <= r.UnitValue;
	public static bool operator <=(Feet l, Meters r) => l <= r.To(LengthConversions.Foot);
	public static bool operator <=(Feet l, Inches r) => l <= r.To(LengthConversions.Foot);
	public static bool operator <=(Feet l, Kilometers r) => l <= r.To(LengthConversions.Foot);
	public static bool operator <=(Feet l, NauticalMiles r) => l <= r.To(LengthConversions.Foot);

	public static bool operator >(Feet l, Feet r) => l.UnitValue > r.UnitValue;
	public static bool operator >(Feet l, Meters r) => l > r.To(LengthConversions.Foot);
	public static bool operator >(Feet l, Inches r) => l > r.To(LengthConversions.Foot);
	public static bool operator >(Feet l, Kilometers r) => l > r.To(LengthConversions.Foot);
	public static bool operator >(Feet l, NauticalMiles r) => l > r.To(LengthConversions.Foot);

	public static bool operator >=(Feet l, Feet r) => l.UnitValue >= r.UnitValue;
	public static bool operator >=(Feet l, Meters r) => l >= r.To(LengthConversions.Foot);
	public static bool operator >=(Feet l, Inches r) => l >= r.To(LengthConversions.Foot);
	public static bool operator >=(Feet l, Kilometers r) => l >= r.To(LengthConversions.Foot);
	public static bool operator >=(Feet l, NauticalMiles r) => l >= r.To(LengthConversions.Foot);

}

[Serializable]
public readonly struct Kilometers : ILength
{
	public static readonly Kilometers Zero = new();

	private readonly double unitValue;

	public Kilometers(double kilometers)
	{
		unitValue = kilometers;
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

	public static Kilometers operator -(Kilometers x, Inches y)
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

	public static Kilometers operator +(Kilometers x, Inches y)
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


	public static implicit operator Kilometers(Meters other)
	{
		return other.To(LengthConversions.Kilometer);
	}

	public static implicit operator Kilometers(Inches other)
	{
		return other.To(LengthConversions.Kilometer);
	}

	public static implicit operator Kilometers(Feet other)
	{
		return other.To(LengthConversions.Kilometer);
	}

	public static implicit operator Kilometers(NauticalMiles other)
	{
		return other.To(LengthConversions.Kilometer);
	}

	#endregion

	#region Equality overloads and operators

	public override bool Equals(object obj)
	{
		return obj switch
		{
			Kilometers kts => Equals(kts),
			ILength length => Equals(length.To(LengthConversions.Kilometer)),
			_ => false
		};
	}

	public bool Equals(Kilometers other) => System.Math.Abs(UnitValue - other.UnitValue) <= 1e-14;

	public override int GetHashCode() => 7 * UnitValue.GetHashCode();

	public static bool operator ==(Kilometers l, Kilometers r) => l.Equals(r);

	public static bool operator ==(Kilometers l, Meters r) => l.Equals(r.To(LengthConversions.Kilometer));
	public static bool operator ==(Kilometers l, Inches r) => l.Equals(r.To(LengthConversions.Kilometer));
	public static bool operator ==(Kilometers l, Feet r) => l.Equals(r.To(LengthConversions.Kilometer));
	public static bool operator ==(Kilometers l, NauticalMiles r) => l.Equals(r.To(LengthConversions.Kilometer));

	public static bool operator !=(Kilometers l, Kilometers r) => !l.Equals(r);
	public static bool operator !=(Kilometers l, Meters r) => !l.Equals(r.To(LengthConversions.Kilometer));
	public static bool operator !=(Kilometers l, Inches r) => !l.Equals(r.To(LengthConversions.Kilometer));
	public static bool operator !=(Kilometers l, Feet r) => !l.Equals(r.To(LengthConversions.Kilometer));
	public static bool operator !=(Kilometers l, NauticalMiles r) => !l.Equals(r.To(LengthConversions.Kilometer));

	#endregion

	public double UnitValue => unitValue;

	ILinearConversion ILength.Conversion => LengthConversions.Kilometer;

	double ILength.SiValue => unitValue * LengthConversions.Kilometer.ToSiFactor;

	public int CompareTo(ILength other) => UnitValue.CompareTo(other.To(LengthConversions.Kilometer).UnitValue);

	public static bool operator <(Kilometers l, Kilometers r) => l.UnitValue < r.UnitValue;
	public static bool operator <(Kilometers l, Meters r) => l < r.To(LengthConversions.Kilometer);
	public static bool operator <(Kilometers l, Inches r) => l < r.To(LengthConversions.Kilometer);
	public static bool operator <(Kilometers l, Feet r) => l < r.To(LengthConversions.Kilometer);
	public static bool operator <(Kilometers l, NauticalMiles r) => l < r.To(LengthConversions.Kilometer);

	public static bool operator <=(Kilometers l, Kilometers r) => l.UnitValue <= r.UnitValue;
	public static bool operator <=(Kilometers l, Meters r) => l <= r.To(LengthConversions.Kilometer);
	public static bool operator <=(Kilometers l, Inches r) => l <= r.To(LengthConversions.Kilometer);
	public static bool operator <=(Kilometers l, Feet r) => l <= r.To(LengthConversions.Kilometer);
	public static bool operator <=(Kilometers l, NauticalMiles r) => l <= r.To(LengthConversions.Kilometer);

	public static bool operator >(Kilometers l, Kilometers r) => l.UnitValue > r.UnitValue;
	public static bool operator >(Kilometers l, Meters r) => l > r.To(LengthConversions.Kilometer);
	public static bool operator >(Kilometers l, Inches r) => l > r.To(LengthConversions.Kilometer);
	public static bool operator >(Kilometers l, Feet r) => l > r.To(LengthConversions.Kilometer);
	public static bool operator >(Kilometers l, NauticalMiles r) => l > r.To(LengthConversions.Kilometer);

	public static bool operator >=(Kilometers l, Kilometers r) => l.UnitValue >= r.UnitValue;
	public static bool operator >=(Kilometers l, Meters r) => l >= r.To(LengthConversions.Kilometer);
	public static bool operator >=(Kilometers l, Inches r) => l >= r.To(LengthConversions.Kilometer);
	public static bool operator >=(Kilometers l, Feet r) => l >= r.To(LengthConversions.Kilometer);
	public static bool operator >=(Kilometers l, NauticalMiles r) => l >= r.To(LengthConversions.Kilometer);

}

[Serializable]
public readonly struct NauticalMiles : ILength
{
	public static readonly NauticalMiles Zero = new();

	private readonly double unitValue;

	public NauticalMiles(double nauticalmiles)
	{
		unitValue = nauticalmiles;
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

	public static NauticalMiles operator -(NauticalMiles x, Inches y)
	{
		return x - y.To(LengthConversions.NauticalMile);
	}

	public static NauticalMiles operator -(NauticalMiles x, Feet y)
	{
		return x - y.To(LengthConversions.NauticalMile);
	}

	public static NauticalMiles operator -(NauticalMiles x, Kilometers y)
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

	public static NauticalMiles operator +(NauticalMiles x, Inches y)
	{
		return x + y.To(LengthConversions.NauticalMile);
	}

	public static NauticalMiles operator +(NauticalMiles x, Feet y)
	{
		return x + y.To(LengthConversions.NauticalMile);
	}

	public static NauticalMiles operator +(NauticalMiles x, Kilometers y)
	{
		return x + y.To(LengthConversions.NauticalMile);
	}

	#endregion

	#region conversion operators


	public static implicit operator NauticalMiles(Meters other)
	{
		return other.To(LengthConversions.NauticalMile);
	}

	public static implicit operator NauticalMiles(Inches other)
	{
		return other.To(LengthConversions.NauticalMile);
	}

	public static implicit operator NauticalMiles(Feet other)
	{
		return other.To(LengthConversions.NauticalMile);
	}

	public static implicit operator NauticalMiles(Kilometers other)
	{
		return other.To(LengthConversions.NauticalMile);
	}

	#endregion

	#region Equality overloads and operators

	public override bool Equals(object obj)
	{
		return obj switch
		{
			NauticalMiles kts => Equals(kts),
			ILength length => Equals(length.To(LengthConversions.NauticalMile)),
			_ => false
		};
	}

	public bool Equals(NauticalMiles other) => System.Math.Abs(UnitValue - other.UnitValue) <= 1e-14;

	public override int GetHashCode() => 7 * UnitValue.GetHashCode();

	public static bool operator ==(NauticalMiles l, NauticalMiles r) => l.Equals(r);

	public static bool operator ==(NauticalMiles l, Meters r) => l.Equals(r.To(LengthConversions.NauticalMile));
	public static bool operator ==(NauticalMiles l, Inches r) => l.Equals(r.To(LengthConversions.NauticalMile));
	public static bool operator ==(NauticalMiles l, Feet r) => l.Equals(r.To(LengthConversions.NauticalMile));
	public static bool operator ==(NauticalMiles l, Kilometers r) => l.Equals(r.To(LengthConversions.NauticalMile));

	public static bool operator !=(NauticalMiles l, NauticalMiles r) => !l.Equals(r);
	public static bool operator !=(NauticalMiles l, Meters r) => !l.Equals(r.To(LengthConversions.NauticalMile));
	public static bool operator !=(NauticalMiles l, Inches r) => !l.Equals(r.To(LengthConversions.NauticalMile));
	public static bool operator !=(NauticalMiles l, Feet r) => !l.Equals(r.To(LengthConversions.NauticalMile));
	public static bool operator !=(NauticalMiles l, Kilometers r) => !l.Equals(r.To(LengthConversions.NauticalMile));

	#endregion

	public double UnitValue => unitValue;

	ILinearConversion ILength.Conversion => LengthConversions.NauticalMile;

	double ILength.SiValue => unitValue * LengthConversions.NauticalMile.ToSiFactor;

	public int CompareTo(ILength other) => UnitValue.CompareTo(other.To(LengthConversions.NauticalMile).UnitValue);

	public static bool operator <(NauticalMiles l, NauticalMiles r) => l.UnitValue < r.UnitValue;
	public static bool operator <(NauticalMiles l, Meters r) => l < r.To(LengthConversions.NauticalMile);
	public static bool operator <(NauticalMiles l, Inches r) => l < r.To(LengthConversions.NauticalMile);
	public static bool operator <(NauticalMiles l, Feet r) => l < r.To(LengthConversions.NauticalMile);
	public static bool operator <(NauticalMiles l, Kilometers r) => l < r.To(LengthConversions.NauticalMile);

	public static bool operator <=(NauticalMiles l, NauticalMiles r) => l.UnitValue <= r.UnitValue;
	public static bool operator <=(NauticalMiles l, Meters r) => l <= r.To(LengthConversions.NauticalMile);
	public static bool operator <=(NauticalMiles l, Inches r) => l <= r.To(LengthConversions.NauticalMile);
	public static bool operator <=(NauticalMiles l, Feet r) => l <= r.To(LengthConversions.NauticalMile);
	public static bool operator <=(NauticalMiles l, Kilometers r) => l <= r.To(LengthConversions.NauticalMile);

	public static bool operator >(NauticalMiles l, NauticalMiles r) => l.UnitValue > r.UnitValue;
	public static bool operator >(NauticalMiles l, Meters r) => l > r.To(LengthConversions.NauticalMile);
	public static bool operator >(NauticalMiles l, Inches r) => l > r.To(LengthConversions.NauticalMile);
	public static bool operator >(NauticalMiles l, Feet r) => l > r.To(LengthConversions.NauticalMile);
	public static bool operator >(NauticalMiles l, Kilometers r) => l > r.To(LengthConversions.NauticalMile);

	public static bool operator >=(NauticalMiles l, NauticalMiles r) => l.UnitValue >= r.UnitValue;
	public static bool operator >=(NauticalMiles l, Meters r) => l >= r.To(LengthConversions.NauticalMile);
	public static bool operator >=(NauticalMiles l, Inches r) => l >= r.To(LengthConversions.NauticalMile);
	public static bool operator >=(NauticalMiles l, Feet r) => l >= r.To(LengthConversions.NauticalMile);
	public static bool operator >=(NauticalMiles l, Kilometers r) => l >= r.To(LengthConversions.NauticalMile);

}

