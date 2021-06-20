﻿using System;
using Harmony;
using StardewModdingAPI;
using StardewValley;

namespace KiranMurmu.StardewValleyMods.LuckyReclamationTrashCan
{
  /// <summary>The mod entry point.</summary>
  public class ModEntry : Mod
  {
    /// <summary>The mod entry point, called after the mod is first loaded.</summary>
    /// <param name="helper">Provides simplified APIs for writing mods.</param>
    public override void Entry(IModHelper helper)
    {
      try
      {
        HarmonyInstance.Create(this.ModManifest.UniqueID).Patch(
          original: AccessTools.Method(typeof(Utility), nameof(Utility.getTrashReclamationPrice)),
          postfix: new HarmonyMethod(typeof(ModPatch), nameof(ModPatch.After_getTrashReclamationPrice))
        );
      }
      catch (Exception ex)
      {
        this.Monitor.Log(ex.Message, LogLevel.Error);
      }
    }
  }
}