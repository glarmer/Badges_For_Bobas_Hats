using HarmonyLib;
using MoreBadges;
using UnityEngine;

namespace Badges_for_Bobas_Hats.Patches;

public class CharacterAnimationsRPCAPlayRemove
{
    public static float EmoteTime = 0;
    
    [HarmonyPatch(typeof(CharacterAnimations), nameof(CharacterAnimations.RPCA_PlayRemove))]
    [HarmonyPostfix]
    static void Postfix(BugleSFX __instance, string emoteName)
    {
        EmoteTime = Time.time;
        Plugin.Logger.LogInfo($"Dance happened at: {EmoteTime}");
        if (BugleSFXRPCStartTootPatch.BuglesPlaying > 0 && emoteName.Equals("A_Scout_Emote_Dance1"))
        {
            MoreBadgesPlugin.AddProgress(BadgeData.DiscoBadge, 1);
        }
    }
}