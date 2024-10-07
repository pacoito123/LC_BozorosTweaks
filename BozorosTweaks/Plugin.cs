using BepInEx;
using BepInEx.Logging;
using BozorosTweaks.Patches;
using HarmonyLib;
using System;

namespace BozorosTweaks
{
    /// <summary>
    ///     Fixes, tweaks, and small additions for LethalMatt's Bozoros!
    /// </summary>
    [BepInPlugin(GUID, PLUGIN_NAME, VERSION)]
    public class Plugin : BaseUnityPlugin
    {
        internal const string GUID = "pacoito.BozorosTweaks", PLUGIN_NAME = "BozorosTweaks", VERSION = "1.0.1";
        internal static ManualLogSource? StaticLogger { get; private set; }

        /// <summary>
        ///     Harmony instance for patching.
        /// </summary>
        internal static Harmony? Harmony { get; private set; }

        /// <summary>
        ///     Plugin configuration instance.
        /// </summary>
        // public static Config? Settings { get; private set; }

        private void Awake()
        {
            StaticLogger = Logger;

            try
            {
                // Initialize 'Config' and 'Harmony' instances.
                // Settings = new(Config);
                Harmony = new(GUID);
                //

                // Apply all patches.
                Harmony.PatchAll(typeof(LoadPatches));
                Harmony.PatchAll(typeof(ClownGiantPatch));
                // Harmony.PatchAll(typeof(EnemiesPatch));
                // ...

                StaticLogger.LogInfo($"'{PLUGIN_NAME}' loaded!");
            }
            catch (Exception e)
            {
                StaticLogger.LogError($"Error while initializing '{PLUGIN_NAME}': {e}");
            }
        }
    }
}