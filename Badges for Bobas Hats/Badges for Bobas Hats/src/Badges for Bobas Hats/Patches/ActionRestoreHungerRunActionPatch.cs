using HarmonyLib;
using MoreBadges;

namespace Badges_for_Bobas_Hats.Patches;

public class ActionRestoreHungerRunActionPatch
{
    private const int HoneycombItemID = 38;

    [HarmonyPatch(typeof(Action_RestoreHunger), nameof(Action_RestoreHunger.RunAction))]
    [HarmonyPostfix]
    static void Postfix(Action_RestoreHunger __instance)
    {
        if(__instance.item.itemID == HoneycombItemID) MoreBadgesPlugin.AddProgress(BadgeNames.BearBadge, 1);

        if (!MoreBadgesPlugin.GetCustomBadgeStatus(BadgeNames.RainbowBadge)!.isUnlocked)
        {
            if (__instance.item.name.ToLower().Contains("red")) AchievementFlagManager.HasConsumedRed = true;
            if (__instance.item.name.ToLower().Contains("orange")) AchievementFlagManager.HasConsumedOrange = true;
            if (__instance.item.name.ToLower().Contains("yellow")) AchievementFlagManager.HasConsumedYellow = true;
            if (__instance.item.name.ToLower().Contains("green")) AchievementFlagManager.HasConsumedGreen = true;
            if (__instance.item.name.ToLower().Contains("blue")) AchievementFlagManager.HasConsumedBlue = true;
            if (__instance.item.name.ToLower().Contains("purple")) AchievementFlagManager.HasConsumedPurple = true;
            if (__instance.item.name.ToLower().Contains("pink")) AchievementFlagManager.HasConsumedPink = true;
            Plugin.Logger.LogInfo($"Red {AchievementFlagManager.HasConsumedRed} Orange {AchievementFlagManager.HasConsumedOrange} Yellow {AchievementFlagManager.HasConsumedYellow}" +
                                  $"Green {AchievementFlagManager.HasConsumedGreen} Blue {AchievementFlagManager.HasConsumedBlue} Purple {AchievementFlagManager.HasConsumedPurple}" +
                                  $"Pink {AchievementFlagManager.HasConsumedPink}");

            if (AchievementFlagManager.HasConsumedRed && AchievementFlagManager.HasConsumedOrange && AchievementFlagManager.HasConsumedYellow && 
                AchievementFlagManager.HasConsumedGreen && AchievementFlagManager.HasConsumedBlue &&
                AchievementFlagManager.HasConsumedPurple && AchievementFlagManager.HasConsumedPink)
            {
                MoreBadgesPlugin.AddProgress(BadgeNames.RainbowBadge, 1);
            }
        }

        if (!MoreBadgesPlugin.GetCustomBadgeStatus(BadgeNames.MustardBadge)!.isUnlocked)
        {
            if (__instance.item.name.ToLower().Contains("coconut")) AchievementFlagManager.HasConsumedNaturalFood = true;
            if (__instance.item.name.ToLower().Contains("berry")) AchievementFlagManager.HasConsumedNaturalFood = true;
            if (__instance.item.name.ToLower().Contains("root")) AchievementFlagManager.HasConsumedNaturalFood = true;
            if (__instance.item.name.ToLower().Contains("shroom")) AchievementFlagManager.HasConsumedNaturalFood = true;
            Plugin.Logger.LogInfo($"Anti-naturalist: {AchievementFlagManager.HasConsumedNaturalFood}");
        }
        
    }
}