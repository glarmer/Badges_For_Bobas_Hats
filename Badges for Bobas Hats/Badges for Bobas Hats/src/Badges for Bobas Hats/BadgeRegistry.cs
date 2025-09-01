using MoreBadges;
using UnityEngine;

namespace Badges_for_Bobas_Hats;

public static class BadgeRegistry
{
    private static readonly Texture2D PlaceholderBadgeIcon = Texture2D.whiteTexture;
    public static void RegisterBadges()
    {
        RegisterLabubuBadges();
        MoreBadgesPlugin.CustomBadge toastBadge = new MoreBadgesPlugin.CustomBadge(
            name: BadgeNames.ToastBadge,
            displayName: "YOU'RE TOAST!", // All uppercase to match in game badge name display
            description: "Get a whole bar of heat damage.",
            icon: PlaceholderBadgeIcon, //128x128 Texture2D
            progressRequired: 1,
            runBasedProgress: true
        );
        MoreBadgesPlugin.RegisterBadge(toastBadge, "Boba_toast");
    }

    private static void RegisterLabubuBadges()
    {
        
        MoreBadgesPlugin.CustomBadge boingBadge = new MoreBadgesPlugin.CustomBadge(
            name: BadgeNames.BoingBadge,
            displayName: "BOING!", // All uppercase to match in game badge name display
            description: "Jump 50 times.",
            icon: PlaceholderBadgeIcon, //128x128 Texture2D
            progressRequired: 50
        );
        MoreBadgesPlugin.RegisterBadge(boingBadge, "Boba_labubu");
        
        MoreBadgesPlugin.CustomBadge boingBadge2 = new MoreBadgesPlugin.CustomBadge(
            name: BadgeNames.BoingBadge2,
            displayName: "BOING... AGAIN?!",
            description: "Jump 250 times.",
            icon: PlaceholderBadgeIcon,
            progressRequired: 250
        );
        MoreBadgesPlugin.RegisterBadge(boingBadge2, "Boba_labubu_blue");
        
        MoreBadgesPlugin.CustomBadge boingBadge3 = new MoreBadgesPlugin.CustomBadge(
            name: BadgeNames.BoingBadge3,
            displayName: "BOING... AGAIN AGAIN?!",
            description: "Jump 500 times.",
            icon: PlaceholderBadgeIcon,
            progressRequired: 500
        );
        MoreBadgesPlugin.RegisterBadge(boingBadge3, "Boba_labubu_cyan");
        
        MoreBadgesPlugin.CustomBadge boingBadge4 = new MoreBadgesPlugin.CustomBadge(
            name: BadgeNames.BoingBadge4,
            displayName: "BOING... AGAIN AGAIN AGAIN?!",
            description: "Jump 1000 times.",
            icon: PlaceholderBadgeIcon,
            progressRequired: 1000
        );
        MoreBadgesPlugin.RegisterBadge(boingBadge4, "Boba_labubu_green");
        
        MoreBadgesPlugin.CustomBadge boingBadge5 = new MoreBadgesPlugin.CustomBadge(
            name: BadgeNames.BoingBadge5,
            displayName: "BOING... AGAIN AGAIN AGAIN AG- THAT'S ENOUGH!",
            description: "Jump 2000 times.",
            icon: PlaceholderBadgeIcon,
            progressRequired: 2000
        );
        MoreBadgesPlugin.RegisterBadge(boingBadge5, "Boba_labubu_orange");
        
        MoreBadgesPlugin.CustomBadge boingBadge6 = new MoreBadgesPlugin.CustomBadge(
            name: BadgeNames.BoingBadge6,
            displayName: "BOING... YOU REALLY LIKE JUMPING!",
            description: "Jump 3000 times.",
            icon: PlaceholderBadgeIcon,
            progressRequired: 3000
        );
        MoreBadgesPlugin.RegisterBadge(boingBadge6, "Boba_labubu_pink");
        
        MoreBadgesPlugin.CustomBadge boingBadge7 = new MoreBadgesPlugin.CustomBadge(
            name: BadgeNames.BoingBadge7,
            displayName: "BOING.. WOW YOU DON'T STOP!",
            description: "Jump 5000 times.",
            icon: PlaceholderBadgeIcon,
            progressRequired: 5000
        );
        MoreBadgesPlugin.RegisterBadge(boingBadge7, "Boba_labubu_purple");
        
        MoreBadgesPlugin.CustomBadge boingBadge8 = new MoreBadgesPlugin.CustomBadge(
            name: BadgeNames.BoingBadge8,
            displayName: "BOING... BASICALLY A RABIT!",
            description: "Jump 7500 times.",
            icon: PlaceholderBadgeIcon,
            progressRequired: 7500
        );
        MoreBadgesPlugin.RegisterBadge(boingBadge8, "Boba_labubu_red");
        
        MoreBadgesPlugin.CustomBadge boingBadge9 = new MoreBadgesPlugin.CustomBadge(
            name: BadgeNames.BoingBadge9,
            displayName: "BOING... YOU'VE JUMPED HOW MANY TIMES?!",
            description: "Jump 10000 times.",
            icon: PlaceholderBadgeIcon,
            progressRequired: 10000
        );
        MoreBadgesPlugin.RegisterBadge(boingBadge9, "Boba_labubu_yellow");
    }
    
}