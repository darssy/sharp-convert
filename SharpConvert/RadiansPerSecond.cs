using System;

namespace MmiSoft.Core.Math.Units
{
	[Serializable]
	public class RadiansPerSecond : AngularVelocity
	{
		public RadiansPerSecond(double unitValue)
			: base(unitValue, Conversion.RadianPerSecond)
		{
		}

		protected override AngleUnit GetAngleUnit()
		{
			return new Radians();
		}

		protected override TimeUnit GetTimeUnit()
		{
			return new Seconds();
		}

		public static Radians operator *(RadiansPerSecond omega, TimeUnit t)
		{
			return ((AngularVelocity)omega * t).To<Radians>();
		}

		public static Radians operator *(RadiansPerSecond omega, TimeSpan t)
		{
			return omega * new Seconds(t);
		}

		public static Seconds operator /(AngleUnit a, RadiansPerSecond omega)
		{
			return (a / (AngularVelocity)omega).To<Seconds>();
		}

	}
}
