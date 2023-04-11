using System;

namespace MmiSoft.Core.Math.Units.Struct;

[Serializable]
public class TimeConversion<TUnit> : ILinearConversion where TUnit : ITime
{
	public double ToSiFactor { get; }

	public UnitType UnitType => UnitType.Time;

	public string Symbol { get; }
		
	private Func<double, TUnit> create;

	protected internal TimeConversion(double toSiFactor, string symbol, Func<double, TUnit> create)
	{
		if (toSiFactor <= 0)
		{
			throw new ArgumentOutOfRangeException($"SI Factor should be positive value: {toSiFactor}");
		}
		this.create = create ?? throw new ArgumentNullException(nameof(create));
		ToSiFactor = toSiFactor;
		Symbol = symbol;
	}

	public TUnit Create(double value) => create(value);
}

public static class TimeConversions
{
	public static readonly TimeConversion<Seconds> Second = new (1, "s", s => new Seconds(s));
	public static readonly TimeConversion<Minutes> Minute = new (60, "min", m => new Minutes(m));
	public static readonly TimeConversion<Hours> Hour = new(3600, "h", h => new Hours(h));

	public static TOut To<TOut, TIn>(this TIn toConvert, TimeConversion<TOut> conversion)
		where TOut : struct, ITime
		where TIn : struct, ITime
	{
		return conversion.Create(toConvert.SiValue / conversion.ToSiFactor);
	}

	public static TOut To<TOut>(this ITime toConvert, TimeConversion<TOut> conversion)
		where TOut : struct, ITime
	{
		return conversion.Create(toConvert.SiValue / conversion.ToSiFactor);
	}
}
