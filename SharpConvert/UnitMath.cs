using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MmiSoft.Core.Math.Units
{
	public static class UnitMath
	{
		public static T Max<T>(T x, T y)
		{
			return (Comparer<T>.Default.Compare(x, y) > 0) ? x : y;
		}

		public static T Min<T>(T x, T y)
		{
			return (Comparer<T>.Default.Compare(x, y) < 0) ? x : y;
		}
	}
}
