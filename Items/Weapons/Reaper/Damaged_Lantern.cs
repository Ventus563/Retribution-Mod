using System;
using System.IO;
using Microsoft.Xna.Framework;
using Terraria;
using Retribution;
using Terraria.GameContent.Events;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using Retribution.Projectiles.Minions.Necromancer;

namespace Retribution.Items.Weapons.Reaper
{
	public class Damaged_Lantern : ReaperClass
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Damaged Lantern");
			Tooltip.SetDefault("Summons a Fire Wisp");
		}

		public override void SafeSetDefaults()
		{
			item.channel = true;
			item.maxStack = 1;
			item.damage = 13;
			item.width = 46;
			item.height = 66;
			item.useTime = 50;
			item.useAnimation = 50;
			item.useStyle = 1;
			item.knockBack = 6f;
			item.value = Item.sellPrice(0, 1, 0, 0);
			item.rare = 0;
			item.melee = true;
			item.UseSound = SoundID.Item1;
			item.shoot = ModContent.ProjectileType<firewisp>();
			item.useTurn = true;

			soulCost = 3;
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
