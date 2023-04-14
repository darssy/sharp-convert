namespace MmiSoft.Core.Math.Units.Struct;

public interface ISpeed
{
	double UnitValue { get; }
	internal ILinearConversion Conversion { get; }
	internal double SiValue { get; }
	//internal double SiValue => UnitValue * Conversion.ToSiFactor;
}
