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

    public static int jumped = 0;

    private void Awake()
    {
        Logger = base.Logger;
        Logger.LogInfo($"Plugin {Name} is loaded!");
        BadgeRegistry.RegisterBadges();
        Logger.LogInfo("Badges for Bobas Hats are loaded!");
        
        _harmony.PatchAll(typeof(CharacterOnJumpPatch));
        _harmony.PatchAll(typeof(CharacterAfflictionsAddStatus));
    }
}