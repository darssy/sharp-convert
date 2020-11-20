using System;

namespace MmiSoft.Core.Math.Units
{

	[Serializable]
	public class FeetPerSecond : SpeedUnit
	{

		public FeetPerSecond()
			: this(0)
		{
		}

		public FeetPerSecond(double fps)
			: base(fps, Conversion.FootPerSecond)
		{
		}

		protected override LengthUnit GetLengthUnit()
		{
			return new Feet();
		}

		protected override TimeUnit GetTimeUnit()
		{
			return new Seconds();
		}

		public static FeetPerSecond operator -(FeetPerSecond x)
		{
			return new FeetPerSecond(-x.unitValue);
		}

		public override string Symbol => "ft/s";
	}
}
