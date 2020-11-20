using System;

namespace MmiSoft.Core.Math.Units
{
	[Serializable]
	public class Conversion
	{
		public double ToSiFactor { get; }

		public UnitType UnitType { get; }

		public string Symbol { get; }

		protected internal Conversion(double toSiFactor, string symbol, UnitType unitType)
		{
			if (toSiFactor <= 0)
			{
				throw new ArgumentOutOfRangeException($"SI Factor should be positive value: {toSiFactor}");
			}
			ToSiFactor = toSiFactor;
			UnitType = unitType;
			Symbol = symbol;
		}

		/* Whenever a derivative is per second the / Second.ToSiFactor is omitted for brevity*/
		// Length
		public static readonly Conversion Meter = new Conversion(1, "m", UnitType.Length);
		public static readonly Conversion Foot = new Conversion(0.3048, "ft", UnitType.Length);
		public static readonly Conversion Kilometer = new Conversion(1000, "Km", UnitType.Length);
		public static readonly Conversion NauticalMile = new Conversion(1852, "NM", UnitType.Length);

		// Time
		public static readonly Conversion Second = new Conversion(1, "s", UnitType.Time);
		public static readonly Conversion Minute = new Conversion(60, "min", UnitType.Time);
		public static readonly Conversion Hour = new Conversion(3600, "h", UnitType.Time);

		//Speed
		public static readonly Conversion MeterPerSecond = new Conversion(1, "m/s", UnitType.Speed);
		public static readonly Conversion FootPerSecond = new Conversion(Foot.ToSiFactor, "ft/s", UnitType.Speed);
		public static readonly Conversion FootPerMinute = new Conversion(Foot.ToSiFactor / Minute.ToSiFactor, "fpm", UnitType.Speed);
		public static readonly Conversion Knot = new Conversion(NauticalMile.ToSiFactor / Hour.ToSiFactor, "kt", UnitType.Speed);

		// Acceleration
		public static readonly Conversion MeterPerSecondSquared = new Conversion(1, "m/s^2", UnitType.Acceleration);
		public static readonly Conversion FootPerSecondSquared = new Conversion(FootPerSecond.ToSiFactor, "ft/s^2", UnitType.Acceleration);
		public static readonly Conversion FootPerMinutePerSecond = new Conversion(FootPerMinute.ToSiFactor, "fpm/s", UnitType.Acceleration);
		public static readonly Conversion KnotPerSecond = new Conversion(Knot.ToSiFactor, "kt/s", UnitType.Acceleration);

		//Angle
		public static readonly Conversion Radian = new Conversion(1, "rad", UnitType.Angle);
		public static readonly Conversion Degree = new Conversion(System.Math.PI / 180, "\u00B0", UnitType.Angle);

		//Angular velocity
		public static readonly Conversion RadianPerSecond = new Conversion(1, "rad/s", UnitType.AngularVelocity);
		public static readonly Conversion DegreePerSecond = new Conversion(Degree.ToSiFactor, "\u00B0/s", UnitType.AngularVelocity);

		//Mass
		public static readonly Conversion Kilogram = new Conversion(1, "Kg", UnitType.Mass);
	}

}
