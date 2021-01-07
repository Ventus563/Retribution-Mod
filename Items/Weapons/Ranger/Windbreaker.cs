<<<<<<< HEAD
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

namespace Retribution.Items.Weapons.Ranger
{
	public class Windbreaker : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Windbreaker");
			Tooltip.SetDefault("Turns arrows into Wind Waves");
		}

		public override void SetDefaults()
		{
			item.damage = 30;
			item.ranged = true;
			item.width = 22;
			item.height = 64;
			item.useTime = 20;
			item.useAnimation = 20;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.noMelee = true;
			item.knockBack = 15;
			item.value = 10000;
			item.rare = ItemRarityID.Green;
			item.UseSound = SoundID.Item5;
			item.autoReuse = true;
			item.shoot = 10;
			item.shootSpeed = 16f;
			item.useAmmo = AmmoID.Arrow;
		}

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
			Projectile.NewProjectile(position.X, position.Y, speedX, speedY, ModContent.ProjectileType<WindWave>(), damage, knockBack, player.whoAmI, 0f, 0f);
			return false;
		}
    }
=======
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Retribution.Items.Weapons.Ranger
{
  public class Windbreaker : ModItem
  {
  public override void SetStaticDefaults()
  {
  DisplayName.SetDefault("Windbreaker");
  Tooltip.SetDefault("A strong and sturdy bow that shoots out a gust of wind.");
  }

  public override void SetDefaults()
  {
  item.damage = 16;
  item.ranged = true;
  item.width = 12;
  item.height = 38;
  item.maxStack = 1;
  item.useTime = 28;
  item.useAnimation = 28;
  item.useStyle = 5;
  item.knockBack = 2;
  item.value = 12000;
  item.rare = 2;
  item.UseSound = SoundID.Item5;
  item.noMelee = true;
  item.shoot = ModContent.ProjectileType<WindWave>();
  item.useAmmo = AmmoID.Arrow;
  item.shootSpeed = 10f;
  item.autoReuse = false;
  }
  }
>>>>>>> 4a1799b94a1a1f71cbc8879896000b727a54cfc0
}