using System;

namespace MmiSoft.Core.Math.Units
{
	[Serializable]
	public sealed class Minutes : TimeUnit
	{
		public Minutes()
			: this(0)
		{ }

		public Minutes(double minutes)
			: base(minutes, 60)
		{ }

		public override string Symbol => "min";
	}
}
