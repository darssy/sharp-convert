using System;

namespace MmiSoft.Core.Math.Units
{
	[Serializable]
	public class MetersPerSecond : SpeedUnit
	{
		public MetersPerSecond() : this(0)
		{
			
		}
		public MetersPerSecond(double speed)
			: base(speed, Conversion.MeterPerSecond)
		{
		}

		protected override LengthUnit GetLengthUnit()
		{
			return new Meters();
		}

		protected override TimeUnit GetTimeUnit()
		{
			return new Seconds();
		}

		public static MetersPerSecond operator -(MetersPerSecond x)
		{
			return new MetersPerSecond(-x.unitValue);
		}
	}
}
