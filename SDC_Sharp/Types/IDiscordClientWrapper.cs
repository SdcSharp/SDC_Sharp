namespace SDC_Sharp.SDC_Sharp.Types
{
    public interface IDiscordClientWrapper
    {
        public int ShardCount { get; }
        public int ServersCount { get; }
        public ulong CurrentUserId { get; }
    }
}