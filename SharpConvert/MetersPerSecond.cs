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
			: base(speed, new Meters().ToSiFactor / new Seconds().ToSiFactor)
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

		public override string Symbol => "m/s";
	}
}
