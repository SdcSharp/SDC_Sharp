using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SDC_Sharp.Types.Bots;
using SDC_Sharp.Types.Interfaces;

namespace SDC_Sharp.Services;

public abstract class BaseBotsService
{
	protected readonly ISdcSharpClient Client;

	public BaseBotsService(ISdcSharpClient client)
	{
		Client = client;
	}

	protected void AutoPostStats(TimeSpan interval,
		ulong botId,
		uint shards = 1,
		uint servers = 1,
		bool logging = false,
		CancellationToken cancellationToken = default)
	{
		_ = Task.Run(async () =>
		{
			while (!cancellationToken.IsCancellationRequested)
			{
				var response = await PostStats<StatsResponse>(botId, shards, servers);
				if (logging)
					Console.WriteLine("{ status: " + response.Status + " }");

				await Task.Delay(interval, cancellationToken);
			}
		}, cancellationToken);
	}

	protected Task<T> PostStats<T>(ulong botId, uint shards = 1, uint servers = 1)
		where T : IStatsResponse
	{
		return Client.PostRequest<T>(
			"/bots/" + botId + "/stats",
			new StringContent(
				JsonConvert.SerializeObject(
					new Dictionary<string, uint>
					{
						{ "shardsCount", shards },
						{ "serversCount", servers }
					}
				),
				Encoding.ASCII,
				"application/json"
			)
		);
	}
}