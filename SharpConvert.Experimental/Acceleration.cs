namespace SharpConvert.Experimental
{
	public readonly struct Acceleration<TLength, TTime1, TTime2>
		where TLength : struct, ILength
		where TTime1 : struct, ITime
		where TTime2 : struct, ITime
	{
		private static readonly double SiFactor = new TLength().ToSiFactor / new TTime1().ToSiFactor / new TTime2().ToSiFactor;
		public Acceleration(double value)
		{
			Value = value;
		}

		public double Value { get; }

		public static Acceleration<TLength, TTime1, TTime2> operator +(Acceleration<TLength, TTime1, TTime2> first,
			Acceleration<TLength, TTime1, TTime2> second)
		{
			return new Acceleration<TLength, TTime1, TTime2>(first.Value + second.Value);
		}


		public static Speed<TLength, TTime1> operator *(Acceleration<TLength, TTime1, TTime2> first, Time<TTime2> second)
		{
			return new Speed<TLength, TTime1>(first.Value * second.Value);
		}

		// quite a cumbersome choice but that way we can take advantage of C# type inference that wouldn't work otherwise with
		// the return type.
		public void To<L, T1, T2>(out Acceleration<L, T1, T2> result) where L : struct, ILength
			where T1 : struct, ITime
			where T2 : struct, ITime
		{
			result = new Acceleration<L, T1, T2>(Value * SiFactor / Acceleration<L, T1, T2>.SiFactor);
		}
	}
}
