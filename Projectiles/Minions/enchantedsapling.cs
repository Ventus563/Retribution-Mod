using Retribution.Dusts;
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Retribution.Projectiles.Minions
{
	public class enchantedsapling : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Enchanted Sapling");
			Main.projFrames[projectile.type] = 5;
			Main.projPet[projectile.type] = true;
			ProjectileID.Sets.MinionSacrificable[projectile.type] = true;
			ProjectileID.Sets.Homing[projectile.type] = true;
			ProjectileID.Sets.MinionTargettingFeature[projectile.type] = false;
		}

		public override void SetDefaults()
		{
			projectile.netImportant = true;
			projectile.width = 58;
			projectile.height = 174;
			projectile.friendly = true;
			projectile.minion = true;
			projectile.minionSlots = 1;
			projectile.penetrate = -1;
			projectile.timeLeft = 18000;
			projectile.tileCollide = false;
			projectile.ignoreWater = true;
			projectile.CloneDefaults(ProjectileID.FlyingImp);
		}

		/*public override void CheckActive()
		{
			Player player = Main.player[projectile.owner];
			ExamplePlayer modPlayer = player.GetModPlayer<ExamplePlayer>();
			if (player.dead)
			{
				modPlayer.purityMinion = false;
			}
			if (modPlayer.purityMinion)
			{ // Make sure you are resetting this bool in ModPlayer.ResetEffects. See ExamplePlayer.ResetEffects
				projectile.timeLeft = 2;
			}
		}*/

		public override void AI()
		{
			for (int i = 0; i < 200; i++)
			{
				NPC target = Main.npc[i];

				float shootToX = target.position.X + target.width * 0.5f - projectile.Center.X;
				float shootToY = target.position.Y + target.height * 0.5f - projectile.Center.Y;
				float distance = (float)Math.Sqrt(shootToX * shootToX + shootToY * shootToY);

				if (distance < 1000f && !target.friendly && target.active)
				{
					if (projectile.ai[0] > 20f) // Time in (60 = 1 second) 
					{

						distance = 1.6f / distance;

						shootToX *= distance * 3;
						shootToY *= distance * 3;
						int damage = 32;
						int knockback = 4;
						Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, shootToX, shootToY, ProjectileID.ChlorophyteBullet, damage, 0, Main.myPlayer, 0f, 0f);

						for (int d = 0; d < 10; d++)
						{
							Dust.NewDust(projectile.position, projectile.width, projectile.height, 256, 0f, 0f, 150, default, 1.5f);
						}
						projectile.ai[0] = 0f;
					}
				}
			}
			projectile.ai[0] += 1f;

			int frameSpeed = 15;
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
		}
	}
}