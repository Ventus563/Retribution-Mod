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
	public class miniblade : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Miniblade");
		}
		public override void SetDefaults()
		{
			projectile.width = 28;
			projectile.height = 15;
			projectile.alpha = 255;
			projectile.aiStyle = 0;
			projectile.friendly = true;
			projectile.tileCollide = true;
			projectile.friendly = true;
			projectile.penetrate = 1;

		}

        public override void AI()
        {
			Dust dust;
			Vector2 position = projectile.Center;
			dust = Terraria.Dust.NewDustPerfect(position, 77, new Vector2(0f, 0f), 157, new Color(255, 255, 255), 1f);
			dust.noGravity = true;
			dust.shader = GameShaders.Armor.GetSecondaryShader(19, Main.LocalPlayer);

		}

		public override void Kill(int timeLeft)
		{
			Main.PlaySound(SoundID.Dig, (int)projectile.position.X, (int)projectile.position.Y);
			Vector2 usePos = projectile.position;

			Vector2 rotVector = (projectile.rotation - MathHelper.ToRadians(90f)).ToRotationVector2();
			usePos += rotVector * 16f;

			const int NUM_DUSTS = 20;

			// Spawn some dusts upon javelin death
			for (int i = 0; i < NUM_DUSTS; i++)
			{
				Dust dust;
				dust = Main.dust[Terraria.Dust.NewDust(projectile.position, projectile.width, projectile.height, 1, 0f, 0f, 0, new Color(255, 255, 255), 0.65f)];
				dust.noGravity = true;
				dust.noLight = true;
			}
		}
	}
}
