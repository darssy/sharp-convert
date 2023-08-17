using System;

namespace MmiSoft.Core.Math.Units.Struct;

[Serializable]
public readonly partial struct Meters : ILength
{
	public static readonly Meters Zero = new();

	private readonly double unitValue;

	public Meters(double meters)
	{
		if (meters < 0) throw new ArgumentException("Cowardly refusing to create a negative length unit");
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
			Meters m => Equals(m),
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

	public static Meters operator *(Meters m, double f) => new Meters(m.unitValue * f);
	public static Meters operator *(double f, Meters m) => new Meters(m.unitValue * f);

	public static double operator /(Meters x, Meters y) => x.unitValue / y.unitValue;

	public static Meters operator /(Meters x, double y) => new Meters(x.unitValue / y);
	public static Meters operator /(Meters x, float y) => new Meters(x.unitValue / y);
	public static Meters operator /(Meters x, int y) => new Meters(x.unitValue / y);

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
public readonly partial struct Inches : ILength
{
	public static readonly Inches Zero = new();

	private readonly double unitValue;

	public Inches(double inches)
	{
		if (inches < 0) throw new ArgumentException("Cowardly refusing to create a negative length unit");
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
			Inches i => Equals(i),
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

	public static Inches operator *(Inches m, double f) => new Inches(m.unitValue * f);
	public static Inches operator *(double f, Inches m) => new Inches(m.unitValue * f);

	public static double operator /(Inches x, Inches y) => x.unitValue / y.unitValue;

	public static Inches operator /(Inches x, double y) => new Inches(x.unitValue / y);
	public static Inches operator /(Inches x, float y) => new Inches(x.unitValue / y);
	public static Inches operator /(Inches x, int y) => new Inches(x.unitValue / y);

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
public readonly partial struct Feet : ILength
{
	public static readonly Feet Zero = new();

	private readonly double unitValue;

	public Feet(double feet)
	{
		if (feet < 0) throw new ArgumentException("Cowardly refusing to create a negative length unit");
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
			Feet f => Equals(f),
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

	public static Feet operator *(Feet m, double f) => new Feet(m.unitValue * f);
	public static Feet operator *(double f, Feet m) => new Feet(m.unitValue * f);

	public static double operator /(Feet x, Feet y) => x.unitValue / y.unitValue;

	public static Feet operator /(Feet x, double y) => new Feet(x.unitValue / y);
	public static Feet operator /(Feet x, float y) => new Feet(x.unitValue / y);
	public static Feet operator /(Feet x, int y) => new Feet(x.unitValue / y);

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
public readonly partial struct Kilometers : ILength
{
	public static readonly Kilometers Zero = new();

	private readonly double unitValue;

	public Kilometers(double kilometers)
	{
		if (kilometers < 0) throw new ArgumentException("Cowardly refusing to create a negative length unit");
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
			Kilometers k => Equals(k),
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

	public static Kilometers operator *(Kilometers m, double f) => new Kilometers(m.unitValue * f);
	public static Kilometers operator *(double f, Kilometers m) => new Kilometers(m.unitValue * f);

	public static double operator /(Kilometers x, Kilometers y) => x.unitValue / y.unitValue;

	public static Kilometers operator /(Kilometers x, double y) => new Kilometers(x.unitValue / y);
	public static Kilometers operator /(Kilometers x, float y) => new Kilometers(x.unitValue / y);
	public static Kilometers operator /(Kilometers x, int y) => new Kilometers(x.unitValue / y);

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
public readonly partial struct NauticalMiles : ILength
{
	public static readonly NauticalMiles Zero = new();

	private readonly double unitValue;

	public NauticalMiles(double nauticalmiles)
	{
		if (nauticalmiles < 0) throw new ArgumentException("Cowardly refusing to create a negative length unit");
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
			NauticalMiles n => Equals(n),
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

	public static NauticalMiles operator *(NauticalMiles m, double f) => new NauticalMiles(m.unitValue * f);
	public static NauticalMiles operator *(double f, NauticalMiles m) => new NauticalMiles(m.unitValue * f);

	public static double operator /(NauticalMiles x, NauticalMiles y) => x.unitValue / y.unitValue;

	public static NauticalMiles operator /(NauticalMiles x, double y) => new NauticalMiles(x.unitValue / y);
	public static NauticalMiles operator /(NauticalMiles x, float y) => new NauticalMiles(x.unitValue / y);
	public static NauticalMiles operator /(NauticalMiles x, int y) => new NauticalMiles(x.unitValue / y);

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

