using System;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
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
			return unitStr.ParseUnit(culture);
		}

		public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
		{
			return sourceType == typeof(string) && typeof(UnitBase).IsAssignableFrom(context.PropertyDescriptor?.PropertyType);
		}

		public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
		{
			return destinationType == typeof(string) || destinationType == typeof(InstanceDescriptor);
		}

		public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
		{
			if (destinationType == typeof(string))
			{
				return ((UnitBase)value).ToString("0.##");
			}
			if (destinationType == typeof(InstanceDescriptor))
			{
				return new InstanceDescriptor(value.GetType().GetConstructor(new[] { typeof(double) }),
					new[] { ((UnitBase)value).UnitValue });
			}
			return base.ConvertTo(context, culture, value, destinationType);
		}
	}
}
