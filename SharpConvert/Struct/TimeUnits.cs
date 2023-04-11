using System;

namespace MmiSoft.Core.Math.Units.Struct;

public interface ITime
{
	double UnitValue { get; }
	internal ILinearConversion Conversion { get; }
	internal double SiValue { get; }
	//internal double SiValue => UnitValue * Conversion.ToSiFactor;
}

[Serializable]
public struct Seconds : ITime
{
	public static readonly Seconds Zero = new();

	public Seconds()
		: this(0)
	{ }

	private readonly double unitValue;

	public Seconds(double seconds)
	{
		unitValue = seconds;
	}

	public Seconds(TimeSpan time)
		:this(time.TotalSeconds)
	{ }

	public static Seconds operator *(Seconds t, double f)
	{
		return new Seconds(t.unitValue * f);
	}

	public static Seconds operator *(double f, Seconds t)
	{
		return new Seconds(t.unitValue * f);
	}

	public static implicit operator Seconds(TimeSpan t)
	{
		return new Seconds(t);
	}

	public double UnitValue => unitValue;
	ILinearConversion ITime.Conversion => TimeConversions.Second;
	double ITime.SiValue => unitValue/* * TimeConversions.Second.ToSiFactor*/;
}

[Serializable]
public readonly struct Minutes : ITime
{
	public static readonly Minutes Zero = new();

	public Minutes(double hours)
	{
		UnitValue = hours;
	}

	public Minutes(TimeSpan time)
		:this(time.TotalMinutes)
	{ }

	public override bool Equals(object obj)
	{
		return obj switch
		{
			Minutes kts => Equals(kts),
			ITime time => Equals(time.To(TimeConversions.Minute)),
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

	public static implicit operator Minutes(TimeSpan t)
	{
		return new Minutes(t);
	}

	public double UnitValue { get; }

	ILinearConversion ITime.Conversion => TimeConversions.Minute;

	double ITime.SiValue => UnitValue * TimeConversions.Minute.ToSiFactor;
}

[Serializable]
public readonly struct Hours : ITime
{
	public static readonly Hours Zero = new();

	public Hours(double hours)
	{
		UnitValue = hours;
	}

	public Hours(TimeSpan time)
		:this(time.TotalHours)
	{ }

	public static implicit operator Hours(TimeSpan t)
	{
		return new Hours(t);
	}

	public double UnitValue { get; }

	ILinearConversion ITime.Conversion => TimeConversions.Hour;

	double ITime.SiValue => UnitValue * TimeConversions.Hour.ToSiFactor;
}
