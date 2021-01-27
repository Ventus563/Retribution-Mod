using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Retribution.Projectiles.Minions.Worms
{
	public class EarthBody : ModProjectile
	{
		public override void SetDefaults()
		{
			base.projectile.width = 60;
			base.projectile.height = 26;
			base.projectile.friendly = true;
			base.projectile.ignoreWater = true;
			base.projectile.netImportant = true;
			base.projectile.tileCollide = false;
			base.projectile.minion = true;
			base.projectile.penetrate = -1;
			base.projectile.timeLeft = 18000;
			ProjectileID.Sets.MinionSacrificable[base.projectile.type] = true;
			base.projectile.timeLeft *= 5;
			base.projectile.minionSlots = 1f;
		}

		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Earth Worm");
		}

		public override void AI()
		{
			if (!Main.player[base.projectile.owner].active)
			{
				base.projectile.active = false;
				return;
			}
			int num1049 = 30;
			Vector2 parCenter = Vector2.Zero;
			if (base.projectile.ai[1] == 1f)
			{
				base.projectile.ai[1] = 0f;
				base.projectile.netUpdate = true;
			}
			Projectile parent = Main.projectile[(int)base.projectile.ai[0]];
			if ((int)base.projectile.ai[0] >= 0 && parent.active)
			{
				parCenter = parent.Center;
				float parRot = parent.rotation;
				float scaleFactor17 = MathHelper.Clamp(parent.scale, 0f, 50f);
				float scaleFactor18 = 10f;
				parent.localAI[0] = base.projectile.localAI[0] + 1f;
				if (base.projectile.alpha > 0)
				{
					int num1052;
					for (int num1050 = 0; num1050 < 2; num1050 = num1052 + 1)
					{
						int num1051 = Dust.NewDust(base.projectile.position, base.projectile.width, base.projectile.height, DustID.Dirt, 0f, 0f, 100, default(Color), 2f);
						Main.dust[num1051].noGravity = true;
						Main.dust[num1051].noLight = true;
						num1052 = num1050;
					}
				}
				base.projectile.alpha -= 42;
				if (base.projectile.alpha < 0)
				{
					base.projectile.alpha = 0;
				}
				base.projectile.velocity = Vector2.Zero;
				Vector2 vector151 = parCenter - base.projectile.Center;
				if (parRot != base.projectile.rotation)
				{
					float num1053 = MathHelper.WrapAngle(parRot - base.projectile.rotation);
					vector151 = Utils.RotatedBy(vector151, (double)(num1053 * 0.1f), default(Vector2));
				}
				base.projectile.rotation = Utils.ToRotation(vector151) + 1.57079637f;
				base.projectile.position = base.projectile.Center;
				base.projectile.scale = scaleFactor17;
				base.projectile.width = (base.projectile.height = (int)((float)num1049 * base.projectile.scale));
				base.projectile.Center = base.projectile.position;
				if (vector151 != Vector2.Zero)
				{
					float multiplier = 1.5f;
					if (parent.type == base.mod.ProjectileType("EarthHead"))
					{
						multiplier = 3f;
					}
					base.projectile.Center = parCenter - Vector2.Normalize(vector151) * multiplier * scaleFactor18 * scaleFactor17;
				}
				base.projectile.spriteDirection = ((vector151.X > 0f) ? 1 : -1);
				return;
			}
			base.projectile.Kill();
		}
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			target.immune[base.projectile.owner] = 7;
		}
	}
}
