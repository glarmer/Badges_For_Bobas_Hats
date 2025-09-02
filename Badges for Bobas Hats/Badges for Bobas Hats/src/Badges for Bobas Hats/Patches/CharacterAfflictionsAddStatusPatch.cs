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
        if (statusType == CharacterAfflictions.STATUSTYPE.Hot)
        {
            int index = (int) statusType;
            if (__instance.currentStatuses[index] >= 1)
            {
                MoreBadgesPlugin.AddProgress(BadgeNames.ToastBadge, 1);
            }
        }
    }
}