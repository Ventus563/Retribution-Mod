using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Retribution.Buffs;
using Terraria.ID;

namespace Retribution.NPCs.Bosses.Vanilla
{
	public class SlimeBolt : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Slime Bolt");
		}

		public override void SetDefaults()
		{
			projectile.width = 10;
			projectile.height = 10;
			projectile.aiStyle = -1;
			projectile.hostile = true;
			projectile.tileCollide = false;
			projectile.penetrate = -1;
			projectile.alpha = 100;
			projectile.timeLeft = 120;
			aiType = 0;
		}

		public override void OnHitPlayer(Player target, int damage, bool crit)
		{
			target.AddBuff(BuffID.Slimed, 120);
		}

		public override void Kill(int timeLeft)
		{
			Main.PlaySound(SoundID.Item17, (int)projectile.position.X, (int)projectile.position.Y);

			for (int i = 0; i < 10; i++)
			{
				int num = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, DustID.t_Slime, projectile.velocity.X * 0.2f, projectile.velocity.Y * 0.2f, 100, new Color(133, 196, 255), 2f);
				Main.dust[num].noGravity = true;
			}
		}

        public override void AI()
        {
			int i = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, DustID.t_Slime, projectile.velocity.X * 0.2f, projectile.velocity.Y * 0.2f, 100, new Color(133, 196, 255));
			Main.dust[i].noGravity = true;
		}
	}
}
