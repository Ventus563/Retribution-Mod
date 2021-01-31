using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Retribution.NPCs.Bosses.Silva
{
	public class SilvaAttach : ModProjectile
	{

		public override void SetDefaults()
		{
			base.projectile.width = 50;
			base.projectile.height = 50;
			base.projectile.aiStyle = 0;
			base.projectile.alpha = 100;
			base.projectile.penetrate = -1;
			base.projectile.tileCollide = false;
			base.projectile.timeLeft = 60;
		}

		public override void AI()
		{
			Player player = Main.player[base.projectile.owner];
			base.projectile.ai[1] += 1f;
			if (base.projectile.timeLeft < 40)
			{
				if (base.projectile.ai[1] > 10f)
				{
					float num2 = 15f;
					int num3 = 0;
					while ((float)num3 < num2)
					{
						Vector2 vector = Vector2.UnitX * 0f;
						vector += -Utils.RotatedBy(Vector2.UnitY, (double)((float)num3 * (6.28318548f / num2)), default(Vector2)) * new Vector2(20f, 8f);
						vector = Utils.RotatedBy(vector, (double)Utils.ToRotation(base.projectile.velocity), default(Vector2));
						int num4 = Dust.NewDust(base.projectile.Center, 0, 0, 22, 0f, 0f, 0, default(Color), 1f);
						Main.dust[num4].noGravity = true;
						Main.dust[num4].position = base.projectile.Center + vector;
						Main.dust[num4].velocity = base.projectile.velocity * 0f + Utils.SafeNormalize(vector, Vector2.UnitY) * 0f;
						num3++;
					}
				}
			}
			else if (base.projectile.timeLeft < 60)
			{
				if (base.projectile.ai[1] > 20f)
				{
					float num5 = 15f;
					int num6 = 0;
					while ((float)num6 < num5)
					{
						Vector2 vector2 = Vector2.UnitX * 0f;
						vector2 += -Utils.RotatedBy(Vector2.UnitY, (double)((float)num6 * (6.28318548f / num5)), default(Vector2)) * new Vector2(20f, 8f);
						vector2 = Utils.RotatedBy(vector2, (double)Utils.ToRotation(base.projectile.velocity), default(Vector2));
						int num7 = Dust.NewDust(base.projectile.Center, 0, 0, 22, 0f, 0f, 0, default(Color), 1f);
						Main.dust[num7].noGravity = true;
						Main.dust[num7].position = base.projectile.Center + vector2;
						Main.dust[num7].velocity = base.projectile.velocity * 0f + Utils.SafeNormalize(vector2, Vector2.UnitY) * 0f;
						num6++;
					}
				}
			}
			else if (base.projectile.timeLeft < 60 && base.projectile.ai[1] > 30f)
			{
				float num8 = 15f;
				int num9 = 0;
				while ((float)num9 < num8)
				{
					Vector2 vector3 = Vector2.UnitX * 0f;
					vector3 += -Utils.RotatedBy(Vector2.UnitY, (double)((float)num9 * (6.28318548f / num8)), default(Vector2)) * new Vector2(20f, 8f);
					vector3 = Utils.RotatedBy(vector3, (double)Utils.ToRotation(base.projectile.velocity), default(Vector2));
					int num10 = Dust.NewDust(base.projectile.Center, 0, 0, 22, 0f, 0f, 0, default(Color), 1f);
					Main.dust[num10].noGravity = true;
					Main.dust[num10].position = base.projectile.Center + vector3;
					Main.dust[num10].velocity = base.projectile.velocity * 0f + Utils.SafeNormalize(vector3, Vector2.UnitY) * 0f;
					num9++;
				}
			}
			if (base.projectile.timeLeft > 50)
			{
				base.projectile.position.X = player.Center.X - 25f;
				base.projectile.position.Y = player.Center.Y - 25f + 50f;
			}
			if (base.projectile.timeLeft == 5)
			{
				Main.PlaySound(SoundID.Item18, (int)base.projectile.position.X, (int)base.projectile.position.Y);
				Projectile.NewProjectile(base.projectile.Center.X, base.projectile.Center.Y - 10f, 0f, -7f, ModContent.ProjectileType<SharpenedBranch>(), 10, 0f, 0, 0f, 0f);
			}
		}
	}
}
