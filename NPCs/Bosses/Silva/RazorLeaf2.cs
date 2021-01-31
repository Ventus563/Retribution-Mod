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
	public class RazorLeaf2 : ModProjectile
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

        public override void Kill(int timeLeft)
        {
            Main.PlaySound(SoundID.Dig, (int)projectile.position.X, (int)projectile.position.Y);
            Vector2 usePos = projectile.position;

            Vector2 rotVector = (projectile.rotation - MathHelper.ToRadians(90f)).ToRotationVector2();
            usePos += rotVector * 16f;

            const int NUM_DUSTS = 20;

            for (int i = 0; i < NUM_DUSTS; i++)
            {
                Dust dust;
                dust = Main.dust[Terraria.Dust.NewDust(projectile.Center, projectile.width, projectile.height, 3, 0f, 0f, 0, new Color(150, 200, 200), 2.5f)];
                dust.noGravity = true;
            }
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
        }
    }
}