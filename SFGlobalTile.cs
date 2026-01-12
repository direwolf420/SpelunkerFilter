using Terraria;
using Terraria.ModLoader;
using Terraria.ModLoader.Config;

namespace SpelunkerFilter
{
	public class SFGlobalTile : GlobalTile
	{
		public override void Load()
		{
			On_SceneMetrics.IsValidForOreFinder += On_SceneMetrics_IsValidForOreFinder;
		}

		private static bool On_SceneMetrics_IsValidForOreFinder(On_SceneMetrics.orig_IsValidForOreFinder orig, Tile t)
		{
			bool ret = orig(t);

			if (!SFConfig.Instance.ApplyToMetalDetector || (NotFiltered(t, t.TileType) ?? true))
			{
				return ret;
			}

			return false;
		}

		public override bool? IsTileSpelunkable(int i, int j, int type)
		{
			return NotFiltered(Main.tile[i, j], type);
		}

		private static bool? NotFiltered(Tile t, int type)
		{
			var def = new TileDefinition(type);

			if (SpelunkerFilter.specialFilters.TryGetValue(type, out var filter))
			{
				return filter(t);
			}

			if (SFConfig.Instance.CustomWhitelist.Contains(def))
			{
				return true;
			}

			if (SFConfig.Instance.CustomBlacklist.Contains(def))
			{
				return false;
			}

			if (SpelunkerFilter.tileToDefaultFilterToggle.TryGetValue(type, out var toggle) && !toggle())
			{
				return false;
			}

			return null;
		}
	}
}