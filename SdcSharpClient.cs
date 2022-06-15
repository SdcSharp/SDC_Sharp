#nullable enable
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using ComposableAsync;
using Newtonsoft.Json;
using RateLimiter;
using SDC_Sharp.Types;

namespace SDC_Sharp
{
    public sealed class SdcSharpClient
    {
        private static HttpClient _httpClient = null!;

        private static readonly TimeLimiter _botsRateLimit =
            TimeLimiter.GetFromMaxCountByInterval(2, TimeSpan.FromMinutes(1));

        private static readonly DelegatingHandler _handler =
            TimeLimiter.GetFromMaxCountByInterval(5, TimeSpan.FromSeconds(10)).AsDelegatingHandler();

        public SdcSharpClient(SdcConfig config)
        {
            _httpClient = new HttpClient(_handler);
            _httpClient.BaseAddress = new Uri("https://api.server-discord.com/v2");
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            _httpClient.DefaultRequestHeaders.Add("Authorization", config.Token);
        }

        internal async Task<T> PostRequest<T>(string path, StringContent data)
        {
            await _botsRateLimit;
            return await Request<T>(_httpClient.PostAsync(path, data));
        }

        internal async Task<T> GetRequest<T>(string path)
        {
            return await Request<T>(_httpClient.GetAsync(path));
        }

        private async Task<T> Request<T>(Task<HttpResponseMessage> task)
        {
            var response = await task;
            response.EnsureSuccessStatusCode();
            var str = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<T>(str)!;
        }
    }
}