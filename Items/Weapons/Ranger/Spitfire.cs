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
using Microsoft.Xna.Framework.Graphics;

namespace Retribution.Items.Weapons.Ranger
{
	public class Spitfire : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Spitfire");
			Tooltip.SetDefault("A peculiar gun, seems to be made out of bones.\nTurns bullets into fireballs");
		}

		public override void SetDefaults()
		{
			item.damage = 20;
			item.ranged = true;
			item.width = 62;
			item.height = 28;
			item.useTime = 20;
			item.useAnimation = 20;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.noMelee = true;
			item.knockBack = 15;
			item.value = 10000;
			item.rare = ItemRarityID.Orange;
			item.UseSound = SoundID.Item7;
			item.autoReuse = true;
			item.shoot = 10;
			item.shootSpeed = 15f;
			item.useAmmo = AmmoID.Bullet;
		}

        public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
        {
			target.AddBuff(BuffID.OnFire, 180);
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			int i = Projectile.NewProjectile(position.X, position.Y, speedX, speedY, ProjectileID.DD2BetsyFireball, damage, knockBack, player.whoAmI, 0f, 0f);
			Main.projectile[i].hostile = false;
			Main.projectile[i].friendly = true;

			return false;
		}
	}
}