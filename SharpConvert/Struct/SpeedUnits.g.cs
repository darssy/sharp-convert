using System;

namespace MmiSoft.Core.Math.Units.Struct;

[Serializable]
public readonly struct MetersPerSecond : ISpeed
{
	public static readonly MetersPerSecond Zero = new();

	private readonly double unitValue;

	public MetersPerSecond(double meterspersecond)
	{
		unitValue = meterspersecond;
	}

	#region minus operators


	public static MetersPerSecond operator -(MetersPerSecond x, MetersPerSecond y)
	{
		return new MetersPerSecond(x.unitValue - y.unitValue);
	}

	public static MetersPerSecond operator -(MetersPerSecond x, KilometersPerHour y)
	{
		return x - y.To(SpeedConversions.MeterPerSecond);
	}

	public static MetersPerSecond operator -(MetersPerSecond x, FeetPerSecond y)
	{
		return x - y.To(SpeedConversions.MeterPerSecond);
	}

	public static MetersPerSecond operator -(MetersPerSecond x, FeetPerMinute y)
	{
		return x - y.To(SpeedConversions.MeterPerSecond);
	}

	public static MetersPerSecond operator -(MetersPerSecond x, Knots y)
	{
		return x - y.To(SpeedConversions.MeterPerSecond);
	}
	#endregion

	#region plus operators

	public static MetersPerSecond operator +(MetersPerSecond x, MetersPerSecond y)
	{
		return new MetersPerSecond(x.unitValue + y.unitValue);
	}

	public static MetersPerSecond operator +(MetersPerSecond x, KilometersPerHour y)
	{
		return x + y.To(SpeedConversions.MeterPerSecond);
	}

	public static MetersPerSecond operator +(MetersPerSecond x, FeetPerSecond y)
	{
		return x + y.To(SpeedConversions.MeterPerSecond);
	}

	public static MetersPerSecond operator +(MetersPerSecond x, FeetPerMinute y)
	{
		return x + y.To(SpeedConversions.MeterPerSecond);
	}

	public static MetersPerSecond operator +(MetersPerSecond x, Knots y)
	{
		return x + y.To(SpeedConversions.MeterPerSecond);
	}

	#endregion

	#region conversion operators


	public static implicit operator MetersPerSecond(KilometersPerHour other)
	{
		return other.To(SpeedConversions.MeterPerSecond);
	}

	public static implicit operator MetersPerSecond(FeetPerSecond other)
	{
		return other.To(SpeedConversions.MeterPerSecond);
	}

	public static implicit operator MetersPerSecond(FeetPerMinute other)
	{
		return other.To(SpeedConversions.MeterPerSecond);
	}

	public static implicit operator MetersPerSecond(Knots other)
	{
		return other.To(SpeedConversions.MeterPerSecond);
	}

	#endregion

	#region Equality overloads and operators

	public override bool Equals(object obj)
	{
		return obj switch
		{
			MetersPerSecond m => Equals(m),
			ISpeed length => Equals(length.To(SpeedConversions.MeterPerSecond)),
			_ => false
		};
	}

	public bool Equals(MetersPerSecond other) => System.Math.Abs(UnitValue - other.UnitValue) <= 1e-14;

	public override int GetHashCode() => 7 * UnitValue.GetHashCode();

	public static bool operator ==(MetersPerSecond l, MetersPerSecond r) => l.Equals(r);

	public static bool operator ==(MetersPerSecond l, KilometersPerHour r) => l.Equals(r.To(SpeedConversions.MeterPerSecond));
	public static bool operator ==(MetersPerSecond l, FeetPerSecond r) => l.Equals(r.To(SpeedConversions.MeterPerSecond));
	public static bool operator ==(MetersPerSecond l, FeetPerMinute r) => l.Equals(r.To(SpeedConversions.MeterPerSecond));
	public static bool operator ==(MetersPerSecond l, Knots r) => l.Equals(r.To(SpeedConversions.MeterPerSecond));

	public static bool operator !=(MetersPerSecond l, MetersPerSecond r) => !l.Equals(r);
	public static bool operator !=(MetersPerSecond l, KilometersPerHour r) => !l.Equals(r.To(SpeedConversions.MeterPerSecond));
	public static bool operator !=(MetersPerSecond l, FeetPerSecond r) => !l.Equals(r.To(SpeedConversions.MeterPerSecond));
	public static bool operator !=(MetersPerSecond l, FeetPerMinute r) => !l.Equals(r.To(SpeedConversions.MeterPerSecond));
	public static bool operator !=(MetersPerSecond l, Knots r) => !l.Equals(r.To(SpeedConversions.MeterPerSecond));

	#endregion

	public static MetersPerSecond operator *(MetersPerSecond m, double f) => new MetersPerSecond(m.unitValue * f);
	public static MetersPerSecond operator *(double f, MetersPerSecond m) => new MetersPerSecond(m.unitValue * f);

	public static double operator /(MetersPerSecond x, MetersPerSecond y) => x.unitValue / y.unitValue;

	public static MetersPerSecond operator /(MetersPerSecond x, double y) => new MetersPerSecond(x.unitValue / y);
	public static MetersPerSecond operator /(MetersPerSecond x, float y) => new MetersPerSecond(x.unitValue / y);
	public static MetersPerSecond operator /(MetersPerSecond x, int y) => new MetersPerSecond(x.unitValue / y);

	public double UnitValue => unitValue;

	ILinearConversion ISpeed.Conversion => SpeedConversions.MeterPerSecond;

	double ISpeed.SiValue => unitValue ;

	public int CompareTo(ISpeed other) => UnitValue.CompareTo(other.To(SpeedConversions.MeterPerSecond).UnitValue);

	public static bool operator <(MetersPerSecond l, MetersPerSecond r) => l.UnitValue < r.UnitValue;
	public static bool operator <(MetersPerSecond l, KilometersPerHour r) => l < r.To(SpeedConversions.MeterPerSecond);
	public static bool operator <(MetersPerSecond l, FeetPerSecond r) => l < r.To(SpeedConversions.MeterPerSecond);
	public static bool operator <(MetersPerSecond l, FeetPerMinute r) => l < r.To(SpeedConversions.MeterPerSecond);
	public static bool operator <(MetersPerSecond l, Knots r) => l < r.To(SpeedConversions.MeterPerSecond);

	public static bool operator <=(MetersPerSecond l, MetersPerSecond r) => l.UnitValue <= r.UnitValue;
	public static bool operator <=(MetersPerSecond l, KilometersPerHour r) => l <= r.To(SpeedConversions.MeterPerSecond);
	public static bool operator <=(MetersPerSecond l, FeetPerSecond r) => l <= r.To(SpeedConversions.MeterPerSecond);
	public static bool operator <=(MetersPerSecond l, FeetPerMinute r) => l <= r.To(SpeedConversions.MeterPerSecond);
	public static bool operator <=(MetersPerSecond l, Knots r) => l <= r.To(SpeedConversions.MeterPerSecond);

	public static bool operator >(MetersPerSecond l, MetersPerSecond r) => l.UnitValue > r.UnitValue;
	public static bool operator >(MetersPerSecond l, KilometersPerHour r) => l > r.To(SpeedConversions.MeterPerSecond);
	public static bool operator >(MetersPerSecond l, FeetPerSecond r) => l > r.To(SpeedConversions.MeterPerSecond);
	public static bool operator >(MetersPerSecond l, FeetPerMinute r) => l > r.To(SpeedConversions.MeterPerSecond);
	public static bool operator >(MetersPerSecond l, Knots r) => l > r.To(SpeedConversions.MeterPerSecond);

	public static bool operator >=(MetersPerSecond l, MetersPerSecond r) => l.UnitValue >= r.UnitValue;
	public static bool operator >=(MetersPerSecond l, KilometersPerHour r) => l >= r.To(SpeedConversions.MeterPerSecond);
	public static bool operator >=(MetersPerSecond l, FeetPerSecond r) => l >= r.To(SpeedConversions.MeterPerSecond);
	public static bool operator >=(MetersPerSecond l, FeetPerMinute r) => l >= r.To(SpeedConversions.MeterPerSecond);
	public static bool operator >=(MetersPerSecond l, Knots r) => l >= r.To(SpeedConversions.MeterPerSecond);

}

[Serializable]
public readonly struct KilometersPerHour : ISpeed
{
	public static readonly KilometersPerHour Zero = new();

	private readonly double unitValue;

	public KilometersPerHour(double kilometersperhour)
	{
		unitValue = kilometersperhour;
	}

	#region minus operators


	public static KilometersPerHour operator -(KilometersPerHour x, KilometersPerHour y)
	{
		return new KilometersPerHour(x.unitValue - y.unitValue);
	}

	public static KilometersPerHour operator -(KilometersPerHour x, MetersPerSecond y)
	{
		return x - y.To(SpeedConversions.KilometerPerHour);
	}

	public static KilometersPerHour operator -(KilometersPerHour x, FeetPerSecond y)
	{
		return x - y.To(SpeedConversions.KilometerPerHour);
	}

	public static KilometersPerHour operator -(KilometersPerHour x, FeetPerMinute y)
	{
		return x - y.To(SpeedConversions.KilometerPerHour);
	}

	public static KilometersPerHour operator -(KilometersPerHour x, Knots y)
	{
		return x - y.To(SpeedConversions.KilometerPerHour);
	}
	#endregion

	#region plus operators

	public static KilometersPerHour operator +(KilometersPerHour x, KilometersPerHour y)
	{
		return new KilometersPerHour(x.unitValue + y.unitValue);
	}

	public static KilometersPerHour operator +(KilometersPerHour x, MetersPerSecond y)
	{
		return x + y.To(SpeedConversions.KilometerPerHour);
	}

	public static KilometersPerHour operator +(KilometersPerHour x, FeetPerSecond y)
	{
		return x + y.To(SpeedConversions.KilometerPerHour);
	}

	public static KilometersPerHour operator +(KilometersPerHour x, FeetPerMinute y)
	{
		return x + y.To(SpeedConversions.KilometerPerHour);
	}

	public static KilometersPerHour operator +(KilometersPerHour x, Knots y)
	{
		return x + y.To(SpeedConversions.KilometerPerHour);
	}

	#endregion

	#region conversion operators


	public static implicit operator KilometersPerHour(MetersPerSecond other)
	{
		return other.To(SpeedConversions.KilometerPerHour);
	}

	public static implicit operator KilometersPerHour(FeetPerSecond other)
	{
		return other.To(SpeedConversions.KilometerPerHour);
	}

	public static implicit operator KilometersPerHour(FeetPerMinute other)
	{
		return other.To(SpeedConversions.KilometerPerHour);
	}

	public static implicit operator KilometersPerHour(Knots other)
	{
		return other.To(SpeedConversions.KilometerPerHour);
	}

	#endregion

	#region Equality overloads and operators

	public override bool Equals(object obj)
	{
		return obj switch
		{
			KilometersPerHour k => Equals(k),
			ISpeed length => Equals(length.To(SpeedConversions.KilometerPerHour)),
			_ => false
		};
	}

	public bool Equals(KilometersPerHour other) => System.Math.Abs(UnitValue - other.UnitValue) <= 1e-14;

	public override int GetHashCode() => 7 * UnitValue.GetHashCode();

	public static bool operator ==(KilometersPerHour l, KilometersPerHour r) => l.Equals(r);

	public static bool operator ==(KilometersPerHour l, MetersPerSecond r) => l.Equals(r.To(SpeedConversions.KilometerPerHour));
	public static bool operator ==(KilometersPerHour l, FeetPerSecond r) => l.Equals(r.To(SpeedConversions.KilometerPerHour));
	public static bool operator ==(KilometersPerHour l, FeetPerMinute r) => l.Equals(r.To(SpeedConversions.KilometerPerHour));
	public static bool operator ==(KilometersPerHour l, Knots r) => l.Equals(r.To(SpeedConversions.KilometerPerHour));

	public static bool operator !=(KilometersPerHour l, KilometersPerHour r) => !l.Equals(r);
	public static bool operator !=(KilometersPerHour l, MetersPerSecond r) => !l.Equals(r.To(SpeedConversions.KilometerPerHour));
	public static bool operator !=(KilometersPerHour l, FeetPerSecond r) => !l.Equals(r.To(SpeedConversions.KilometerPerHour));
	public static bool operator !=(KilometersPerHour l, FeetPerMinute r) => !l.Equals(r.To(SpeedConversions.KilometerPerHour));
	public static bool operator !=(KilometersPerHour l, Knots r) => !l.Equals(r.To(SpeedConversions.KilometerPerHour));

	#endregion

	public static KilometersPerHour operator *(KilometersPerHour m, double f) => new KilometersPerHour(m.unitValue * f);
	public static KilometersPerHour operator *(double f, KilometersPerHour m) => new KilometersPerHour(m.unitValue * f);

	public static double operator /(KilometersPerHour x, KilometersPerHour y) => x.unitValue / y.unitValue;

	public static KilometersPerHour operator /(KilometersPerHour x, double y) => new KilometersPerHour(x.unitValue / y);
	public static KilometersPerHour operator /(KilometersPerHour x, float y) => new KilometersPerHour(x.unitValue / y);
	public static KilometersPerHour operator /(KilometersPerHour x, int y) => new KilometersPerHour(x.unitValue / y);

	public double UnitValue => unitValue;

	ILinearConversion ISpeed.Conversion => SpeedConversions.KilometerPerHour;

	double ISpeed.SiValue => unitValue * SpeedConversions.KilometerPerHour.ToSiFactor;

	public int CompareTo(ISpeed other) => UnitValue.CompareTo(other.To(SpeedConversions.KilometerPerHour).UnitValue);

	public static bool operator <(KilometersPerHour l, KilometersPerHour r) => l.UnitValue < r.UnitValue;
	public static bool operator <(KilometersPerHour l, MetersPerSecond r) => l < r.To(SpeedConversions.KilometerPerHour);
	public static bool operator <(KilometersPerHour l, FeetPerSecond r) => l < r.To(SpeedConversions.KilometerPerHour);
	public static bool operator <(KilometersPerHour l, FeetPerMinute r) => l < r.To(SpeedConversions.KilometerPerHour);
	public static bool operator <(KilometersPerHour l, Knots r) => l < r.To(SpeedConversions.KilometerPerHour);

	public static bool operator <=(KilometersPerHour l, KilometersPerHour r) => l.UnitValue <= r.UnitValue;
	public static bool operator <=(KilometersPerHour l, MetersPerSecond r) => l <= r.To(SpeedConversions.KilometerPerHour);
	public static bool operator <=(KilometersPerHour l, FeetPerSecond r) => l <= r.To(SpeedConversions.KilometerPerHour);
	public static bool operator <=(KilometersPerHour l, FeetPerMinute r) => l <= r.To(SpeedConversions.KilometerPerHour);
	public static bool operator <=(KilometersPerHour l, Knots r) => l <= r.To(SpeedConversions.KilometerPerHour);

	public static bool operator >(KilometersPerHour l, KilometersPerHour r) => l.UnitValue > r.UnitValue;
	public static bool operator >(KilometersPerHour l, MetersPerSecond r) => l > r.To(SpeedConversions.KilometerPerHour);
	public static bool operator >(KilometersPerHour l, FeetPerSecond r) => l > r.To(SpeedConversions.KilometerPerHour);
	public static bool operator >(KilometersPerHour l, FeetPerMinute r) => l > r.To(SpeedConversions.KilometerPerHour);
	public static bool operator >(KilometersPerHour l, Knots r) => l > r.To(SpeedConversions.KilometerPerHour);

	public static bool operator >=(KilometersPerHour l, KilometersPerHour r) => l.UnitValue >= r.UnitValue;
	public static bool operator >=(KilometersPerHour l, MetersPerSecond r) => l >= r.To(SpeedConversions.KilometerPerHour);
	public static bool operator >=(KilometersPerHour l, FeetPerSecond r) => l >= r.To(SpeedConversions.KilometerPerHour);
	public static bool operator >=(KilometersPerHour l, FeetPerMinute r) => l >= r.To(SpeedConversions.KilometerPerHour);
	public static bool operator >=(KilometersPerHour l, Knots r) => l >= r.To(SpeedConversions.KilometerPerHour);

}

[Serializable]
public readonly struct FeetPerSecond : ISpeed
{
	public static readonly FeetPerSecond Zero = new();

	private readonly double unitValue;

	public FeetPerSecond(double feetpersecond)
	{
		unitValue = feetpersecond;
	}

	#region minus operators


	public static FeetPerSecond operator -(FeetPerSecond x, FeetPerSecond y)
	{
		return new FeetPerSecond(x.unitValue - y.unitValue);
	}

	public static FeetPerSecond operator -(FeetPerSecond x, MetersPerSecond y)
	{
		return x - y.To(SpeedConversions.FootPerSecond);
	}

	public static FeetPerSecond operator -(FeetPerSecond x, KilometersPerHour y)
	{
		return x - y.To(SpeedConversions.FootPerSecond);
	}

	public static FeetPerSecond operator -(FeetPerSecond x, FeetPerMinute y)
	{
		return x - y.To(SpeedConversions.FootPerSecond);
	}

	public static FeetPerSecond operator -(FeetPerSecond x, Knots y)
	{
		return x - y.To(SpeedConversions.FootPerSecond);
	}
	#endregion

	#region plus operators

	public static FeetPerSecond operator +(FeetPerSecond x, FeetPerSecond y)
	{
		return new FeetPerSecond(x.unitValue + y.unitValue);
	}

	public static FeetPerSecond operator +(FeetPerSecond x, MetersPerSecond y)
	{
		return x + y.To(SpeedConversions.FootPerSecond);
	}

	public static FeetPerSecond operator +(FeetPerSecond x, KilometersPerHour y)
	{
		return x + y.To(SpeedConversions.FootPerSecond);
	}

	public static FeetPerSecond operator +(FeetPerSecond x, FeetPerMinute y)
	{
		return x + y.To(SpeedConversions.FootPerSecond);
	}

	public static FeetPerSecond operator +(FeetPerSecond x, Knots y)
	{
		return x + y.To(SpeedConversions.FootPerSecond);
	}

	#endregion

	#region conversion operators


	public static implicit operator FeetPerSecond(MetersPerSecond other)
	{
		return other.To(SpeedConversions.FootPerSecond);
	}

	public static implicit operator FeetPerSecond(KilometersPerHour other)
	{
		return other.To(SpeedConversions.FootPerSecond);
	}

	public static implicit operator FeetPerSecond(FeetPerMinute other)
	{
		return other.To(SpeedConversions.FootPerSecond);
	}

	public static implicit operator FeetPerSecond(Knots other)
	{
		return other.To(SpeedConversions.FootPerSecond);
	}

	#endregion

	#region Equality overloads and operators

	public override bool Equals(object obj)
	{
		return obj switch
		{
			FeetPerSecond f => Equals(f),
			ISpeed length => Equals(length.To(SpeedConversions.FootPerSecond)),
			_ => false
		};
	}

	public bool Equals(FeetPerSecond other) => System.Math.Abs(UnitValue - other.UnitValue) <= 1e-14;

	public override int GetHashCode() => 7 * UnitValue.GetHashCode();

	public static bool operator ==(FeetPerSecond l, FeetPerSecond r) => l.Equals(r);

	public static bool operator ==(FeetPerSecond l, MetersPerSecond r) => l.Equals(r.To(SpeedConversions.FootPerSecond));
	public static bool operator ==(FeetPerSecond l, KilometersPerHour r) => l.Equals(r.To(SpeedConversions.FootPerSecond));
	public static bool operator ==(FeetPerSecond l, FeetPerMinute r) => l.Equals(r.To(SpeedConversions.FootPerSecond));
	public static bool operator ==(FeetPerSecond l, Knots r) => l.Equals(r.To(SpeedConversions.FootPerSecond));

	public static bool operator !=(FeetPerSecond l, FeetPerSecond r) => !l.Equals(r);
	public static bool operator !=(FeetPerSecond l, MetersPerSecond r) => !l.Equals(r.To(SpeedConversions.FootPerSecond));
	public static bool operator !=(FeetPerSecond l, KilometersPerHour r) => !l.Equals(r.To(SpeedConversions.FootPerSecond));
	public static bool operator !=(FeetPerSecond l, FeetPerMinute r) => !l.Equals(r.To(SpeedConversions.FootPerSecond));
	public static bool operator !=(FeetPerSecond l, Knots r) => !l.Equals(r.To(SpeedConversions.FootPerSecond));

	#endregion

	public static FeetPerSecond operator *(FeetPerSecond m, double f) => new FeetPerSecond(m.unitValue * f);
	public static FeetPerSecond operator *(double f, FeetPerSecond m) => new FeetPerSecond(m.unitValue * f);

	public static double operator /(FeetPerSecond x, FeetPerSecond y) => x.unitValue / y.unitValue;

	public static FeetPerSecond operator /(FeetPerSecond x, double y) => new FeetPerSecond(x.unitValue / y);
	public static FeetPerSecond operator /(FeetPerSecond x, float y) => new FeetPerSecond(x.unitValue / y);
	public static FeetPerSecond operator /(FeetPerSecond x, int y) => new FeetPerSecond(x.unitValue / y);

	public double UnitValue => unitValue;

	ILinearConversion ISpeed.Conversion => SpeedConversions.FootPerSecond;

	double ISpeed.SiValue => unitValue * SpeedConversions.FootPerSecond.ToSiFactor;

	public int CompareTo(ISpeed other) => UnitValue.CompareTo(other.To(SpeedConversions.FootPerSecond).UnitValue);

	public static bool operator <(FeetPerSecond l, FeetPerSecond r) => l.UnitValue < r.UnitValue;
	public static bool operator <(FeetPerSecond l, MetersPerSecond r) => l < r.To(SpeedConversions.FootPerSecond);
	public static bool operator <(FeetPerSecond l, KilometersPerHour r) => l < r.To(SpeedConversions.FootPerSecond);
	public static bool operator <(FeetPerSecond l, FeetPerMinute r) => l < r.To(SpeedConversions.FootPerSecond);
	public static bool operator <(FeetPerSecond l, Knots r) => l < r.To(SpeedConversions.FootPerSecond);

	public static bool operator <=(FeetPerSecond l, FeetPerSecond r) => l.UnitValue <= r.UnitValue;
	public static bool operator <=(FeetPerSecond l, MetersPerSecond r) => l <= r.To(SpeedConversions.FootPerSecond);
	public static bool operator <=(FeetPerSecond l, KilometersPerHour r) => l <= r.To(SpeedConversions.FootPerSecond);
	public static bool operator <=(FeetPerSecond l, FeetPerMinute r) => l <= r.To(SpeedConversions.FootPerSecond);
	public static bool operator <=(FeetPerSecond l, Knots r) => l <= r.To(SpeedConversions.FootPerSecond);

	public static bool operator >(FeetPerSecond l, FeetPerSecond r) => l.UnitValue > r.UnitValue;
	public static bool operator >(FeetPerSecond l, MetersPerSecond r) => l > r.To(SpeedConversions.FootPerSecond);
	public static bool operator >(FeetPerSecond l, KilometersPerHour r) => l > r.To(SpeedConversions.FootPerSecond);
	public static bool operator >(FeetPerSecond l, FeetPerMinute r) => l > r.To(SpeedConversions.FootPerSecond);
	public static bool operator >(FeetPerSecond l, Knots r) => l > r.To(SpeedConversions.FootPerSecond);

	public static bool operator >=(FeetPerSecond l, FeetPerSecond r) => l.UnitValue >= r.UnitValue;
	public static bool operator >=(FeetPerSecond l, MetersPerSecond r) => l >= r.To(SpeedConversions.FootPerSecond);
	public static bool operator >=(FeetPerSecond l, KilometersPerHour r) => l >= r.To(SpeedConversions.FootPerSecond);
	public static bool operator >=(FeetPerSecond l, FeetPerMinute r) => l >= r.To(SpeedConversions.FootPerSecond);
	public static bool operator >=(FeetPerSecond l, Knots r) => l >= r.To(SpeedConversions.FootPerSecond);

}

[Serializable]
public readonly struct FeetPerMinute : ISpeed
{
	public static readonly FeetPerMinute Zero = new();

	private readonly double unitValue;

	public FeetPerMinute(double feetperminute)
	{
		unitValue = feetperminute;
	}

	#region minus operators


	public static FeetPerMinute operator -(FeetPerMinute x, FeetPerMinute y)
	{
		return new FeetPerMinute(x.unitValue - y.unitValue);
	}

	public static FeetPerMinute operator -(FeetPerMinute x, MetersPerSecond y)
	{
		return x - y.To(SpeedConversions.FootPerMinute);
	}

	public static FeetPerMinute operator -(FeetPerMinute x, KilometersPerHour y)
	{
		return x - y.To(SpeedConversions.FootPerMinute);
	}

	public static FeetPerMinute operator -(FeetPerMinute x, FeetPerSecond y)
	{
		return x - y.To(SpeedConversions.FootPerMinute);
	}

	public static FeetPerMinute operator -(FeetPerMinute x, Knots y)
	{
		return x - y.To(SpeedConversions.FootPerMinute);
	}
	#endregion

	#region plus operators

	public static FeetPerMinute operator +(FeetPerMinute x, FeetPerMinute y)
	{
		return new FeetPerMinute(x.unitValue + y.unitValue);
	}

	public static FeetPerMinute operator +(FeetPerMinute x, MetersPerSecond y)
	{
		return x + y.To(SpeedConversions.FootPerMinute);
	}

	public static FeetPerMinute operator +(FeetPerMinute x, KilometersPerHour y)
	{
		return x + y.To(SpeedConversions.FootPerMinute);
	}

	public static FeetPerMinute operator +(FeetPerMinute x, FeetPerSecond y)
	{
		return x + y.To(SpeedConversions.FootPerMinute);
	}

	public static FeetPerMinute operator +(FeetPerMinute x, Knots y)
	{
		return x + y.To(SpeedConversions.FootPerMinute);
	}

	#endregion

	#region conversion operators


	public static implicit operator FeetPerMinute(MetersPerSecond other)
	{
		return other.To(SpeedConversions.FootPerMinute);
	}

	public static implicit operator FeetPerMinute(KilometersPerHour other)
	{
		return other.To(SpeedConversions.FootPerMinute);
	}

	public static implicit operator FeetPerMinute(FeetPerSecond other)
	{
		return other.To(SpeedConversions.FootPerMinute);
	}

	public static implicit operator FeetPerMinute(Knots other)
	{
		return other.To(SpeedConversions.FootPerMinute);
	}

	#endregion

	#region Equality overloads and operators

	public override bool Equals(object obj)
	{
		return obj switch
		{
			FeetPerMinute f => Equals(f),
			ISpeed length => Equals(length.To(SpeedConversions.FootPerMinute)),
			_ => false
		};
	}

	public bool Equals(FeetPerMinute other) => System.Math.Abs(UnitValue - other.UnitValue) <= 1e-14;

	public override int GetHashCode() => 7 * UnitValue.GetHashCode();

	public static bool operator ==(FeetPerMinute l, FeetPerMinute r) => l.Equals(r);

	public static bool operator ==(FeetPerMinute l, MetersPerSecond r) => l.Equals(r.To(SpeedConversions.FootPerMinute));
	public static bool operator ==(FeetPerMinute l, KilometersPerHour r) => l.Equals(r.To(SpeedConversions.FootPerMinute));
	public static bool operator ==(FeetPerMinute l, FeetPerSecond r) => l.Equals(r.To(SpeedConversions.FootPerMinute));
	public static bool operator ==(FeetPerMinute l, Knots r) => l.Equals(r.To(SpeedConversions.FootPerMinute));

	public static bool operator !=(FeetPerMinute l, FeetPerMinute r) => !l.Equals(r);
	public static bool operator !=(FeetPerMinute l, MetersPerSecond r) => !l.Equals(r.To(SpeedConversions.FootPerMinute));
	public static bool operator !=(FeetPerMinute l, KilometersPerHour r) => !l.Equals(r.To(SpeedConversions.FootPerMinute));
	public static bool operator !=(FeetPerMinute l, FeetPerSecond r) => !l.Equals(r.To(SpeedConversions.FootPerMinute));
	public static bool operator !=(FeetPerMinute l, Knots r) => !l.Equals(r.To(SpeedConversions.FootPerMinute));

	#endregion

	public static FeetPerMinute operator *(FeetPerMinute m, double f) => new FeetPerMinute(m.unitValue * f);
	public static FeetPerMinute operator *(double f, FeetPerMinute m) => new FeetPerMinute(m.unitValue * f);

	public static double operator /(FeetPerMinute x, FeetPerMinute y) => x.unitValue / y.unitValue;

	public static FeetPerMinute operator /(FeetPerMinute x, double y) => new FeetPerMinute(x.unitValue / y);
	public static FeetPerMinute operator /(FeetPerMinute x, float y) => new FeetPerMinute(x.unitValue / y);
	public static FeetPerMinute operator /(FeetPerMinute x, int y) => new FeetPerMinute(x.unitValue / y);

	public double UnitValue => unitValue;

	ILinearConversion ISpeed.Conversion => SpeedConversions.FootPerMinute;

	double ISpeed.SiValue => unitValue * SpeedConversions.FootPerMinute.ToSiFactor;

	public int CompareTo(ISpeed other) => UnitValue.CompareTo(other.To(SpeedConversions.FootPerMinute).UnitValue);

	public static bool operator <(FeetPerMinute l, FeetPerMinute r) => l.UnitValue < r.UnitValue;
	public static bool operator <(FeetPerMinute l, MetersPerSecond r) => l < r.To(SpeedConversions.FootPerMinute);
	public static bool operator <(FeetPerMinute l, KilometersPerHour r) => l < r.To(SpeedConversions.FootPerMinute);
	public static bool operator <(FeetPerMinute l, FeetPerSecond r) => l < r.To(SpeedConversions.FootPerMinute);
	public static bool operator <(FeetPerMinute l, Knots r) => l < r.To(SpeedConversions.FootPerMinute);

	public static bool operator <=(FeetPerMinute l, FeetPerMinute r) => l.UnitValue <= r.UnitValue;
	public static bool operator <=(FeetPerMinute l, MetersPerSecond r) => l <= r.To(SpeedConversions.FootPerMinute);
	public static bool operator <=(FeetPerMinute l, KilometersPerHour r) => l <= r.To(SpeedConversions.FootPerMinute);
	public static bool operator <=(FeetPerMinute l, FeetPerSecond r) => l <= r.To(SpeedConversions.FootPerMinute);
	public static bool operator <=(FeetPerMinute l, Knots r) => l <= r.To(SpeedConversions.FootPerMinute);

	public static bool operator >(FeetPerMinute l, FeetPerMinute r) => l.UnitValue > r.UnitValue;
	public static bool operator >(FeetPerMinute l, MetersPerSecond r) => l > r.To(SpeedConversions.FootPerMinute);
	public static bool operator >(FeetPerMinute l, KilometersPerHour r) => l > r.To(SpeedConversions.FootPerMinute);
	public static bool operator >(FeetPerMinute l, FeetPerSecond r) => l > r.To(SpeedConversions.FootPerMinute);
	public static bool operator >(FeetPerMinute l, Knots r) => l > r.To(SpeedConversions.FootPerMinute);

	public static bool operator >=(FeetPerMinute l, FeetPerMinute r) => l.UnitValue >= r.UnitValue;
	public static bool operator >=(FeetPerMinute l, MetersPerSecond r) => l >= r.To(SpeedConversions.FootPerMinute);
	public static bool operator >=(FeetPerMinute l, KilometersPerHour r) => l >= r.To(SpeedConversions.FootPerMinute);
	public static bool operator >=(FeetPerMinute l, FeetPerSecond r) => l >= r.To(SpeedConversions.FootPerMinute);
	public static bool operator >=(FeetPerMinute l, Knots r) => l >= r.To(SpeedConversions.FootPerMinute);

}

[Serializable]
public readonly struct Knots : ISpeed
{
	public static readonly Knots Zero = new();

	private readonly double unitValue;

	public Knots(double knots)
	{
		unitValue = knots;
	}

	#region minus operators


	public static Knots operator -(Knots x, Knots y)
	{
		return new Knots(x.unitValue - y.unitValue);
	}

	public static Knots operator -(Knots x, MetersPerSecond y)
	{
		return x - y.To(SpeedConversions.Knot);
	}

	public static Knots operator -(Knots x, KilometersPerHour y)
	{
		return x - y.To(SpeedConversions.Knot);
	}

	public static Knots operator -(Knots x, FeetPerSecond y)
	{
		return x - y.To(SpeedConversions.Knot);
	}

	public static Knots operator -(Knots x, FeetPerMinute y)
	{
		return x - y.To(SpeedConversions.Knot);
	}
	#endregion

	#region plus operators

	public static Knots operator +(Knots x, Knots y)
	{
		return new Knots(x.unitValue + y.unitValue);
	}

	public static Knots operator +(Knots x, MetersPerSecond y)
	{
		return x + y.To(SpeedConversions.Knot);
	}

	public static Knots operator +(Knots x, KilometersPerHour y)
	{
		return x + y.To(SpeedConversions.Knot);
	}

	public static Knots operator +(Knots x, FeetPerSecond y)
	{
		return x + y.To(SpeedConversions.Knot);
	}

	public static Knots operator +(Knots x, FeetPerMinute y)
	{
		return x + y.To(SpeedConversions.Knot);
	}

	#endregion

	#region conversion operators


	public static implicit operator Knots(MetersPerSecond other)
	{
		return other.To(SpeedConversions.Knot);
	}

	public static implicit operator Knots(KilometersPerHour other)
	{
		return other.To(SpeedConversions.Knot);
	}

	public static implicit operator Knots(FeetPerSecond other)
	{
		return other.To(SpeedConversions.Knot);
	}

	public static implicit operator Knots(FeetPerMinute other)
	{
		return other.To(SpeedConversions.Knot);
	}

	#endregion

	#region Equality overloads and operators

	public override bool Equals(object obj)
	{
		return obj switch
		{
			Knots k => Equals(k),
			ISpeed length => Equals(length.To(SpeedConversions.Knot)),
			_ => false
		};
	}

	public bool Equals(Knots other) => System.Math.Abs(UnitValue - other.UnitValue) <= 1e-14;

	public override int GetHashCode() => 7 * UnitValue.GetHashCode();

	public static bool operator ==(Knots l, Knots r) => l.Equals(r);

	public static bool operator ==(Knots l, MetersPerSecond r) => l.Equals(r.To(SpeedConversions.Knot));
	public static bool operator ==(Knots l, KilometersPerHour r) => l.Equals(r.To(SpeedConversions.Knot));
	public static bool operator ==(Knots l, FeetPerSecond r) => l.Equals(r.To(SpeedConversions.Knot));
	public static bool operator ==(Knots l, FeetPerMinute r) => l.Equals(r.To(SpeedConversions.Knot));

	public static bool operator !=(Knots l, Knots r) => !l.Equals(r);
	public static bool operator !=(Knots l, MetersPerSecond r) => !l.Equals(r.To(SpeedConversions.Knot));
	public static bool operator !=(Knots l, KilometersPerHour r) => !l.Equals(r.To(SpeedConversions.Knot));
	public static bool operator !=(Knots l, FeetPerSecond r) => !l.Equals(r.To(SpeedConversions.Knot));
	public static bool operator !=(Knots l, FeetPerMinute r) => !l.Equals(r.To(SpeedConversions.Knot));

	#endregion

	public static Knots operator *(Knots m, double f) => new Knots(m.unitValue * f);
	public static Knots operator *(double f, Knots m) => new Knots(m.unitValue * f);

	public static double operator /(Knots x, Knots y) => x.unitValue / y.unitValue;

	public static Knots operator /(Knots x, double y) => new Knots(x.unitValue / y);
	public static Knots operator /(Knots x, float y) => new Knots(x.unitValue / y);
	public static Knots operator /(Knots x, int y) => new Knots(x.unitValue / y);

	public double UnitValue => unitValue;

	ILinearConversion ISpeed.Conversion => SpeedConversions.Knot;

	double ISpeed.SiValue => unitValue * SpeedConversions.Knot.ToSiFactor;

	public int CompareTo(ISpeed other) => UnitValue.CompareTo(other.To(SpeedConversions.Knot).UnitValue);

	public static bool operator <(Knots l, Knots r) => l.UnitValue < r.UnitValue;
	public static bool operator <(Knots l, MetersPerSecond r) => l < r.To(SpeedConversions.Knot);
	public static bool operator <(Knots l, KilometersPerHour r) => l < r.To(SpeedConversions.Knot);
	public static bool operator <(Knots l, FeetPerSecond r) => l < r.To(SpeedConversions.Knot);
	public static bool operator <(Knots l, FeetPerMinute r) => l < r.To(SpeedConversions.Knot);

	public static bool operator <=(Knots l, Knots r) => l.UnitValue <= r.UnitValue;
	public static bool operator <=(Knots l, MetersPerSecond r) => l <= r.To(SpeedConversions.Knot);
	public static bool operator <=(Knots l, KilometersPerHour r) => l <= r.To(SpeedConversions.Knot);
	public static bool operator <=(Knots l, FeetPerSecond r) => l <= r.To(SpeedConversions.Knot);
	public static bool operator <=(Knots l, FeetPerMinute r) => l <= r.To(SpeedConversions.Knot);

	public static bool operator >(Knots l, Knots r) => l.UnitValue > r.UnitValue;
	public static bool operator >(Knots l, MetersPerSecond r) => l > r.To(SpeedConversions.Knot);
	public static bool operator >(Knots l, KilometersPerHour r) => l > r.To(SpeedConversions.Knot);
	public static bool operator >(Knots l, FeetPerSecond r) => l > r.To(SpeedConversions.Knot);
	public static bool operator >(Knots l, FeetPerMinute r) => l > r.To(SpeedConversions.Knot);

	public static bool operator >=(Knots l, Knots r) => l.UnitValue >= r.UnitValue;
	public static bool operator >=(Knots l, MetersPerSecond r) => l >= r.To(SpeedConversions.Knot);
	public static bool operator >=(Knots l, KilometersPerHour r) => l >= r.To(SpeedConversions.Knot);
	public static bool operator >=(Knots l, FeetPerSecond r) => l >= r.To(SpeedConversions.Knot);
	public static bool operator >=(Knots l, FeetPerMinute r) => l >= r.To(SpeedConversions.Knot);

}

