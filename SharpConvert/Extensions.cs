
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace MmiSoft.Core.Math.Units
{
	public static class Extensions
	{
		private static List<string> registeredUnitSymbols = new List<string>();
		private static Dictionary<string, Func<double, UnitBase>> registeredUnitConstructors
			= new Dictionary<string, Func<double, UnitBase>>();

		static Extensions()
		{
			var type = typeof(UnitBase);
			List<Type> types = AppDomain.CurrentDomain.GetAssemblies()
				.SelectMany(a => a.GetTypes())
				.Where(t => type.IsAssignableFrom(t) && !t.IsAbstract)
				.ToList();

			Type paramType = typeof(double);
			foreach (Type t in types)
			{
				foreach (ConstructorInfo constructor in t.GetConstructors())
				{
					ParameterInfo[] parameters = constructor.GetParameters();
					if (parameters.Length == 1 && parameters[0].ParameterType == paramType)
					{
						ParameterExpression param = Expression.Parameter(paramType, "val");
						Expression<Func<double, UnitBase>> lambda = Expression.Lambda<Func<double, UnitBase>>(
							Expression.New(constructor, param), param);
						Func<double, UnitBase> func = lambda.Compile();
						try
						{
							UnitBase unit = func.Invoke(0);
							registeredUnitConstructors[unit.Symbol] = func;
						}
						catch (Exception e)
						{
							//TODO log exception
						}
						break;
					}
				}
			}
			registeredUnitSymbols.AddRange(registeredUnitConstructors.Keys);
		}

		public static UnitBase Parse(this string text)
		{
			text = text.Trim();
			string unit = registeredUnitSymbols.FirstOrDefault(text.EndsWith);
			if (unit == null) throw new FormatException($"Unknown unit for input: '{text}'");

			double value = double.Parse(text.Replace(unit, ""), CultureInfo.InvariantCulture);
			return registeredUnitConstructors[unit].Invoke(value);
		}

		#region Length Units
		public static Feet Feet(this double d)
		{
			return new Feet(d);
		}

		public static Feet Feet(this float d)
		{
			return new Feet(d);
		}

		public static Feet Feet(this int d)
		{
			return new Feet(d);
		}

		public static Meters Meters(this double d)
		{
			return new Meters(d);
		}

		public static Meters Meters(this float d)
		{
			return new Meters(d);
		}

		public static Meters Meters(this int d)
		{
			return new Meters(d);
		}

		public static Kilometers Kilometers(this double d)
		{
			return new Kilometers(d);
		}

		public static Kilometers Kilometers(this float d)
		{
			return new Kilometers(d);
		}

		public static Kilometers Kilometers(this int d)
		{
			return new Kilometers(d);
		}

		public static NauticalMiles NauticalMiles(this double d)
		{
			return new NauticalMiles(d);
		}

		public static NauticalMiles NauticalMiles(this float d)
		{
			return new NauticalMiles(d);
		}

		public static NauticalMiles NauticalMiles(this int d)
		{
			return new NauticalMiles(d);
		}
		#endregion

		#region Time
		public static Hours Hours(this double t)
		{
			return new Hours(t);
		}

		public static Hours Hours(this float t)
		{
			return new Hours(t);
		}

		public static Hours Hours(this int t)
		{
			return new Hours(t);
		}

		public static Minutes Minutes(this double t)
		{
			return new Minutes(t);
		}

		public static Minutes Minutes(this float t)
		{
			return new Minutes(t);
		}

		public static Minutes Minutes(this int t)
		{
			return new Minutes(t);
		}

		public static Seconds Seconds(this double t)
		{
			return new Seconds(t);
		}

		public static Seconds Seconds(this float t)
		{
			return new Seconds(t);
		}

		public static Seconds Seconds(this int t)
		{
			return new Seconds(t);
		}
		#endregion

		#region Speed Units
		public static Knots Knots(this double d)
		{
			return new Knots(d);
		}

		public static Knots Knots(this float d)
		{
			return new Knots(d);
		}

		public static Knots Knots(this int d)
		{
			return new Knots(d);
		}

		public static FeetPerMinute FeetPerMinute(this double d)
		{
			return new FeetPerMinute(d);
		}

		public static FeetPerMinute FeetPerMinute(this float d)
		{
			return new FeetPerMinute(d);
		}

		public static FeetPerMinute FeetPerMinute(this int d)
		{
			return new FeetPerMinute(d);
		}

		public static MetersPerSecond MetersPerSecond(this int mps)
		{
			return new MetersPerSecond(mps);
		}
		#endregion
		
		#region Angle Units

		public static Degrees Degrees(this int d)
		{
			return new Degrees(d);
		}

		public static Degrees Degrees(this float d)
		{
			return new Degrees(d);
		}

		public static Degrees Degrees(this double d)
		{
			return new Degrees(d);
		}

		public static Degrees Degrees(this decimal d)
		{
			return new Degrees((double)d);
		}

		public static Radians Radians(this int r)
		{
			return new Radians(r);
		}

		public static Radians Radians(this float r)
		{
			return new Radians(r);
		}

		public static Radians Radians(this double r)
		{
			return new Radians(r);
		}

		public static Radians Radians(this decimal r)
		{
			return new Radians((double)r);
		}
		#endregion

		#region Angular Velocity
		public static DegreesPerSecond DegreesPerSecond(this int d)
		{
			return new DegreesPerSecond(d);
		}

		public static DegreesPerSecond DegreesPerSecond(this float d)
		{
			return new DegreesPerSecond(d);
		}

		public static DegreesPerSecond DegreesPerSecond(this double d)
		{
			return new DegreesPerSecond(d);
		}

		public static RadiansPerSecond RadiansPerSecond(this int d)
		{
			return new RadiansPerSecond(d);
		}

		public static RadiansPerSecond RadiansPerSecond(this float d)
		{
			return new RadiansPerSecond(d);
		}

		public static RadiansPerSecond RadiansPerSecond(this double d)
		{
			return new RadiansPerSecond(d);
		}
		#endregion


		#region Mass

		public static Kilogram Kilogram(this int kg) => new Kilogram(kg);
		public static Kilogram Kilogram(this float kg) => new Kilogram(kg);
		public static Kilogram Kilogram(this double kg) => new Kilogram(kg);

		#endregion

		#region Acceleration

		public static KnotsPerSecond KnotsPerSecond(this int ktsPerSec) => new KnotsPerSecond(ktsPerSec);
		public static KnotsPerSecond KnotsPerSecond(this float ktsPerSec) => new KnotsPerSecond(ktsPerSec);
		public static KnotsPerSecond KnotsPerSecond(this double ktsPerSec) => new KnotsPerSecond(ktsPerSec);

		public static FeetPerMinutePerSecond FeetPerMinutePerSecond(this int fpsPerSec) => new FeetPerMinutePerSecond(fpsPerSec);
		public static FeetPerMinutePerSecond FeetPerMinutePerSecond(this float fpsPerSec) => new FeetPerMinutePerSecond(fpsPerSec);
		public static FeetPerMinutePerSecond FeetPerMinutePerSecond(this double fpsPerSec) => new FeetPerMinutePerSecond(fpsPerSec);

		#endregion
	}
}
