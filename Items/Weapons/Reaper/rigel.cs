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
	public class rigel : ReaperClass
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Rigel");
			Tooltip.SetDefault("Shoots a spinning star. If this star hits an enemy, more stars will rain down upon them.");
		}

		public override void SafeSetDefaults()
		{
			item.channel = true;
			item.maxStack = 1;
			item.damage = 180;
			item.width = 56;
			item.height = 48;
			item.useTime = 20;
			item.useAnimation = 20;
			item.useStyle = 1;
			item.knockBack = 6f;
			item.value = Item.sellPrice(0, 15, 0, 0);
			item.rare = 3;
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

			if (player.altFunctionUse == 2 && retributionPlayer.soulCurrent >= 8)
			{
				item.useStyle = ItemUseStyleID.HoldingOut;
				item.useTime = 20;
				item.useAnimation = 20;
				item.damage = 200;
				item.crit = 20; 
				item.noMelee = true;
				item.melee = false;
				item.autoReuse = true;
				item.UseSound = SoundID.Item1;
				item.shoot = ProjectileID.HallowStar;
				item.shootSpeed = 20f;

				soulCost = 6;
			}
			else {
				item.useStyle = ItemUseStyleID.SwingThrow;
				item.useTime = 20;
				item.useAnimation = 20;
				item.damage = 180;
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
				{
					Lighting.AddLight(item.Center, Color.Blue.ToVector3() * 0.98f);
				}
			}
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.HellstoneBar, 12);
			recipe.AddTile(TileID.Hellforge);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
