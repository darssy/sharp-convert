using System;
using System.Collections.Generic;
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

			const int capacity = 10000000;
			List<Meters> resultsList = new List<Meters>(capacity);
			List<Meters> metersList = new List<Meters>(capacity);
			List<Feet> feetList = new List<Feet>(capacity);

			for (int i = 0; i < capacity; i++)
			{
				metersList.Add(random.Next(50000).Meters());
				feetList.Add(random.Next(50000).Feet());
			}

			Stopwatch sw = Stopwatch.StartNew();
			for (int i = 0; i < capacity; i++)
			{
				resultsList.Add(metersList[i] - feetList[i]);
			}
			sw.Stop();
			Console.WriteLine(sw.Elapsed);
			Console.WriteLine(resultsList.Count);
		}
	}
}
