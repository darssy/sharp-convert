using System;

namespace MmiSoft.Core.Math.Units
{
	[Serializable]
	public class Degrees : AngleUnit
	{
		public Degrees() :this(0f)
		{ }

		public Degrees(double unitValue)
			: base(unitValue, System.Math.PI / 180)
		{
		}

		public Degrees(decimal unitValue) : this((float)unitValue)
		{ }

		public Degrees(int unitValue)
			: this((float)unitValue)
		{ }
	}
}
