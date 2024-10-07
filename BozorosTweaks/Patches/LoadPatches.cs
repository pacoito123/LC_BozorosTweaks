using BozorosTweaks.Util;
using HarmonyLib;
using UnityEngine;

namespace BozorosTweaks.Patches
{
    [HarmonyPatch(typeof(StartOfRound), "Start")]
    internal class LoadPatches
    {
        [HarmonyPostfix]
        private static void OnStartPost()
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
    }
}