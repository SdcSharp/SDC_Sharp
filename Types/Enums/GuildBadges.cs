using System;

namespace SDC_Sharp.Types.Enums
{
    [Flags]
    public enum GuildBadges : ushort
    {
        None = 0,
        SiteDev = 1 << 0,
        Verified = 1 << 1,
        Partner = 1 << 2,
        Favorite = 1 << 3,
        BugHunter = 1 << 4,
        EasterEgg = 1 << 5,
        BotDev = 1 << 6,
        YouTube = 1 << 7,
        Twitch = 1 << 8,
        SpamHunt = 1 << 9
    }
}