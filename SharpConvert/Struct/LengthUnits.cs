using System;

namespace MmiSoft.Core.Math.Units.Struct;

public interface ILength : IComparable<ILength>
{
	double UnitValue { get; }
	internal ILinearConversion Conversion { get; }

	internal double SiValue { get; }
	//internal double SiValue => UnitValue * Conversion.ToSiFactor;
}
