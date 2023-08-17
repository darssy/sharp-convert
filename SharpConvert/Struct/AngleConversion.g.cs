using System;
using System.Runtime.CompilerServices;

namespace MmiSoft.Core.Math.Units.Struct;

[Serializable]
public class AngleConversion<TUnit> : ILinearConversion where TUnit : IAngle
{
	public double ToSiFactor { get; }

	public UnitType UnitType => UnitType.Angle;

	public string Symbol { get; }
		
	private Func<double, TUnit> create;

	protected internal AngleConversion(double toSiFactor, string symbol, Func<double, TUnit> create)
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

public static class AngleConversions
{
	public static readonly AngleConversion<Radians> Radian = new(1, "rad", r => new Radians(r));
	public static readonly AngleConversion<Degrees> Degree = new(0.0174532925199433, "°", d => new Degrees(d));

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static TOut To<TOut, TIn>(this TIn toConvert, AngleConversion<TOut> conversion)
		where TOut : struct, IAngle
		where TIn : struct, IAngle
	{
		return conversion.Create(toConvert.SiValue / conversion.ToSiFactor);
	}

	public static TOut To<TOut>(this IAngle toConvert, AngleConversion<TOut> conversion)
		where TOut : struct, IAngle
	{
		return conversion.Create(toConvert.SiValue / conversion.ToSiFactor);
	}
}


