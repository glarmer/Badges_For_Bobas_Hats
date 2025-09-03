using System.Collections.Generic;
using System.Reflection;
using MoreBadges;

namespace Badges_for_Bobas_Hats;

public class AchievementFlagManager
{
    public static bool HasConsumedRed = false;
    public static bool HasConsumedOrange = false;
    public static bool HasConsumedYellow = false;
    public static bool HasConsumedGreen = false;
    public static bool HasConsumedBlue = false;
    public static bool HasConsumedPurple = false;
    public static bool HasConsumedPink = false;

    public static bool HasConsumedNaturalFood = false;
    
    public static bool HasHealedThisGame = false;
    
    static AchievementFlagManager()
    {
        GlobalEvents.OnSomeoneWonRun += UnlockWinBasedAchievements;
        GlobalEvents.OnRunEnded += ResetAchievementFlags;
    }

    private static void ResetAchievementFlags()
    {
        foreach (var field in typeof(AchievementFlagManager).GetFields(BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic))
        {
            if (field.FieldType == typeof(bool))
            {
                field.SetValue(null, false); 
            }
        }
    }

    private static void UnlockWinBasedAchievements()
    {
        if (!HasConsumedNaturalFood) MoreBadgesPlugin.AddProgress(BadgeNames.MustardBadge, 1);
    }
}