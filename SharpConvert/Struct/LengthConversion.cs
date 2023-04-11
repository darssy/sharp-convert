using System;

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

	public TUnit Create(double value) => create(value);
}

public static class LengthConversions
{
	public static readonly LengthConversion<Meters> Meter = new(1, "m", d => new Meters(d));
	public static readonly LengthConversion<Feet> Foot = new(0.3048, "ft", d => new Feet(d));
	public static readonly LengthConversion<Kilometers> Kilometer = new (1000, "Km", km => new Kilometers(km));
	public static readonly LengthConversion<NauticalMiles> NauticalMile = new (1852, "NM", nm => new NauticalMiles(nm));

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
