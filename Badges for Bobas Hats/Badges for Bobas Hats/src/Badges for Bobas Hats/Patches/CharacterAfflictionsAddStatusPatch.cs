using HarmonyLib;
using MoreBadges;
using Peak.Afflictions;

namespace Badges_for_Bobas_Hats.Patches;

public class CharacterAfflictionsAddStatusPatch
{
    [HarmonyPatch(typeof(CharacterAfflictions), "AddStatus")]
    [HarmonyPostfix]
    static void Postfix(CharacterAfflictions __instance, CharacterAfflictions.STATUSTYPE statusType)
    {
        int index = (int) statusType;
        if (statusType == CharacterAfflictions.STATUSTYPE.Hot)
        {
            if (__instance.currentStatuses[index] >= 1)
            {
                MoreBadgesPlugin.AddProgress(BadgeData.ToastBadge, 1);
            }
        } else if (statusType == CharacterAfflictions.STATUSTYPE.Cold)
        {
            if (__instance.currentStatuses[index] >= 1)
            {
                MoreBadgesPlugin.AddProgress(BadgeData.PenguinBadge, 1);
            }
        }
    }
}