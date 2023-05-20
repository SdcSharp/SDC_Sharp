using System.Net.Http;
using System.Threading.Tasks;

namespace SDC_Sharp;

public interface ISdcSharpClient
{
	public Task<T> PostRequest<T>(string path, StringContent data);

	public Task<T> GetRequest<T>(string path);
}