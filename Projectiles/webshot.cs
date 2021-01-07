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
	public class webshot : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.width = 12;
			projectile.height = 16;
			projectile.aiStyle = 1;
			projectile.friendly = true;
			projectile.ranged = true;
			projectile.timeLeft = 120;
			projectile.tileCollide = true;
			projectile.friendly = true;
			projectile.penetrate = 1;
			aiType = 1;

		}

		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			target.AddBuff(BuffID.Venom, 300);
		}

        public override void Kill(int timeLeft)
        {
            Main.PlaySound(SoundID.Dig, (int)projectile.position.X, (int)projectile.position.Y);
            Vector2 usePos = projectile.position;


            const int NUM_DUSTS = 20;

            for (int i = 0; i < NUM_DUSTS; i++)
            {
                Dust dust;
                Vector2 position = projectile.position;
                dust = Main.dust[Terraria.Dust.NewDust(position, projectile.width, projectile.height, 31, 0f, 0f, 0, new Color(255, 255, 255), 0.8552632f)];
                dust.noGravity = true;
                dust.noLight = true;
            }
        }

        public override void AI()
		{
            const int NUM_DUSTS = 2;

            for (int i = 0; i < NUM_DUSTS; i++)
            {
                Dust dust;
                Vector2 position = projectile.position;
                dust = Main.dust[Terraria.Dust.NewDust(position, projectile.width, projectile.height, 31, 0f, 0f, 0, new Color(255, 255, 255), 0.8552632f)];
                dust.noGravity = true;
                dust.noLight = true;
            }
        }
	}
}