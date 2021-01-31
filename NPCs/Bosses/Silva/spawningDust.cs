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

namespace Retribution.NPCs.Bosses.Silva
{
	public class spawningDust : ModProjectile
	{

		public override void SetDefaults()
		{
			projectile.width = 16;               
			projectile.height = 16;             
			projectile.aiStyle = 0;                   
			projectile.penetrate = -1;
			projectile.alpha = 255;             
			projectile.timeLeft = 1000;
			projectile.ignoreWater = true;         
			projectile.tileCollide = false;
			projectile.extraUpdates = 2;
		}

		public override void AI()
		{
			Dust dust1;
			Dust dust2;
			dust1 = Main.dust[Terraria.Dust.NewDust(projectile.Center, 30, 30, 0, -3f, -3f, 0, new Color(255, 255, 255), 1f)];
			dust2 = Main.dust[Terraria.Dust.NewDust(projectile.Center, 30, 30, 0, 3f, -3f, 0, new Color(255, 255, 255), 1f)];
			dust1.alpha = 255;
			dust2.alpha = 255;

			projectile.ai[0]++;

			if (projectile.ai[0] < 720)
			{
				dust1.alpha--;
				dust2.alpha--;
			}

			if (projectile.ai[0] >= 720)
			{
				projectile.timeLeft = 1;
			}
		}
	}
}