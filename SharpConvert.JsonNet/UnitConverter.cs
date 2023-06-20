using System;
using System.Globalization;
using MmiSoft.Core.Configuration;
using MmiSoft.Core.Math.Units;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace MmiSoft.Core.Json;

public class UnitConverter : JsonConverter<UnitBase>
{
	private CultureInfo culture;

	public UnitConverter(CultureInfo culture)
	{
		this.culture = culture;
	}

	public override void WriteJson(JsonWriter writer, UnitBase value, JsonSerializer serializer)
	{
		serializer.Serialize(writer, new JValue(value.ToString("G", culture)));
	}

	public override UnitBase ReadJson(JsonReader reader, Type objectType, UnitBase existingValue, bool hasExistingValue,
	                                  JsonSerializer serializer)
	{
		string unitAsText = JToken.Load(reader).Value<string>();
		UnitBase unit = unitAsText?.ParseUnit(culture);
		if (unit?.GetType() != objectType && !objectType.IsInstanceOfType(unit))
		{
			throw new ArgumentException("Unit mismatch");
		}
		return unit;
	}
}

public sealed class UnitConverterAttribute : JsonConverterBaseAttribute
{
	private CultureInfo culture;
	public UnitConverterAttribute(string culture)
	{
		this.culture = CultureInfo.GetCultureInfo(culture);
	}

	public override JsonConverter Create() => new UnitConverter(culture);
}
