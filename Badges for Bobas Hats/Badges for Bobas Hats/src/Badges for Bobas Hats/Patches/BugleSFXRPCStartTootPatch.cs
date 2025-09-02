using System;
using System.Collections.Generic;
using HarmonyLib;
using MoreBadges;

namespace Badges_for_Bobas_Hats.Patches;

public class BugleSFXRPCStartTootPatch
{
    public static int BuglesPlaying = 0;
    
    [HarmonyPatch(typeof(BugleSFX), nameof(BugleSFX.RPC_StartToot))]
    [HarmonyPostfix]
    static void Postfix(BugleSFX __instance)
    {
        BuglesPlaying++;
    }
}