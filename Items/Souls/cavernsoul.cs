using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.DataStructures;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Retribution.Items.Souls
{
	public class cavernsoul : ModItem
	{

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Caveren Soul");
			Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(5, 4));
			ItemID.Sets.AnimatesAsSoul[item.type] = true;
			ItemID.Sets.ItemNoGravity[item.type] = true;
		}

		public override void SetDefaults()
		{
			item.width = 22;
			item.height = 22;
			item.UseSound = SoundID.Item25;
			item.maxStack = 999;
			item.consumable = false;
		}

		public override bool OnPickup(Player player)
		{
			var rP = player.GetModPlayer<RetributionPlayer>();

			rP.addSoul = true;

			return false;
		}

		public override void PostUpdate()
		{
			Lighting.AddLight(item.position, 0.6f, 0.6f, 0.6f);
		}
	}
}