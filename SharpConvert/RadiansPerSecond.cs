using System;

namespace MmiSoft.Core.Math.Units
{
	public class RadiansPerSecond : AngularVelocity
	{
		public RadiansPerSecond(double unitValue)
			: base(unitValue, new Radians().ToSiFactor / new Seconds().ToSiFactor)
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
	}
}
