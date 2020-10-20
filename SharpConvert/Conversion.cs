using System;

namespace MmiSoft.Core.Math.Units
{
	public class Conversion
	{
		private readonly int hashCode;

		public double ToSiFactor { get; }

		public UnitType UnitType { get; }

		public override int GetHashCode()
		{
			return hashCode;
		}

		protected internal Conversion(double toSiFactor, UnitType unitType)
		{
			if (toSiFactor <= 0)
			{
				throw new ArgumentOutOfRangeException($"SI Factor should be positive value: {toSiFactor}");
			}
			ToSiFactor = toSiFactor;
			UnitType = unitType;
			hashCode = unitType.ToString().GetHashCode();
		}

		// Length
		public static readonly Conversion Meter = new Conversion(1, UnitType.Length);
		public static readonly Conversion Foot = new Conversion(0.3048, UnitType.Length);
		public static readonly Conversion Kilometer = new Conversion(1000, UnitType.Length);
		public static readonly Conversion NauticalMile = new Conversion(1852, UnitType.Length);

		// Time
		public static readonly Conversion Second = new Conversion(1, UnitType.Time);
		public static readonly Conversion Minute = new Conversion(60, UnitType.Time);
		public static readonly Conversion Hour = new Conversion(3600, UnitType.Time);

		//Speed
		public static readonly Conversion MeterPerSecond = new Conversion(1, UnitType.Speed);
		public static readonly Conversion FootPerSecond = new Conversion(Foot.ToSiFactor/* / Second.ToSiFactor*/, UnitType.Speed);
		public static readonly Conversion FootPerMinute = new Conversion(Foot.ToSiFactor / Minute.ToSiFactor, UnitType.Speed);
		public static readonly Conversion Knot = new Conversion(NauticalMile.ToSiFactor / Hour.ToSiFactor, UnitType.Speed);

		// Acceleration
		public static readonly Conversion MeterPerSecondSquared = new Conversion(1, UnitType.Acceleration);
		public static readonly Conversion FootPerSecondSquared = new Conversion(FootPerSecond.ToSiFactor/* / Second.ToSiFactor*/, UnitType.Acceleration);
		public static readonly Conversion FootPerMinutePerSecond = new Conversion(FootPerMinute.ToSiFactor /* / Second.ToSiFactor*/, UnitType.Acceleration);
		public static readonly Conversion KnotPerSecond = new Conversion(Knot.ToSiFactor/* / Second.ToSiFactor*/, UnitType.Acceleration);

		//Angle
		public static readonly Conversion Radian = new Conversion(1, UnitType.Angle);
		public static readonly Conversion Degree = new Conversion(System.Math.PI / 180, UnitType.Angle);

		//Angular velocity
		public static readonly Conversion RadianPerSecond = new Conversion(1, UnitType.AngularVelocity);
		public static readonly Conversion DegreePerSecond = new Conversion(Degree.ToSiFactor, UnitType.AngularVelocity);

		//Mass
		public static readonly Conversion Kilogram = new Conversion(1, UnitType.Mass);
	}

}
