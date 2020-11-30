using Retribution.Dusts;
using Retribution.Buffs;
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Retribution.Projectiles
{
	public class bow : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Magic Bow");
		}
		public override void SetDefaults()
		{
			projectile.width = 16;
			projectile.height = 32;
			projectile.aiStyle = 0;
			projectile.friendly = true;
			projectile.ranged = true;
			projectile.timeLeft = 300;
			projectile.tileCollide = true;
			projectile.penetrate = 1;
		}

		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			target.AddBuff(BuffID.Bleeding, 3);
		}

		public override void Kill(int timeLeft)
		{
			Main.PlaySound(SoundID.Dig, (int)projectile.position.X, (int)projectile.position.Y);
			Vector2 usePos = projectile.position;

			const int NUM_DUSTS = 20;

			for (int i = 0; i < NUM_DUSTS; i++)
			{
				Dust dust;
				Vector2 position = projectile.Center;
				dust = Main.dust[Terraria.Dust.NewDust(position, 30, 30, 7, 0f, 0f, 0, new Color(255, 255, 255), 1f)];
				dust.noGravity = true;
			}
		}

		public override void AI()
		{
			Player player = Main.player[projectile.owner];

			projectile.rotation += 0.2f;

			for (int i = 0; i < 200; i++)
			{
				NPC target = Main.npc[i];
				float shootToX = target.position.X + (float)target.width * 0.5f - projectile.Center.X;
				float shootToY = target.position.Y - projectile.Center.Y;
				float distance = (float)System.Math.Sqrt((double)(shootToX * shootToX + shootToY * shootToY));
				if (distance < 480f && !target.friendly && target.active)
				{
					if (projectile.ai[0] > 10f)
					{
						const int NUM_DUSTS = 15;

						for (int j = 0; j < NUM_DUSTS; j++)
						{
							Dust dust;
							Vector2 position = projectile.Center;
							dust = Main.dust[Terraria.Dust.NewDust(position, 30, 30, 7, 0f, 0f, 0, new Color(255, 255, 255), 1f)];
							dust.noGravity = true;
						}

						distance = 3f / distance;
						shootToX *= distance * 5;
						shootToY *= distance * 5;
						int proj = Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, shootToX, shootToY, ModContent.ProjectileType<arrow>(), 14, projectile.knockBack, Main.myPlayer, 0f, 0f);
						Main.projectile[proj].timeLeft = 300;
						Main.projectile[proj].netUpdate = true;
						projectile.netUpdate = true;
						Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 5);
						projectile.ai[0] = -50f;
					}
				}
			}
			projectile.ai[0] += 1f;
		}
	}
}