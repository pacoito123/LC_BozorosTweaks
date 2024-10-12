using System.Linq;
using BozorosTweaks.Util;
using HarmonyLib;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace BozorosTweaks.Patches
{
    [HarmonyPatch]
    internal class LoadPatches
    {
        public static Scene BozorosScene { get; internal set; }
        public static GameObject? BozorosEnvironment { get; private set; }

        [HarmonyPatch(typeof(StartOfRound), "Start")]
        [HarmonyPostfix]
        private static void StartPost()
        {
            if (VanillaPrefabUtils.GetOutsideEnemyPrefab("ForestGiant", out GameObject? giantPrefab))
            {
                ClownGiantPatch.ForestGiantPrefab = giantPrefab;
            }

            /* if (VanillaPrefabUtils.GetInsideEnemyPrefab("Clay Surgeon", out GameObject? barberPrefab)
                && barberPrefab?.TryGetComponent(out ClaySurgeonAI barber) == true)
            {
                EnemiesPatch.BarberType = barber.enemyType;
            } */
        }

        [HarmonyPatch(typeof(RoundManager), nameof(RoundManager.LoadNewLevel))]
        [HarmonyPriority(Priority.First)]
        [HarmonyPostfix]
        private static void LoadNewLevelPost(SelectableLevel newLevel)
        {
            if (string.CompareOrdinal(newLevel.PlanetName, "Bozoros") != 0 || BozorosScene == null)
            {
                return;
            }

            BozorosEnvironment = BozorosScene.GetRootGameObjects().First(gameObject => string.CompareOrdinal(gameObject.name, "Environment") == 0);
        }
    }
}