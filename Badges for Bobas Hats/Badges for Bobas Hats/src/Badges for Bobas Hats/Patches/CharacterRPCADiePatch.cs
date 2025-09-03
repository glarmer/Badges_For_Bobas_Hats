using HarmonyLib;
using MoreBadges;

namespace Badges_for_Bobas_Hats.Patches;

public class CharacterRPCADiePatch
{
    [HarmonyPatch(typeof(Character), nameof(Character.RPCA_Die))]
    [HarmonyPostfix]
    static void Prefix(Character __instance)
    {
        if (__instance.data.isCarried)
        {
            MoreBadgesPlugin.AddProgress(BadgeNames.ChairBadge, 1);
        }
    }
}