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
	public class corruptedscythe : ReaperClass
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Corrupted Scythe");
			Tooltip.SetDefault("Shoots a firey ghast to eat your enemies\nCosts 5 soul fragments");
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
			item.knockBack = 6f;
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

			if (player.altFunctionUse == 2 && retributionPlayer.soulCurrent >= 2)
			{
				item.useStyle = ItemUseStyleID.HoldingOut;
				item.useTime = 20;
				item.useAnimation = 20;
				item.damage = 10;
				item.crit = 10; 
				item.noMelee = true;
				item.melee = false;
				item.autoReuse = true;
				item.UseSound = SoundID.Item1;
				item.shoot = mod.ProjectileType("shadowball");
				item.shootSpeed = 3f;

				soulCost = 5;
				
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

		public override void MeleeEffects(Player player, Rectangle hitbox)
		{
			if (player.altFunctionUse == 2)
			{
				int dust = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, DustID.Shadowflame, player.velocity.X * 0.2f + (float)(player.direction * 3), player.velocity.Y * 0.2f, 100, default(Color), 2.5f);
				Lighting.AddLight(item.Center, Color.Purple.ToVector3() * 0.98f);
			}
			else
			{
				int dust = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, DustID.Shadowflame, player.velocity.X * 0.2f + (float)(player.direction * 3), player.velocity.Y * 0.2f, 100, default(Color), 2.5f);
				Main.dust[dust].noGravity = true;
				Lighting.AddLight(item.Center, Color.Purple.ToVector3() * 0.98f);
			}
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Ebonwood, 50);
			recipe.AddIngredient(mod.ItemType("scythemold"), 1);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
