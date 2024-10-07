# BozorosTweaks

[![Thunderstore Downloads](https://img.shields.io/thunderstore/dt/pacoito/BozorosTweaks?style=for-the-badge&logo=thunderstore&color=mediumseagreen
)](https://thunderstore.io/c/lethal-company/p/pacoito/BozorosTweaks)
[![GitHub Releases](https://img.shields.io/github/v/release/pacoito123/LC_BozorosTweaks?display_name=tag&style=for-the-badge&logo=github&color=steelblue
)](https://github.com/pacoito123/LC_BozorosTweaks/releases)
[![License](https://img.shields.io/github/license/pacoito123/LC_BozorosTweaks?style=for-the-badge&logo=github&color=teal
)](https://github.com/pacoito123/LC_BozorosTweaks/blob/main/LICENSE)

> Fixes, tweaks, and small additions for LethalMatt's Bozoros!

## Description

Mod attempting to fix and tweak certain aspects of [Bozoros](https://thunderstore.io/c/lethal-company/p/LethalMatt/Bozoros) by [LethalMatt](https://thunderstore.io/c/lethal-company/p/LethalMatt), keeping it compatible with the latest versions of the game for as long as possible.

Due to the Bozoros project files not exactly being accessible anymore (a lot of the data was sadly lost), the scope of this mod will remain somewhat narrow; it's not really feasible to make large map changes like modifying terrain, or adding more scripted events.

## Current Features

- Fixes for Teller (Clown Giant) enemy variant:
  - Clown Giants no longer completely break when killed.
    - [Missing components](https://1a3.uk/lethal_company/versions/v50_1?tab=6#ForestGiantAI.cs) that were introduced to the Forest Giant prefab in `v50` are now haphazardly added at runtime to stop Clown Giants from erroring out.
  - Clown Giant falling animation now properly plays on death, leaving its body collapsed on the ground.
    - Haven't confirmed if a player standing under a falling Clown Giant actually takes damage, but it's likely to be the case.
  - Clown Giants are no longer fireproof and properly play their burning animation when set on fire.
    - They can be set on fire through the same means as regular Forest Giants (e.g. Cruiser explosion, lightning strike, meteor strike).
  - Missing falling and burning sound effects added to Clown Giants.
    - [EnemySoundFixes](https://thunderstore.io/c/lethal-company/p/ButteryStancakes/EnemySoundFixes) by [ButteryStancakes](https://github.com/ButteryStancakes) is recommended for every Clown Giant sound effect to play.
    - Only vanilla sound effects are played at the moment, but custom goofy sound effects could be added in the future.
  - Clown Giants' health amount now matches the same value as regular Forest Giants (`38 HP`, if not modified by another mod).
  - Company Cruiser is no longer able to instantly kill Clown Giants at any speed, and a minimum velocity is required (same requirement as regular Forest Giants).

## Planned Features

- Adding some enemies from `v50` and above to the map's spawn pool.
- Adding some of the scrap items from `v61` to the map's spawn pool.
  - A mod such as [LethalQuantities](https://thunderstore.io/c/lethal-company/p/BananaPuncher714/LethalQuantities) by [BananaPuncher714](https://github.com/BananaPuncher714) can do both things above, and will likely remain the recommended way to add enemies and scrap to Bozoros, but I'll still integrate it into this mod as a standalone option.
- Making certain obstacles destructible when the Cruiser rams into them, like vanilla trees.
- Making the doors of the custom interior intangible when opening, so as to not push the player.
- Adding the ability to pop balloons by shooting them with a shotgun, or slice them with a knife to release them into the sky.

## Credits

- [LethalMatt](https://thunderstore.io/c/lethal-company/p/LethalMatt) for the all-around great [Bozoros](https://thunderstore.io/c/lethal-company/p/LethalMatt/Bozoros) moon, which is easily one of me and my friend group's favorite moons to land on.
- Everyone else mentioned in the [Bozoros](https://thunderstore.io/c/lethal-company/p/LethalMatt/Bozoros) credits section who helped with the map itself.
