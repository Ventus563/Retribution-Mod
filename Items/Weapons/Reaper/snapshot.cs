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
	public class snapshot : ReaperClass
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Snapshot");
			Tooltip.SetDefault("Takes a deadly circular snapshot around the player");
		}

		public override void SafeSetDefaults()
		{
			item.channel = true;
			item.maxStack = 1;
			item.damage = 80;
			item.crit = 5;
			item.width = 32;
			item.height = 34;
			item.useTime = 20;
			item.useAnimation = 20;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.knockBack = 6f;
			item.value = Item.sellPrice(0, 15, 0, 0);
			item.rare = 3;
			item.noMelee = true;
			item.useTurn = true;
		}

		public override bool CanUseItem(Player player)
		{
			var rP = player.GetModPlayer<RetributionPlayer>();

			if (rP.soulCurrent >= rP.soulMax / 2)
			{
				item.channel = true;
				item.maxStack = 1;
				item.damage = 40;
				item.crit = 5;
				item.width = 32;
				item.height = 34;
				item.useTime = 20;
				item.useAnimation = 20;
				item.useStyle = ItemUseStyleID.HoldingOut;
				item.knockBack = 6f;
				item.value = Item.sellPrice(0, 15, 0, 0);
				item.rare = 3;
				item.noMelee = true;
				item.UseSound = new Terraria.Audio.LegacySoundStyle(SoundID.Camera, 0);
				item.UseSound = SoundID.DD2_MonkStaffGroundImpact;
				item.useTurn = true;
				item.shoot = mod.ProjectileType("snapshotproj");

				soulCost = rP.soulMax / 2;

				return base.CanUseItem(player);
			}
			else
			{
				return false;
			}
		}
	}
}
