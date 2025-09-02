using System.IO;
using System.Reflection;
using Badges_for_Bobas_Hats.Patches;
using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using UnityEngine;

namespace Badges_for_Bobas_Hats;

[BepInAutoPlugin]
[BepInDependency("com.snosz.morebadges", BepInDependency.DependencyFlags.HardDependency)]
[BepInDependency("BobaHats", BepInDependency.DependencyFlags.HardDependency)]
public partial class Plugin : BaseUnityPlugin
{
    internal new static ManualLogSource Logger;
    private readonly Harmony _harmony = new(Id);

    private void Awake()
    {
        Logger = base.Logger;
        Logger.LogInfo($"Plugin {Name} is loaded!");
        BadgeRegistry.Init();
        Logger.LogInfo("Badges for Bobas Hats are loaded!");
        
        _harmony.PatchAll(typeof(CharacterOnJumpPatch));
        _harmony.PatchAll(typeof(CharacterAfflictionsAddStatusPatch));
        _harmony.PatchAll(typeof(MagicBeanGrowVineRPCPatch));
        _harmony.PatchAll(typeof(ActionConsumeRunActionPatch));
        
        _harmony.PatchAll(typeof(CharacterAnimationsRPCAPlayRemove));
        _harmony.PatchAll(typeof(BugleSFXRPCStartTootPatch));
        _harmony.PatchAll(typeof(BugleSFXRPCEndTootPatch));
    }

    
}