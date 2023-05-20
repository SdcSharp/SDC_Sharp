using System;
using System.Runtime.CompilerServices;
using SDC_Sharp.Types.Enums;

namespace SDC_Sharp.Types;

public static class Extensions
{
	[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
	public static bool HasBadge(this GuildBadges badges, GuildBadges badge)
	{
		return ((byte)badges & (byte)badge) != 0;
	}

	public static string BadgeToString(this GuildBadges badge)
	{
		return badge switch
		{
			GuildBadges.None => nameof(GuildBadges.None),
			GuildBadges.SiteDev => nameof(GuildBadges.SiteDev),
			GuildBadges.Verified => nameof(GuildBadges.Verified),
			GuildBadges.Partner => nameof(GuildBadges.Partner),
			GuildBadges.Favorite => nameof(GuildBadges.Favorite),
			GuildBadges.BugHunter => nameof(GuildBadges.BugHunter),
			GuildBadges.EasterEgg => nameof(GuildBadges.EasterEgg),
			GuildBadges.BotDev => nameof(GuildBadges.BotDev),
			GuildBadges.YouTube => nameof(GuildBadges.YouTube),
			GuildBadges.Twitch => nameof(GuildBadges.Twitch),
			GuildBadges.SpamHunt => nameof(GuildBadges.SpamHunt),
			_ => throw new ArgumentOutOfRangeException(nameof(badge), badge, null)
		};
	}

	public static string BoostLevelToString(this GuildBoostLevel boostLevel)
	{
		return boostLevel switch
		{
			GuildBoostLevel.None => nameof(GuildBoostLevel.None),
			GuildBoostLevel.Light => nameof(GuildBoostLevel.Light),
			GuildBoostLevel.Pro => nameof(GuildBoostLevel.Pro),
			GuildBoostLevel.Max => nameof(GuildBoostLevel.Max),
			_ => throw new ArgumentOutOfRangeException(nameof(boostLevel), boostLevel, null)
		};
	}

	public static string LanguageToString(this GuildLanguages language)
	{
		return language switch
		{
			GuildLanguages.None => nameof(GuildLanguages.None),
			GuildLanguages.All => nameof(GuildLanguages.All),
			GuildLanguages.Ru => nameof(GuildLanguages.Ru),
			GuildLanguages.Ua => nameof(GuildLanguages.Ua),
			GuildLanguages.En => nameof(GuildLanguages.En),
			_ => throw new ArgumentOutOfRangeException(nameof(language), language, null)
		};
	}

	public static string TagsToString(this GuildTags tags)
	{
		return tags switch
		{
			GuildTags.None => nameof(GuildTags.None),
			GuildTags.Nsfw => nameof(GuildTags.Nsfw),
			GuildTags.Anime => nameof(GuildTags.Anime),
			GuildTags.Games => nameof(GuildTags.Games),
			GuildTags.Art => nameof(GuildTags.Art),
			GuildTags.Business => nameof(GuildTags.Business),
			GuildTags.Music => nameof(GuildTags.Music),
			GuildTags.Communication => nameof(GuildTags.Communication),
			GuildTags.RolePlay => nameof(GuildTags.RolePlay),
			GuildTags.Politics => nameof(GuildTags.Politics),
			GuildTags.Programming => nameof(GuildTags.Programming),
			GuildTags.Community => nameof(GuildTags.Community),
			GuildTags.Technologies => nameof(GuildTags.Technologies),
			GuildTags.Films => nameof(GuildTags.Films),
			GuildTags.Fun => nameof(GuildTags.Fun),
			GuildTags.Other => nameof(GuildTags.Other),
			_ => throw new ArgumentOutOfRangeException(nameof(tags), tags, null)
		};
	}

	public static string RateToString(this Rate rate)
	{
		return rate switch
		{
			Rate.None => nameof(Rate.None),
			Rate.Positive => nameof(Rate.Positive),
			Rate.Negative => nameof(Rate.Negative),
			_ => throw new ArgumentOutOfRangeException(nameof(rate), rate, null)
		};
	}
}