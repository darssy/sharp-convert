using System;
using System.ComponentModel;
using System.Globalization;

namespace MmiSoft.Core.Math.Units.ComponentModel
{
	public class UnitsConverter : TypeConverter
	{
		public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
		{
			string unitStr = value?.ToString();
			if (unitStr == null)
			{
				throw new ArgumentException($"'null' is not a valid value for {context.PropertyDescriptor?.PropertyType.FullName}");
			}
			return unitStr.Parse(culture);
		}

		public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
		{
			return sourceType == typeof(string) && typeof(UnitBase).IsAssignableFrom(context.PropertyDescriptor?.PropertyType);
		}

		public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
		{
			return destinationType == typeof(string)
				? ((UnitBase)value).ToString("0.##")
				: base.ConvertTo(context, culture, value, destinationType);
		}
	}
}
