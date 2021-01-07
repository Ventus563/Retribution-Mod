using System.IO;
using System.Collections.Generic;
using Terraria;
using System;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.World.Generation;
using Microsoft.Xna.Framework;
using Terraria.GameContent.Generation;
using System.Linq;
using Retribution.Tiles;
using Retribution.Projectiles;

namespace Retribution
{
    public class RetributionProjectile : GlobalProjectile
    {
        public override void OnHitNPC(Projectile projectile, NPC target, int damage, float knockback, bool crit)
        {
            if (projectile.type == ProjectileID.HallowStar)
            {
                int numberProjectiles = 6;
                for (int index = 0; index < numberProjectiles; ++index)
                {
                    Vector2 vector2_1 = new Vector2((float)((double)target.position.X + (double)target.width * 0.5 + (double)(Main.rand.Next(201) * -target.direction) + ((double)Main.mouseX + (double)Main.screenPosition.X - (double)target.position.X)), (float)((double)target.position.Y + (double)target.height * 0.5 - 600.0));
                    vector2_1.X = (float)(((double)vector2_1.X + (double)target.Center.X) / 2.0) + (float)Main.rand.Next(-200, 201);
                    vector2_1.Y -= (float)(100 * index);
                    float num12 = (float)target.position.Y;
                    float num13 = (float)target.position.X;
                    if ((double)num13 < 0.0) num13 *= -1f;
                    if ((double)num13 < 20.0) num13 = 20f;
                    float num14 = (float)Math.Sqrt((double)num12 * (double)num12 + (double)num13 * (double)num13);
                    float num15 = 20 / num14;
                    float num16 = num12 * num15;
                    float num17 = num13 * num15;
                    float SpeedX = num16 + (float)Main.rand.Next(-40, 41) * 0.02f;
                    float SpeedY = num17 + (float)Main.rand.Next(-40, 41) * 0.02f;
                    Projectile.NewProjectile(vector2_1.X, vector2_1.Y, SpeedX, SpeedY, ProjectileID.FallingStar, damage, 5, Main.myPlayer, 0.0f, (float)Main.rand.Next(5));
                }
            }
        }
    }
}