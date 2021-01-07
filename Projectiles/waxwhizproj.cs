using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace Retribution.Projectiles
{
	public class waxwhizproj : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			ProjectileID.Sets.YoyosLifeTimeMultiplier[projectile.type] = 8.5f;
			ProjectileID.Sets.YoyosMaximumRange[projectile.type] = 500f;
			ProjectileID.Sets.YoyosTopSpeed[projectile.type] = 18f;
		}

		public override void SetDefaults()
		{
			projectile.extraUpdates = 0;
			projectile.width = 16;
			projectile.height = 16;

			projectile.aiStyle = 99;
			projectile.friendly = true;
			projectile.penetrate = -1;
			projectile.melee = true;
			projectile.scale = 1f;
		}

		public override void PostAI()
		{
			if (Main.rand.NextBool())
			{
				Dust dust = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 153);
				dust.noGravity = true;
				dust.scale = 1.6f;
			}
		}
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
			target.AddBuff(BuffID.Poisoned, 5);

			Projectile.NewProjectile(projectile.position.X, projectile.position.Y, 1, 1,ProjectileID.Bee, Main.rand.Next(5, 8), 0, Main.myPlayer);
		}
	}
}