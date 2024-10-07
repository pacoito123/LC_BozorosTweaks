using HarmonyLib;
using UnityEngine;

namespace BozorosTweaks.Patches
{
    /// <summary>
    ///     Patch for fixing Bozoros' Tellers (Clown Giants) by haphazardly adding missing stuff from v50 and above.
    /// </summary>
    /// <remarks>Probably better to add the individual clown features to any Forest Giant that spawns in Bozoros, but this works for now.</remarks>
    [HarmonyPatch(typeof(ForestGiantAI), nameof(ForestGiantAI.Start))]
    internal class ClownGiantPatch
    {
        /// <summary>
        ///     Vanilla Prefab for the Forest Giant.
        /// </summary>
        public static GameObject? ForestGiantPrefab { get; internal set; }

        private static void Postfix(ForestGiantAI __instance)
        {
            // Check if current ForestGiantAI instance belongs to a ClownGiant.
            if (!__instance.gameObject.name.StartsWith("ClownGiant")
                || ForestGiantPrefab?.TryGetComponent(out ForestGiantAI forestGiantPrefab) != true)
            {
                return;
            }

            // Copy health and general enemy properties from the Forest Giant enemy prefab.
            __instance.enemyHP = forestGiantPrefab.enemyHP;
            __instance.enemyType = forestGiantPrefab.enemyType;

            // Copy behaviour animation states from the Forest Giant enemy prefab to include falling and burning.
            __instance.enemyBehaviourStates = forestGiantPrefab.enemyBehaviourStates;

            // Copy missing falling and burning sound effects from the Forest Giant enemy prefab.
            __instance.giantFall = forestGiantPrefab.giantFall;
            __instance.giantCry = forestGiantPrefab.giantCry;

            // Obtain ClownGiant's animation container.
            GameObject animContainer = __instance.transform.Find("FGiantModelContainer/AnimContainer").gameObject;

            // Override ClownGiant Animator with one obtained from the Forest Giant enemy prefab.
            animContainer.GetComponent<Animator>().runtimeAnimatorController = new AnimatorOverrideController(
                ForestGiantPrefab.transform.Find("FGiantModelContainer/AnimContainer").GetComponent<Animator>().runtimeAnimatorController);

            // Add EnemyAnimationEvent component to ClownGiant's animation container.
            animContainer.AddComponent<EnemyAnimationEvent>().mainScript = __instance;

            // Clone BurningSFX GameObject from Forest Giant enemy prefab and parent it to the ClownGiant's model.
            __instance.giantBurningAudio = Object.Instantiate(ForestGiantPrefab.transform.Find("FGiantModelContainer/BurningSFX"),
                animContainer.transform.GetParent(), false).GetComponent<AudioSource>();
            __instance.giantBurningAudio.name = "BurningSFX";

            // Clone FireParticlesContainer GameObject from Forest Giant enemy prefab and parent it to the ClownGiant.
            __instance.burningParticlesContainer = Object.Instantiate(ForestGiantPrefab.transform.Find("FireParticlesContainer"),
                __instance.transform, false).gameObject;
            __instance.burningParticlesContainer.name = "FireParticlesContainer";

            // Clone FallPosition GameObject from Forest Giant enemy prefab and parent it to the ClownGiant.
            __instance.deathFallPosition = Object.Instantiate(ForestGiantPrefab.transform.Find("FallPosition"),
                __instance.transform, false);
            __instance.deathFallPosition.name = "FallPosition";
        }
    }
}