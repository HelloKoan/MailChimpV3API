using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace MailChimpV3API.Sections.Lists.Members
{
    public class MailChimpListMembersCollection : IMailChimpCollection
    {
        [JsonProperty("members")]
        public IEnumerable<MailChimpListMember> Members { get; set; }

        [JsonProperty("list_id")]
        public string ListId { get; set; }

        [JsonProperty("total_items")]
        public int TotalItems { get; set; }
    }

    public class IEnumerableConverter<T> : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, Newtonsoft.Json.JsonSerializer serializer)
        {
            serializer.Serialize(writer, value);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, Newtonsoft.Json.JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null)
            {
                return null;
            }

            var list = new List<T>();

            serializer.Populate(reader, list);

            return list;
        }

        public override bool CanConvert(Type objectType)
        {
            return typeof(List<T>).IsAssignableFrom(objectType);
        }
    }
}
