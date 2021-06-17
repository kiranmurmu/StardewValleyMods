using Harmony;
using StardewModdingAPI;
using StardewModdingAPI.Events;
using StardewValley;
using System;

namespace KiranMurmu.StardewValleyMods.LuckyReclamationTrashCan
{
  /// <summary>The mod entry point.</summary>
  public class ModEntry : Mod
  {
    /// <summary>The mod entry point, called after the mod is first loaded.</summary>
    /// <param name="helper">Provides simplified APIs for writing mods.</param>
    public override void Entry(IModHelper helper)
    {
      helper.Events.GameLoop.SaveLoaded += new EventHandler<SaveLoadedEventArgs>(this.OnSaveLoaded);

      HarmonyInstance.Create(this.ModManifest.UniqueID).Patch(
        original: AccessTools.Method(typeof(Utility), nameof(Utility.getTrashReclamationPrice)),
        postfix: new HarmonyMethod(typeof(ModPatch), nameof(ModPatch.After_getTrashReclamationPrice))
      );
    }

    private void OnSaveLoaded(object sender, SaveLoadedEventArgs e)
    {
      this.Monitor.Log($"Luck Level: {Game1.player.LuckLevel}, Added Luck: {Game1.player.addedLuckLevel}, Daily Luck: {Game1.player.DailyLuck}", LogLevel.Debug);
    }
  }
}