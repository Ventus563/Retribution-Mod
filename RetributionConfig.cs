using System.IO;
using System.Collections.Generic;
using Terraria;
using System;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.World.Generation;
using Microsoft.Xna.Framework;
using Terraria.GameContent.Generation;
using System.Linq;
using Retribution.Tiles;
using Retribution.Items;
using Retribution.Projectiles;
using IL.Terraria.Utilities;
using Terraria.ModLoader.IO;
using Terraria.Utilities;
using Terraria.ModLoader.Config;
using System.Runtime.Serialization;
using System.ComponentModel;

namespace Retribution
{
	[Label("Configuration")]
	public class RetributionConfig : ModConfig
	{
		public override ConfigScope Mode => ConfigScope.ServerSide;

		public static RetributionConfig Instance;

		[Header("General Options")]
		[Label("Auto-Swing")]
		[Tooltip("Enables auto swing for every weapon.")]
		[DefaultValue(true)]
		[ReloadRequired]
		public bool autoSwing { get; set; }
	}
}