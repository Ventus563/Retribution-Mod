using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Retribution.Projectiles.Minions

{
    public class Avernus : ModProjectile
    {

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Avernus");
        }

        public override void SetDefaults()
        {
            projectile.width = 60;
            projectile.height = 46;
            projectile.hostile = false;
            projectile.friendly = false; 
            projectile.ignoreWater = true; 
            projectile.timeLeft = 900; 
            projectile.penetrate = -1;
            projectile.tileCollide = true;
            projectile.sentry = true;
        }

        public override void Kill(int timeLeft)
        {

            Main.PlaySound(SoundID.Dig, projectile.Center, 62); 

            for (int i = 0; i < 20; i++)
            {
                int dust = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, DustID.Dirt, projectile.velocity.X * 1.2f, projectile.velocity.Y * 1.2f, 120, default(Color));
                Main.dust[dust].velocity *= 2.5f;
            }
        }

        public override void AI()
        {
            int dust = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y - 23), projectile.width, projectile.height, DustID.Fire, projectile.velocity.X * 1.2f, projectile.velocity.Y * 1.2f, 120, default(Color));
            Main.dust[dust].velocity *= 2.5f;
            projectile.ai[0]++;

            if (projectile.ai[0] > 180)
            {
                Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y - 23, -4, -4, ProjectileID.BallofFire, 32, 0, Main.myPlayer);
                Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y - 23, 4, -4, ProjectileID.BallofFire, 32, 0, Main.myPlayer);
                Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y - 23, 2, -2, ProjectileID.BallofFire, 32, 0, Main.myPlayer);
                Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y - 23, -2, -2, ProjectileID.BallofFire, 32, 0, Main.myPlayer);
                Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y - 23, -0.5f, -0.5f, ProjectileID.BallofFire, 32, 0, Main.myPlayer);
                Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y - 23, -0.5f, -0.5f, ProjectileID.BallofFire, 32, 0, Main.myPlayer);


                projectile.ai[0] = 0;
            }
        }
    }
}