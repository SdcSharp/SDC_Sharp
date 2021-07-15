namespace SDC_Sharp
{
    public interface IDiscordClientWrapper
    {
        public int ShardCount { get; }
        public int ServersCount { get; }
        public ulong CurrentUserId { get; }
    }
}