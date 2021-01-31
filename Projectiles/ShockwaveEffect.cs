using System;
using Terraria;
using Terraria.Graphics.Effects;
using Terraria.ModLoader;

namespace Retribution.Projectiles
{
	public class ShockwaveEffect : ModProjectile
	{
		public override void SetDefaults()
		{
			base.projectile.width = 4;
			base.projectile.height = 4;
			base.projectile.timeLeft = 400;
			base.projectile.alpha = 255;
		}

		private int rCount = 2;
		private int rSize = 6;
		private int rSpeed = 30;
		private float distortStrength = 800f;

		public override void AI()
		{
			base.projectile.ai[0] += 8f;
			Player player = Main.player[Main.myPlayer];
			if (base.projectile.ai[1] == 0f)
			{
				base.projectile.ai[1] = 1f;
				if (!Filters.Scene["Shockwave"].IsActive())
				{
					Filters.Scene.Activate("Shockwave", base.projectile.Center, new object[0]).GetShader().UseColor((float)this.rCount, (float)this.rSize, (float)this.rSpeed).UseTargetPosition(base.projectile.Center);
					return;
				}
			}
			else
			{
				base.projectile.ai[1] += 1f;
				float num = base.projectile.ai[1] / 60f;
				float num2 = 200f;
				Filters.Scene["Shockwave"].GetShader().UseProgress(num).UseOpacity(num2 * (1f - num / 3f));
			}
		}

		public override void Kill(int timeLeft)
		{
			Filters.Scene["Shockwave"].Deactivate(new object[0]);
		}
	}
}
