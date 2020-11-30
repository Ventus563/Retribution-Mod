using Retribution.Dusts;
using Retribution.Buffs;
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework.Graphics;
using Terraria.Graphics.Shaders;

namespace Retribution.Projectiles
{
	public class slime : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Slime");
			ProjectileID.Sets.TrailCacheLength[projectile.type] = 5;
			ProjectileID.Sets.TrailingMode[projectile.type] = 0;
			Main.projFrames[projectile.type] = 2;
		}

		public override void SetDefaults()
		{
			projectile.width = 32;               //The width of projectile hitbox
			projectile.height = 26;              //The height of projectile hitbox
			projectile.aiStyle = 1;             //The ai style of the projectile, please reference the source code of Terraria
			projectile.friendly = true;         //Can the projectile deal damage to enemies?
			projectile.hostile = false;         //Can the projectile deal damage to the player?
			projectile.ranged = true;           //Is the projectile shoot by a ranged weapon?
			projectile.penetrate = 5;
			projectile.alpha = 150;              //How many monsters the projectile can penetrate. (OnTileCollide below also decrements penetrate for bounces as well)
			projectile.timeLeft = 600;          //The live time for the projectile (60 = 1 second, so 600 is 10 seconds)
			projectile.light = 0.5f;            //How much light emit around the projectile
			projectile.ignoreWater = true;          //Does the projectile's speed be influenced by water?
			projectile.tileCollide = true;          //Can the projectile collide with tiles?
			projectile.extraUpdates = 1;            //Set to above 0 if you want the projectile to update multiple time in a frame
		}

		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			target.AddBuff(BuffID.Slimed, 120);
		}

		public override bool OnTileCollide(Vector2 oldVelocity)
		{
			//If collide with tile, reduce the penetrate.
			//So the projectile can reflect at most 5 times
			projectile.penetrate--;
			if (projectile.penetrate <= 0)
			{
				projectile.Kill();
			}
			else
			{
				Collision.HitTiles(projectile.position + projectile.velocity, projectile.velocity, projectile.width, projectile.height);
				Main.PlaySound(SoundID.Item10, projectile.position);
				if (projectile.velocity.X != oldVelocity.X)
				{
					projectile.velocity.X = -oldVelocity.X;
				}
				if (projectile.velocity.Y != oldVelocity.Y)
				{
					projectile.velocity.Y = -oldVelocity.Y;
				}
			}
			return false;
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
                dust = Main.dust[Terraria.Dust.NewDust(projectile.position, projectile.width, projectile.height, 1, 0f, 0f, 50, new Color(0, 142, 255), 1f)];
                dust.noGravity = true;
                dust.shader = GameShaders.Armor.GetSecondaryShader(91, Main.LocalPlayer);
            }
		}

		public override void AI()
		{
			if (++projectile.frameCounter >= 8)
			{
				projectile.frameCounter = 0;
				if (++projectile.frame >= 2)
				{
					projectile.frame = 0;
				}
			}

			for (int d = 0; d < 1; d++)
			{
				Dust dust;
				dust = Main.dust[Terraria.Dust.NewDust(projectile.position, projectile.width, projectile.height, 124, 0f, 0f, 150, new Color(0, 142, 255), 1f)];
				dust.noGravity = true;
			}
			Lighting.AddLight(projectile.position, 0.1f, 0.1f, 0.9f);
		}
	}
}