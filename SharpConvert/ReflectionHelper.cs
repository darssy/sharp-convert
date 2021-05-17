using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace MmiSoft.Core.Math.Units
{
	internal static class ReflectionHelper
	{
		private static Dictionary<Type, Func<double, UnitBase>> registeredUnitConstructors
			= new Dictionary<Type, Func<double, UnitBase>>();

		static ReflectionHelper()
		{
			var type = typeof(UnitBase);
			List<Type> types = AppDomain.CurrentDomain.GetAssemblies()
				.SelectMany(a => a.GetTypes())
				.Where(t => type.IsAssignableFrom(t) && !t.IsAbstract)
				.ToList();

			Type paramType = typeof(double);
			foreach (Type unitType in types)
			{
				foreach (ConstructorInfo constructor in unitType.GetConstructors())
				{
					ParameterInfo[] parameters = constructor.GetParameters();
					if (parameters.Length == 1 && parameters[0].ParameterType == paramType)
					{
						ParameterExpression param = Expression.Parameter(paramType, "unitValue");
						Expression<Func<double, UnitBase>> lambda = Expression.Lambda<Func<double, UnitBase>>(
							Expression.New(constructor, param), param);
						Func<double, UnitBase> func = lambda.Compile();
						try
						{
							registeredUnitConstructors[unitType] = func;
						}
						catch (Exception e)
						{
							//TODO log exception
						}
						break;
					}
				}
			}
		}

		public static Func<double, UnitBase> GetConstructor<TUnit>() where TUnit : UnitBase
			=> registeredUnitConstructors[typeof(TUnit)];

		public static IEnumerable<Func<double, UnitBase>> All() => registeredUnitConstructors.Values.ToList();
	}
}
