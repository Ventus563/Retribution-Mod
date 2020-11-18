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
	public class snapshotproj : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.width = 640;
			projectile.height = 635;
			projectile.aiStyle = 0;
			projectile.friendly = true;
			projectile.ranged = true;
			projectile.timeLeft = 20;
			projectile.tileCollide = false;
			projectile.friendly = true;
			projectile.penetrate = -1;

		}

		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			target.AddBuff(BuffID.BrokenArmor, 5);
		}

		public override void AI()
		{

			if (projectile.timeLeft < 18)
			{
				projectile.alpha += 255 / 20;
			}
		}
	}
}