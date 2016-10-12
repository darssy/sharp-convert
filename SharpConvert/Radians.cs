using System;

namespace MmiSoft.Core.Math.Units
{
	[Serializable]
	public class Radians : AngleUnit
	{
		public Radians() : this(0)
		{ }

		public Radians(double unitValue)
			: base(unitValue, 1)
		{
		}
	}
}