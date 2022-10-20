using SDC_Sharp.Types.Interfaces;

namespace SDC_Sharp.Types.Blacklist
{
	public abstract class BaseUserWarns : IUserWarns
	{
		public ulong Id { get; set; }
		public string Type { get; set; } = "user";
		public sbyte Warns { get; set; }
	}
}