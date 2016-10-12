using System;

namespace MmiSoft.Core.Math.Units
{
	public class DegreesPerSecond : AngularVelocity
	{
		public DegreesPerSecond() : this(0d)
		{ }

		public DegreesPerSecond(double unitValue)
			: base(unitValue, new Degrees().ToSiFactor / new Seconds().ToSiFactor)
		{
		}

		public DegreesPerSecond(decimal unitValue)
			: this((double) unitValue)
		{
		}

		public DegreesPerSecond(int unitValue)
			: this((double)unitValue)
		{
		}

		protected override AngleUnit GetAngleUnit()
		{
			return new Degrees();
		}

		protected override TimeUnit GetTimeUnit()
		{
			return new Seconds();
		}
	}
}
