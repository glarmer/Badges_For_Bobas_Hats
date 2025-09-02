using HarmonyLib;
using MoreBadges;

namespace Badges_for_Bobas_Hats.Patches;

public class ActionConsumeRunActionPatch
{
    private const int HoneycombItemID = 38;
    private static bool hasConsumedRed = false;
    private static bool hasConsumedOrange = false;
    private static bool hasConsumedYellow = false;
    private static bool hasConsumedGreen = false;
    private static bool hasConsumedBlue = false;
    private static bool hasConsumedPurple = false;
    private static bool hasConsumedPink = false;

    [HarmonyPatch(typeof(Action_Consume), nameof(Action_Consume.RunAction))]
    [HarmonyPostfix]
    static void Postfix(Action_Consume __instance)
    {
        if(__instance.item.itemID == HoneycombItemID) MoreBadgesPlugin.AddProgress(BadgeNames.BearBadge, 1);

        if (!MoreBadgesPlugin.GetCustomBadgeStatus(BadgeNames.RainbowBadge)!.isUnlocked)
        {
            //TODO: reset these at the end of a run
            if (__instance.item.name.Contains("Red")) hasConsumedRed = true;
            if (__instance.item.name.Contains("Orange")) hasConsumedOrange = true;
            if (__instance.item.name.Contains("Yellow")) hasConsumedYellow = true;
            if (__instance.item.name.Contains("Green")) hasConsumedGreen = true;
            if (__instance.item.name.Contains("Blue")) hasConsumedBlue = true;
            if (__instance.item.name.Contains("Purple")) hasConsumedPurple = true;
            if (__instance.item.name.Contains("Pink")) hasConsumedPink = true;

            if (hasConsumedRed && hasConsumedOrange && hasConsumedYellow && hasConsumedGreen && hasConsumedBlue &&
                hasConsumedPurple && hasConsumedPink)
            {
                MoreBadgesPlugin.AddProgress(BadgeNames.RainbowBadge, 1);
            }
        }
        
    }
}