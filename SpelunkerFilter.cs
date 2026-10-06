using Terraria.ModLoader;
using Terraria;
using Terraria.ID;
using System.Collections.Generic;
using System.Linq;
using Terraria.Localization;
using System;
using Terraria.GameContent.Drawing;

namespace SpelunkerFilter
{
	public class SpelunkerFilter : Mod
	{
        public const string presetFilterTooltipKey = $"Mods.{nameof(SpelunkerFilter)}.Configs.{nameof(SFConfigBase)}.DefaultFilterTooltip";
		public const string specialFilterTooltipKey = $"Mods.{nameof(SpelunkerFilter)}.Configs.{nameof(SFConfigBase)}.SpecialFilterTooltip";

        public static Dictionary<int, Func<SFConfigBase, bool>> tileToDefaultFilterToggle;

		public static Dictionary<int, Func<SFConfigBase, Tile, bool?>> specialFilters;

		private static bool drawTileRunning;

        public override void Load()
        {
            Language.GetOrRegister(presetFilterTooltipKey);
			Language.GetOrRegister(specialFilterTooltipKey);

			specialFilters = new();

			if (SFConfig.Instance.RemoveSparklingDust)
			{
				On_TileDrawing.DrawSingleTile += On_TileDrawing_DrawSingleTile;
				On_TileDrawing.DrawAnimatedTile_AdjustForVisionChangers += On_TileDrawing_DrawAnimatedTile_AdjustForVisionChangers;
				On_Dust.NewDust += On_Dust_NewDust;
			}
		}

		private static int On_Dust_NewDust(On_Dust.orig_NewDust orig, Microsoft.Xna.Framework.Vector2 Position, int Width, int Height, int Type, float SpeedX, float SpeedY, int Alpha, Microsoft.Xna.Framework.Color newColor, float Scale)
		{
			int ret = orig(Position, Width, Height, Type, SpeedX, SpeedY, Alpha, newColor, Scale);

			//The sparkle dust spawns during spelunker effect
			if (drawTileRunning && ret < Main.maxDust && Main.dust[ret] is Dust dust && dust.type == 204)
			{
				dust.active = false;
			}

			return ret;
		}

		private static void On_TileDrawing_DrawAnimatedTile_AdjustForVisionChangers(On_TileDrawing.orig_DrawAnimatedTile_AdjustForVisionChangers orig, TileDrawing self, int i, int j, Tile tileCache, ushort typeCache, short tileFrameX, short tileFrameY, ref Microsoft.Xna.Framework.Color tileLight, bool canDoDust)
		{
			drawTileRunning = true;
			orig(self, i, j, tileCache, typeCache, tileFrameX, tileFrameY, ref tileLight, canDoDust);
			drawTileRunning = false;
		}

		private static void On_TileDrawing_DrawSingleTile(On_TileDrawing.orig_DrawSingleTile orig, TileDrawing self, Terraria.DataStructures.TileDrawInfo drawData, bool solidLayer, int waterStyleOverride, Microsoft.Xna.Framework.Vector2 screenPosition, Microsoft.Xna.Framework.Vector2 screenOffset, int tileX, int tileY)
		{
			drawTileRunning = true;
			orig(self, drawData, solidLayer, waterStyleOverride, screenPosition, screenOffset, tileX, tileY);
			drawTileRunning = false;
		}

		public override void PostSetupContent()
        {
            //GenerateLogOutput();

			specialFilters.Add(TileID.Crystals, (config, t) =>
				{
					//Vanilla check:
					//if (t.type == 129 && t.frameX < 324)
						//return false;
					//Our check: more robust based on spritesheet
					//6 wide 8 tall
					bool gelatin = t.TileFrameX is >= 18 * 18 and < 24 * 18 &&
						t.TileFrameY is >= 0 and < 8 * 18;

					if (!gelatin) return null;

					//Check config toggle last, as it should only apply if the gelatin crystal is found
					return GetToggleValue(config.GelatinCrystal);
				}
			);

            tileToDefaultFilterToggle = new()
            {
                //paste result of dictDefinition here
                { TileID.Pots, config => config.Pots },
                { TileID.DesertFossil, config => config.DesertFossil },
                { TileID.FossilOre, config => config.FossilOre },
                { TileID.Copper, config => config.Copper },
                { TileID.Tin, config => config.Tin },
                { TileID.Iron, config => config.Iron },
                { TileID.Lead, config => config.Lead },
                { TileID.Silver, config => config.Silver },
                { TileID.Tungsten, config => config.Tungsten },
                { TileID.Gold, config => config.Gold },
                { TileID.Platinum, config => config.Platinum },
                { TileID.Meteorite, config => config.Meteorite },
                { TileID.Containers, config => config.Containers },
                { TileID.FakeContainers, config => config.FakeContainers },
                { TileID.Containers2, config => config.Containers2 },
                { TileID.FakeContainers2, config => config.FakeContainers2 },
                { TileID.Heart, config => config.Heart },
                { TileID.ManaCrystal, config => config.ManaCrystal },
                { TileID.Cobalt, config => config.Cobalt },
                { TileID.Palladium, config => config.Palladium },
                { TileID.Mythril, config => config.Mythril },
                { TileID.Orichalcum, config => config.Orichalcum },
                { TileID.Adamantite, config => config.Adamantite },
                { TileID.Titanium, config => config.Titanium },
                { TileID.Chlorophyte, config => config.Chlorophyte },
                { TileID.DyePlants, config => config.DyePlants },
                { TileID.LifeFruit, config => config.LifeFruit },
                { TileID.Sapphire, config => config.Sapphire },
                { TileID.Ruby, config => config.Ruby },
                { TileID.Emerald, config => config.Emerald },
                { TileID.Topaz, config => config.Topaz },
                { TileID.Amethyst, config => config.Amethyst },
                { TileID.Diamond, config => config.Diamond },
                { TileID.MatureHerbs, config => config.MatureHerbs },
                { TileID.BloomingHerbs, config => config.BloomingHerbs },
                { TileID.Statues, config => config.Statues },
                { TileID.ExposedGems, config => config.ExposedGems },
                { TileID.Painting3X3, config => config.Painting3X3 },
                { TileID.Painting6X4, config => config.Painting6X4 },
                { TileID.Painting2X3, config => config.Painting2X3 },
                { TileID.Painting3X2, config => config.Painting3X2 },
                { TileID.AlphabetStatues, config => config.AlphabetStatues },
                { TileID.MushroomStatue, config => config.MushroomStatue },
                { TileID.CatBast, config => config.CatBast },
                { TileID.BoulderStatue, config => config.BoulderStatue },
                { TileID.AmberStoneBlock, config => config.AmberStoneBlock },
            };
        }

		public static bool? GetToggleValue(ToggleOverride value)
		{
			return value switch
			{
				ToggleOverride.Default => null,
				ToggleOverride.Whitelist => true,
				ToggleOverride.Blacklist => false,
				_ => throw new ArgumentOutOfRangeException(nameof(value), value, null)
			};
		}

        //Ghetto Source Generator
        private void GenerateLogOutput()
        {
            List<int> types = new();
            //Vanilla only
            for (int i = 0; i < TileID.Count; i++)
            {
                if (!Main.tileSpelunker[i])
                {
                    continue;
                }
                types.Add(i);
            }

            //Things with no priority at the end
            types = types.OrderBy(i => Main.tileOreFinderPriority[i] > 0 ? Main.tileOreFinderPriority[i] : short.MaxValue).ToList();

            string configOutput = "\n[Header(\"PresetFilter\")]\n";
            string dictDefinition = "\n";
            foreach (var type in types)
            {
                string name = TileID.Search.GetName(type);
                configOutput += $"[DefaultValue(true)]\n[TooltipKey(\"$\" + SpelunkerFilter.presetFilterTooltipKey)]\npublic bool {name} " + "{ get; set; }\n\n";
                dictDefinition += "{ " + $"TileID.{name}, config => config.{name}" + " },\n";
            }

            Logger.Info(configOutput);
            Logger.Info(dictDefinition);
        }
    }
}
