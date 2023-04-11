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
		
	public static readonly SpeedConversion<MetersPerSecond> MeterPerSecond = new(1, "m/s", mps => new MetersPerSecond(mps));
	/*public static readonly ConversionBis FootPerSecond = new ConversionBis(Foot.ToSiFactor, "ft/s", UnitType.Speed);*/
	public static readonly SpeedConversion<FeetPerMinute> FootPerMinute = new (Foot.ToSiFactor / Minute.ToSiFactor, "fpm", fpm => new FeetPerMinute(fpm));
	public static readonly SpeedConversion<Knots> Knot = new (NauticalMile.ToSiFactor / Hour.ToSiFactor, "kt", kts => new Knots(kts));

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static TOut To<TOut, TIn>(this TIn toConvert, SpeedConversion<TOut> conversion)
		where TOut : struct, ISpeed
		where TIn : struct, ISpeed
	{
		return /*toConvert.Conversion == conversion
			? conversion.Create(toConvert.UnitValue)
			: */conversion.Create(toConvert.SiValue / conversion.ToSiFactor);
	}

	public static TOut To<TOut>(this ISpeed toConvert, SpeedConversion<TOut> conversion)
		where TOut : struct, ISpeed
	{
		return conversion.Create(toConvert.SiValue / conversion.ToSiFactor);
	}
}
