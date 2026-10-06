using System.ComponentModel;
using Terraria.ModLoader.Config;

namespace SpelunkerFilter
{
	//Pasted in manually from log output
	public abstract partial class SFConfigBase : ModConfig
	{
		[Header("PresetFilter")]
		[DefaultValue(true)]
		[TooltipKey("$" + SpelunkerFilter.presetFilterTooltipKey)]
		public bool Pots { get; set; }

		[DefaultValue(true)]
		[TooltipKey("$" + SpelunkerFilter.presetFilterTooltipKey)]
		public bool DesertFossil { get; set; }

		[DefaultValue(true)]
		[TooltipKey("$" + SpelunkerFilter.presetFilterTooltipKey)]
		public bool FossilOre { get; set; }

		[DefaultValue(true)]
		[TooltipKey("$" + SpelunkerFilter.presetFilterTooltipKey)]
		public bool Copper { get; set; }

		[DefaultValue(true)]
		[TooltipKey("$" + SpelunkerFilter.presetFilterTooltipKey)]
		public bool Tin { get; set; }

		[DefaultValue(true)]
		[TooltipKey("$" + SpelunkerFilter.presetFilterTooltipKey)]
		public bool Iron { get; set; }

		[DefaultValue(true)]
		[TooltipKey("$" + SpelunkerFilter.presetFilterTooltipKey)]
		public bool Lead { get; set; }

		[DefaultValue(true)]
		[TooltipKey("$" + SpelunkerFilter.presetFilterTooltipKey)]
		public bool Silver { get; set; }

		[DefaultValue(true)]
		[TooltipKey("$" + SpelunkerFilter.presetFilterTooltipKey)]
		public bool Tungsten { get; set; }

		[DefaultValue(true)]
		[TooltipKey("$" + SpelunkerFilter.presetFilterTooltipKey)]
		public bool Gold { get; set; }

		[DefaultValue(true)]
		[TooltipKey("$" + SpelunkerFilter.presetFilterTooltipKey)]
		public bool Platinum { get; set; }

		[DefaultValue(true)]
		[TooltipKey("$" + SpelunkerFilter.presetFilterTooltipKey)]
		public bool Meteorite { get; set; }

		[DefaultValue(true)]
		[TooltipKey("$" + SpelunkerFilter.presetFilterTooltipKey)]
		public bool Containers { get; set; }

		[DefaultValue(true)]
		[TooltipKey("$" + SpelunkerFilter.presetFilterTooltipKey)]
		public bool FakeContainers { get; set; }

		[DefaultValue(true)]
		[TooltipKey("$" + SpelunkerFilter.presetFilterTooltipKey)]
		public bool Containers2 { get; set; }

		[DefaultValue(true)]
		[TooltipKey("$" + SpelunkerFilter.presetFilterTooltipKey)]
		public bool FakeContainers2 { get; set; }

		[DefaultValue(true)]
		[TooltipKey("$" + SpelunkerFilter.presetFilterTooltipKey)]
		public bool Heart { get; set; }

		[DefaultValue(true)]
		[TooltipKey("$" + SpelunkerFilter.presetFilterTooltipKey)]
		public bool ManaCrystal { get; set; }

		[DefaultValue(true)]
		[TooltipKey("$" + SpelunkerFilter.presetFilterTooltipKey)]
		public bool Cobalt { get; set; }

		[DefaultValue(true)]
		[TooltipKey("$" + SpelunkerFilter.presetFilterTooltipKey)]
		public bool Palladium { get; set; }

		[DefaultValue(true)]
		[TooltipKey("$" + SpelunkerFilter.presetFilterTooltipKey)]
		public bool Mythril { get; set; }

		[DefaultValue(true)]
		[TooltipKey("$" + SpelunkerFilter.presetFilterTooltipKey)]
		public bool Orichalcum { get; set; }

		[DefaultValue(true)]
		[TooltipKey("$" + SpelunkerFilter.presetFilterTooltipKey)]
		public bool Adamantite { get; set; }

		[DefaultValue(true)]
		[TooltipKey("$" + SpelunkerFilter.presetFilterTooltipKey)]
		public bool Titanium { get; set; }

		[DefaultValue(true)]
		[TooltipKey("$" + SpelunkerFilter.presetFilterTooltipKey)]
		public bool Chlorophyte { get; set; }

		[DefaultValue(true)]
		[TooltipKey("$" + SpelunkerFilter.presetFilterTooltipKey)]
		public bool DyePlants { get; set; }

		[DefaultValue(true)]
		[TooltipKey("$" + SpelunkerFilter.presetFilterTooltipKey)]
		public bool LifeFruit { get; set; }

		[DefaultValue(true)]
		[TooltipKey("$" + SpelunkerFilter.presetFilterTooltipKey)]
		public bool Sapphire { get; set; }

		[DefaultValue(true)]
		[TooltipKey("$" + SpelunkerFilter.presetFilterTooltipKey)]
		public bool Ruby { get; set; }

		[DefaultValue(true)]
		[TooltipKey("$" + SpelunkerFilter.presetFilterTooltipKey)]
		public bool Emerald { get; set; }

		[DefaultValue(true)]
		[TooltipKey("$" + SpelunkerFilter.presetFilterTooltipKey)]
		public bool Topaz { get; set; }

		[DefaultValue(true)]
		[TooltipKey("$" + SpelunkerFilter.presetFilterTooltipKey)]
		public bool Amethyst { get; set; }

		[DefaultValue(true)]
		[TooltipKey("$" + SpelunkerFilter.presetFilterTooltipKey)]
		public bool Diamond { get; set; }

		[DefaultValue(true)]
		[TooltipKey("$" + SpelunkerFilter.presetFilterTooltipKey)]
		public bool MatureHerbs { get; set; }

		[DefaultValue(true)]
		[TooltipKey("$" + SpelunkerFilter.presetFilterTooltipKey)]
		public bool BloomingHerbs { get; set; }

		[DefaultValue(true)]
		[TooltipKey("$" + SpelunkerFilter.presetFilterTooltipKey)]
		public bool Statues { get; set; }

		[DefaultValue(true)]
		[TooltipKey("$" + SpelunkerFilter.presetFilterTooltipKey)]
		public bool ExposedGems { get; set; }

		[DefaultValue(true)]
		[TooltipKey("$" + SpelunkerFilter.presetFilterTooltipKey)]
		public bool Painting3X3 { get; set; }

		[DefaultValue(true)]
		[TooltipKey("$" + SpelunkerFilter.presetFilterTooltipKey)]
		public bool Painting6X4 { get; set; }

		[DefaultValue(true)]
		[TooltipKey("$" + SpelunkerFilter.presetFilterTooltipKey)]
		public bool Painting2X3 { get; set; }

		[DefaultValue(true)]
		[TooltipKey("$" + SpelunkerFilter.presetFilterTooltipKey)]
		public bool Painting3X2 { get; set; }

		[DefaultValue(true)]
		[TooltipKey("$" + SpelunkerFilter.presetFilterTooltipKey)]
		public bool AlphabetStatues { get; set; }

		[DefaultValue(true)]
		[TooltipKey("$" + SpelunkerFilter.presetFilterTooltipKey)]
		public bool MushroomStatue { get; set; }

		[DefaultValue(true)]
		[TooltipKey("$" + SpelunkerFilter.presetFilterTooltipKey)]
		public bool CatBast { get; set; }

		[DefaultValue(true)]
		[TooltipKey("$" + SpelunkerFilter.presetFilterTooltipKey)]
		public bool BoulderStatue { get; set; }

		[DefaultValue(true)]
		[TooltipKey("$" + SpelunkerFilter.presetFilterTooltipKey)]
		public bool AmberStoneBlock { get; set; }
	}
}
