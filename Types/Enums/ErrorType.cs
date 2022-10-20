using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace SDC_Sharp.Types.Enums
{
	[JsonConverter(typeof(StringEnumConverter))]
	public enum ErrorType : byte
	{
		NoContent
	}
}