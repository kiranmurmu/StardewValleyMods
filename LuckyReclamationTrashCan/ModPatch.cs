using StardewValley;

namespace KiranMurmu.StardewValleyMods.LuckyReclamationTrashCan
{
  /// <summary>The mod patch for Harmony</summary>
  internal class ModPatch
  {
    /// <summary>A method called via Harmony after <see cref="StardewValley.Utility.getTrashReclamationPrice(Item, Farmer)"/>.</summary>
    /// <param name="__result">The return value.</param>
    public static void After_getTrashReclamationPrice(ref int __result)
    {
      __result = (int)(__result / (double)(0.321 - (double)Game1.player.LuckLevel * 0.05 - Game1.player.DailyLuck));
    }
  }
}