using System.Threading.Tasks;
using SDC_Sharp.Types.Interfaces;

namespace SDC_Sharp.Services
{
	public class BaseMonitoringService
	{
		protected readonly SdcSharpClient Client;

		public BaseMonitoringService(SdcSharpClient client)
		{
			Client = client;
		}

		protected async Task<T> GetGuild<T>(ulong guildId) where T : IGuild
		{
			return await Client.GetRequest<T>("guild/" + guildId);
		}

		protected async Task<T> GetGuildPlace<T>(ulong guildId) where T : IGuildPlace
		{
			return await Client.GetRequest<T>("guild/" + guildId + "/place");
		}

		protected async Task<T> GetGuildRates<T>(ulong guildId)
		{
			return await Client.GetRequest<T>("guild/" + guildId + "/rated");
		}

		protected async Task<T> GetUserRates<T>(ulong userId)
		{
			return await Client.GetRequest<T>("user/" + userId + "/rated");
		}
	}
}