using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEditor;
using UnityEngine;

[InitializeOnLoad]
class EditorUpdate
{
    static EditorUpdate()
    {
        EditorApplication.update += Update;
    }

    static void Update()
    {
        EditorApplication.update -= Update;

        string from = "Assets/Pixel_Art/Plugins/Android/GoogleMobileAdsPlugin.androidlib";
        string to = "Assets/Plugins/Android/GoogleMobileAdsPlugin.androidlib";

        if (Directory.Exists(from) && !Directory.Exists(to))
        {
            if (!Directory.Exists("Assets/Plugins")) AssetDatabase.CreateFolder("Assets", "Plugins");
            if (!Directory.Exists("Assets/Plugins/Android")) AssetDatabase.CreateFolder("Assets/Plugins", "Android");

            AssetDatabase.MoveAsset(from, to);
            AssetDatabase.MoveAsset("Assets/Pixel_Art/Plugins/Android/googlemobileads-unity.aar", "Assets/Plugins/Android/googlemobileads-unity.aar");
        }

        from = "Assets/Pixel_Art/Resources/BillingMode.json";
        to = "Assets/Resources/BillingMode.json";

        if (File.Exists(from))
        {
            AssetDatabase.MoveAsset(from, to);
            AssetDatabase.DeleteAsset(from);
            if (Directory.GetFiles("Assets/Pixel_Art/Resources").Length == 0)
            {
                AssetDatabase.DeleteAsset("Assets/Pixel_Art/Resources");
            }
        }

        if (Directory.Exists("Assets/EasyMobile"))
        {
            AddDefine("EASY_MOBILE_LITE", BuildTargetGroup.Android);
            AddDefine("EASY_MOBILE_LITE", BuildTargetGroup.iOS);
        }

        PluginImporter importer = AssetImporter.GetAtPath("Assets/EasyMobile/Plugins/iOS/libEasyMobileLite.a") as PluginImporter;
        if (importer != null)
        {
            importer.SetCompatibleWithAnyPlatform(false);
            importer.SetCompatibleWithPlatform(BuildTarget.iOS, true);
            importer.SaveAndReimport();
        }
    }

    public static void AddDefine(string symbol, BuildTargetGroup platform)
    {
        string symbolStr = PlayerSettings.GetScriptingDefineSymbolsForGroup(platform);
        List<string> symbols = new List<string>(symbolStr.Split(';'));

        if (!symbols.Contains(symbol))
        {
            symbols.Add(symbol);
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < symbols.Count; i++)
            {
                sb.Append(symbols[i]);
                if (i < symbols.Count - 1)
                    sb.Append(";");
            }
            PlayerSettings.SetScriptingDefineSymbolsForGroup(platform, sb.ToString());
        }
    }
}