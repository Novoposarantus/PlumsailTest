using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.DTOs;
using Newtonsoft.Json.Linq;

namespace API.Helpers
{
    public static class JsonToValues
    {
        public static List<NewFieldDto> Parse(JObject json)
        {
            var result = new List<NewFieldDto>();
            var properties = json.Properties().ToList();
            for (var index = 0; index < properties.Count(); ++index)
            {
                var value = properties[index].Value;
                if (value.Type == JTokenType.Array)
                {
                    result.AddRange(value.Values<string>().Select(v => new NewFieldDto(v, index)));
                }

                if (value.Type == JTokenType.String)
                {
                    result.Add(new NewFieldDto(value.Value<string>(), index));
                }
            }

            return result;
        }
    }
}
