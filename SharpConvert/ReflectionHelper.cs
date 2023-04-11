using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;

namespace MmiSoft.Core.Math.Units
{
	internal static class ReflectionHelper
	{
		private static Dictionary<Type, Func<double, UnitBase>> registeredUnitConstructors = new();

		static ReflectionHelper()
		{
			try
			{
				var type = typeof(UnitBase);
				List<Type> types = AppDomain.CurrentDomain.GetAssemblies()
					.Where(a => a.GetCustomAttributes(typeof(UnitContainerAttribute)).Any())
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
			catch (Exception e)
			{
				SearchForLoaderExceptions(e);
			}
		}
		

		private static void SearchForLoaderExceptions(Exception exception)
		{
			if (exception == null) return;
			if (exception is ReflectionTypeLoadException ex)
			{
				StringBuilder sb = new();
				foreach (Exception exSub in ex.LoaderExceptions)
				{
					sb.AppendLine(exSub.Message);
					if (exSub is FileNotFoundException exFileNotFound)
					{
						if (!string.IsNullOrEmpty(exFileNotFound.FusionLog))
						{
							sb.AppendLine("Fusion Log:");
							sb.AppendLine(exFileNotFound.FusionLog);
						}
						sb.Append("File name ").Append(exFileNotFound.FileName);
					}

					sb.AppendLine();
				}

				string errorMessage = sb.ToString();
				//Granted, you need a console attached to make this work. But this is temporary, at least until this library is connected with the parent "Toolbox" library.
				Console.WriteLine(errorMessage);
			}
			else
			{
				SearchForLoaderExceptions(exception.InnerException);
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Func<double, UnitBase> GetConstructor<TUnit>() where TUnit : UnitBase
			=> registeredUnitConstructors[typeof(TUnit)];

		public static IEnumerable<Func<double, UnitBase>> All() => registeredUnitConstructors.Values.ToList();
	}

}
