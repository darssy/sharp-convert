using System;

namespace SharpConvert.Experimental
{
	public interface ITime : IUnit { }

	public static class Time
	{
		public readonly struct ms : ITime
		{
			public double ToSiFactor => 0.001;
		}

		public readonly struct s : ITime
		{
			public double ToSiFactor => 1;
		}

		public readonly struct min : ITime
		{
			public double ToSiFactor => 60;
		}

		public readonly struct h : ITime
		{
			public double ToSiFactor => 3600;
		}
	}

	public readonly struct Time<T> where T : struct, ITime
	{
		private static readonly double SiFactor = new T().ToSiFactor;

		public Time(double value)
		{
			if (value < 0) throw new ArgumentNullException(nameof(value));
			Value = value;
		}

		public double Value { get; }

		public static Time<T> operator +(Time<T> first, Time<T> second)
		{
			return new Time<T>(first.Value + second.Value);
		}

		public static Time<T> operator -(Time<T> first, Time<T> second)
		{
			return new Time<T>(System.Math.Abs(first.Value - second.Value));
		}

		public Time<R> To<R>() where R : struct, ITime
		{
			return new Time<R>(Value * SiFactor / Time<R>.SiFactor);
		}
	}
}
