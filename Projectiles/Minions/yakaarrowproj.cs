using Retribution.Dusts;
using Retribution.Buffs;
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Graphics.Shaders;

namespace Retribution.Projectiles.Minions
{
	public class yakaarrowproj : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Yaka Arrow");
		}

		public sealed override void SetDefaults()
		{
			projectile.width = 14;
			projectile.height = 48;
			/*projectile.tileCollide = false;
			projectile.friendly = true;
			projectile.minion = true;
			projectile.minionSlots = 1f;
			projectile.penetrate = -1;*/
			projectile.CloneDefaults(ProjectileID.Retanimini);
		}
	}
}