using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace SharpConvert.Experimental
{
	public readonly struct Speed<TLength, TTime> where TLength : struct, ILength where TTime : struct, ITime
	{
		private static readonly double SiFactor = new TLength().ToSiFactor / new TTime().ToSiFactor;
		public Speed(double value)
		{
			Value = value;
		}

		public double Value { get; }

		public static bool operator <(Speed<TLength, TTime> x, Speed<TLength, TTime> y)
		{
			return x.Value < y.Value;
		}

		public static bool operator >(Speed<TLength, TTime> x, Speed<TLength, TTime> y)
		{
			return x.Value > y.Value;
		}

		public static bool operator <=(Speed<TLength, TTime> x, Speed<TLength, TTime> y)
		{
			return x.Value <= y.Value;
		}

		public static bool operator >=(Speed<TLength, TTime> x, Speed<TLength, TTime> y)
		{
			return x.Value >= y.Value;
		}

		public static Speed<TLength, TTime> operator +(Speed<TLength, TTime> first, Speed<TLength, TTime> second)
		{
			return new Speed<TLength, TTime>(first.Value + second.Value);
		}

		public static Length<TLength> operator *(Speed<TLength, TTime> first, Time<TTime> second)
		{
			return new Length<TLength>(first.Value * second.Value);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public Speed<L, T> To<L, T>() where L : struct, ILength where T : struct, ITime
		{
			return new Speed<L, T>(Value * SiFactor / Speed<L, T>.SiFactor);
		}
	}

	public static class UnitSymbols
	{
		private static readonly Dictionary<Type, string> Symbols = new Dictionary<Type, string>();
	}
}
