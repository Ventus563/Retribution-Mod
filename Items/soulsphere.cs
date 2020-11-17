using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.DataStructures;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Retribution.Items
{
	public class soulsphere : ModItem
	{

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Soul Sphere");
			Tooltip.SetDefault("Permanently increases soul storage by 5");
			// ticksperframe, frameCount
			Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(5, 4));
			ItemID.Sets.AnimatesAsSoul[item.type] = true;
			ItemID.Sets.ItemIconPulse[item.type] = true;
			ItemID.Sets.ItemNoGravity[item.type] = true;
		}

		public override void SetDefaults()
		{
			item.width = 40;
			item.height = 42;
			item.useStyle = 4;
			item.useAnimation = 15;
			item.useTime = 100;
			item.useTurn = true;
			item.UseSound = SoundID.Item25;
			item.maxStack = 1;
			item.value = 30000;
			item.consumable = false;
		}

		public override bool UseItem(Player player)
		{
			var rP = player.GetModPlayer<RetributionPlayer>();

			if (rP.soulMax < 40)
			{
				rP.soulMax += 2;
			}
			return true;
		}

        /*public override void AddRecipes()
        {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "wanderingspirit", 3);
			recipe.AddTile(TileID.Furnaces);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}*/
    }
}