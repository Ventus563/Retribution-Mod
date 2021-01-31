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

namespace Retribution.NPCs.Bosses.Locus
{
	public class WindWaveLocus : ModProjectile
	{
        public override void SetStaticDefaults()
        {
            ProjectileID.Sets.TrailCacheLength[projectile.type] = 4;
            ProjectileID.Sets.TrailingMode[projectile.type] = 0;
            projectile.hostile = true;
            projectile.friendly = false;
            
        }

        public override void SetDefaults()
		{
            projectile.hostile = true;
            projectile.friendly = false;
			projectile.width = 62;
			projectile.height = 18;
			projectile.aiStyle = 0;
			projectile.friendly = false;
			projectile.ranged = true;
			projectile.timeLeft = 20;
            projectile.alpha = 100;
			projectile.tileCollide = true;
			projectile.friendly = false;
            projectile.knockBack = 15;
			projectile.penetrate = 1;

		}

        public override void Kill(int timeLeft)
        {
            if (Locus.sideRight == true)
            {
                Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, 6, -6, ModContent.ProjectileType<MiniWave>(), 100, 0f, Main.myPlayer, projectile.whoAmI, 100);
                Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, 8, 0, ModContent.ProjectileType<MiniWave>(), 100, 0f, Main.myPlayer, projectile.whoAmI, 100);
                Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, 6, 6, ModContent.ProjectileType<MiniWave>(), 100, 0f, Main.myPlayer, projectile.whoAmI, 100);
            }
            else
            {
                Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, -6, 6, ModContent.ProjectileType<MiniWave>(), 100, 0f, Main.myPlayer, projectile.whoAmI, 100);
                Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, -8, 0, ModContent.ProjectileType<MiniWave>(), 100, 0f, Main.myPlayer, projectile.whoAmI, 100);
                Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, -6, -6, ModContent.ProjectileType<MiniWave>(), 100, 0f, Main.myPlayer, projectile.whoAmI, 100);
            }
        }

        public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            Vector2 drawOrigin = new Vector2(Main.projectileTexture[projectile.type].Width * 0.5f, projectile.height * 0.5f);
            for (int k = 0; k < projectile.oldPos.Length; k++)
            {
                Vector2 drawPos = projectile.oldPos[k] - Main.screenPosition + drawOrigin + new Vector2(0f, projectile.gfxOffY);
                Color color = projectile.GetAlpha(lightColor) * ((float)(projectile.oldPos.Length - k) / (float)projectile.oldPos.Length);
                spriteBatch.Draw(Main.projectileTexture[projectile.type], drawPos, null, color, projectile.rotation, drawOrigin, projectile.scale, SpriteEffects.None, 0f);
            }
            return true;
        }

        public override void AI()
        {
            projectile.rotation = projectile.velocity.ToRotation() + MathHelper.PiOver2;
        }
    }
}