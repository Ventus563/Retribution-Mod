using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Retribution.Buffs;

namespace Retribution.NPCs.Bosses.Tesca
{
	public class TescanHome : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Tescan Spike");
			ProjectileID.Sets.TrailCacheLength[projectile.type] = 5;
			ProjectileID.Sets.TrailingMode[projectile.type] = 0;
		}

		public override void SetDefaults()
		{
			projectile.width = 8;
			projectile.height = 8;
			projectile.aiStyle = 1;
			projectile.alpha = 255;
			projectile.hostile = true;
			projectile.ignoreWater = true;
			projectile.tileCollide = false;
			projectile.penetrate = 1;
			projectile.timeLeft = 150;
			aiType = 0;
		}

		public override void OnHitPlayer(Player target, int damage, bool crit)
		{
			if (RetributionWorld.nightmareMode == true)
			{
				target.AddBuff(ModContent.BuffType<TerrariasFrost>(), 60);
			}
			else
			{
				target.AddBuff(BuffID.Frostburn, 180);
			}
		}

		public override void AI()
		{
			if (projectile.timeLeft == 140)
			{
				float num = 30f;
				int num2 = 0;
				while ((float)num2 < num)
				{
					Vector2 vector = Vector2.UnitX * 0f;
					vector += -Utils.RotatedBy(Vector2.UnitY, (double)((float)num2 * (6.28318548f / num)), default(Vector2)) * new Vector2(6f, 16f);
					vector = Utils.RotatedBy(vector, (double)Utils.ToRotation(projectile.velocity), default(Vector2));
					int num3 = Dust.NewDust(projectile.Center, 0, 0, 185, 0f, 0f, 0, default(Color), 1.25f);
					Main.dust[num3].noGravity = true;
					Main.dust[num3].position = projectile.Center + vector;
					Main.dust[num3].velocity = projectile.velocity * 0f + Utils.SafeNormalize(vector, Vector2.UnitY) * 1f;
					num2++;
				}
			}
			if (projectile.timeLeft < 140)
			{
				for (int i = 0; i < 3; i++)
				{
					float num4 = projectile.velocity.X / 3f * (float)i;
					float num5 = projectile.velocity.Y / 3f * (float)i;
					int num6 = Dust.NewDust(projectile.position, projectile.width, projectile.height, 185, 0f, 0f, 0, default(Color), 1f);
					Main.dust[num6].position.X = projectile.Center.X - num4;
					Main.dust[num6].position.Y = projectile.Center.Y - num5;
					Main.dust[num6].noGravity = true;
					Main.dust[num6].velocity *= 0f;
				}
			}
			if (projectile.timeLeft < 140)
			{
				projectile.alpha = 50;
			}
			float num7 = projectile.Center.X;
			float num8 = projectile.Center.Y;
			float range = 1000f;
			bool flag = false;
			int num13;
			for (int j = 0; j < 200; j = num13 + 1)
			{
				if (projectile.Distance(Main.player[j].Center) < range && Collision.CanHit(projectile.Center, 1, 1, Main.player[j].Center, 1, 1))
				{
					float num10 = Main.player[j].position.X + (float)(Main.player[j].width / 2);
					float num11 = Main.player[j].position.Y + (float)(Main.player[j].height / 2);
					float num12 = Math.Abs(projectile.position.X + (float)(projectile.width / 2) - num10) + Math.Abs(projectile.position.Y + (float)(projectile.height / 2) - num11);
					if (num12 < range)
					{
						range = num12;
						num7 = num10;
						num8 = num11;
						flag = true;
					}
				}
				num13 = j;
			}
			if (flag)
			{
				float speed = 9f;
				Vector2 vector2 = new Vector2(projectile.position.X + (float)projectile.width * 0.5f, projectile.position.Y + (float)projectile.height * 0.5f);
				float num15 = num7 - vector2.X;
				float num16 = num8 - vector2.Y;
				float num17 = (float)Math.Sqrt((double)(num15 * num15 + num16 * num16));
				num17 = speed / num17;
				num15 *= num17;
				num16 *= num17;
				projectile.velocity.X = (projectile.velocity.X * 20f + num15) / 21f;
				projectile.velocity.Y = (projectile.velocity.Y * 20f + num16) / 21f;
			}
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
	}
}
