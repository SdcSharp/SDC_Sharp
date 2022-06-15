using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SDC_Sharp.Types.Bots;
using SDC_Sharp.Types.Interfaces;

namespace SDC_Sharp.Services
{
    public class BaseBotsService
    {
        protected readonly SdcSharpClient Client;

        public BaseBotsService(SdcSharpClient client)
        {
            Client = client;
        }

        protected void AutoPostStats(TimeSpan interval, ulong botId, uint shards = 1, uint servers = 1,
            bool logging = false)
        {
            _ = Task.Run(async () =>
            {
                while (true)
                {
                    var response = await PostStats<StatsResponse>(botId, shards, servers);
                    if (logging)
                        Console.WriteLine("{ status: " + response.Status + " }");

                    await Task.Delay(interval);
                }
            });
        }

        protected async Task<T> PostStats<T>(ulong botId, uint shards = 1, uint servers = 1)
            where T : IStatsResponse
        {
            shards = shards == 0 ? 1 : shards;
            servers = servers == 0 ? 1 : servers;

            return await Client.PostRequest<T>(
                "/bots" + botId + "/stats",
                new StringContent(
                    JsonConvert.SerializeObject(
                        new Dictionary<string, uint>
                        {
                            {"shardsCount", shards},
                            {"serversCount", servers}
                        }
                    ),
                    Encoding.ASCII,
                    "application/json"
                )
            );
        }
    }
}