namespace MmiSoft.Core.Math.Units
{
	public class Kilogram : MassUnit
	{

		public Kilogram() : this(0){}

		public Kilogram(double mass) : base(mass, 1)
		{
		}

		public override string Symbol => "Kg";

		public static Kilogram operator -(Kilogram x, Kilogram y)
		{
			return new Kilogram(System.Math.Abs(x.unitValue - y.unitValue));
		}

		public static Kilogram operator +(Kilogram x, Kilogram y)
		{
			return new Kilogram(x.unitValue + y.unitValue);
		}

		public static Kilogram operator -(Kilogram x, MassUnit y)
		{
			if (y is Kilogram k) return x - k;
			return Subtract<Kilogram>(x, y);
		}

		public static Kilogram operator +(Kilogram x, MassUnit y)
		{
			if (y is Kilogram k) return x + k;
			return Add<Kilogram>(x, y);
		}
	}
}
