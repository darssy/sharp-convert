namespace MmiSoft.Core.Math.Units
{
	public class FeetPerSecond : SpeedUnit
	{
		private static readonly double SiConversionFactor = new Feet().ToSiFactor / new Seconds().ToSiFactor;

		public FeetPerSecond()
			: this(0)
		{
		}

		public FeetPerSecond(double fps)
			: base(fps, SiConversionFactor)
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
