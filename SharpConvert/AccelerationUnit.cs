namespace MmiSoft.Core.Math.Units
{
	public abstract class AccelerationUnit : UnitBase
	{
		protected AccelerationUnit(double unitValue, double toSiFactor) : base(unitValue, toSiFactor)
		{
		}

		protected abstract SpeedUnit GetSpeedUnit();

		public A To<A>() where A : AccelerationUnit, new()
		{
			return ConvertTo<A, AccelerationUnit>(this);
		}

		public static SpeedUnit operator *(AccelerationUnit a, TimeUnit t)
		{
			double s = a.ToSi() * t.ToSi();
			SpeedUnit changeInSpeed = a.GetSpeedUnit();
			changeInSpeed.FromSi(System.Math.Abs(s));
			return changeInSpeed;
		}

		public static AccelerationUnit operator -(AccelerationUnit x)
		{
			AccelerationUnit cloned = (AccelerationUnit)x.MemberwiseClone();
			cloned.unitValue = -cloned.unitValue;
			return cloned;
		}
	}
}
