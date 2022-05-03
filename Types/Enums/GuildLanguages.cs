using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace SDC_Sharp.Types.Enums
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum GuildLanguages : byte
    {
        None = 0,
        [EnumMember(Value = "al")]
        All,
        Ru,
        Ua,
        En
    }
}