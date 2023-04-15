using System;
using System.Runtime.CompilerServices;

namespace MmiSoft.Core.Math.Units.Struct;

using static LengthConversions;
using static TimeConversions;

[Serializable]
public class SpeedConversion<TUnit> : ILinearConversion where TUnit : ISpeed
{
	public double ToSiFactor { get; }

	public UnitType UnitType => UnitType.Speed;

	public string Symbol { get; }
		
	private Func<double, TUnit> create;

	protected internal SpeedConversion(double toSiFactor, string symbol, Func<double, TUnit> create)
	{
		if (toSiFactor <= 0)
		{
			throw new ArgumentOutOfRangeException($"SI Factor should be positive value: {toSiFactor}");
		}
		this.create = create ?? throw new ArgumentNullException(nameof(create));
		ToSiFactor = toSiFactor;
		Symbol = symbol;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public TUnit Create(double value) => create(value);
}

public static class SpeedConversions
{
	public static readonly SpeedConversion<MetersPerSecond> MeterPerSecond = new(1, "m/s", m => new MetersPerSecond(m));
	public static readonly SpeedConversion<FeetPerMinute> FootPerMinute = new(0.00508, "fpm", f => new FeetPerMinute(f));
	public static readonly SpeedConversion<Knots> Knot = new(0.514444444444444, "kt", k => new Knots(k));

	public static TOut To<TOut, TIn>(this TIn toConvert, SpeedConversion<TOut> conversion)
		where TOut : struct, ISpeed
		where TIn : struct, ISpeed
	{
		return conversion.Create(toConvert.SiValue / conversion.ToSiFactor);
	}

	public static TOut To<TOut>(this ISpeed toConvert, SpeedConversion<TOut> conversion)
		where TOut : struct, ISpeed
	{
		return conversion.Create(toConvert.SiValue / conversion.ToSiFactor);
	}
}
