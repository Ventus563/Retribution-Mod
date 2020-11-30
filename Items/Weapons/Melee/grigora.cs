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

namespace Retribution.Items.Weapons.Melee
{
	public class grigora : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Grigora");
		}

		public override void SetDefaults()
		{
			item.channel = true;
			item.maxStack = 1;
			item.damage = 80;
			item.width = 42;
			item.height = 50;
			item.useTime = 3;
			item.useAnimation = 3;
			item.useStyle = 1;
			item.knockBack = 1f;
			item.autoReuse = true;
			item.value = Item.sellPrice(0, 0, 25, 0);
			item.rare = 0;
			item.melee = true;
			item.UseSound = SoundID.Item1;
			item.useTurn = true;
			item.shoot = ModContent.ProjectileType<damagebullet>();
			item.shootSpeed = 20f;
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
