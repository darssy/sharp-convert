using System;
using System.Diagnostics;
using MmiSoft.Core.Math.Units;
using NUnit.Framework;

namespace UnitTests.MmiSoft.Core.Math.Units
{
	//[TestFixture]
	public class Performance
	{
		//[Test]
		//TODO use a benchmark library
		public void InternedUnitPerformance()
		{
			Random random = new Random(1);
			Stopwatch sw = Stopwatch.StartNew();
			for (int i = 0; i < 10000000; i++)
			{
				Feet unit1 = random.Next(50000).Feet();
				Feet unit2 = random.Next(50000).Feet();
				LengthUnit feet = (unit1 - unit2);
			}
			sw.Stop();
			Console.WriteLine(sw.Elapsed);
		}
	}
}
