using System;

namespace MmiSoft.Core.Math.Units
{
	[Serializable]
	public class FeetPerMinute : SpeedUnit
	{
		private static readonly double SiConversionFactor = new Feet().ToSiFactor / new Minutes().ToSiFactor;

		public FeetPerMinute()
			: this(0)
		{
		}

		public FeetPerMinute(double fpm)
			: base(fpm, SiConversionFactor)
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

		public override string Symbol => "fpm";
	}
}
