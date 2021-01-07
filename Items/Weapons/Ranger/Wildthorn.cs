using Retribution.Projectiles;
using Retribution.Items.Souls;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace Retribution.Items.Weapons.Ranger
{
	public class Wildthorn : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Wildthorn");
		}

		public override void SetDefaults()
		{
			item.damage = 37;
			item.ranged = true;
			item.width = 50;
			item.height = 28;
			item.useTime = 10;
			item.useAnimation = 10;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.noMelee = true;
			item.knockBack = 4;
			item.value = 80000;
			item.rare = 0;
			item.UseSound = SoundID.Item11;
			item.shoot = 10;
			item.shootSpeed = 36f;
			item.useAmmo = AmmoID.Bullet;
		}

        public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.JungleSpores, 5);
            recipe.AddIngredient(ItemID.Stinger, 5);
			recipe.AddTile(TileID.WorkBench);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
	