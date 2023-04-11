using System;

namespace MmiSoft.Core.Math.Units.Struct
{
	public interface ILinearConversion
	{
		public double ToSiFactor { get; }
	}

	[Serializable]
	public class Conversion<TUnit> : ILinearConversion
	{
		public double ToSiFactor { get; }

		public UnitType UnitType { get; }

		public string Symbol { get; }
		
		private Func<double, TUnit> create;

		protected internal Conversion(double toSiFactor, string symbol, UnitType unitType, Func<double, TUnit> create)
		{
			if (toSiFactor <= 0)
			{
				throw new ArgumentOutOfRangeException($"SI Factor should be positive value: {toSiFactor}");
			}
			this.create = create ?? throw new ArgumentNullException(nameof(create));
			ToSiFactor = toSiFactor;
			UnitType = unitType;
			Symbol = symbol;
		}

		public TUnit Create(double value) => create(value);
	}

	public static class Conversions
	{
		/* Whenever a derivative is per second the / Second.ToSiFactor is omitted for brevity*/
		/*

		// Time

		//Speed

		// Acceleration
		public static readonly ConversionBis MeterPerSecondSquared = new ConversionBis(1, "m/s^2", UnitType.Acceleration);
		public static readonly ConversionBis FootPerSecondSquared = new ConversionBis(FootPerSecond.ToSiFactor, "ft/s^2", UnitType.Acceleration);
		public static readonly ConversionBis FootPerMinutePerSecond = new ConversionBis(FootPerMinute.ToSiFactor, "fpm/s", UnitType.Acceleration);
		public static readonly ConversionBis KnotPerSecond = new ConversionBis(Knot.ToSiFactor, "kt/s", UnitType.Acceleration);

		//Angle
		public static readonly ConversionBis Radian = new ConversionBis(1, "rad", UnitType.Angle);
		public static readonly ConversionBis Degree = new ConversionBis(System.Math.PI / 180, "\u00B0", UnitType.Angle);

		//Angular velocity
		public static readonly ConversionBis RadianPerSecond = new ConversionBis(1, "rad/s", UnitType.AngularVelocity);
		public static readonly ConversionBis DegreePerSecond = new ConversionBis(Degree.ToSiFactor, "\u00B0/s", UnitType.AngularVelocity);

		//Mass
		public static readonly ConversionBis Kilogram = new ConversionBis(1, "Kg", UnitType.Mass);*/
	}
}
