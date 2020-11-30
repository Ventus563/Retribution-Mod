using System;
using System.IO;
using Microsoft.Xna.Framework;
using Retribution.Projectiles.Minions;
using Terraria;
using Retribution;
using Retribution.Items.Souls;
using Terraria.GameContent.Events;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using Retribution.Buffs;

namespace Retribution.Items.Weapons.Summoner
{
	public class yakaarrow : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Yaka Arrow");
			Tooltip.SetDefault("Summons a yaka arrow to pierce your enemies");
			ItemID.Sets.LockOnIgnoresCollision[item.type] = true;
		}

		public override void SetDefaults()
		{
			item.damage = 3;
			item.knockBack = 3f;
			item.mana = 10;
			item.width = 28;
			item.height = 28;
			item.useTime = 36;
			item.useAnimation = 36;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.value = Item.buyPrice(0, 30, 0, 0);
			item.rare = ItemRarityID.Cyan;
			item.UseSound = SoundID.Item44;

			// These below are needed for a minion weapon
			item.noMelee = true;
			item.summon = true;
			//item.buffType = ModContent.BuffType<blackholebuff>();
			// No buffTime because otherwise the item tooltip would say something like "1 minute duration"
			item.shoot = ModContent.ProjectileType<yakaarrowproj>();
		}

		/*public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			// This is needed so the buff that keeps your minion alive and allows you to despawn it properly applies
			player.AddBuff(item.buffType, 2);

			return true;
		}*/

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.SoulofFright, 25);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
