using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;


namespace Euronet.System.Enums
{
    [Serializable]
    [JsonConverter(typeof(StringEnumConverter))]
    public enum SortDirection
    {
        [EnumMember(Value = "asc")]
        Asc,
        [EnumMember(Value = "dsc")]
        Dsc
    }
}
