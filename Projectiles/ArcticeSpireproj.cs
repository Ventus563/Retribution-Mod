using Retribution.Dusts;
using Retribution.Buffs;
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria.Graphics.Shaders;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Retribution.Projectiles
{
	public class ArcticSpireproj : ModProjectile
	{
        public override void SetDefaults()
		{
			projectile.width = 7;
			projectile.height = 7;
			projectile.aiStyle = 0;
			projectile.friendly = true;
			projectile.tileCollide = true;
			projectile.penetrate = 2;
            projectile.alpha = 255;
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(BuffID.Frozen, 60);
        }

        public override void Kill(int timeLeft)
        {
            Main.PlaySound(SoundID.Item27, (int)projectile.position.X, (int)projectile.position.Y);
            Vector2 usePos = projectile.position;

            Vector2 rotVector = (projectile.rotation - MathHelper.ToRadians(90f)).ToRotationVector2();
            usePos += rotVector * 16f;

            const int NUM_DUSTS = 20;

            for (int i = 0; i < NUM_DUSTS; i++)
            {
                Dust dust;
                Vector2 position = projectile.Center;
                dust = Terraria.Dust.NewDustDirect(position, projectile.width, projectile.height, 113, 0f, 0f, 0, new Color(255, 226, 0), 1f);
                dust.noGravity = true;
                dust.shader = GameShaders.Armor.GetSecondaryShader(29, Main.LocalPlayer);

            }
        }

        public override void AI()
        {
            const int NUM_DUSTS = 2;

            for (int i = 0; i < NUM_DUSTS; i++)
            {
                Dust dust;
                Vector2 position = projectile.Center;
                dust = Terraria.Dust.NewDustDirect(position, projectile.width, projectile.height, 113, 0f, 0f, 0, new Color(255, 226, 0), 1f);
                dust.noGravity = true;
                dust.shader = GameShaders.Armor.GetSecondaryShader(29, Main.LocalPlayer);
            }

            Lighting.AddLight(projectile.position, 0.9f, 0.9f, 1f);
        }
    }
}