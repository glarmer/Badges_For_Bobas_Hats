using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using UnityEngine;

namespace Badges_for_Bobas_Hats;

public static class BadgeData
{
    public const string BadgePrefix = "Badge_Badges_For_Bobas_Hats:";
    public const string BoingBadge = $"{BadgePrefix}Boing";
    public const string BoingBadge2 = $"{BadgePrefix}Boing_2";
    public const string BoingBadge3 = $"{BadgePrefix}Boing_3";
    public const string BoingBadge4 = $"{BadgePrefix}Boing_4";
    public const string BoingBadge5 = $"{BadgePrefix}Boing_5";
    public const string BoingBadge6 = $"{BadgePrefix}Boing_6";
    public const string BoingBadge7 = $"{BadgePrefix}Boing_7";
    public const string BoingBadge8 = $"{BadgePrefix}Boing_8";
    public const string BoingBadge9 = $"{BadgePrefix}Boing_9";
    public const string ToastBadge = $"{BadgePrefix}Toast";
    public const string MagicBeanVineBadge = $"{BadgePrefix}Magic_Bean_Vine";
    public const string BearBadge = $"{BadgePrefix}Bear";
    public const string DiscoBadge = $"{BadgePrefix}Disco";
    public const string JamiroBadge = $"{BadgePrefix}Jamiro";
    public const string RainbowBadge = $"{BadgePrefix}Rainbow";
    public const string MustardBadge = $"{BadgePrefix}Mustard";
    public const string PenguinBadge = $"{BadgePrefix}Penguin";
    public const string ChairBadge = $"{BadgePrefix}Chair";
    public const string BowBadge = $"{BadgePrefix}Bow";
    
    private static Dictionary<string, List<string>> LocalisationTable;
    public static readonly Texture2D PlaceholderBadgeIcon = Texture2D.whiteTexture;
    public static Dictionary<string, Texture2D> BadgeIcons = new();

    public static void Init()
    {
        LoadLocalisations();
        LoadBadgeResources();
    }
    
    public static void LoadLocalisations()
    {
        var assembly = Assembly.GetExecutingAssembly();
        using Stream stream = assembly.GetManifestResourceStream("Badges_for_Bobas_Hats.Resources.Localisations.Localisations.csv");
        using StreamReader reader = new StreamReader(stream);
        string csvText = reader.ReadToEnd();
        Plugin.Logger.LogInfo($"Read {csvText} text from CSV.");

        LocalisationTable = new Dictionary<string, List<string>>();

        var lines = csvText.Split(new[] { "\r\n", "\n" }, StringSplitOptions.RemoveEmptyEntries);

        if (lines.Length < 2)
        {
            Plugin.Logger.LogWarning("CSV appears to be empty or missing header.");
            return;
        }
        
        for (int i = 1; i < lines.Length; i++)
        {
            var columns = lines[i].Split(',');

            if (columns.Length < 2)
                continue;

            string key = columns[0].ToUpperInvariant();
            List<string> translations = new List<string>();

            for (int j = 1; j < columns.Length; j++)
            {
                translations.Add(columns[j]);
            }

            if (!LocalisationTable.ContainsKey(key))
                LocalisationTable.Add(key, translations);
        }

        Plugin.Logger.LogInfo($"Loaded {LocalisationTable.Count} localisation keys from CSV.");
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

                string badgeName = BadgeData.BadgePrefix + resourceName.Split('.')[^2];
                Texture2D badge = new Texture2D(2, 2, TextureFormat.RGBA32, false);
                badge.LoadImage(data);

                BadgeData.BadgeIcons[badgeName] = badge;

                Plugin.Logger.LogInfo(
                    $"Loaded embedded badge texture {badgeName} ({badge.width}x{badge.height})"
                );
            }
        }
    }
    
    public static string Get(string key, int languageIndex = 0)
    {
        key = key.ToUpperInvariant();
        if (LocalisationTable == null)
            LoadLocalisations();

        if (LocalisationTable.TryGetValue(key, out var translations))
        {
            if (languageIndex >= 0 && languageIndex < translations.Count)
                return translations[languageIndex];
            return translations[0];
        }

        Plugin.Logger.LogWarning($"Missing localisation key: {key}");
        foreach (string existingKey in LocalisationTable.Keys) Plugin.Logger.LogWarning($"Dictionary contains: {existingKey}");
        return key;
    }

    public static List<string> GetLocalisationList(string key)
    {
        List<string> localisations = new List<string>();
        foreach (Language lang in Enum.GetValues(typeof(Language)))
        {
            Plugin.Logger.LogInfo($"Trying to get {key} for {lang} = {Get(key, (int) lang)}");
            localisations.Add(Get(key, (int) lang));
        }

        return localisations;
    }
}