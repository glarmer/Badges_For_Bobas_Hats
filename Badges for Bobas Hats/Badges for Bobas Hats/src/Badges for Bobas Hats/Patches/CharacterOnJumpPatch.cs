using HarmonyLib;
using MoreBadges;
using Photon.Pun;

namespace Badges_for_Bobas_Hats.Patches;

public class CharacterOnJumpPatch
{
    [HarmonyPatch(typeof(Character), "OnJump")]
    [HarmonyPostfix]
    static void Postfix(Character __instance)
    {
        MoreBadgesPlugin.AddProgress(BadgeData.BoingBadge, 1);
        MoreBadgesPlugin.AddProgress(BadgeData.BoingBadge2, 1);
        MoreBadgesPlugin.AddProgress(BadgeData.BoingBadge3, 1);
        MoreBadgesPlugin.AddProgress(BadgeData.BoingBadge4, 1);
        MoreBadgesPlugin.AddProgress(BadgeData.BoingBadge5, 1);
        MoreBadgesPlugin.AddProgress(BadgeData.BoingBadge6, 1);
        MoreBadgesPlugin.AddProgress(BadgeData.BoingBadge7, 1);
        MoreBadgesPlugin.AddProgress(BadgeData.BoingBadge8, 1);
        MoreBadgesPlugin.AddProgress(BadgeData.BoingBadge9, 1);
    }
}