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
	public class soulsphere : ReaperClass
	{

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Soul Sphere");
			Tooltip.SetDefault("Permanently increases soul storage by 5");
			Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(5, 4));
			ItemID.Sets.AnimatesAsSoul[item.type] = true;
			ItemID.Sets.ItemNoGravity[item.type] = true;
		}

		public override void SafeSetDefaults()
		{
			item.width = 38;
			item.height = 38;
			item.useStyle = 4;
			item.useAnimation = 100;
			item.useTime = 100;
			item.useTurn = true;
			item.noUseGraphic = true;
			item.UseSound = SoundID.Item25;
			item.maxStack = 5;
			item.value = 30000;
			item.consumable = true;
		}

		public override bool CanUseItem(Player player)
		{
			var rP = player.GetModPlayer<RetributionPlayer>();

			if (rP.soulMax < 50)
			{
				return true;
			}

			return false;
		}

        public override bool UseItem(Player player)
		{
			var rP = player.GetModPlayer<RetributionPlayer>();

			if (rP.soulMax < 50)
			{
				rP.soulMax += 5;
			}
			return true;
		}

        public override void AddRecipes()
        {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "desertsoul", 5);
			recipe.AddIngredient(null, "frozensoul", 5);
			recipe.AddIngredient(null, "evilsoul", 5);
			recipe.AddIngredient(null, "hellfiresoul", 5);
			recipe.AddIngredient(null, "cavernsoul", 5);
			recipe.AddIngredient(null, "dungeonsoul", 5);
			recipe.AddIngredient(null, "junglesoul", 5);
			recipe.AddIngredient(null, "oceansoul", 5);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
    }
}