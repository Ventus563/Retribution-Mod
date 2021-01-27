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

namespace Retribution.NPCs.Bosses.Morbus
{
	public class ichorball: ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Ichor Ball");
		}

		public override void SetDefaults()
		{
			projectile.width = 16;               
			projectile.height = 16;             
			projectile.aiStyle = 1;          
			projectile.friendly = false;       
			projectile.hostile = true;    
			projectile.ranged = true;         
			projectile.penetrate = 10;
			projectile.alpha = 150;             
			projectile.timeLeft = 1000;          
			projectile.light = 0.5f;            
			projectile.ignoreWater = true;         
			projectile.tileCollide = true;         
			projectile.extraUpdates = 2;
		}

        public override void OnHitPlayer(Player target, int damage, bool crit)
        {
			target.AddBuff(BuffID.Ichor, 180);
        }

		public override bool OnTileCollide(Vector2 oldVelocity)
		{
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

            for (int i = 0; i < NUM_DUSTS; i++)
            {
                Dust dust;
                dust = Main.dust[Terraria.Dust.NewDust(projectile.position, projectile.width, projectile.height, 75, 0f, 0f, 50, new Color(255, 196, 33), 1f)];
                dust.noGravity = true;
            }
		}

		public override void AI()
		{
			projectile.netUpdate = true;
			projectile.rotation++;

			projectile.velocity.Y = projectile.velocity.Y + 0.001f;
			if (projectile.velocity.Y > 16f)
			{
				projectile.velocity.Y = 16f;
			}

			Dust dust;
			Vector2 position = projectile.position;
			dust = Main.dust[Terraria.Dust.NewDust(position, 1, 1, 75, 0f, 0f, 0, new Color(235, 186, 52), 2.776316f)];
			dust.noGravity = true;

			Lighting.AddLight(projectile.position, 0.8f, 0.8f, 0f);
		}
	}
}