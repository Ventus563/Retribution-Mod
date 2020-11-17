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
	public class shadowball : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Shadowball");
			Main.projFrames[projectile.type] = 4;
		}
		public override void SetDefaults()
		{
			projectile.width = 40;
			projectile.height = 42;
			projectile.aiStyle = 0;
			projectile.friendly = true;
			projectile.ranged = true;
			projectile.timeLeft = 150;
			projectile.tileCollide = false;
			projectile.friendly = true;
			projectile.penetrate = -1;
			aiType = 21;

		}

		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			target.AddBuff(BuffID.Venom, 3);
		}

		public override void AI()
		{

			if (projectile.timeLeft < 10)
			{
				projectile.alpha += 255 / 20;
			}

			#region AI Style
			Player player = Main.player[projectile.owner];

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
						distance = 3f / distance;
						shootToX *= distance * 5;
						shootToY *= distance * 5;
						int proj = Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, shootToX, shootToY, ProjectileID.AmethystBolt, projectile.damage, projectile.knockBack, Main.myPlayer, 0f, 0f);
						Main.projectile[proj].timeLeft = 300;
						Main.projectile[proj].netUpdate = true;
						projectile.netUpdate = true;
						projectile.ai[0] = -50f;
					}
				}
			}

			projectile.ai[0] += 1f;
            #endregion

			#region Animation and visuals
			// So it will lean slightly towards the direction it's moving
			projectile.rotation = projectile.velocity.X * 0.05f;

			// This is a simple "loop through all frames from top to bottom" animation
			int frameSpeed = 3;
			projectile.frameCounter++;
			if (projectile.frameCounter >= frameSpeed)
			{
				projectile.frameCounter = 0;
				projectile.frame++;
				if (projectile.frame >= Main.projFrames[projectile.type])
				{
					projectile.frame = 0;
				}
			}

			// Some visuals here
			Lighting.AddLight(projectile.Center, Color.Purple.ToVector3() * 0.98f);
			#endregion
		}
	}
}