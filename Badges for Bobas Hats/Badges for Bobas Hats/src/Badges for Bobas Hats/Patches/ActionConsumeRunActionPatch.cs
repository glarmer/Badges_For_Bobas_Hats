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

        if (!MoreBadgesPlugin.GetCustomBadgeStatus(BadgeNames.RainbowBadge)!.isUnlocked)
        {
            if (__instance.item.name.Contains("Red")) AchievementFlagManager.HasConsumedRed = true;
            if (__instance.item.name.Contains("Orange")) AchievementFlagManager.HasConsumedOrange = true;
            if (__instance.item.name.Contains("Yellow")) AchievementFlagManager.HasConsumedYellow = true;
            if (__instance.item.name.Contains("Green")) AchievementFlagManager.HasConsumedGreen = true;
            if (__instance.item.name.Contains("Blue")) AchievementFlagManager.HasConsumedBlue = true;
            if (__instance.item.name.Contains("Purple")) AchievementFlagManager.HasConsumedPurple = true;
            if (__instance.item.name.Contains("Pink")) AchievementFlagManager.HasConsumedPink = true;

            if (AchievementFlagManager.HasConsumedRed &&AchievementFlagManager.HasConsumedOrange && AchievementFlagManager.HasConsumedYellow && 
                AchievementFlagManager.HasConsumedGreen && AchievementFlagManager.HasConsumedBlue &&
                AchievementFlagManager.HasConsumedPurple && AchievementFlagManager.HasConsumedPink)
            {
                MoreBadgesPlugin.AddProgress(BadgeNames.RainbowBadge, 1);
            }
        }

        if (!MoreBadgesPlugin.GetCustomBadgeStatus(BadgeNames.MustardBadge).isUnlocked)
        {
            if (__instance.item.name.Contains("Coconut")) AchievementFlagManager.HasConsumedNaturalFood = true;
            if (__instance.item.name.ToLower().Contains("berry")) AchievementFlagManager.HasConsumedNaturalFood = true;
            if (__instance.item.name.ToLower().Contains("root")) AchievementFlagManager.HasConsumedNaturalFood = true;
        }
        
    }
}