namespace MmiSoft.Core.Math.Units
{
	public class Conversion
	{
		public readonly double toSiFactor;

		protected Conversion(double toSiFactor)
		{
			this.toSiFactor = toSiFactor;
		}

		// Length
		public static readonly Conversion Meter = new Conversion(1);
		public static readonly Conversion Foot = new Conversion(0.3048);
		public static readonly Conversion Kilometer = new Conversion(1000);
		public static readonly Conversion NauticalMile = new Conversion(1852);

		// Time
		public static readonly Conversion Second = new Conversion(1);
		public static readonly Conversion Minute = new Conversion(60);
		public static readonly Conversion Hour = new Conversion(3600);

		//Speed
		public static readonly Conversion MeterPerSecond = new Conversion(1);
		public static readonly Conversion FootPerSecond = new Conversion(Foot.toSiFactor/* / Second.toSiFactor*/);
		public static readonly Conversion FootPerMinute = new Conversion(Foot.toSiFactor / Minute.toSiFactor);
		public static readonly Conversion Knot = new Conversion(NauticalMile.toSiFactor / Hour.toSiFactor);

		// Acceleration
		public static readonly Conversion MeterPerSecondSquared = new Conversion(1);
		public static readonly Conversion FootPerSecondSquared = new Conversion(FootPerSecond.toSiFactor/* / Second.toSiFactor*/);
		public static readonly Conversion FootPerMinutePerSecond = new Conversion(FootPerMinute.toSiFactor /* / Second.toSiFactor*/);
		public static readonly Conversion KnotPerSecond = new Conversion(Knot.toSiFactor/* / Second.toSiFactor*/);

		//Angle
		public static readonly Conversion Radian = new Conversion(1);
		public static readonly Conversion Degree = new Conversion(System.Math.PI / 180);

		//Angular velocity
		public static readonly Conversion RadianPerSecond = new Conversion(1);
		public static readonly Conversion DegreePerSecond = new Conversion(Degree.toSiFactor);

		//Mass
		public static readonly Conversion Kilogram = new Conversion(1);
	}
}
