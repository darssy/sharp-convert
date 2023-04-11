using System;

namespace MmiSoft.Core.Math.Units.Struct;

using static LengthConversions;
using static TimeConversions;

public interface ISpeed
{
	double UnitValue { get; }
	internal ILinearConversion Conversion { get; }
	internal double SiValue { get; }
	//internal double SiValue => UnitValue * Conversion.ToSiFactor;
}

[Serializable]
public struct MetersPerSecond : ISpeed
{
	public static readonly MetersPerSecond Zero = new();

	private readonly double unitValue;

	public MetersPerSecond(double speed)
	{
		unitValue = speed;
	}

	public static MetersPerSecond operator -(MetersPerSecond x)
	{
		return new MetersPerSecond(-x.unitValue);
	}

	public static MetersPerSecond operator -(MetersPerSecond l, MetersPerSecond r)
	{
		return new MetersPerSecond(l.unitValue - r.unitValue);
	}

	public static MetersPerSecond operator +(MetersPerSecond l, MetersPerSecond r)
	{
		return new MetersPerSecond(l.unitValue + r.unitValue);
	}

	public double UnitValue => unitValue;
	ILinearConversion ISpeed.Conversion => SpeedConversions.MeterPerSecond;
	double ISpeed.SiValue  => unitValue/* * SpeedConversions.MeterPerSecond.ToSiFactor*/;
}

[Serializable]
public readonly struct FeetPerMinute : ISpeed
{
	public static readonly FeetPerMinute Zero = new();

	public FeetPerMinute(double fpm)
	{
		UnitValue = fpm;
	}

	#region multiply operators

	public static Feet operator *(FeetPerMinute u, Minutes t)
	{
		return new Feet(u.UnitValue * t.UnitValue);
	}

	public static Feet operator *(FeetPerMinute u, Hours t)
	{
		return u * t.To(Minute);
	}

	public static Feet operator *(FeetPerMinute u, Seconds t)
	{
		return u * t.To(Minute);
	}

	public static Feet operator *(FeetPerMinute u, TimeSpan t)
	{
		return u * new Minutes(t);
	}

	#endregion

	#region divide operators

	public static Minutes? operator /(Feet s, FeetPerMinute u)
	{
		return u == Zero ? null : new Minutes(s.UnitValue / u.UnitValue);
	}

	public static Minutes? operator /(NauticalMiles s, FeetPerMinute u)
	{
		return s.To(Foot) / u;
	}

	public static Minutes? operator /(Kilometers s, FeetPerMinute u)
	{
		return s.To(Foot) / u;
	}

	public static Minutes? operator /(Meters s, FeetPerMinute u)
	{
		return s.To(Foot) / u;
	}

	#endregion

	public override bool Equals(object obj)
	{
		return obj switch
		{
			FeetPerMinute kts => Equals(kts),
			ISpeed speed => Equals(speed.To(SpeedConversions.FootPerMinute)),
			_ => false
		};
	}

	public bool Equals(FeetPerMinute other) => System.Math.Abs(UnitValue - other.UnitValue) <= 1e-14;

	public override int GetHashCode() => 7 * UnitValue.GetHashCode();

	public static bool operator ==(FeetPerMinute l, FeetPerMinute r) => l.Equals(r);
	public static bool operator ==(FeetPerMinute l, MetersPerSecond r) => l.Equals(r.To(SpeedConversions.FootPerMinute));

	public static bool operator !=(FeetPerMinute l, FeetPerMinute r) => !l.Equals(r);
	public static bool operator !=(FeetPerMinute l, MetersPerSecond r) => !l.Equals(r.To(SpeedConversions.FootPerMinute));

	#region minus operators

	public static FeetPerMinute operator -(FeetPerMinute l, FeetPerMinute r) => new(l.UnitValue - r.UnitValue);

	public static FeetPerMinute operator -(FeetPerMinute l, MetersPerSecond r) => l - r.To(SpeedConversions.FootPerMinute);

	#endregion

	#region plus operators

	public static FeetPerMinute operator +(FeetPerMinute l, FeetPerMinute r) => new(l.UnitValue + r.UnitValue);

	public static FeetPerMinute operator +(FeetPerMinute l, MetersPerSecond r) => l + r.To(SpeedConversions.FootPerMinute);

	#endregion

	public double UnitValue { get; }
	ILinearConversion ISpeed.Conversion => SpeedConversions.FootPerMinute;
	double ISpeed.SiValue => UnitValue * SpeedConversions.FootPerMinute.ToSiFactor;
}

[Serializable]
public readonly struct Knots : ISpeed
{
	public static readonly Knots Zero = new();

	public Knots(double knots)
	{
		UnitValue = knots;
	}

	#region multiply operators

	public static NauticalMiles operator *(Knots u, Hours t)
	{
		return new NauticalMiles(u.UnitValue * t.UnitValue);
	}

	public static NauticalMiles operator *(Knots u, Seconds t) => u * t.To(Hour);

	public static NauticalMiles operator *(Knots u, Minutes t) => u * t.To(Hour);

	public static NauticalMiles operator *(Knots u, TimeSpan t) => u * new Hours(t);

	#endregion

	#region divide operators

	public static Hours? operator /(NauticalMiles s, Knots u)
	{
		return u == Zero ? null : new Hours(s.UnitValue / u.UnitValue);
	}

	public static Hours? operator /(Kilometers s, Knots u)
	{
		return s.To(NauticalMile) / u;
	}

	public static Hours? operator /(Meters s, Knots u)
	{
		return s.To(NauticalMile) / u;
	}

	public static Hours? operator /(Feet s, Knots u)
	{
		return s.To(NauticalMile) / u;
	}

	#endregion

	public override bool Equals(object obj)
	{
		return obj switch
		{
			Knots kts => Equals(kts),
			ISpeed speed => Equals(speed.To(SpeedConversions.Knot)),
			_ => false
		};
	}

	public bool Equals(Knots other) => System.Math.Abs(UnitValue - other.UnitValue) <= 1e-14;

	public override int GetHashCode() => 7 * UnitValue.GetHashCode();

	public static bool operator ==(Knots l, Knots r) => l.Equals(r);
	public static bool operator ==(Knots l, MetersPerSecond r) => l.Equals(r.To(SpeedConversions.Knot));
	public static bool operator ==(Knots l, FeetPerMinute r) => l.Equals(r.To(SpeedConversions.Knot));

	public static bool operator !=(Knots l, Knots r) => !l.Equals(r);
	public static bool operator !=(Knots l, MetersPerSecond r) => !l.Equals(r.To(SpeedConversions.Knot));
	public static bool operator !=(Knots l, FeetPerMinute r) => !l.Equals(r.To(SpeedConversions.Knot));

	#region minus operators

	public static Knots operator -(Knots l, Knots r) => new(l.UnitValue - r.UnitValue);

	public static Knots operator -(Knots l, MetersPerSecond r) => l - r.To(SpeedConversions.Knot);
	public static Knots operator -(Knots l, FeetPerMinute r) => l - r.To(SpeedConversions.Knot);

	#endregion

	#region plus operators

	public static Knots operator +(Knots l, Knots r) => new(l.UnitValue + r.UnitValue);

	public static Knots operator +(Knots l, MetersPerSecond r) => l + r.To(SpeedConversions.Knot);
	public static Knots operator +(Knots l, FeetPerMinute r) => l + r.To(SpeedConversions.Knot);

	#endregion

	public double UnitValue { get; }
	ILinearConversion ISpeed.Conversion => SpeedConversions.Knot;
	double ISpeed.SiValue => UnitValue * SpeedConversions.Knot.ToSiFactor;
}
