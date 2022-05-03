namespace SDC_Sharp.Types
{
    public abstract class BaseService
    {
        protected readonly SdcSharpClient Client;
        protected BaseService(SdcSharpClient client) => Client = client;
    }
}