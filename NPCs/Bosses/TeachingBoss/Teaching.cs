using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Retribution.Projectiles;

namespace Retribution.NPCs.Bosses.TeachingBoss
{
    public class Teaching : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("TestBoss");
        }

        public override void SetDefaults()
        {
            npc.aiStyle = -1;
            npc.lifeMax = 12000;
            npc.damage = 25;
            npc.defense = 16;
            npc.knockBackResist = 0f;
            npc.width = 100;
            npc.height = 88;
            npc.value = Item.buyPrice(0, 12, 0, 0);
            npc.npcSlots = 12f;
            npc.boss = true;
            npc.alpha = 0;
            npc.lavaImmune = true;
            npc.noGravity = true;
            npc.noTileCollide = true;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.DD2_BetsyScream;
            npc.buffImmune[BuffID.Poisoned] = true;
            npc.buffImmune[BuffID.Venom] = true;

            for (int k = 0; k < npc.buffImmune.Length; k++)
            {
                npc.buffImmune[k] = true;
            }
            music = mod.GetSoundSlot(SoundType.Music, "Sounds/Music/cursedprotector");
        }

        private int bulletTimer;
        private int dashTimer;
        private int opacityTimer;

        private int soundCount = 0;
        private int phaseCount = 0;

        private bool stateEnraged = false;

        public override void AI()
        {
            #region Enraged
            if (npc.life <= npc.lifeMax / 2)
            {
                stateEnraged = true;
            }
            if (stateEnraged == true)
            {
                npc.alpha++;
                opacityTimer++;
                if (opacityTimer >= 120)
                {
                    npc.alpha--;
                    phaseCount = 1;
                }

                if (opacityTimer >= 400)
                {
                    opacityTimer = 0;
                    npc.alpha = 0;
                }
            }
            if (npc.alpha == 0 && phaseCount == 1)
            {
                Main.PlaySound(SoundID.DD2_BetsyScream, (int)npc.position.X, (int)npc.position.Y);
                Projectile.NewProjectile(npc.Center.X, npc.Center.Y, -8, -8, ProjectileID.Fireball, 100, 0f, Main.myPlayer, npc.whoAmI, 100);

                phaseCount = 2;
            }
            #endregion

            #region Dash Attack
            npc.TargetClosest(true);
            Vector2 targetPosition = Main.player[npc.target].position;
            dashTimer++;

            if (dashTimer >= 240 && Main.rand.NextFloat() < .10f)
            {
                if (soundCount <= 0)
                {
                    Main.PlaySound(15, (int)npc.position.X, (int)npc.position.Y, 0);

                    soundCount += 1;
                }

                if (targetPosition.X < npc.position.X && npc.velocity.X > -4)
                {
                    npc.velocity.X -= 3f;
                }
                if (targetPosition.X > npc.position.X && npc.velocity.X < 4)
                {
                    npc.velocity.X += 3f;
                }

                if (targetPosition.Y < npc.position.Y + 60)
                {
                    if (npc.velocity.Y < 0 && npc.velocity.Y > -2)
                    {
                        npc.velocity.Y -= 3f;

                    }
                    else
                    {
                        npc.velocity.Y -= 3f;
                    }
                }

                if (targetPosition.Y > npc.position.Y + 60)
                {
                    if (npc.velocity.Y > 0 && npc.velocity.Y < 2)
                    {
                        npc.velocity.Y += 3f;
                    }
                    else
                    {
                        npc.velocity.Y += 3f;
                    }
                }

                npc.position += npc.velocity;

                if (dashTimer >= 480)
                {
                    dashTimer = 0;
                    soundCount = 0;
                    npc.velocity.Y = 0;
                    npc.velocity.X = 0;
                }
            }
            #endregion

            #region Bullet Hell
            bulletTimer++;
            if (bulletTimer >= 180 && Main.rand.NextFloat() < .25f) // .50f is the percent. .05f would be 5%
            {
                Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 0, -8, ProjectileID.Fireball, 100, 0f, Main.myPlayer, npc.whoAmI, 100);
                Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 8, -8, ProjectileID.Fireball, 100, 0f, Main.myPlayer, npc.whoAmI, 100);
                Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 8, 0, ProjectileID.Fireball, 100, 0f, Main.myPlayer, npc.whoAmI, 100);
                Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 8, 8, ProjectileID.Fireball, 100, 0f, Main.myPlayer, npc.whoAmI, 100);
                Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 0, 8, ProjectileID.Fireball, 100, 0f, Main.myPlayer, npc.whoAmI, 100);
                Projectile.NewProjectile(npc.Center.X, npc.Center.Y, -8, 8, ProjectileID.Fireball, 100, 0f, Main.myPlayer, npc.whoAmI, 100);
                Projectile.NewProjectile(npc.Center.X, npc.Center.Y, -8, 0, ProjectileID.Fireball, 100, 0f, Main.myPlayer, npc.whoAmI, 100);
                Projectile.NewProjectile(npc.Center.X, npc.Center.Y, -8, -8, ProjectileID.Fireball, 100, 0f, Main.myPlayer, npc.whoAmI, 100);

                bulletTimer = 0;
            }
            #endregion
        }
    }
}