#nullable enable
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SDC_Sharp
{
    public class SdcSharpClient
    {
        internal static readonly HttpClient HttpClient = new HttpClient
        {
            BaseAddress = new Uri("https://api.server-discord.com/v2")
        };

        public readonly TimeSpan DefaultTimeout = TimeSpan.FromHours(4);
        internal readonly TimeSpan RateLimit = TimeSpan.FromSeconds(3);
        internal DateTime LastRequest;

        public SdcSharpClient(string token, IDiscordClientWrapper wrapper)
        {
            Wrapper = wrapper;

            HttpClient.DefaultRequestHeaders.Add("User-Agent", "Discord Bot");
            HttpClient.DefaultRequestHeaders.Add("Authorization", token.StartsWith("SDC ") ? token : $"SDC {token}");
            HttpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public IDiscordClientWrapper Wrapper { get; }

        public Task RateLimiter(TimeSpan? timeout = null)
        {
            return Task.Run(async () =>
            {
                timeout ??= RateLimit;

                while (true)
                {
                    if (LastRequest == new DateTime() || DateTime.UtcNow - LastRequest > timeout) break;
                    await Task.Delay((TimeSpan) timeout - (DateTime.UtcNow - LastRequest));
                }
            });
        }

        public async Task<T> PostRequest<T>(string path, StringContent data, HttpClient? httpClient = null,
            TimeSpan? timeout = null)
        {
            await RateLimiter(timeout ?? TimeSpan.FromMilliseconds(50f / 1000f));

            httpClient ??= HttpClient;
            var response = await httpClient.PostAsync(path, data);
            response.EnsureSuccessStatusCode();

            LastRequest = DateTime.UtcNow;

            return JsonConvert.DeserializeObject<T>(await response.Content.ReadAsStringAsync())!;
        }

        public async Task<T> GetRequest<T>(string path, HttpClient? httpClient = null,
            TimeSpan? timeout = null)
        {
            await RateLimiter(timeout ?? TimeSpan.FromMilliseconds(50f / 1000f));

            httpClient ??= HttpClient;
            var response = await httpClient.GetAsync(path);
            response.EnsureSuccessStatusCode();

            LastRequest = DateTime.UtcNow;

            return JsonConvert.DeserializeObject<T>(await response.Content.ReadAsStringAsync())!;
        }
    }
}