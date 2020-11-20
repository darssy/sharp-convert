using System;

namespace MmiSoft.Core.Math.Units
{
	[Serializable]
	public class FeetPerMinute : SpeedUnit
	{

		public FeetPerMinute()
			: this(0)
		{
		}

		public FeetPerMinute(double fpm)
			: base(fpm, Conversion.FootPerMinute)
		{
		}

		protected override LengthUnit GetLengthUnit()
		{
			return new Feet();
		}

		protected override TimeUnit GetTimeUnit()
		{
			return new Minutes();
		}

		public static FeetPerMinute operator -(FeetPerMinute x)
		{
			return new FeetPerMinute(-x.unitValue);
		}
	}
}
