using System;
using HarmonyLib;
using MoreBadges;
using UnityEngine;

namespace Badges_for_Bobas_Hats.Patches;

public class PlayerMoveZoneAddForceToCharacterPatch
{
    private static float _startTime = 0;
    private static float _lastTime = 0;
    private static readonly float DurationRequired = 5;
    
    [HarmonyPatch(typeof(PlayerMoveZone), nameof(PlayerMoveZone.AddForceToCharacter))]
    [HarmonyPostfix]
    static void Postfix(PlayerMoveZone __instance)
    {
        if (Time.time - _lastTime > 1)
        {
            _startTime = Time.time;
        }
        if (Character.localCharacter.input.useSecondaryIsPressed)
        {
            _lastTime = Time.time;
        }
        if (_lastTime - _startTime > DurationRequired)
        {
            MoreBadgesPlugin.AddProgress(BadgeData.JamiroBadge, 1);
        }
    }
}