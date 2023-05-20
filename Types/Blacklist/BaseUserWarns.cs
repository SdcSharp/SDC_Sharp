using SDC_Sharp.Types.Interfaces;

namespace SDC_Sharp.Types.Blacklist;

public abstract record BaseUserWarns(ulong Id, sbyte Warns, string Type = "user") : IUserWarns;