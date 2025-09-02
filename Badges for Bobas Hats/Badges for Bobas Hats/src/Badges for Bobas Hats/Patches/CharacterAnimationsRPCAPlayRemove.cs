using HarmonyLib;
using MoreBadges;

namespace Badges_for_Bobas_Hats.Patches;

public class CharacterAnimationsRPCAPlayRemove
{
    [HarmonyPatch(typeof(CharacterAnimations), nameof(CharacterAnimations.RPCA_PlayRemove))]
    [HarmonyPostfix]
    static void Postfix(BugleSFX __instance, string emoteName)
    {
        if (BugleSFXRPCStartTootPatch.BuglesPlaying > 0 && emoteName.Equals("A_Scout_Emote_Dance1"))
        {
            MoreBadgesPlugin.AddProgress(BadgeNames.DiscoBadge, 1);
        }
    }
}