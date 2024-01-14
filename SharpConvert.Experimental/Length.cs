using System;

// ReSharper disable InconsistentNaming

namespace SharpConvert.Experimental
{

	public interface ILength : IUnit { }

	public static class Length
	{

		public readonly struct m : ILength
		{
			public double ToSiFactor => 1;
		}

		public readonly struct mm : ILength
		{
			public double ToSiFactor => 0.001;
		}

		public readonly struct cm : ILength
		{
			public double ToSiFactor => 0.01;
		}

		public readonly struct @in : ILength
		{
			public double ToSiFactor => 0.001;
		}

		public readonly struct Km : ILength
		{
			public double ToSiFactor => 1000;
		}

		public readonly struct NM : ILength
		{
			public double ToSiFactor => 1852;
		}

		public readonly struct ft : ILength
		{
			public double ToSiFactor => 0.3048;
		}

		public static Length<m> Meters(this double meterValue) => new(meterValue);
		public static Length<m> Meters(this float meterValue) => new(meterValue);
		public static Length<m> Meters(this int meterValue) => new(meterValue);

		public static Length<ft> Feet(this double d) => new(d);
		public static Length<ft> Feet(this float d) => new(d);
		public static Length<ft> Feet(this int d) => new(d);

		public static Length<Km> Kilometers(this double d) => new(d);
		public static Length<Km> Kilometers(this float d) => new(d);
		public static Length<Km> Kilometers(this int d) => new(d);

		public static Length<NM> NauticalMiles(this double d) => new(d);
		public static Length<NM> NauticalMiles(this float d) => new(d);
		public static Length<NM> NauticalMiles(this int d) => new(d);
	}

	public readonly struct Length<T> where T : struct, ILength
	{
		private static readonly double SiFactor = new T().ToSiFactor;
		public Length(double value)
		{
			if (value < 0) throw new ArgumentNullException(nameof(value));
			Value = value;
		}

		public double Value { get; }

		public static Length<T> operator +(Length<T> first, Length<T> second)
		{
			return new Length<T>(first.Value + second.Value);
		}

		public static Length<T> operator -(Length<T> first, Length<T> second)
		{
			return new Length<T>(System.Math.Abs(first.Value - second.Value));
		}

		public Length<R> To<R>() where R : struct, ILength
		{
			return new Length<R>(Value * SiFactor / Length<R>.SiFactor);
		}
	}
}
