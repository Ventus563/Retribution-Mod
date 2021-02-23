using Retribution.Dusts;
using Retribution.Buffs;
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Graphics;
using Microsoft.Xna.Framework.Graphics;

namespace Retribution.NPCs.Minotaur
{
	public class Firestrike : ModProjectile
	{

        public override void SetDefaults()
		{
            projectile.damage = 30;
            projectile.hostile = true;
			projectile.width = 100;
			projectile.height = 100;
			projectile.aiStyle = 1;
			projectile.friendly = false;
			projectile.ranged = true;
			projectile.timeLeft = 120;
            projectile.alpha = 100;
			projectile.tileCollide = false;
			projectile.friendly = false;
            projectile.knockBack = 15;
			projectile.penetrate = 1;
			aiType = 1;

		}
    }
}