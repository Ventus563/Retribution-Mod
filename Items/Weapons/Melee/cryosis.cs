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
using Retribution.Items.Souls;

namespace Retribution.Items.Weapons.Melee
{
	public class cryosis : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Cryosis");
		}

		public override void SetDefaults()
		{
			item.channel = true;
			item.maxStack = 1;
			item.damage = 15;
			item.crit = 2;
			item.width = 34;
			item.height = 40;
			item.useTime = 25;
			item.useAnimation = 25;
			item.useStyle = 1;
			item.knockBack = 1f;
			item.autoReuse = true;
			item.value = Item.sellPrice(0, 1, 0, 0);
			item.rare = 0;
			item.melee = true;
			item.UseSound = SoundID.Item28;
			item.useTurn = true;
			item.shoot = ModContent.ProjectileType<cryosisproj>();
			item.shootSpeed = 12f;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.IceBlade, 1);
			recipe.AddIngredient(ModContent.ItemType<frozensoul>(), 8);
			recipe.AddTile(TileID.Solidifier);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
