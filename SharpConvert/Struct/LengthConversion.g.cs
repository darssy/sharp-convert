using System;
using System.Runtime.CompilerServices;

namespace MmiSoft.Core.Math.Units.Struct;

[Serializable]
public class LengthConversion<TUnit> : ILinearConversion where TUnit : ILength
{
	public double ToSiFactor { get; }

	public UnitType UnitType => UnitType.Length;

	public string Symbol { get; }
		
	private Func<double, TUnit> create;

	protected internal LengthConversion(double toSiFactor, string symbol, Func<double, TUnit> create)
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

public static class LengthConversions
{
	public static readonly LengthConversion<Meters> Meter = new(1, "m", v => new Meters(v));
	public static readonly LengthConversion<Inches> Inch = new(0.254, "in", v => new Inches(v));
	public static readonly LengthConversion<Feet> Foot = new(0.3048, "ft", v => new Feet(v));
	public static readonly LengthConversion<Kilometers> Kilometer = new(1000, "Km", v => new Kilometers(v));
	public static readonly LengthConversion<NauticalMiles> NauticalMile = new(1852, "NM", v => new NauticalMiles(v));

	public static TOut To<TOut, TIn>(this TIn toConvert, LengthConversion<TOut> conversion)
		where TOut : struct, ILength
		where TIn : struct, ILength
	{
		return conversion.Create(toConvert.SiValue / conversion.ToSiFactor);
	}

	public static TOut To<TOut>(this ILength toConvert, LengthConversion<TOut> conversion)
		where TOut : struct, ILength
	{
		return conversion.Create(toConvert.SiValue / conversion.ToSiFactor);
	}
}
