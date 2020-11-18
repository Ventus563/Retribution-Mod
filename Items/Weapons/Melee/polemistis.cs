using System;
using System.IO;
using Microsoft.Xna.Framework;
using Terraria;
using Retribution;
using Retribution.Items.Souls;
using Terraria.GameContent.Events;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using Retribution.Projectiles.Minions;

namespace Retribution.Items.Weapons.Melee
{
	public class polemistis : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Polemistis");
		}

		public override void SetDefaults()
		{
			item.channel = true;
			item.maxStack = 1;
			item.damage = 18;
			item.width = 48;
			item.height = 48;
			item.useTime = 20;
			item.useAnimation = 20;
			item.useStyle = 1;
			item.knockBack = 3f;
			item.value = Item.sellPrice(0, 15, 0, 0);
			item.rare = 3;
			item.melee = true;
			item.UseSound = SoundID.Item1;
			item.useTurn = true;
			item.shoot = mod.ProjectileType("heart");
			item.shootSpeed = 9f;
		}
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<desertsoul>(), 5);
			recipe.AddIngredient(ModContent.ItemType<brokenblade>(), 1);
			//recipe.AddIngredient(ModContent.ItemType<residue>(), 1);
			//recipe.AddTile(TileID.MysticForge);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
