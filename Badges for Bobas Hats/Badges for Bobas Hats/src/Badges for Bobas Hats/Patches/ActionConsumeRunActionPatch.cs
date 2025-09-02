using HarmonyLib;
using MoreBadges;

namespace Badges_for_Bobas_Hats.Patches;

public class ActionConsumeRunActionPatch
{
    private const int HoneycombItemID = 38;

    [HarmonyPatch(typeof(Action_Consume), nameof(Action_Consume.RunAction))]
    [HarmonyPostfix]
    static void Postfix(Action_Consume __instance)
    {
        if(__instance.item.itemID == HoneycombItemID) MoreBadgesPlugin.AddProgress(BadgeNames.BearBadge, 1);
    }
}