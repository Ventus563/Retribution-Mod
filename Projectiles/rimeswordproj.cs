using Retribution.Dusts;
using Retribution.Buffs;
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Graphics.Shaders;

namespace Retribution.Projectiles
{
	public class rimeswordproj : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.width = 10;
			projectile.height = 10;
			projectile.alpha = 150;
			projectile.aiStyle = 0;
			projectile.friendly = true;
			projectile.tileCollide = true;
			projectile.ignoreWater = false;
			projectile.friendly = true;
			projectile.penetrate = 3;

		}

        public override void AI()
        {
			Dust dust;
			Dust dust2;
			Vector2 position = projectile.Center;
			dust = Main.dust[Terraria.Dust.NewDust(position, projectile.width, projectile.height, 253, -1f, 0f, 0, new Color(255, 255, 255), 1)];
			dust2 = Main.dust[Terraria.Dust.NewDust(position, projectile.width, projectile.height, 253, 1f, 0f, 0, new Color(255, 255, 255), 1)];
			dust.noGravity = true;
			dust.noLight = true;
			dust2.noGravity = true;
			dust2.noLight = true;

			Lighting.AddLight(projectile.position, 0f, 0.75f, 1.1f);

			projectile.spriteDirection = projectile.direction;


			projectile.rotation = projectile.velocity.ToRotation() + MathHelper.PiOver2;
		}

		public override void Kill(int timeLeft)
		{
			Main.PlaySound(SoundID.Item27, (int)projectile.position.X, (int)projectile.position.Y);
			Vector2 usePos = projectile.position;

			const int NUM_DUSTS = 20;

			// Spawn some dusts upon javelin death
			for (int i = 0; i < NUM_DUSTS; i++)
			{
				Dust dust;
				dust = Main.dust[Terraria.Dust.NewDust(projectile.Center, 5, 5, 253, 0f, 0f, 0, new Color(255, 255, 255), 1)];
				dust.noGravity = true;
				dust.noLight = true;
			}
		}
	}
}
