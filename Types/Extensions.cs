using System.Runtime.CompilerServices;
using SDC_Sharp.Types.Enums;

namespace SDC_Sharp.Types
{
    public static class Extensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        public static bool HasBadge(this GuildBadges badges, GuildBadges badge)
        {
            return ((byte) badges & (byte) badge) != 0;
        }
    }
}