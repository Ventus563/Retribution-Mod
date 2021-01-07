using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Graphics.Shaders;

namespace Retribution.Projectiles
{
	public class frostfirebullet : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Frostfire Bullet");
			ProjectileID.Sets.TrailCacheLength[projectile.type] = 5;
			ProjectileID.Sets.TrailingMode[projectile.type] = 0;
		}

		public override void SetDefaults()
		{
			projectile.width = 10;
			projectile.height = 18;
			projectile.aiStyle = 1;
			projectile.friendly = true;
			projectile.hostile = false;
			projectile.ranged = true;
			projectile.penetrate = 3;
			projectile.timeLeft = 600;
			projectile.alpha = 255;
			projectile.light = 0.5f;
			projectile.ignoreWater = true;
			projectile.tileCollide = true;
			aiType = ProjectileID.Bullet;
		}

		public override bool OnTileCollide(Vector2 oldVelocity)
		{
			projectile.penetrate--;
			if (projectile.penetrate <= 0)
			{
				projectile.Kill();
			}
			else
			{
				Collision.HitTiles(projectile.position + projectile.velocity, projectile.velocity, projectile.width, projectile.height);
				Main.PlaySound(SoundID.Item10, projectile.position);
				if (projectile.velocity.X != oldVelocity.X)
				{
					projectile.velocity.X = -oldVelocity.X;
				}
				if (projectile.velocity.Y != oldVelocity.Y)
				{
					projectile.velocity.Y = -oldVelocity.Y;
				}
			}
			return false;
		}

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
			target.AddBuff(BuffID.OnFire, 120);
			target.AddBuff(BuffID.Frostburn, 120);

		}

		public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
		{
			Vector2 drawOrigin = new Vector2(Main.projectileTexture[projectile.type].Width * 0.5f, projectile.height * 0.5f);
			for (int k = 0; k < projectile.oldPos.Length; k++)
			{
				Vector2 drawPos = projectile.oldPos[k] - Main.screenPosition + drawOrigin + new Vector2(0f, projectile.gfxOffY);
				Color color = projectile.GetAlpha(lightColor) * ((float)(projectile.oldPos.Length - k) / (float)projectile.oldPos.Length);
				spriteBatch.Draw(Main.projectileTexture[projectile.type], drawPos, null, color, projectile.rotation, drawOrigin, projectile.scale, SpriteEffects.None, 0f);
			}
			return true;
		}

		public override void Kill(int timeLeft)
		{
			Collision.HitTiles(projectile.position + projectile.velocity, projectile.velocity, projectile.width, projectile.height);
			Main.PlaySound(SoundID.Item10, projectile.position);

			const int NUM_DUSTS = 10;

			for (int i = 0; i < NUM_DUSTS; i++)
			{
				Dust dust;
				Vector2 position = projectile.Center;
				dust = Main.dust[Terraria.Dust.NewDust(projectile.position, projectile.width, projectile.height, DustID.Fire, 0f, 0f, 0, new Color(255, 255, 255), 1.710526f)];
			}

			const int NUM_DUSTS2 = 10;

			for (int i = 0; i < NUM_DUSTS2; i++)
			{
				Dust dust;
				Vector2 position = projectile.Center;
				dust = Main.dust[Terraria.Dust.NewDust(projectile.position, projectile.width, projectile.height, 135, 0f, 0f, 0, new Color(255, 255, 255), 1.710526f)];
			}
		}

        public override void AI()
        {
			Dust dust;
			Vector2 position = projectile.Center;
			dust = Terraria.Dust.NewDustPerfect(position, DustID.Fire, new Vector2(0f, 0f), 0, new Color(255, 0, 75), 1.578947f);
			dust.noGravity = true;
			dust = Main.dust[Terraria.Dust.NewDust(projectile.position, projectile.width, projectile.height, 135, 0f, 0f, 0, new Color(255, 255, 255), 1.710526f)];
			dust.noGravity = true;
		}
	}
}