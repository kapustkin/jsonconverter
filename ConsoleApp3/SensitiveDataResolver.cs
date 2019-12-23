using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace ConsoleApp3
{
    public class SensitiveDataResolver : DefaultContractResolver
    {
        protected override JsonContract CreateContract(Type objectType)
        {
            JsonContract contract = base.CreateContract(objectType);

            var attribute = (SensitiveDataAttribute)objectType.GetCustomAttribute(typeof(SensitiveDataAttribute));
            if (attribute != null)
            {
                // this will only be called once and then cached
                if (objectType == typeof(DateTime) || objectType == typeof(DateTimeOffset))
                {
                    //contract.Converter = new JavaScriptDateTimeConverter();
                }
            }

            return contract;
        }
        protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
        {
            var property = base.CreateProperty(member, memberSerialization);

            if (member is PropertyInfo)
            {
                var prop = member as PropertyInfo;
                var attribute = (SensitiveDataAttribute)prop.GetCustomAttribute(typeof(SensitiveDataAttribute));
                if (attribute != null)
                {
                    switch (attribute.dataType)
                    {
                        case DataType.Passport:
                            //property.ValueProvider = new StringValueProvider("***");
                            break;
                        case DataType.Family:
                            //property.ValueProvider = new StringValueProvider("*");
                            break;
                        case DataType.VinCode:
                            property.Converter = new SensetiveJsonConverter();
                            break;
                        default:
                            break;
                    }


                }

            }

            return property;
        }
    }
}
