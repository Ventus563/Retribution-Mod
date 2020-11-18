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

namespace Retribution.Items.Weapons.Summoner
{
	public class kalon : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Kalon");
		}

		public override void SetDefaults()
		{
			item.channel = true;
			item.maxStack = 1;
			item.summon = true;
			item.damage = 21;
			item.width = 42;
			item.height = 42;
			item.useTime = 25;
			item.useAnimation = 25;
			item.useStyle = 1;
			item.knockBack = 6f;
			item.value = Item.sellPrice(0, 1, 0, 0);
			item.rare = 3;
			item.melee = true;
			item.UseSound = SoundID.Item1;
			item.useTurn = true;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<junglesoul>(), 5);
			//recipe.AddIngredient(ModContent.ItemType<brokenrod>(), 1);
			//recipe.AddIngredient(ModContent.ItemType<residue>(), 1);
			//recipe.AddTile(TileID.MysticForge);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
