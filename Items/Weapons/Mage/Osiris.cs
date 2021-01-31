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

namespace Retribution.Items.Weapons.Mage
{
	public class Osiris : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Osiris");
			Item.staff[item.type] = true;
		}

		public override void SetDefaults()
		{
			item.channel = true;
			item.maxStack = 1;
			item.damage = 6;
			item.width = 42;
			item.height = 50;
			item.useTime = 3;
			item.useAnimation = 20;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.knockBack = 1f;
			item.autoReuse = true;
			item.value = Item.sellPrice(0, 0, 25, 0);
			item.rare = 0;
			item.UseSound = SoundID.Item1;
			item.useTurn = true;
			item.shoot = ModContent.ProjectileType<damagebullet>();
			item.shootSpeed = 15f;
			item.mana = 3;
		}

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
			float numberProjectiles = 2;
			int spread = Main.rand.Next(0, 20);
			float rotation = MathHelper.ToRadians(spread);
			position += Vector2.Normalize(new Vector2(speedX, speedY)) * spread;
			for (int i = 0; i < numberProjectiles; i++)
			{
				Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedBy(MathHelper.Lerp(-rotation, rotation, i / (numberProjectiles - 1))) * 1f;
				Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);
			}
			return false;
		}

        public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.IronBar, 10);
			recipe.AddIngredient(mod, "desertsoul", 5);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
