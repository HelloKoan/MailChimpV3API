using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace MailChimpV3API
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum CollectionSortDirection
    {
        [EnumMember(Value = "ASC")]
        Ascending,

        [EnumMember(Value = "DESC")]
        Descending
    }
}