using System.Threading.Tasks;
using SDC_Sharp.Types;
using SDC_Sharp.Types.Blacklist;
using SDC_Sharp.Types.Interfaces;

namespace SDC_Sharp.Services
{
    public class BaseBlacklistService : BaseService
    {
        public BaseBlacklistService(SdcSharpClient client) : base(client) { }

        public async ValueTask<BaseUserWarns> GetWarns(ulong userId)
        {
            return await GetWarns<BaseUserWarns>(userId);
        }
        
        public async ValueTask<T> GetWarns<T>(ulong userId) where T: IUserWarns
        {
            return await Client.GetRequest<T>("warns/" + userId);
        }
    }
}