using Retribution.Projectiles;
using Retribution.Items.Souls;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace Retribution.Items.Weapons.Ranger
{
	public class Wildthorn : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Wildthorn");
		}

		public override void SetDefaults()
		{
			item.damage = 6;
			item.ranged = true;
			item.width = 70;
			item.height = 20;
			item.useTime = 10;
			item.useAnimation = 10;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.noMelee = true;
			item.knockBack = 4;
			item.value = 80000;
			item.rare = 0;
			item.UseSound = SoundID.Item11;
			item.autoReuse = true;
			item.shoot = 10;
			item.shootSpeed = 17f;
			item.useAmmo = AmmoID.Bullet;
		}

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
			if (Main.rand.NextFloat() < .05f)
			{
				Projectile.NewProjectile(position.X, position.Y, speedX, speedY, ModContent.ProjectileType<thorn>(), 25, 0f, Main.myPlayer);
				Main.PlaySound(SoundID.Item7, player.position);
				return false;
			}
			else
			{
				return true;
			}
		}
    }

	public class thorn : ModProjectile
	{

		public override void SetDefaults()
		{
			projectile.width = 5;
			projectile.height = 5;
			projectile.aiStyle = 0;
			projectile.friendly = true;
			projectile.tileCollide = true;
			projectile.penetrate = 1;
			projectile.alpha = 255;
			projectile.extraUpdates = 2;
		}

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
			target.AddBuff(BuffID.Poisoned, 180);
        }

        public override void AI()
		{
			Dust dust;
			Vector2 position = projectile.position;
			dust = Terraria.Dust.NewDustPerfect(position, 46, new Vector2(0f, 0f), 0, new Color(255, 255, 255), 1f);
			dust.noGravity = true;

			Dust dust2;
			Vector2 position2 = projectile.position;
			dust2 = Terraria.Dust.NewDustPerfect(position, 128, new Vector2(0f, 0f), 0, new Color(255, 255, 255), 1f);
			dust2.noGravity = true;
		}
	}
}
