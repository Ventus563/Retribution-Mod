using System;
using System.IO;
using Microsoft.Xna.Framework;
using Terraria;
using Retribution;
using Terraria.GameContent.Events;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using Retribution.Projectiles;

namespace Retribution.Items.Weapons.Ranger
{
	public class Windbreaker : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Windbreaker");
			Tooltip.SetDefault("Turns arrows into Wind Waves");
		}

		public override void SetDefaults()
		{
			item.damage = 30;
			item.ranged = true;
			item.width = 22;
			item.height = 64;
			item.useTime = 20;
			item.useAnimation = 20;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.noMelee = true;
			item.knockBack = 15;
			item.value = 10000;
			item.rare = ItemRarityID.Green;
			item.UseSound = SoundID.Item5;
			item.autoReuse = true;
			item.shoot = 10;
			item.shootSpeed = 16f;
			item.useAmmo = AmmoID.Arrow;
		}

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
			Projectile.NewProjectile(position.X, position.Y, speedX, speedY, ModContent.ProjectileType<WindWave>(), damage, knockBack, player.whoAmI, 0f, 0f);
			return false;
		}
    
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Cloud, 30);
			recipe.AddIngredient(ItemID.Feather, 15)
			///recipe.AddIngredient(ModContent.ItemType<SkySoul>())
			recipe.AddTile(TileID.IronAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}