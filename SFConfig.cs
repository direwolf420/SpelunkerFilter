using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;
using Terraria.ModLoader;
using Terraria.ModLoader.Config;

namespace SpelunkerFilter
{
	public enum ToggleOverride : byte
	{
		Default,
		Whitelist,
		Blacklist
	}

	public partial class SFConfig
	{
		public override ConfigScope Mode => ConfigScope.ClientSide;

		public static SFConfig Instance => ModContent.GetInstance<SFConfig>();

		[DefaultValue(true)]
		public bool ApplyToMetalDetector { get; set; }

		[ReloadRequired]
		[DefaultValue(false)]
		public bool RemoveSparklingDust { get; set; }

		[Header("CustomFilter")]
		[BackgroundColor(220, 220, 220)]
		public List<TileDefinition> CustomWhitelist { get; set; } = new List<TileDefinition>();

		[BackgroundColor(30, 30, 30)]
		public List<TileDefinition> CustomBlacklist { get; set; } = new List<TileDefinition>();

		[Header("SpecialFilter")]
		[DefaultValue(ToggleOverride.Default)]
		[TooltipKey("$" + SpelunkerFilter.specialFilterTooltipKey)]
		public ToggleOverride GelatinCrystal { get; set; }

		[Header("PresetFilterGroupToggles")]
		[BackgroundColor(30, 30, 200)]
		[JsonIgnore]
		[ShowDespiteJsonIgnore]
		[DefaultValue(true)]
		public bool ToggleGems
		{
			get => Amethyst;
			set
			{
				Amethyst = value;
				Sapphire = value;
				Ruby = value;
				Emerald = value;
				Topaz = value;
				Diamond = value;
				AmberStoneBlock = value;
				ExposedGems = value;
			}
		}

		[BackgroundColor(30, 30, 200)]
		[JsonIgnore]
		[ShowDespiteJsonIgnore]
		[DefaultValue(true)]
		public bool TogglePreHMMetalOres
		{
			get => Copper;
			set
			{
				Copper = value;
				Tin = value;
				Iron = value;
				Lead = value;
				Silver = value;
				Tungsten = value;
				Gold = value;
				Platinum = value;
			}
		}

		[BackgroundColor(30, 30, 200)]
		[JsonIgnore]
		[ShowDespiteJsonIgnore]
		[DefaultValue(true)]
		public bool ToggleHMMetalOres
		{
			get => Cobalt;
			set
			{
				Cobalt = value;
				Palladium = value;
				Mythril = value;
				Orichalcum = value;
				Adamantite = value;
				Titanium = value;
			}
		}

		[OnDeserialized]
		internal void OnDeserializedMethod(StreamingContext context)
		{
			//Correct invalid values to default fallback
			GelatinCrystal = EnumFallback(GelatinCrystal, ToggleOverride.Default);
		}

		private static T EnumFallback<T>(T value, T defaultValue) where T : Enum
		{
			if (!Enum.IsDefined(typeof(T), value))
			{
				return defaultValue;
			}
			return value;
		}
	}
}
