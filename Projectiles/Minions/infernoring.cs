using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Retribution.Projectiles.Minions

{
    public class infernoring : ModProjectile
    {

        public override void SetDefaults()
        {

            projectile.width = 180;
            projectile.height = 180;
            projectile.hostile = false;
            projectile.friendly = false;
            projectile.ignoreWater = true;
            Main.projFrames[projectile.type] = 1;
            projectile.penetrate = -1;
            projectile.tileCollide = false;
            projectile.sentry = true;
            ProjectileID.Sets.MinionTargettingFeature[projectile.type] = false;

        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Holy Ring");

        }

        public override void AI()
        {

            for (int i = 0; i < 1; i++)
            {
                int dust = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 169, projectile.velocity.X * 1.2f, projectile.velocity.Y * 1.2f, 120, default(Color), 1.50f);   //this make so when this projectile is active has dust around , change PinkPlame to what dust you want from Terraria, or add mod.DustType("CustomDustName") for your custom dust
                Main.dust[dust].noGravity = true; //this make so the dust is effected by gravity
                Main.dust[dust].velocity *= 0.9f;
            }


            projectile.rotation += 0.1f;

            for (int i = 0; i < 200; i++)
            {
                NPC target = Main.npc[i];

                float shootToX = target.position.X + target.width * 0.5f - projectile.Center.X;
                float shootToY = target.position.Y + target.height * 0.5f - projectile.Center.Y;
                float distance = (float)Math.Sqrt(shootToX * shootToX + shootToY * shootToY);

                if (distance < 1000f && !target.friendly && target.active)
                {
                    if (projectile.ai[0] > 1.5f) // Time in (60 = 1 second) 
                    {

                        distance = 1.6f / distance;

                        shootToX *= distance * 3;
                        shootToY *= distance * 3;
                        int damage = 1000;
                        int knockback = 4;
                        Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, shootToX, shootToY, ProjectileID.ChlorophyteBullet, damage, 0, Main.myPlayer, 0f, 0f);
                        projectile.ai[0] = 0f;
                    }
                }
            }
            projectile.ai[0] += 1f;
        }
    }
}