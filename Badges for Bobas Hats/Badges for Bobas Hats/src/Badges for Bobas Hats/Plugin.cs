using Badges_for_Bobas_Hats.Patches;
using BepInEx;
using BepInEx.Logging;
using HarmonyLib;

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
        
        //Patch for Labubu hats
        _harmony.PatchAll(typeof(CharacterOnJumpPatch));
        
        //Patch for Toast hat
        _harmony.PatchAll(typeof(CharacterAfflictionsAddStatusPatch));
        
        //Patch for Sprout hat
        _harmony.PatchAll(typeof(MagicBeanGrowVineRPCPatch));
        
        //Patch for Bear hat
        _harmony.PatchAll(typeof(ActionConsumeRunActionPatch));
        
        //Patches for Disco hat
        _harmony.PatchAll(typeof(CharacterAnimationsRPCAPlayRemove));
        _harmony.PatchAll(typeof(BugleSFXRPCStartTootPatch));
        _harmony.PatchAll(typeof(BugleSFXRPCEndTootPatch));
        
        _harmony.PatchAll(typeof(PlayerMoveZoneAddForceToCharacterPatch));
    }

    
}