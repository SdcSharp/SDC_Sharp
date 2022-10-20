using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace SDC_Sharp.Types.Enums
{
	[JsonConverter(typeof(StringEnumConverter))]
	public enum GuildTags : byte
	{
		None = 0,
		[EnumMember(Value = "eighteen")] Nsfw,
		Anime,
		Games,
		Art,
		Business,
		Music,
		Communication,
		[EnumMember(Value = "rp")] RolePlay,
		[EnumMember(Value = "policy")] Politics,
		Programming,
		Community,
		Technologies,
		Films,
		[EnumMember(Value = "humor")] Fun,
		[EnumMember(Value = "more")] Other
	}
}