using Retribution.Dusts;
using Retribution.Buffs;
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria.Graphics.Shaders;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework.Graphics;

namespace Retribution.NPCs.Bosses.Tesca
{
	public class tescanlaserspike : ModProjectile
	{
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Tescan Laser Spike");
            ProjectileID.Sets.TrailCacheLength[projectile.type] = 5;
            ProjectileID.Sets.TrailingMode[projectile.type] = 0;
        }

        public override void SetDefaults()
		{
			projectile.width = 50;
			projectile.height = 66;
			projectile.aiStyle = 0;
			projectile.friendly = false;
            projectile.hostile = true;
			projectile.tileCollide = true;
			projectile.penetrate = 10;
        }

        public override void OnHitPlayer(Player target, int damage, bool crit)
        {
            if (RetributionWorld.nightmareMode == true)
            {
                target.AddBuff(ModContent.BuffType<TerrariasFrost>(), 60);
            }
            else
            {
                target.AddBuff(BuffID.Frostburn, 180);
            }
        }

        public override void Kill(int timeLeft)
        {
            Main.PlaySound(SoundID.Item27, (int)projectile.position.X, (int)projectile.position.Y);
            Vector2 usePos = projectile.position;

            Projectile.NewProjectile(projectile.position.X + 75, projectile.Center.Y + 80, -2, 0, ModContent.ProjectileType<tescanminiproj>(), 20, 0f, Main.myPlayer, projectile.whoAmI, 40);
            Projectile.NewProjectile(projectile.position.X + 75, projectile.Center.Y + 80, 2, 0, ModContent.ProjectileType<tescanminiproj>(), 20, 0f, Main.myPlayer, projectile.whoAmI, 40);

            const int NUM_DUSTS = 45;

            for (int i = 0; i < NUM_DUSTS; i++)
            {
                Dust dust;
                dust = Main.dust[Terraria.Dust.NewDust(projectile.position, projectile.width, projectile.height, 185, 0f, 0f, 0)];
                dust.noGravity = true;
            }
        }

        public override void AI()
        {
            Lighting.AddLight(projectile.Center, 0f, 0.93f, 0.93f);
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
    }
}