using SDC_Sharp.Types.Enums;

namespace SDC_Sharp.Types.Interfaces
{
    public interface IGuild
    {
        public string Name { get; }
        public string Avatar { get; }
        public string Invite { get; }
        public string OwnerTag { get; }
        public string TagsString { get; }
        public string Description { get; }

        public ulong Online { get; }
        public ulong Members { get; }
        public ulong UpPoints { get; }

        public bool IsBotOnServer { get; }

        public GuildBadges Badges { get; }
        public GuildBoostLevel Boost { get; }
        public GuildLanguages Language { get; }
    }
}