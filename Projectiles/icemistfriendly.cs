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
	public class icemistfriendly : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.width = 92;
			projectile.height = 102;
			projectile.aiStyle = 0;
			projectile.friendly = true;
			projectile.hostile = false;
			projectile.ranged = true;
			projectile.timeLeft = 60;
			projectile.tileCollide = false;
			projectile.penetrate = -1;
			aiType = 0;

		}

		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			target.AddBuff(BuffID.Bleeding, 3);
		}

        public override void Kill(int timeLeft)
        {
			int i = Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, 0, 0, ProjectileID.CultistBossIceMist, 10, 0f, Main.myPlayer);

			Main.projectile[i].hostile = false;
			Main.projectile[i].friendly = true;

			Main.PlaySound(SoundID.Item27, (int)projectile.position.X, (int)projectile.position.Y);
			Vector2 usePos = projectile.position;
		}

		public override void AI()
		{
			projectile.rotation += 0.2f;

			Dust dust;
			Vector2 position = projectile.position;
			dust = Main.dust[Terraria.Dust.NewDust(position, projectile.width, projectile.height, 185, 0f, 0f, 0, new Color(255, 255, 255), 1)];
			dust.noGravity = true;
			dust.noLight = true;
			//dust.shader = GameShaders.Armor.GetSecondaryShader(30, Main.LocalPlayer);

			Lighting.AddLight(projectile.position, 0f, 0.93f, 0.93f);
		}
	}
}