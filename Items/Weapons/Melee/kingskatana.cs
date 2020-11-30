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

namespace Retribution.Items.Weapons.Melee
{
	public class kingskatana : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("King's Katana");
			Tooltip.SetDefault("It's... Very slimey.");
		}

		public override void SetDefaults()
		{
			item.channel = true;
			item.maxStack = 1;
			item.damage = 12;
			item.width = 54;
			item.height = 54;
			item.useTime = 16;
			item.useAnimation = 16;
			item.useStyle = 1;
			item.knockBack = 3f;
			item.value = Item.sellPrice(0, 15, 0, 0);
			item.rare = 3;
			item.melee = true;
			item.UseSound = SoundID.Item1;
			item.useTurn = true;
			item.shoot = mod.ProjectileType("slime");
			item.shootSpeed = 4f;
		}
	}
}
