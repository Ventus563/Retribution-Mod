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
using Terraria.Graphics.Shaders;

namespace Retribution.Items.Weapons.Reaper
{
	public class ocellus : ReaperClass
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Ocellus");
			Tooltip.SetDefault("Unleashes a regenerative burst");
		}

		public override void SafeSetDefaults()
		{
			item.channel = true;
			item.maxStack = 1;
			item.damage = 21;
			item.width = 60;
			item.height = 54;
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

			if (player.altFunctionUse == 2 && retributionPlayer.soulCurrent >= 5)
			{
				item.useStyle = ItemUseStyleID.HoldingOut;
				item.useTime = 10;
				item.useAnimation = 10;
				item.damage = 10;
				item.crit = 20; 
				item.noMelee = true;
				item.melee = false;
				item.autoReuse = true;
				item.UseSound = SoundID.Item25;

				Lighting.AddLight(player.position, 0.8f, 0.06f, 0.46f);

				for (int i = 0; i < 30; i++)
				{
					Dust dust;
					Vector2 position = Main.LocalPlayer.position;
					dust = Main.dust[Terraria.Dust.NewDust(position, player.width, player.height, 16, 0f, 0f, 100, new Color(255, 255, 255), 1.513158f)];
					dust.shader = GameShaders.Armor.GetSecondaryShader(47, Main.LocalPlayer);
				}
				player.statLife += 25;

				soulCost = 5;
				
			}
			else {
				item.useStyle = ItemUseStyleID.SwingThrow;
				item.useTime = 20;
				item.useAnimation = 20;
				item.damage = 20;
				item.noMelee = false;
				item.melee = true;
				item.autoReuse = true;
				item.UseSound = SoundID.Item1;

				soulCost = 0;
			}
			return base.CanUseItem(player);
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.CrimtaneBar, 12);
			recipe.AddIngredient(ModContent.ItemType<bleedingbackblade>());
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
