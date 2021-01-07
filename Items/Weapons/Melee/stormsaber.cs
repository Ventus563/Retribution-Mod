using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using Microsoft.Xna.Framework.Graphics;
using Retribution.Items.Weapons;
using System;
using System.IO;
using Retribution;
using Terraria.GameContent.Events;
using Terraria.ModLoader.IO;
using Retribution.Projectiles.Minions;

namespace Retribution.Items.Weapons.Melee
{
    class stormsaber : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Storm Saber");
        }

        public override void SetDefaults()
        {
            item.damage = 52;
            item.melee = true;
            item.width = 32;
            item.height = 32;
            item.useTime = 6;
            item.useAnimation = 6;
            item.channel = true;
            item.noUseGraphic = true;
            item.noMelee = true;
            item.useStyle = 5;
            item.knockBack = 0;
            item.value = Item.buyPrice(0, 22, 50, 0);
            item.rare = 9;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
            item.shoot = mod.ProjectileType("stormsaberbarrage");
            item.shootSpeed = 40f;
        }
    }

    class stormsaberbarrage : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            Main.projFrames[projectile.type] = 18;
        }

        public override void SetDefaults()
        {
            projectile.width = 110;
            projectile.height = 92;
            projectile.aiStyle = 20;
            projectile.friendly = true;
            projectile.penetrate = -1;
            projectile.tileCollide = false;
            projectile.hide = true;
            projectile.ownerHitCheck = true;
            projectile.melee = true;
            projectile.soundDelay = int.MaxValue;
        }

        public override Color? GetAlpha(Color lightColor)
        {
            return new Color(255, 255, 255, 0) * (1f - (float)projectile.alpha / 255f);
        }

        public override void AI()
        {
            projectile.velocity *= 0.98f;

            int frameSpeed = 1;
            projectile.frameCounter++;
            if (projectile.frameCounter >= frameSpeed)
            {
                projectile.frameCounter = 0;
                projectile.frame++;
                if (projectile.frame >= Main.projFrames[projectile.type])
                {
                    projectile.frame = 0;
                }
            }

            projectile.direction = (projectile.spriteDirection = ((projectile.velocity.X > 0f) ? 1 : -1));
            projectile.rotation = projectile.velocity.ToRotation();
            if (projectile.velocity.Y > 16f)
            {
                projectile.velocity.Y = 16f;
            }
            if (projectile.spriteDirection == -1)
            {
                projectile.rotation += MathHelper.Pi;
            }

            Lighting.AddLight(projectile.position, 0f, 0.93f, 0.93f);

        }

        public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
        {

            SpriteEffects spriteEffects = SpriteEffects.None;
            if (projectile.spriteDirection == -1)
            {
                spriteEffects = SpriteEffects.FlipHorizontally;
            }
            Texture2D texture = Main.projectileTexture[projectile.type];
            int frameHeight = Main.projectileTexture[projectile.type].Height / Main.projFrames[projectile.type];
            int startY = frameHeight * projectile.frame;
            Rectangle sourceRectangle = new Rectangle(0, startY, texture.Width, frameHeight);
            Vector2 origin = sourceRectangle.Size() / 2f;
            origin.X = (float)((projectile.spriteDirection == 1) ? (sourceRectangle.Width - 60) : 60);

            Color drawColor = projectile.GetAlpha(lightColor);
            Main.spriteBatch.Draw(texture,
            projectile.Center - Main.screenPosition + new Vector2(0f, projectile.gfxOffY),
            sourceRectangle, drawColor, projectile.rotation, origin, projectile.scale, spriteEffects, 0f);

            return false;
        }
    }
}
