using System.Collections.Generic;
using System.IO;
using System.Reflection;
using MoreBadges;
using UnityEngine;

namespace Badges_for_Bobas_Hats;

public static class BadgeRegistry
{
    private static readonly Texture2D PlaceholderBadgeIcon = Texture2D.whiteTexture;
    private static Dictionary<string, Texture2D> _badgeIcons = new();

    public static void Init()
    {
        LoadBadgeResources();
        RegisterBadges();
    }
    
    private static void RegisterBadges()
    {
        RegisterLabubuBadges();
        MoreBadgesPlugin.CustomBadge toastBadge = new MoreBadgesPlugin.CustomBadge(
            name: BadgeNames.ToastBadge,
            displayName: "YOU'RE TOAST!", // All uppercase to match in game badge name display
            description: "Singed to the absolute max.",
            icon: _badgeIcons[BadgeNames.ToastBadge],
            progressRequired: 1,
            runBasedProgress: true
        );
        MoreBadgesPlugin.RegisterBadge(toastBadge, "Boba_toast");
        
        MoreBadgesPlugin.CustomBadge magicBeanVineBadge = new MoreBadgesPlugin.CustomBadge(
            name: BadgeNames.MagicBeanVineBadge,
            displayName: "GREEN THUMB!",
            description: "Grow a magical vine.",
            icon: _badgeIcons[BadgeNames.MagicBeanVineBadge],
            progressRequired: 1,
            runBasedProgress: true
        );
        MoreBadgesPlugin.RegisterBadge(magicBeanVineBadge, "Boba_sprout");
        
        MoreBadgesPlugin.CustomBadge bearBadge = new MoreBadgesPlugin.CustomBadge(
            name: BadgeNames.BearBadge,
            displayName: "MMM HONEY!",
            description: "Consume the nectar of the gods.",
            icon: _badgeIcons[BadgeNames.BearBadge],
            progressRequired: 1,
            runBasedProgress: true
        );
        MoreBadgesPlugin.RegisterBadge(bearBadge, "Boba_bear");
        
        MoreBadgesPlugin.CustomBadge discoBadge = new MoreBadgesPlugin.CustomBadge(
            name: BadgeNames.DiscoBadge,
            displayName: "SCOUT RAVE!",
            description: "Dance at an epic performance.",
            icon: PlaceholderBadgeIcon,
            progressRequired: 1,
            runBasedProgress: true
        );
        MoreBadgesPlugin.RegisterBadge(discoBadge, "Boba_disco");
        
        MoreBadgesPlugin.CustomBadge jamiroBadge = new MoreBadgesPlugin.CustomBadge(
            name: BadgeNames.JamiroBadge,
            displayName: "VIRTUAL INSANITY!",
            description: "Move like magic with your arm out.",
            icon: PlaceholderBadgeIcon,
            progressRequired: 1,
            runBasedProgress: true
        );
        MoreBadgesPlugin.RegisterBadge(jamiroBadge, "Boba_jamiro_hat");
        
        MoreBadgesPlugin.CustomBadge knitRainbowBadge = new MoreBadgesPlugin.CustomBadge(
            name: BadgeNames.RainbowBadge,
            displayName: "TASTE THE RAINBOW!",
            description: "Eat a rainbow of fruit.",
            icon: PlaceholderBadgeIcon,
            progressRequired: 1,
            runBasedProgress: true
        );
        MoreBadgesPlugin.RegisterBadge(knitRainbowBadge, "Boba_knit_rainbow");
        
        MoreBadgesPlugin.CustomBadge mustardBadge = new MoreBadgesPlugin.CustomBadge(
            name: BadgeNames.MustardBadge,
            displayName: "HEALTH ADVERSE!",
            description: "Fruit and veg? Over your dead body.",
            icon: PlaceholderBadgeIcon,
            progressRequired: 1,
            runBasedProgress: true
        );
        MoreBadgesPlugin.RegisterBadge(mustardBadge, "Boba_mustard");
        
        MoreBadgesPlugin.CustomBadge penguinBadge = new MoreBadgesPlugin.CustomBadge(
            name: BadgeNames.PenguinBadge,
            displayName: "CHILLY!",
            description: "It's a bit nippy out isn't it?",
            icon: PlaceholderBadgeIcon,
            progressRequired: 1,
            runBasedProgress: true
        );
        MoreBadgesPlugin.RegisterBadge(penguinBadge, "Boba_penguin");
        
        MoreBadgesPlugin.CustomBadge chairBadge = new MoreBadgesPlugin.CustomBadge(
            name: BadgeNames.ChairBadge,
            displayName: "ETERNAL SIT!",
            description: "Be carried into the afterlife.",
            icon: PlaceholderBadgeIcon,
            progressRequired: 1,
            runBasedProgress: true
        );
        MoreBadgesPlugin.RegisterBadge(chairBadge, "Boba_chair_hat");
        
        MoreBadgesPlugin.CustomBadge bowBadge = new MoreBadgesPlugin.CustomBadge(
            name: BadgeNames.BowBadge,
            displayName: "SUCH A CUTIE!",
            description: "Give the bestest boys some pets.",
            icon: PlaceholderBadgeIcon,
            progressRequired: 1,
            runBasedProgress: true
        );
        MoreBadgesPlugin.RegisterBadge(bowBadge, "Boba_bow");
    }
    
    private static void LoadBadgeResources()
    {
        var assembly = Assembly.GetExecutingAssembly();
        string[] resources = assembly.GetManifestResourceNames();

        foreach (string resourceName in resources)
        {
            Plugin.Logger.LogInfo($"Trying to load resource: {resourceName}");
            if (!resourceName.EndsWith(".png") || !resourceName.Contains(".Resources."))
                continue;

            using (Stream stream = assembly.GetManifestResourceStream(resourceName))
            {
                if (stream == null)
                {
                    Plugin.Logger.LogError($"Failed to load resource: {resourceName}");
                    continue;
                }

                byte[] data = new byte[stream.Length];
                stream.Read(data, 0, data.Length);

                string badgeName = "Badge_Badges_For_Bobas_Hats_" + resourceName.Split('.')[^2];
                Texture2D badge = new Texture2D(2, 2, TextureFormat.RGBA32, false);
                badge.LoadImage(data);

                _badgeIcons[badgeName] = badge;

                Plugin.Logger.LogInfo(
                    $"Loaded embedded badge texture {badgeName} ({badge.width}x{badge.height})"
                );
            }
        }
    }

    private static void RegisterLabubuBadges()
    {
        MoreBadgesPlugin.CustomBadge boingBadge = new MoreBadgesPlugin.CustomBadge(
            name: BadgeNames.BoingBadge,
            displayName: "BOING!", // All uppercase to match in game badge name display
            description: "Jump 50 times.",
            icon: _badgeIcons[BadgeNames.BoingBadge], //128x128 Texture2D
            progressRequired: 50
        );
        MoreBadgesPlugin.RegisterBadge(boingBadge, "Boba_labubu");
        
        MoreBadgesPlugin.CustomBadge boingBadge2 = new MoreBadgesPlugin.CustomBadge(
            name: BadgeNames.BoingBadge2,
            displayName: "BOING... AGAIN?!",
            description: "Jump 250 times.",
            icon: _badgeIcons[BadgeNames.BoingBadge2],
            progressRequired: 250
        );
        MoreBadgesPlugin.RegisterBadge(boingBadge2, "Boba_labubu_blue");
        
        MoreBadgesPlugin.CustomBadge boingBadge3 = new MoreBadgesPlugin.CustomBadge(
            name: BadgeNames.BoingBadge3,
            displayName: "BOING... AGAIN AGAIN?!",
            description: "Jump 500 times.",
            icon: _badgeIcons[BadgeNames.BoingBadge3],
            progressRequired: 500
        );
        MoreBadgesPlugin.RegisterBadge(boingBadge3, "Boba_labubu_cyan");
        
        MoreBadgesPlugin.CustomBadge boingBadge4 = new MoreBadgesPlugin.CustomBadge(
            name: BadgeNames.BoingBadge4,
            displayName: "BOING... AGAIN AGAIN AGAIN?!",
            description: "Jump 1000 times.",
            icon: _badgeIcons[BadgeNames.BoingBadge4],
            progressRequired: 1000
        );
        MoreBadgesPlugin.RegisterBadge(boingBadge4, "Boba_labubu_green");
        
        MoreBadgesPlugin.CustomBadge boingBadge5 = new MoreBadgesPlugin.CustomBadge(
            name: BadgeNames.BoingBadge5,
            displayName: "BOING... DON'T YOU GET TIRED?!",
            description: "Jump 2000 times.",
            icon: _badgeIcons[BadgeNames.BoingBadge5],
            progressRequired: 2000
        );
        MoreBadgesPlugin.RegisterBadge(boingBadge5, "Boba_labubu_orange");
        
        MoreBadgesPlugin.CustomBadge boingBadge6 = new MoreBadgesPlugin.CustomBadge(
            name: BadgeNames.BoingBadge6,
            displayName: "BOING... YOU REALLY LIKE JUMPING!",
            description: "Jump 3000 times.",
            icon: _badgeIcons[BadgeNames.BoingBadge6],
            progressRequired: 3000
        );
        MoreBadgesPlugin.RegisterBadge(boingBadge6, "Boba_labubu_pink");
        
        MoreBadgesPlugin.CustomBadge boingBadge7 = new MoreBadgesPlugin.CustomBadge(
            name: BadgeNames.BoingBadge7,
            displayName: "BOING.. WOW YOU DON'T STOP!",
            description: "Jump 5000 times.",
            icon: _badgeIcons[BadgeNames.BoingBadge7],
            progressRequired: 5000
        );
        MoreBadgesPlugin.RegisterBadge(boingBadge7, "Boba_labubu_purple");
        
        MoreBadgesPlugin.CustomBadge boingBadge8 = new MoreBadgesPlugin.CustomBadge(
            name: BadgeNames.BoingBadge8,
            displayName: "BOING... BASICALLY A RABIT!",
            description: "Jump 7500 times.",
            icon: _badgeIcons[BadgeNames.BoingBadge8],
            progressRequired: 7500
        );
        MoreBadgesPlugin.RegisterBadge(boingBadge8, "Boba_labubu_red");
        
        MoreBadgesPlugin.CustomBadge boingBadge9 = new MoreBadgesPlugin.CustomBadge(
            name: BadgeNames.BoingBadge9,
            displayName: "BOING... YOU'VE JUMPED HOW MANY TIMES?!",
            description: "Jump 10000 times.",
            icon: _badgeIcons[BadgeNames.BoingBadge9],
            progressRequired: 10000
        );
        MoreBadgesPlugin.RegisterBadge(boingBadge9, "Boba_labubu_yellow");
    }
    
}