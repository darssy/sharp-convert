// better than having to do it to every file but still you have to do it to every project. Yikes.
global using FpmPerSecond = SharpConvert.Experimental.Acceleration<
		SharpConvert.Experimental.Length.ft,
		SharpConvert.Experimental.Time.min,
		SharpConvert.Experimental.Time.s>;
using System;

namespace SharpConvert.Experimental
{
	// This has to be on every file. Yikes ^ 2.
	using MetersPerSecondSq = Acceleration<Length.m, Time.s, Time.s>;

	public class SyntaxTest
	{
		public void Test()
		{
			var v = new FpmPerSecond(2);
			v.To(out MetersPerSecondSq c); //Quirky but type inference doesn't work with return types
			Console.WriteLine(c.ToString());
		}
	}
}
