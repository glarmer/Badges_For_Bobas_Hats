using System;
using System.Collections.Generic;
using HarmonyLib;
using MoreBadges;

namespace Badges_for_Bobas_Hats.Patches;

public class BugleSFXRPCEndTootPatch
{
    [HarmonyPatch(typeof(BugleSFX), nameof(BugleSFX.RPC_EndToot))]
    [HarmonyPostfix]
    static void Postfix(BugleSFX __instance)
    {
        BugleSFXRPCStartTootPatch.BuglesPlaying--;
    }
}