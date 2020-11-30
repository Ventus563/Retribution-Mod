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
	public class heart : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Heart");
		}
		public override void SetDefaults()
		{
			projectile.width = 20;
			projectile.height = 20;
			projectile.aiStyle = 1;
			projectile.friendly = true;
			projectile.tileCollide = true;
			projectile.friendly = true;
			projectile.penetrate = -1;
			projectile.light = 0.5f;

		}

		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			target.AddBuff(BuffID.Lovestruck, 60);
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
				dust = Main.dust[Terraria.Dust.NewDust(projectile.position, projectile.width, projectile.height, 1, 0f, 0f, 0, new Color(255, 0, 201), 1f)];
				dust.noGravity = true;
				dust.shader = GameShaders.Armor.GetSecondaryShader(91, Main.LocalPlayer);
			}
		} 

		public override void AI()
		{
			for (int d = 0; d < 4; d++)
			{
				Dust dust;
				dust = Main.dust[Terraria.Dust.NewDust(projectile.position, projectile.width, projectile.height, 124, 0f, 0f, 0, new Color(255, 0, 201), 1f)];
				dust.noGravity = true;
			}

			Lighting.AddLight(projectile.Center, 0.9f, 0.1f, 0.3f);
		}
	}
}