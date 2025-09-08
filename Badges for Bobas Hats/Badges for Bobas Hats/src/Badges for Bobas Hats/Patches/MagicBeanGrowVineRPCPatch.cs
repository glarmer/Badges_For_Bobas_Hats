using HarmonyLib;
using MoreBadges;

namespace Badges_for_Bobas_Hats.Patches;

public class MagicBeanGrowVineRPCPatch
{
    [HarmonyPatch(typeof(MagicBean), nameof(MagicBean.GrowVineRPC))]
    [HarmonyPostfix]
    static void Postfix()
    {
        MoreBadgesPlugin.AddProgress(BadgeData.MagicBeanVineBadge, 1);
    }
}