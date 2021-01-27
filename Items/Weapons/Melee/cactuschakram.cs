using System;
using System.IO;
using Microsoft.Xna.Framework;
using Terraria;
using Retribution;
using Terraria.GameContent.Events;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace Retribution.Items.Weapons.Melee
{
	public class cactuschakram : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Cactus Chakram");
		}

		public override void SetDefaults()
		{
			item.maxStack = 1;
			item.damage = 10;
			item.width = 38;
			item.height = 38;
			item.useTime = 23;
			item.useAnimation = 23;
			item.useStyle = 1;
			item.noUseGraphic = true;
			item.knockBack = 3f;
			item.autoReuse = true;
			item.value = Item.sellPrice(0, 0, 50, 0);
			item.rare = 0;
			item.melee = true;
			item.UseSound = SoundID.Item1;
			item.useTurn = true;
			item.shoot = mod.ProjectileType("cactuschakramproj");
			item.shootSpeed = 9f;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Cactus, 25);
			recipe.AddIngredient(mod, "desertsoul", 8);
			recipe.AddTile(TileID.WorkBenches);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}

        public override bool CanUseItem(Player player)
        {
			if (player.ownedProjectileCounts[item.shoot] == 2)
			{
				return false;
			}
			else
			{
				return true;
			}
        }
    }
}
