# SDC_Sharp
* C# враппер для [SDC API](https://docs.server-discord.com)
* API документация: https://docs.server-discord.com/
* [Сервер поддержки](https://discord.gg/NSkg6N9) враппера 

## Установка

Основной пакет: https://www.nuget.org/packages/SDC_Sharp/

Discord.NET расширение: https://www.nuget.org/packages/SDC_Sharp.DiscordNet/
DSharpPlus расширение: https://www.nuget.org/packages/SDC_Sharp.DSharpPlus/

# Внимание!
## Враппер полностью асинхронен. Любые вызовы функций следует проводить только в асинхронных функциях

## Использование, на примере расширения для Discord.NET

```cs
using SDC_Sharp.DiscordNet.Types;
using SDC_Sharp.DiscordNet;

namespace BotNamespace
{
    internal class BotName
    {
        . . .

        public static async Task RunAsync()
        {
            await using var services = new ServiceCollection()
                .AddSdcClient(new SdcClientConfig
                    {
                        // Сюда надо вписать токен бота
                        Token = @"eyJhbGciOiJIUzI1NiIsInR...",

                        // Здесь надо передать объект враппера, в данном примере для бота с шардами
                        Wrapper = new ShardedDiscordClientWrapper(client)
                    })
                .BuildServiceProvider();
        }

        . . .
    }
}
```

### Расширения включают в себя 3 основных класса:


#### Monitoring

```cs
class Monitoring
{
    // guildId - id сервера для поиска на сайте
    async Task<GuildInfo> GetGuild(ulong guildId);
    async Task<GuildPlace> GetGuildPlace(ulong guildId);

    // fetch - нужно ли фетчить сервер дискорда
    async Task<GuildRatedUsers> GetGuildRated(ulong guildId, bool fetch = false);

    // fetch - нужно ли фетчить пользователя дискорда
    async Task<UserRatedServers> GetUserRatedServers(ulong userId, bool fetch = false);
}
```


```cs
using SDC_Sharp.DiscordNet;
using SDC_Sharp.SDC_Sharp;

public class YourCommandsModule : ModuleBase<ShardedCommandContext>
{
    private readonly SdcSharpClient _sdcSharpClient;

    public YourCommandsModule(SdcSharpClient sdcSharpClient) => _sdcSharpClient = sdcSharpClient;

    [Command("monitoring")]
    public async Task Monitoring(ulong? id = null)
    {
        var guild = await _sdcSharpClient.GetMonitoring()

        await ReplyAsync(embed: guild.ToEmbed().Build());
    }
}
```

#### Blacklist

```cs
class Blacklist
{
    // id - пользователя или сервера, для взятия варнов
    async Task<BlacklistResponse> GetWarns(ulong id);
}
```

```cs
using SDC_Sharp.DiscordNet;
using SDC_Sharp.SDC_Sharp;

public class YourCommandsModule : ModuleBase<ShardedCommandContext>
{
    private readonly SdcSharpClient _sdcSharpClient;

    public YourCommandsModule(SdcSharpClient sdcSharpClient) => _sdcSharpClient = sdcSharpClient;

    [Command("warns")]
    public async Task Warns(ulong? id = null)
    {
        var blackList = await _sdcSharpClient.GetBlacklist().GetWarns(id ?? Context.User.Id);

        await ReplyAsync(embed: await blackList.ToEmbed());
    }
}
```

#### Bots

```cs
class Bots
{
    // Ручное обновление статистики
    // clientId     - id бота которому нужно обновить статистику
    // shardsCount  - количество шардов, но не менее 1
    // serversCount - количество серверов
    async Task<BotsResponse> UpdateStats(int serversCount, int shardsCount, ulong clientId);

    // Автоматическая отправка статистики, параметры можно указывать вручную, но они могут и братся автоматически
    // все тоже что и для ручного обновления
    // timeout      - задержка между интервалами отправки статистики, но не менее 30 минут
    async Task AutoUpdateStats(int? serversCount, int? shardsCount, ulong? clientId, TimeSpan timeout = default);
    
    // Тоже что и выше, только автоматическая отправка добавляется в свободный Thread через ThreadPool
    void AutoUpdateStatsThreaded(int? serversCount, int? shardsCount, ulong? clientId, TimeSpan timeout = default);
}
```

```cs
using SDC_Sharp.DiscordNet;
using SDC_Sharp.SDC_Sharp;

public class YourCommandsModule : ModuleBase<ShardedCommandContext>
{
    private readonly SdcSharpClient _sdcSharpClient;

    public YourCommandsModule(SdcSharpClient sdcSharpClient) => _sdcSharpClient = sdcSharpClient;

    [Command("stats")]
    public async Task Stats(ulong? id = null)
    {
        var bots = _sdcSharpClient.GetBots();

        await bots.AutoUpdateStats(null, null, null, TimeSpan.FromHours(4));
    }
}
```
