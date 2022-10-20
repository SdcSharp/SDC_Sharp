namespace SDC_Sharp.Types.Interfaces
{
	public interface IUserWarns
	{
		public ulong Id { get; }
		public string Type { get; }
		public sbyte Warns { get; }
	}
}