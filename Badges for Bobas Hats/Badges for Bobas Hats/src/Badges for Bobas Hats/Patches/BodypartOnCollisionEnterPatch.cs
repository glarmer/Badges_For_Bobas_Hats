using HarmonyLib;
using MoreBadges;
using UnityEngine;

namespace Badges_for_Bobas_Hats.Patches;

public class BodypartOnCollisionEnterPatch
{
    [HarmonyPatch(typeof(Bodypart), nameof(Bodypart.OnCollisionEnter))]
    [HarmonyPostfix]
    static void Postfix(Bodypart __instance, Collision collision)
    {
        if (__instance.partType == BodypartType.Arm_R && __instance.character.input.useSecondaryIsPressed)
        {
            if (collision.collider.name.StartsWith("Capybara"))
            {
                MoreBadgesPlugin.AddProgress(BadgeNames.BowBadge, 1);
            }
        }
    }
}