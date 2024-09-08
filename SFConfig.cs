﻿using System.Collections.Generic;
using Terraria.ModLoader;
using Terraria.ModLoader.Config;

namespace SpelunkerFilter
{
	public partial class SFConfig : ModConfig
	{
		public override ConfigScope Mode => ConfigScope.ClientSide;

		public static SFConfig Instance => ModContent.GetInstance<SFConfig>();

		[Header("CustomFilter")]
		[BackgroundColor(220, 220, 220)]
		public List<TileDefinition> CustomWhitelist { get; set; } = new List<TileDefinition>();

		[BackgroundColor(30, 30, 30)]
		public List<TileDefinition> CustomBlacklist { get; set; } = new List<TileDefinition>();
	}
}