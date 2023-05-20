#nullable enable
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using ComposableAsync;
using Newtonsoft.Json;
using RateLimiter;
using SDC_Sharp.Types.Exceptions;
using SDC_Sharp.Types.Interfaces;

namespace SDC_Sharp;

public sealed class SdcSharpClient : ISdcSharpClient
{
	private static HttpClient s_httpClient = null!;

	private static readonly TimeLimiter s_botsRateLimit =
		TimeLimiter.GetFromMaxCountByInterval(2, TimeSpan.FromMinutes(1));

	private static readonly DelegatingHandler s_handler =
		TimeLimiter.GetFromMaxCountByInterval(5, TimeSpan.FromSeconds(10)).AsDelegatingHandler();

	public SdcSharpClient(ISdcConfig config)
	{
		s_httpClient = new HttpClient(s_handler);
		s_httpClient.BaseAddress = new Uri("https://api.server-discord.com/v2");
		s_httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

		s_httpClient.DefaultRequestHeaders.Add("Authorization", config.Token);
	}

	public async Task<T> PostRequest<T>(string path, StringContent data)
	{
		await s_botsRateLimit;
		return await Request<T>(s_httpClient.PostAsync(path, data));
	}

	public async Task<T> GetRequest<T>(string path)
	{
		return await Request<T>(s_httpClient.GetAsync(path));
	}

	private static async Task<T> Request<T>(Task<HttpResponseMessage> task)
	{
		var response = await task;
		response.EnsureSuccessStatusCode();
		var str = await response.Content.ReadAsStringAsync();

		if (str.StartsWith(@"{""error"":{"))
			throw ApiErrorException.GetException(JsonConvert.DeserializeObject<ApiError>(str)!.Error);

		return JsonConvert.DeserializeObject<T>(str)!;
	}
}