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
	public class cursedspit : ModProjectile
	{
        public override void SetStaticDefaults()
        {
			DisplayName.SetDefault("Cursed Spit");
        }

        public override void SetDefaults()
		{
			projectile.width = 20;
			projectile.height = 20;
			projectile.alpha = 255;
			projectile.aiStyle = 1;
			projectile.friendly = true;
			projectile.tileCollide = false;
			projectile.friendly = false;
			projectile.hostile = true;
			projectile.penetrate = 10;
			projectile.extraUpdates = 2;
		}

        public override void AI()
        {
			Dust dust;
			Vector2 position = projectile.position;
			dust = Main.dust[Terraria.Dust.NewDust(position, 1, 1, 75, 0f, 0f, 0, new Color(0, 217, 255), 2.776316f)];
			dust.noGravity = true;
		}
	}
}
