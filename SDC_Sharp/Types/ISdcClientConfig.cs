namespace SDC_Sharp.SDC_Sharp.Types
{
    public interface ISdcClientConfig
    {
        public IDiscordClientWrapper Wrapper { get; set; }
        public string Token { get; set; }
    }
}