
using System;

namespace MmiSoft.Core.Math.Units.Struct;

[Serializable]
public readonly partial struct Seconds : ITime
{
	public static readonly Seconds Zero = new();

	private readonly double unitValue;

	public Seconds(double seconds)
	{
		if (seconds < 0) throw new ArgumentException("Cowardly refusing to create a negative time unit");
		unitValue = seconds;
	}

	#region minus operators

	public static Seconds operator -(Seconds x) => new Seconds(-x.unitValue);

	public static Seconds operator -(Seconds x, Seconds y)
	{
		return new Seconds(System.Math.Abs(x.unitValue - y.unitValue));
	}

	public static Seconds operator -(Seconds x, Minutes y)
	{
		return x - y.To(TimeConversions.Second);
	}

	public static Seconds operator -(Seconds x, Hours y)
	{
		return x - y.To(TimeConversions.Second);
	}
	#endregion

	#region plus operators

	public static Seconds operator +(Seconds x, Seconds y)
	{
		return new Seconds(x.unitValue + y.unitValue);
	}

	public static Seconds operator +(Seconds x, Minutes y)
	{
		return x + y.To(TimeConversions.Second);
	}

	public static Seconds operator +(Seconds x, Hours y)
	{
		return x + y.To(TimeConversions.Second);
	}

	#endregion

	#region conversion operators


	public static implicit operator Seconds(Minutes other)
	{
		return other.To(TimeConversions.Second);
	}

	public static implicit operator Seconds(Hours other)
	{
		return other.To(TimeConversions.Second);
	}

	#endregion

	#region Equality overloads and operators

	public override bool Equals(object obj)
	{
		return obj switch
		{
			Seconds s => Equals(s),
			ITime length => Equals(length.To(TimeConversions.Second)),
			_ => false
		};
	}

	public bool Equals(Seconds other) => System.Math.Abs(UnitValue - other.UnitValue) <= 1e-14;

	public override int GetHashCode() => 7 * UnitValue.GetHashCode();

	public static bool operator ==(Seconds l, Seconds r) => l.Equals(r);

	public static bool operator ==(Seconds l, Minutes r) => l.Equals(r.To(TimeConversions.Second));
	public static bool operator ==(Seconds l, Hours r) => l.Equals(r.To(TimeConversions.Second));

	public static bool operator !=(Seconds l, Seconds r) => !l.Equals(r);
	public static bool operator !=(Seconds l, Minutes r) => !l.Equals(r.To(TimeConversions.Second));
	public static bool operator !=(Seconds l, Hours r) => !l.Equals(r.To(TimeConversions.Second));

	#endregion

	public static Seconds operator *(Seconds m, double f) => new Seconds(m.unitValue * f);
	public static Seconds operator *(double f, Seconds m) => new Seconds(m.unitValue * f);

	public static double operator /(Seconds x, Seconds y) => x.unitValue / y.unitValue;

	public static Seconds operator /(Seconds x, double y) => new Seconds(x.unitValue / y);
	public static Seconds operator /(Seconds x, float y) => new Seconds(x.unitValue / y);
	public static Seconds operator /(Seconds x, int y) => new Seconds(x.unitValue / y);

	public double UnitValue => unitValue;

	ILinearConversion ITime.Conversion => TimeConversions.Second;

	double ITime.SiValue => unitValue ;

	public int CompareTo(ITime other) => UnitValue.CompareTo(other.To(TimeConversions.Second).UnitValue);

	public static bool operator <(Seconds l, Seconds r) => l.UnitValue < r.UnitValue;
	public static bool operator <(Seconds l, Minutes r) => l < r.To(TimeConversions.Second);
	public static bool operator <(Seconds l, Hours r) => l < r.To(TimeConversions.Second);

	public static bool operator <=(Seconds l, Seconds r) => l.UnitValue <= r.UnitValue;
	public static bool operator <=(Seconds l, Minutes r) => l <= r.To(TimeConversions.Second);
	public static bool operator <=(Seconds l, Hours r) => l <= r.To(TimeConversions.Second);

	public static bool operator >(Seconds l, Seconds r) => l.UnitValue > r.UnitValue;
	public static bool operator >(Seconds l, Minutes r) => l > r.To(TimeConversions.Second);
	public static bool operator >(Seconds l, Hours r) => l > r.To(TimeConversions.Second);

	public static bool operator >=(Seconds l, Seconds r) => l.UnitValue >= r.UnitValue;
	public static bool operator >=(Seconds l, Minutes r) => l >= r.To(TimeConversions.Second);
	public static bool operator >=(Seconds l, Hours r) => l >= r.To(TimeConversions.Second);

}

[Serializable]
public readonly partial struct Minutes : ITime
{
	public static readonly Minutes Zero = new();

	private readonly double unitValue;

	public Minutes(double minutes)
	{
		if (minutes < 0) throw new ArgumentException("Cowardly refusing to create a negative time unit");
		unitValue = minutes;
	}

	#region minus operators

	public static Minutes operator -(Minutes x) => new Minutes(-x.unitValue);

	public static Minutes operator -(Minutes x, Minutes y)
	{
		return new Minutes(System.Math.Abs(x.unitValue - y.unitValue));
	}

	public static Minutes operator -(Minutes x, Seconds y)
	{
		return x - y.To(TimeConversions.Minute);
	}

	public static Minutes operator -(Minutes x, Hours y)
	{
		return x - y.To(TimeConversions.Minute);
	}
	#endregion

	#region plus operators

	public static Minutes operator +(Minutes x, Minutes y)
	{
		return new Minutes(x.unitValue + y.unitValue);
	}

	public static Minutes operator +(Minutes x, Seconds y)
	{
		return x + y.To(TimeConversions.Minute);
	}

	public static Minutes operator +(Minutes x, Hours y)
	{
		return x + y.To(TimeConversions.Minute);
	}

	#endregion

	#region conversion operators


	public static implicit operator Minutes(Seconds other)
	{
		return other.To(TimeConversions.Minute);
	}

	public static implicit operator Minutes(Hours other)
	{
		return other.To(TimeConversions.Minute);
	}

	#endregion

	#region Equality overloads and operators

	public override bool Equals(object obj)
	{
		return obj switch
		{
			Minutes m => Equals(m),
			ITime length => Equals(length.To(TimeConversions.Minute)),
			_ => false
		};
	}

	public bool Equals(Minutes other) => System.Math.Abs(UnitValue - other.UnitValue) <= 1e-14;

	public override int GetHashCode() => 7 * UnitValue.GetHashCode();

	public static bool operator ==(Minutes l, Minutes r) => l.Equals(r);

	public static bool operator ==(Minutes l, Seconds r) => l.Equals(r.To(TimeConversions.Minute));
	public static bool operator ==(Minutes l, Hours r) => l.Equals(r.To(TimeConversions.Minute));

	public static bool operator !=(Minutes l, Minutes r) => !l.Equals(r);
	public static bool operator !=(Minutes l, Seconds r) => !l.Equals(r.To(TimeConversions.Minute));
	public static bool operator !=(Minutes l, Hours r) => !l.Equals(r.To(TimeConversions.Minute));

	#endregion

	public static Minutes operator *(Minutes m, double f) => new Minutes(m.unitValue * f);
	public static Minutes operator *(double f, Minutes m) => new Minutes(m.unitValue * f);

	public static double operator /(Minutes x, Minutes y) => x.unitValue / y.unitValue;

	public static Minutes operator /(Minutes x, double y) => new Minutes(x.unitValue / y);
	public static Minutes operator /(Minutes x, float y) => new Minutes(x.unitValue / y);
	public static Minutes operator /(Minutes x, int y) => new Minutes(x.unitValue / y);

	public double UnitValue => unitValue;

	ILinearConversion ITime.Conversion => TimeConversions.Minute;

	double ITime.SiValue => unitValue * TimeConversions.Minute.ToSiFactor;

	public int CompareTo(ITime other) => UnitValue.CompareTo(other.To(TimeConversions.Minute).UnitValue);

	public static bool operator <(Minutes l, Minutes r) => l.UnitValue < r.UnitValue;
	public static bool operator <(Minutes l, Seconds r) => l < r.To(TimeConversions.Minute);
	public static bool operator <(Minutes l, Hours r) => l < r.To(TimeConversions.Minute);

	public static bool operator <=(Minutes l, Minutes r) => l.UnitValue <= r.UnitValue;
	public static bool operator <=(Minutes l, Seconds r) => l <= r.To(TimeConversions.Minute);
	public static bool operator <=(Minutes l, Hours r) => l <= r.To(TimeConversions.Minute);

	public static bool operator >(Minutes l, Minutes r) => l.UnitValue > r.UnitValue;
	public static bool operator >(Minutes l, Seconds r) => l > r.To(TimeConversions.Minute);
	public static bool operator >(Minutes l, Hours r) => l > r.To(TimeConversions.Minute);

	public static bool operator >=(Minutes l, Minutes r) => l.UnitValue >= r.UnitValue;
	public static bool operator >=(Minutes l, Seconds r) => l >= r.To(TimeConversions.Minute);
	public static bool operator >=(Minutes l, Hours r) => l >= r.To(TimeConversions.Minute);

}

[Serializable]
public readonly partial struct Hours : ITime
{
	public static readonly Hours Zero = new();

	private readonly double unitValue;

	public Hours(double hours)
	{
		if (hours < 0) throw new ArgumentException("Cowardly refusing to create a negative time unit");
		unitValue = hours;
	}

	#region minus operators

	public static Hours operator -(Hours x) => new Hours(-x.unitValue);

	public static Hours operator -(Hours x, Hours y)
	{
		return new Hours(System.Math.Abs(x.unitValue - y.unitValue));
	}

	public static Hours operator -(Hours x, Seconds y)
	{
		return x - y.To(TimeConversions.Hour);
	}

	public static Hours operator -(Hours x, Minutes y)
	{
		return x - y.To(TimeConversions.Hour);
	}
	#endregion

	#region plus operators

	public static Hours operator +(Hours x, Hours y)
	{
		return new Hours(x.unitValue + y.unitValue);
	}

	public static Hours operator +(Hours x, Seconds y)
	{
		return x + y.To(TimeConversions.Hour);
	}

	public static Hours operator +(Hours x, Minutes y)
	{
		return x + y.To(TimeConversions.Hour);
	}

	#endregion

	#region conversion operators


	public static implicit operator Hours(Seconds other)
	{
		return other.To(TimeConversions.Hour);
	}

	public static implicit operator Hours(Minutes other)
	{
		return other.To(TimeConversions.Hour);
	}

	#endregion

	#region Equality overloads and operators

	public override bool Equals(object obj)
	{
		return obj switch
		{
			Hours h => Equals(h),
			ITime length => Equals(length.To(TimeConversions.Hour)),
			_ => false
		};
	}

	public bool Equals(Hours other) => System.Math.Abs(UnitValue - other.UnitValue) <= 1e-14;

	public override int GetHashCode() => 7 * UnitValue.GetHashCode();

	public static bool operator ==(Hours l, Hours r) => l.Equals(r);

	public static bool operator ==(Hours l, Seconds r) => l.Equals(r.To(TimeConversions.Hour));
	public static bool operator ==(Hours l, Minutes r) => l.Equals(r.To(TimeConversions.Hour));

	public static bool operator !=(Hours l, Hours r) => !l.Equals(r);
	public static bool operator !=(Hours l, Seconds r) => !l.Equals(r.To(TimeConversions.Hour));
	public static bool operator !=(Hours l, Minutes r) => !l.Equals(r.To(TimeConversions.Hour));

	#endregion

	public static Hours operator *(Hours m, double f) => new Hours(m.unitValue * f);
	public static Hours operator *(double f, Hours m) => new Hours(m.unitValue * f);

	public static double operator /(Hours x, Hours y) => x.unitValue / y.unitValue;

	public static Hours operator /(Hours x, double y) => new Hours(x.unitValue / y);
	public static Hours operator /(Hours x, float y) => new Hours(x.unitValue / y);
	public static Hours operator /(Hours x, int y) => new Hours(x.unitValue / y);

	public double UnitValue => unitValue;

	ILinearConversion ITime.Conversion => TimeConversions.Hour;

	double ITime.SiValue => unitValue * TimeConversions.Hour.ToSiFactor;

	public int CompareTo(ITime other) => UnitValue.CompareTo(other.To(TimeConversions.Hour).UnitValue);

	public static bool operator <(Hours l, Hours r) => l.UnitValue < r.UnitValue;
	public static bool operator <(Hours l, Seconds r) => l < r.To(TimeConversions.Hour);
	public static bool operator <(Hours l, Minutes r) => l < r.To(TimeConversions.Hour);

	public static bool operator <=(Hours l, Hours r) => l.UnitValue <= r.UnitValue;
	public static bool operator <=(Hours l, Seconds r) => l <= r.To(TimeConversions.Hour);
	public static bool operator <=(Hours l, Minutes r) => l <= r.To(TimeConversions.Hour);

	public static bool operator >(Hours l, Hours r) => l.UnitValue > r.UnitValue;
	public static bool operator >(Hours l, Seconds r) => l > r.To(TimeConversions.Hour);
	public static bool operator >(Hours l, Minutes r) => l > r.To(TimeConversions.Hour);

	public static bool operator >=(Hours l, Hours r) => l.UnitValue >= r.UnitValue;
	public static bool operator >=(Hours l, Seconds r) => l >= r.To(TimeConversions.Hour);
	public static bool operator >=(Hours l, Minutes r) => l >= r.To(TimeConversions.Hour);

}

