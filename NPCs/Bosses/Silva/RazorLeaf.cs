using Retribution.Dusts;
using Retribution.Buffs;
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria.Graphics.Shaders;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework.Graphics;

namespace Retribution.NPCs.Bosses.Silva
{
	public class RazorLeaf : ModProjectile
	{
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Razor Leaf");
            Main.projFrames[projectile.type] = 6;
        }

        public override void SetDefaults()
		{
			projectile.width = 10;
			projectile.height = 15;
			projectile.aiStyle = 0;
			projectile.friendly = false;
            projectile.hostile = true;
            projectile.tileCollide = true;
			projectile.timeLeft = 500;
			projectile.penetrate = 100;
            projectile.extraUpdates = 3;
		}

        public override void AI()
        {
            projectile.rotation = projectile.velocity.ToRotation() + MathHelper.PiOver2;


            int frameSpeed = 25;
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

            projectile.ai[0] += 1;

            if (projectile.ai[0] == 120 && Main.netMode != 1)
            {
                Player target = Main.LocalPlayer;
                float shootToX = target.position.X + (float)target.width * 0.5f - projectile.Center.X;
                float shootToY = target.position.Y - projectile.Center.Y;
                float distance = (float)System.Math.Sqrt((double)(shootToX * shootToX + shootToY * shootToY));

                distance = 3f / distance;
                shootToX *= distance * 1;
                shootToY *= distance * 1;

                Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, shootToX, shootToY, ModContent.ProjectileType<RazorLeaf2>(), 10, 0f, Main.myPlayer, 0f, 0f);

                projectile.netUpdate = true;
                projectile.ai[0] = 121;
                projectile.timeLeft = 0;
            }
        }
    }
}