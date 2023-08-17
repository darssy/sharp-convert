using System;

namespace MmiSoft.Core.Math.Units.Struct;

public partial struct Seconds
{
	public Seconds(TimeSpan time)
		:this(time.TotalSeconds)
	{ }
}

public partial struct Minutes
{
	public Minutes(TimeSpan time)
		:this(time.TotalMinutes)
	{ }
}

public partial struct Hours
{
	public Hours(TimeSpan time)
		:this(time.TotalHours)
	{ }
}
