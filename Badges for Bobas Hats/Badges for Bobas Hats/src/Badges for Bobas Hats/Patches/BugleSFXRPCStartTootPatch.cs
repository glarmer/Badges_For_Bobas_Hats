using HarmonyLib;
using MoreBadges;
using UnityEngine;

namespace Badges_for_Bobas_Hats.Patches;

public class BugleSFXRPCStartTootPatch
{
    public static int BuglesPlaying = 0;
    
    [HarmonyPatch(typeof(BugleSFX), nameof(BugleSFX.RPC_StartToot))]
    [HarmonyPostfix]
    static void Postfix(BugleSFX __instance)
    {
        BuglesPlaying++;
        Plugin.Logger.LogInfo($"Toot happened at: {Time.time} Dance time: {CharacterAnimationsRPCAPlayRemove.EmoteTime}");
        if (CharacterAnimationsRPCAPlayRemove.EmoteTime + 3f >= Time.time)
        {
            MoreBadgesPlugin.AddProgress(BadgeData.DiscoBadge, 1);
        }
    }
}