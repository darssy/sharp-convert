namespace MmiSoft.Core.Math.Units.Struct;

public partial struct Degrees
{
	public static readonly Degrees _30 = new(30);
	public static readonly Degrees _45 = new(45);
	public static readonly Degrees _60 = new(60);
	public static readonly Degrees _90 = new(90);
	public static readonly Degrees _180 = new(180);
	public static readonly Degrees _360 = new(360);

	public static readonly Degrees FullCircle = _360;
	public static readonly Degrees HalfCircle = _180;
	public static readonly Degrees RightAngle = _90;
	public static readonly Degrees Thirty = _30;
	public static readonly Degrees FortyFive = _45;
	public static readonly Degrees Sixty = _60;
}
