using HarmonyLib;
using UnityEngine;

namespace BozorosTweaks.Patches
{
    [HarmonyPatch(typeof(RoundManager), nameof(RoundManager.LoadNewLevel))]
    internal class CollisionPatches
    {
        [HarmonyPostfix]
        private static void DisableTentColliders(SelectableLevel newLevel)
        {
            // Check if Bozoros environment object exists.
            if (LoadPatches.BozorosEnvironment == null)
            {
                return;
            }

            // Obtain container for every tent on the map.
            Transform? tentsContainer = LoadPatches.BozorosEnvironment.transform.Find("Bozoros_Map/Tents");

            // Iterate for every tent on the map.
            for (int i = 0; i < tentsContainer?.childCount; i++)
            {
                // Get tent at current index.
                Transform tent = tentsContainer.GetChild(i);

                // Check if current tent is rectangular (named 'Tent_Rectangle').
                if (tent.name[0] == 'T')
                {
                    // Try to obtain goofy collider on top of rectangular tent.
                    if (tent.GetChild(0)?.GetChild(0)?.TryGetComponent(out BoxCollider collider) == true)
                    {
                        // Reset collider object position and scale.
                        collider.transform.SetLocalPositionAndRotation(Vector3.zero, Quaternion.identity);
                        collider.transform.localScale = Vector3.one;

                        // Set goofy collider to a more reasonable size.
                        collider.center = new(0f, 17.5f, 0f);
                        collider.size = new(35f, 12f, 49f);
                    }
                }
                else
                {
                    // Disable goofy colliders on top of circular tent and use its mesh collider.
                    tent.GetChild(0)?.gameObject.SetActive(false);
                }
            }
        }
    }
}