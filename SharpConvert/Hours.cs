using System;

namespace MmiSoft.Core.Math.Units
{
	[Serializable]
	public class Hours : TimeUnit
	{
		public Hours()
			: this(0)
		{ }

		public Hours(double hours)
			: base(hours, Conversion.Hour)
		{ }

		public Hours(TimeSpan time)
			:this(time.TotalHours)
		{ }

		public static implicit operator Hours(TimeSpan t)
		{
			return new Hours(t);
		}

	}
}
