using System;
using MmiSoft.Core.Math.Units;
using NUnit.Framework;

namespace UnitTests.MmiSoft.Core.Math.Units
{
	[TestFixture]
	public class ParseTest
	{
		[Test]
		public void ParseFeet_HappyPathScenario()
		{
			UnitBase parsed = "30.5ft".Parse();
			Assert.AreEqual(30.5.Feet(), parsed);
		}

		[Test]
		public void ParseFeet_InvalidInput_ExceptionIsThrown()
		{
			Assert.Catch<Exception>(() => "garbage".Parse());
			Assert.Catch<Exception>(() => "390.45garbage".Parse());
		}
	}
}
