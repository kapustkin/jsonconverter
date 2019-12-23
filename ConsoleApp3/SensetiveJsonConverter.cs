using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace ConsoleApp3
{
    public class SensetiveJsonConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return true;
        }

        public override object ReadJson(JsonReader reader, Type objectType,  object existingValue, JsonSerializer serializer)
        {
            return existingValue;
        }

        public override void WriteJson(JsonWriter writer,  object existingValue, JsonSerializer serializer)
        {
            var value = existingValue?.ToString();
            writer.WriteValue(value != null ? $"{value[0]}***{value[value.Length - 1]}" : null);

            //https://www.newtonsoft.com/json/help/html/ContractResolver.htm
        }
    }
}
