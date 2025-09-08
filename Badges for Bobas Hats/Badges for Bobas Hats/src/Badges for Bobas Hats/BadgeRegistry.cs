using System.Collections.Generic;
using System.IO;
using System.Reflection;
using MoreBadges;
using UnityEngine;

namespace Badges_for_Bobas_Hats;

public static class BadgeRegistry
{
    
    public static void RegisterBadges()
    {
        RegisterLabubuBadges();
        RegisterBadge(BadgeData.BearBadge, 1, true, "Boba_bear");
        RegisterBadge(BadgeData.BowBadge, 1, true, "Boba_bow");
        RegisterBadge(BadgeData.ChairBadge, 1, true, "Boba_chair_hat");
        RegisterBadge(BadgeData.DiscoBadge, 1, true, "Boba_disco");
        RegisterBadge(BadgeData.JamiroBadge, 1, true, "Boba_jamiro_hat");
        RegisterBadge(BadgeData.MagicBeanVineBadge, 1, true, "Boba_sprout");
        RegisterBadge(BadgeData.MustardBadge, 1, true, "Boba_mustard");
        RegisterBadge(BadgeData.RainbowBadge, 1, true, "Boba_knit_rainbow");
        RegisterBadge(BadgeData.PenguinBadge, 1, true, "Boba_penguin");
        RegisterBadge(BadgeData.ToastBadge, 1, true, "Boba_toast");
    }

    private static void RegisterBadge(string id, int progressRequired, bool runBasedProgress, string cosmeticId)
    {
        Plugin.Logger.LogInfo("Registering a badge");
        string badgeName = id.Split(":")[1];
        Plugin.Logger.LogInfo($"Registering a badge: {badgeName}");
        List<string> names = BadgeData.GetLocalisationList((badgeName + "_Name"));
        List<string> descriptions = BadgeData.GetLocalisationList((badgeName + "_Description"));
        Plugin.Logger.LogInfo($"Registering a badge: {names[0]} {descriptions[0]}");
        Plugin.Logger.LogInfo($"Registering a badge: {names.ToString()} | {descriptions.ToString()}");
        MoreBadgesPlugin.CustomBadge newBadge = new MoreBadgesPlugin.CustomBadge(
            name: id,
            displayName: names[0],
            description: descriptions[0],
            icon: BadgeData.BadgeIcons[id],
            progressRequired: progressRequired,
            runBasedProgress: runBasedProgress,
            nameLocalizations: names,
            descriptionLocalizations: descriptions
        );
        MoreBadgesPlugin.RegisterBadge(newBadge, cosmeticId);
    }
    
    

    private static void RegisterLabubuBadges()
    {
        RegisterBadge(BadgeData.BoingBadge, 50, false, "Boba_labubu");
        RegisterBadge(BadgeData.BoingBadge2, 250, false, "Boba_labubu_blue");
        RegisterBadge(BadgeData.BoingBadge3, 500, false, "Boba_labubu_cyan");
        RegisterBadge(BadgeData.BoingBadge4, 1000, false, "Boba_labubu_green");
        RegisterBadge(BadgeData.BoingBadge5, 2000, false, "Boba_labubu_orange");
        RegisterBadge(BadgeData.BoingBadge6, 3000, false, "Boba_labubu_pink");
        RegisterBadge(BadgeData.BoingBadge7, 5000, false, "Boba_labubu_purple");
        RegisterBadge(BadgeData.BoingBadge8, 7500, false, "Boba_labubu_red");
        RegisterBadge(BadgeData.BoingBadge9, 10000, false, "Boba_labubu_yellow");
    }
    
}