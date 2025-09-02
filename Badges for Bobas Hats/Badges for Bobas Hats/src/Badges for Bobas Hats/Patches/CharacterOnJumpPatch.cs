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
        MoreBadgesPlugin.AddProgress(BadgeNames.BoingBadge, 1);
        MoreBadgesPlugin.AddProgress(BadgeNames.BoingBadge2, 1);
        MoreBadgesPlugin.AddProgress(BadgeNames.BoingBadge3, 1);
        MoreBadgesPlugin.AddProgress(BadgeNames.BoingBadge4, 1);
        MoreBadgesPlugin.AddProgress(BadgeNames.BoingBadge5, 1);
        MoreBadgesPlugin.AddProgress(BadgeNames.BoingBadge6, 1);
        MoreBadgesPlugin.AddProgress(BadgeNames.BoingBadge7, 1);
        MoreBadgesPlugin.AddProgress(BadgeNames.BoingBadge8, 1);
        MoreBadgesPlugin.AddProgress(BadgeNames.BoingBadge9, 1);
    }
}