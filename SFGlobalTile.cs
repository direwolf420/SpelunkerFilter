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

			//TODO change config instance to metal one
			if (!SFConfig.Instance.ApplyToMetalDetector || (NotFiltered(SFConfig.Instance, t, t.TileType) ?? true))
			{
				return ret;
			}

			return false;
		}

		public override bool? IsTileSpelunkable(int i, int j, int type)
		{
			return NotFiltered(SFConfig.Instance, Main.tile[i, j], type);
		}

		private static bool? NotFiltered(SFConfigBase config, Tile t, int type)
		{
			var def = new TileDefinition(type);

			if (SpelunkerFilter.specialFilters.TryGetValue(type, out var filter))
			{
				return filter(config, t);
			}

			if (config.CustomWhitelist.Contains(def))
			{
				return true;
			}

			if (config.CustomBlacklist.Contains(def))
			{
				return false;
			}

			if (SpelunkerFilter.tileToDefaultFilterToggle.TryGetValue(type, out var toggle) && !toggle(config))
			{
				return false;
			}

			return null;
		}
	}
}