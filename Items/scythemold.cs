using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.DataStructures;
using Terraria.Localization;
using Terraria.ModLoader;
using SubworldLibrary;

namespace Retribution.Items
{
	public class scythemold : ModItem
	{

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Scythe Mold");
			Tooltip.SetDefault("Simple metal mold in the shape of a scythe");
		}

		public override void SetDefaults()
		{
			item.width = 10;
			item.height = 18;
			item.maxStack = 20;
			item.rare = ItemRarityID.Cyan;
			item.useAnimation = 45;
			item.useTime = 45;
			item.useStyle = ItemUseStyleID.HoldingUp;
			item.UseSound = SoundID.Item44;
			item.consumable = true;
		}

        public override bool UseItem(Player player)
		{
			Subworld.Enter <HematicZone>();
			return true;
		}
    }
}