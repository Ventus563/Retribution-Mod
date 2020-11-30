using System;
using System.IO;
using Microsoft.Xna.Framework;
using Terraria;
using Retribution;
using Terraria.GameContent.Events;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using Retribution.Projectiles.Minions;

namespace Retribution.Items.Weapons.Reaper
{
	public class bleedingbackblade : ReaperClass
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Bleeding Back Blade");
			Tooltip.SetDefault("Rains poisonous blood on your enemies\nCosts 1 soul fragments");
		}

		public override void SafeSetDefaults()
		{
			item.channel = true;
			item.maxStack = 1;
			item.damage = 21;
			item.width = 32;
			item.height = 30;
			item.useTime = 25;
			item.useAnimation = 25;
			item.useStyle = 1;
			item.knockBack = 0f;
			item.value = Item.sellPrice(0, 1, 0, 0);
			item.rare = 0;
			item.melee = true;
			item.UseSound = SoundID.Item1;
			item.useTurn = true;
		}

		public override bool AltFunctionUse(Player player)
		{
			return true;
		}

		public override bool CanUseItem(Player player)
		{
			var retributionPlayer = player.GetModPlayer<RetributionPlayer>();

			if (player.altFunctionUse == 2 && retributionPlayer.soulCurrent >= 1)
			{
				item.useStyle = ItemUseStyleID.HoldingOut;
				item.useTime = 20;
				item.useAnimation = 20;
				item.damage = 15;
				item.crit = 10; 
				item.noMelee = true;
				item.melee = false;
				item.autoReuse = true;
				item.UseSound = SoundID.Item1;
				item.shoot = mod.ProjectileType("bloodbullet");
				item.shootSpeed = 25f;

				soulCost = 1;
				
			}
			else {
				item.useStyle = ItemUseStyleID.SwingThrow;
				item.useTime = 20;
				item.useAnimation = 20;
				item.damage = 6;
				item.noMelee = false;
				item.melee = true;
				item.autoReuse = true;
				item.UseSound = SoundID.Item1;
				item.shoot = 0;
				item.shootSpeed = 1f;

				soulCost = 0;
			}
			return base.CanUseItem(player);
		}

		public override bool Shoot(Player player, ref Microsoft.Xna.Framework.Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			int numberProjectiles = 8;
			for (int index = 0; index < numberProjectiles; ++index)
			{
				Vector2 vector2_1 = new Vector2((float)((double)player.position.X + (double)player.width * 0.5 + (double)(Main.rand.Next(201) * -player.direction) + ((double)Main.mouseX + (double)Main.screenPosition.X - (double)player.position.X)), (float)((double)player.position.Y + (double)player.height * 0.5 - 600.0));   //this defines the projectile width, direction and position
				vector2_1.X = (float)(((double)vector2_1.X + (double)player.Center.X) / 2.0) + (float)Main.rand.Next(-200, 201);
				vector2_1.Y -= (float)(100 * index);
				float num12 = (float)Main.mouseX + Main.screenPosition.X - vector2_1.X;
				float num13 = (float)Main.mouseY + Main.screenPosition.Y - vector2_1.Y;
				if ((double)num13 < 0.0) num13 *= -1f;
				if ((double)num13 < 20.0) num13 = 20f;
				float num14 = (float)Math.Sqrt((double)num12 * (double)num12 + (double)num13 * (double)num13);
				float num15 = item.shootSpeed / num14;
				float num16 = num12 * num15;
				float num17 = num13 * num15;
				float SpeedX = num16 + (float)Main.rand.Next(-40, 46) * 0.02f; //change the Main.rand.Next here to, for example, (-10, 11) to reduce the spread. Change this to 0 to remove it altogether
				float SpeedY = num17 + (float)Main.rand.Next(-40, 46) * 0.02f;
				Projectile.NewProjectile(vector2_1.X, vector2_1.Y, SpeedX, SpeedY, type, damage, knockBack, Main.myPlayer, 0.0f, (float)Main.rand.Next(5));
			}
			return false;
		}

		public override void MeleeEffects(Player player, Rectangle hitbox)
		{
			if (player.altFunctionUse == 2)
			{
				int dust = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, DustID.Blood, player.velocity.X * 0.2f + (float)(player.direction * 3), player.velocity.Y * 0.2f, 100, default(Color), 2.5f);
				Lighting.AddLight(item.Center, Color.Purple.ToVector3() * 0.98f);
			}
			else
			{
				int dust = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, DustID.Blood, player.velocity.X * 0.2f + (float)(player.direction * 3), player.velocity.Y * 0.2f, 100, default(Color), 2.5f);
				Main.dust[dust].noGravity = true;
				Lighting.AddLight(item.Center, Color.Purple.ToVector3() * 0.98f);
			}
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Shadewood, 50);
			recipe.AddIngredient(mod.ItemType("scythemold"), 1);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
