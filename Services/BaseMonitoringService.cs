using System.Threading.Tasks;
using SDC_Sharp.Types.Interfaces;

namespace SDC_Sharp.Services
{
    public class BaseMonitoringService
    {
        protected BaseMonitoringService(SdcSharpClient client) : base(client) { }

        public virtual async ValueTask<BaseGuild> GetGuild(ulong guildId)
        {
            return await GetGuild<BaseGuild>(guildId);
        }
        public async ValueTask<T> GetGuild<T>(ulong guildId) where T : IGuild
        {
            return await Client.GetRequest<T>("guild/" + guildId);
        }

        public async ValueTask<BaseGuildPlace> GetGuildPlace(ulong guildId)
        {
            return await GetGuildPlace<BaseGuildPlace>(guildId);
        }
        public async ValueTask<T> GetGuildPlace<T>(ulong guildId) where T : IGuildPlace
        {
            return await Client.GetRequest<T>("guild/" + guildId + "/place");
        }

        public async ValueTask<BaseRate> GetGuildRates(ulong guildId)
        {
            return await GetGuildRates<BaseRate>(guildId);
        }
        public async ValueTask<T> GetGuildRates<T>(ulong guildId)
        {
            return await Client.GetRequest<T>("guild/" + guildId + "/place");
        }

        public async ValueTask<BaseRate> GetUserRates(ulong userId)
        {
            return await GetUserRates<BaseRate>(userId);
        }
        public async ValueTask<T> GetUserRates<T>(ulong userId)
        {
            return await Client.GetRequest<T>("user/" + userId + "/place");
        }
    }
}
