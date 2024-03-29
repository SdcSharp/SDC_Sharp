using System.Threading.Tasks;
using SDC_Sharp.Types.Interfaces;

namespace SDC_Sharp.Services;

public abstract class BaseBlacklistService
{
	protected readonly ISdcSharpClient Client;

	public BaseBlacklistService(ISdcSharpClient client)
	{
		Client = client;
	}

	protected async Task<T> GetWarns<T>(ulong userId) where T : IUserWarns
	{
		return await Client.GetRequest<T>("warns/" + userId);
	}
}