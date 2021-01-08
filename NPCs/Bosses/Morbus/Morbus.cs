using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.Graphics.Effects;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Retribution.Projectiles;

namespace Retribution.NPCs.Bosses.Morbus
{
    [AutoloadBossHead]
    public class Morbus : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Morbus");
            Main.npcFrameCount[npc.type] = 15;
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

        private double counting;

        public int frameIdle = 0;
        public int frameBlink = 1;
        public int frameFire = 2;
        public int frameSummon = 3;
        public int frameEnraged = 4;

        private int frame;

        private bool enraged = false;
        private bool moving = true;
        private int soundAmount = 0;

        private bool stateIdle = false;
        private bool stateBlink = false;
        private bool stateFire = false;
        private bool stateFire2 = false;
        private bool stateSummon = false;
        private bool stateEnraged = false;

        private int fire2;
        private int summonTimer;
        private int fangTimer;
        private int fangTimer2;

        public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            npc.lifeMax = (int)(npc.lifeMax * 0.625f * bossLifeScale);
            npc.damage = (int)(npc.damage * 0.6f);
        }

        public override void AI()
        {
            #region Animation Sets
            if (stateIdle == true)
            {
                this.frame = frameIdle;
            }

            if (stateBlink == true)
            {
                this.frame = frameBlink;
            }

            if (stateFire == true)
            {
                this.frame = frameFire;
            }

            if (stateSummon == true)
            {
                this.frame = frameSummon;
            }
            #endregion

            #region Behavior

            #region Despawn
            Player player = Main.player[npc.target];

            if (!player.active || player.dead)
            {
                npc.TargetClosest(false);
                player = Main.player[npc.target];
                if (!player.active || player.dead)
                {
                    npc.velocity = new Vector2(0f, 10f);
                    if (npc.timeLeft > 30)
                    {
                        npc.timeLeft = 30;
                    }
                    return;
                }
            }
            #endregion 

            #region Enrage Trigger
            if (npc.life <= npc.lifeMax / 2)
            {
                enraged = true;
                stateEnraged = true;
                stateIdle = false;
                stateBlink = false;
                frame = frameEnraged;
            }

            if (enraged == true && soundAmount == 0)
            {
                Main.PlaySound(SoundID.DD2_BetsyScream, (int)npc.position.X, (int)npc.position.Y);

                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/Morbus_Left"), 1f);

                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/Morbus_Right"), 1f);

                soundAmount = 1;
            }
            #endregion

            #region Idle
            if (moving == true)
            {
                if (stateIdle == true && stateBlink == false)
                {
                    this.frame = frameIdle;
                }

                npc.ai[1]++;

                if (npc.ai[1] >= 60 && Main.rand.NextFloat() < .30f)
                {
                    stateIdle = false;
                    stateBlink = true;
                    npc.ai[1] = 0;
                }

                if (npc.ai[1] >= 61)
                {
                    npc.ai[1] = 0;
                }

                npc.TargetClosest(true);
                Vector2 targetPosition = Main.player[npc.target].position;

                if (enraged == false)
                {
                    if (targetPosition.X < npc.position.X
                  && npc.velocity.X > -4)
                    {
                        npc.velocity.X -= 0.05f;
                    }
                    if (targetPosition.X > npc.position.X
                        && npc.velocity.X < 4)
                    {
                        npc.velocity.X += 0.05f;
                    }

                    if (targetPosition.Y < npc.position.Y + 60)
                    {
                        if (npc.velocity.Y < 0
                            && npc.velocity.Y > -2)
                            npc.velocity.Y -= 0.01f;
                        else
                            npc.velocity.Y -= 0.01f;
                    }

                    if (targetPosition.Y > npc.position.Y + 60)
                    {
                        if (npc.velocity.Y > 0
                            && npc.velocity.Y < 2)
                            npc.velocity.Y += 0.01f;
                        else
                            npc.velocity.Y += 0.01f;
                    }

                    npc.position += npc.velocity;
                }
                else if (enraged == true)
                {
                    if (targetPosition.X < npc.position.X
                  && npc.velocity.X > -8)
                    {
                        npc.velocity.X -= 0.2f;
                    }
                    if (targetPosition.X > npc.position.X
                        && npc.velocity.X < 8)
                    {
                        npc.velocity.X += 0.2f;
                    }

                    if (targetPosition.Y < npc.position.Y + 100)
                    {
                        if (npc.velocity.Y < 0
                            && npc.velocity.Y > -4)
                            npc.velocity.Y -= 0.01f;
                        else
                            npc.velocity.Y -= 0.01f;
                    }

                    if (targetPosition.Y > npc.position.Y + 100)
                    {
                        if (npc.velocity.Y > 0
                            && npc.velocity.Y < 4)
                            npc.velocity.Y += 0.01f;
                        else
                            npc.velocity.Y += 0.01f;
                    }

                    npc.position += npc.velocity;
                }

            }
            #endregion

            #region Fire
            npc.ai[2]++;

            if (enraged == false)
            {
                if (npc.ai[2] >= 500 && Main.rand.NextFloat() < .40f)
                {
                    stateIdle = false;
                    stateFire = true;
                    moving = false;

                    npc.velocity.X = 0;

                    npc.velocity.Y = 0;

                    npc.ai[3]++;
                    if (npc.ai[3] >= 60)
                    {
                        Main.PlaySound(SoundID.NPCHit52, npc.position);

                        Projectile.NewProjectile(npc.Center.X, npc.Center.Y - 60, 0, -2, ModContent.ProjectileType<cursedspit>(), 40, 0f, Main.myPlayer, npc.whoAmI, 40);
                        Projectile.NewProjectile(npc.Center.X, npc.Center.Y - 60, 2, -2, ModContent.ProjectileType<cursedspit>(), 40, 0f, Main.myPlayer, npc.whoAmI, 40);
                        Projectile.NewProjectile(npc.Center.X, npc.Center.Y - 60, 4, -2, ModContent.ProjectileType<cursedspit>(), 40, 0f, Main.myPlayer, npc.whoAmI, 40);
                        Projectile.NewProjectile(npc.Center.X, npc.Center.Y - 60, 6, -2, ModContent.ProjectileType<cursedspit>(), 40, 0f, Main.myPlayer, npc.whoAmI, 40);
                        Projectile.NewProjectile(npc.Center.X, npc.Center.Y - 60, 8, -2, ModContent.ProjectileType<cursedspit>(), 40, 0f, Main.myPlayer, npc.whoAmI, 40);
                        Projectile.NewProjectile(npc.Center.X, npc.Center.Y - 60, 40, -2, ModContent.ProjectileType<cursedspit>(), 40, 0f, Main.myPlayer, npc.whoAmI, 40);
                        Projectile.NewProjectile(npc.Center.X, npc.Center.Y - 60, -2, -2, ModContent.ProjectileType<cursedspit>(), 40, 0f, Main.myPlayer, npc.whoAmI, 40);
                        Projectile.NewProjectile(npc.Center.X, npc.Center.Y - 60, -4, -2, ModContent.ProjectileType<cursedspit>(), 40, 0f, Main.myPlayer, npc.whoAmI, 40);
                        Projectile.NewProjectile(npc.Center.X, npc.Center.Y - 60, -6, -2, ModContent.ProjectileType<cursedspit>(), 40, 0f, Main.myPlayer, npc.whoAmI, 40);
                        Projectile.NewProjectile(npc.Center.X, npc.Center.Y - 60, -8, -2, ModContent.ProjectileType<cursedspit>(), 40, 0f, Main.myPlayer, npc.whoAmI, 40);
                        Projectile.NewProjectile(npc.Center.X, npc.Center.Y - 60, -40, -2, ModContent.ProjectileType<cursedspit>(), 40, 0f, Main.myPlayer, npc.whoAmI, 40);

                        Projectile.NewProjectile(npc.Center.X, npc.Center.Y - 60, 0, -15, ModContent.ProjectileType<cursedspit>(), 40, 0f, Main.myPlayer, npc.whoAmI, 40);
                        Projectile.NewProjectile(npc.Center.X, npc.Center.Y - 60, 1, -15, ModContent.ProjectileType<cursedspit>(), 40, 0f, Main.myPlayer, npc.whoAmI, 40);
                        Projectile.NewProjectile(npc.Center.X, npc.Center.Y - 60, 2, -15, ModContent.ProjectileType<cursedspit>(), 40, 0f, Main.myPlayer, npc.whoAmI, 40);
                        Projectile.NewProjectile(npc.Center.X, npc.Center.Y - 60, -1, -15, ModContent.ProjectileType<cursedspit>(), 40, 0f, Main.myPlayer, npc.whoAmI, 40);
                        Projectile.NewProjectile(npc.Center.X, npc.Center.Y - 60, -2, -15, ModContent.ProjectileType<cursedspit>(), 40, 0f, Main.myPlayer, npc.whoAmI, 40);


                        npc.ai[3] = 0;
                        npc.ai[2] = 0;
                        stateIdle = true;
                        moving = true;
                        stateFire = false;
                    }
                }
            }

            if (enraged == true)
            {
                if (npc.ai[2] >= 400 && Main.rand.NextFloat() < .50f)
                {
                    stateIdle = false;
                    stateFire2 = true;
                    moving = false;

                    npc.velocity.X = 0;

                    npc.velocity.Y = 0;

                    npc.ai[3]++;
                    if (npc.ai[3] >= 30)
                    {
                        Main.PlaySound(SoundID.DD2_BetsyFireballShot, (int)npc.position.X, (int)npc.position.Y);

                        Projectile.NewProjectile(npc.Center.X, npc.Center.Y - 60, 0, -2, ProjectileID.GoldenShowerHostile, 30, 0f, Main.myPlayer, npc.whoAmI, 30);
                        Projectile.NewProjectile(npc.Center.X, npc.Center.Y - 60, 1, -2, ProjectileID.GoldenShowerHostile, 30, 0f, Main.myPlayer, npc.whoAmI, 30);
                        Projectile.NewProjectile(npc.Center.X, npc.Center.Y - 60, 2, -2, ProjectileID.GoldenShowerHostile, 30, 0f, Main.myPlayer, npc.whoAmI, 30);
                        Projectile.NewProjectile(npc.Center.X, npc.Center.Y - 60, 3, -2, ProjectileID.GoldenShowerHostile, 30, 0f, Main.myPlayer, npc.whoAmI, 30);
                        Projectile.NewProjectile(npc.Center.X, npc.Center.Y - 60, 4, -2, ProjectileID.GoldenShowerHostile, 30, 0f, Main.myPlayer, npc.whoAmI, 30);
                        Projectile.NewProjectile(npc.Center.X, npc.Center.Y - 60, 5, -2, ProjectileID.GoldenShowerHostile, 30, 0f, Main.myPlayer, npc.whoAmI, 30);
                        Projectile.NewProjectile(npc.Center.X, npc.Center.Y - 60, 6, -2, ProjectileID.GoldenShowerHostile, 30, 0f, Main.myPlayer, npc.whoAmI, 30);
                        Projectile.NewProjectile(npc.Center.X, npc.Center.Y - 60, 7, -2, ProjectileID.GoldenShowerHostile, 30, 0f, Main.myPlayer, npc.whoAmI, 30);
                        Projectile.NewProjectile(npc.Center.X, npc.Center.Y - 60, 8, -2, ProjectileID.GoldenShowerHostile, 30, 0f, Main.myPlayer, npc.whoAmI, 30);
                        Projectile.NewProjectile(npc.Center.X, npc.Center.Y - 60, 9, -2, ProjectileID.GoldenShowerHostile, 30, 0f, Main.myPlayer, npc.whoAmI, 30);
                        Projectile.NewProjectile(npc.Center.X, npc.Center.Y - 60, -1, -2, ProjectileID.GoldenShowerHostile, 30, 0f, Main.myPlayer, npc.whoAmI, 30);
                        Projectile.NewProjectile(npc.Center.X, npc.Center.Y - 60, -2, -2, ProjectileID.GoldenShowerHostile, 30, 0f, Main.myPlayer, npc.whoAmI, 30);
                        Projectile.NewProjectile(npc.Center.X, npc.Center.Y - 60, -3, -2, ProjectileID.GoldenShowerHostile, 30, 0f, Main.myPlayer, npc.whoAmI, 30);
                        Projectile.NewProjectile(npc.Center.X, npc.Center.Y - 60, -4, -2, ProjectileID.GoldenShowerHostile, 30, 0f, Main.myPlayer, npc.whoAmI, 30);
                        Projectile.NewProjectile(npc.Center.X, npc.Center.Y - 60, -5, -2, ProjectileID.GoldenShowerHostile, 30, 0f, Main.myPlayer, npc.whoAmI, 30);
                        Projectile.NewProjectile(npc.Center.X, npc.Center.Y - 60, -6, -2, ProjectileID.GoldenShowerHostile, 30, 0f, Main.myPlayer, npc.whoAmI, 30);
                        Projectile.NewProjectile(npc.Center.X, npc.Center.Y - 60, -7, -2, ProjectileID.GoldenShowerHostile, 30, 0f, Main.myPlayer, npc.whoAmI, 30);
                        Projectile.NewProjectile(npc.Center.X, npc.Center.Y - 60, -8, -2, ProjectileID.GoldenShowerHostile, 30, 0f, Main.myPlayer, npc.whoAmI, 30);
                        Projectile.NewProjectile(npc.Center.X, npc.Center.Y - 60, -9, -2, ProjectileID.GoldenShowerHostile, 30, 0f, Main.myPlayer, npc.whoAmI, 30);
                        Projectile.NewProjectile(npc.Center.X, npc.Center.Y - 60, -30, -2, ProjectileID.GoldenShowerHostile, 30, 0f, Main.myPlayer, npc.whoAmI, 30);

                        Projectile.NewProjectile(npc.Center.X, npc.Center.Y - 60, 0, -15, ProjectileID.GoldenShowerHostile, 30, 0f, Main.myPlayer, npc.whoAmI, 30);
                        Projectile.NewProjectile(npc.Center.X, npc.Center.Y - 60, 1, -15, ProjectileID.GoldenShowerHostile, 30, 0f, Main.myPlayer, npc.whoAmI, 30);
                        Projectile.NewProjectile(npc.Center.X, npc.Center.Y - 60, 2, -15, ProjectileID.GoldenShowerHostile, 30, 0f, Main.myPlayer, npc.whoAmI, 30);
                        Projectile.NewProjectile(npc.Center.X, npc.Center.Y - 60, -1, -15, ProjectileID.GoldenShowerHostile, 30, 0f, Main.myPlayer, npc.whoAmI, 30);
                        Projectile.NewProjectile(npc.Center.X, npc.Center.Y - 60, -2, -15, ProjectileID.GoldenShowerHostile, 30, 0f, Main.myPlayer, npc.whoAmI, 30);

                        npc.ai[3] = 0;
                        npc.ai[2] = 0;
                        stateIdle = true;
                        moving = true;
                        stateFire2 = false;
                    }
                }
            }

            #endregion

            #region Fire v2
            fire2++;

            if (enraged == false)
            {
                if (fire2 >= 245 && Main.rand.NextFloat() < .35f)
                {
                    int a = Projectile.NewProjectile(npc.Center.X, npc.Center.Y + 60, 3, 2, ProjectileID.CursedFlameFriendly, 10, 0f, Main.myPlayer, npc.whoAmI, 10);
                    int b = Projectile.NewProjectile(npc.Center.X, npc.Center.Y + 60, 1, 2, ProjectileID.CursedFlameFriendly, 10, 0f, Main.myPlayer, npc.whoAmI, 10);
                    int i = Projectile.NewProjectile(npc.Center.X, npc.Center.Y + 60, -1, 2, ProjectileID.CursedFlameFriendly, 10, 0f, Main.myPlayer, npc.whoAmI, 10);
                    int j = Projectile.NewProjectile(npc.Center.X, npc.Center.Y + 60, -3, 2, ProjectileID.CursedFlameFriendly, 10, 0f, Main.myPlayer, npc.whoAmI, 10);

                    Main.projectile[a].hostile = true;
                    Main.projectile[a].friendly = false;
                    Main.projectile[b].hostile = true;
                    Main.projectile[b].friendly = false;
                    Main.projectile[i].hostile = true;
                    Main.projectile[i].friendly = false;
                    Main.projectile[j].hostile = true;
                    Main.projectile[j].friendly = false;

                    Main.PlaySound(SoundID.NPCHit52, npc.position);

                    fire2 = 0;
                }
            }

            if (enraged == true)
            {
                if (fire2 >= 150 && Main.rand.NextFloat() < .50f)
                {
                    int a = Projectile.NewProjectile(npc.Center.X, npc.Center.Y + 60, 3, 2, ProjectileID.CursedFlameFriendly, 40, 0f, Main.myPlayer, npc.whoAmI, 40);
                    int b = Projectile.NewProjectile(npc.Center.X, npc.Center.Y + 60, 1, 2, ProjectileID.CursedFlameFriendly, 40, 0f, Main.myPlayer, npc.whoAmI, 40);
                    int i = Projectile.NewProjectile(npc.Center.X, npc.Center.Y + 60, -1, 2, ProjectileID.CursedFlameFriendly, 40, 0f, Main.myPlayer, npc.whoAmI, 40);
                    int j = Projectile.NewProjectile(npc.Center.X, npc.Center.Y + 60, -3, 2, ProjectileID.CursedFlameFriendly, 40, 0f, Main.myPlayer, npc.whoAmI, 40);

                    Main.projectile[a].hostile = true;
                    Main.projectile[a].friendly = false;
                    Main.projectile[b].hostile = true;
                    Main.projectile[b].friendly = false;
                    Main.projectile[i].hostile = true;
                    Main.projectile[i].friendly = false;
                    Main.projectile[j].hostile = true;
                    Main.projectile[j].friendly = false;

                    Main.PlaySound(SoundID.NPCHit52, npc.position);

                    fire2 = 0;
                }
            }
            #endregion

            #region Fang

            fangTimer++;
            fangTimer2++;

            if (fangTimer >= 500 && enraged == false)
            {
                Main.PlaySound(2, (int)npc.position.X, (int)npc.position.Y, 39);

                Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 0, -10, ModContent.ProjectileType<morbinspikehostile>(), 40, 0f, Main.myPlayer, npc.whoAmI, 40);
                Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 10, -10, ModContent.ProjectileType<morbinspikehostile>(), 40, 0f, Main.myPlayer, npc.whoAmI, 40);
                Projectile.NewProjectile(npc.Center.X, npc.Center.Y, -10, -10, ModContent.ProjectileType<morbinspikehostile>(), 40, 0f, Main.myPlayer, npc.whoAmI, 40);
                Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 10, 0, ModContent.ProjectileType<morbinspikehostile>(), 40, 0f, Main.myPlayer, npc.whoAmI, 40);
                Projectile.NewProjectile(npc.Center.X, npc.Center.Y, -10, 0, ModContent.ProjectileType<morbinspikehostile>(), 40, 0f, Main.myPlayer, npc.whoAmI, 40);
                Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 10, 10, ModContent.ProjectileType<morbinspikehostile>(), 40, 0f, Main.myPlayer, npc.whoAmI, 40);
                Projectile.NewProjectile(npc.Center.X, npc.Center.Y, -10, 10, ModContent.ProjectileType<morbinspikehostile>(), 40, 0f, Main.myPlayer, npc.whoAmI, 40);
                Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 0, 10, ModContent.ProjectileType<morbinspikehostile>(), 40, 0f, Main.myPlayer, npc.whoAmI, 40);

                fangTimer = 0;
            }

            if (fangTimer >= 200 && enraged == true)
            {
                Main.PlaySound(SoundID.DD2_BetsysWrathShot, (int)npc.position.X, (int)npc.position.Y);


                Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 0, -20, ModContent.ProjectileType<morbinspikehostile>(), 40, 0f, Main.myPlayer, npc.whoAmI, 40);
                Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 20, -20, ModContent.ProjectileType<morbinspikehostile>(), 40, 0f, Main.myPlayer, npc.whoAmI, 40);
                Projectile.NewProjectile(npc.Center.X, npc.Center.Y, -20, -20, ModContent.ProjectileType<morbinspikehostile>(), 40, 0f, Main.myPlayer, npc.whoAmI, 40);
                Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 20, 0, ModContent.ProjectileType<morbinspikehostile>(), 40, 0f, Main.myPlayer, npc.whoAmI, 40);
                Projectile.NewProjectile(npc.Center.X, npc.Center.Y, -20, 0, ModContent.ProjectileType<morbinspikehostile>(), 40, 0f, Main.myPlayer, npc.whoAmI, 40);
                Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 20, 20, ModContent.ProjectileType<morbinspikehostile>(), 40, 0f, Main.myPlayer, npc.whoAmI, 40);
                Projectile.NewProjectile(npc.Center.X, npc.Center.Y, -20, 20, ModContent.ProjectileType<morbinspikehostile>(), 40, 0f, Main.myPlayer, npc.whoAmI, 40);
                Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 0, 20, ModContent.ProjectileType<morbinspikehostile>(), 40, 0f, Main.myPlayer, npc.whoAmI, 40);

                fangTimer = 0;
            }

            if (fangTimer2 >= 300 && enraged == true)
            {
                Main.PlaySound(SoundID.DD2_BetsysWrathImpact, (int)npc.position.X, (int)npc.position.Y);

                Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 0, -20, ModContent.ProjectileType<morbinspikehostile>(), 40, 0f, Main.myPlayer, npc.whoAmI, 40);
                Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 20, -20, ModContent.ProjectileType<morbinspikehostile>(), 40, 0f, Main.myPlayer, npc.whoAmI, 40);
                Projectile.NewProjectile(npc.Center.X, npc.Center.Y, -20, -20, ModContent.ProjectileType<morbinspikehostile>(), 40, 0f, Main.myPlayer, npc.whoAmI, 40);
                Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 20, 0, ModContent.ProjectileType<morbinspikehostile>(), 40, 0f, Main.myPlayer, npc.whoAmI, 40);
                Projectile.NewProjectile(npc.Center.X, npc.Center.Y, -20, 0, ModContent.ProjectileType<morbinspikehostile>(), 40, 0f, Main.myPlayer, npc.whoAmI, 40);
                Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 20, 20, ModContent.ProjectileType<morbinspikehostile>(), 40, 0f, Main.myPlayer, npc.whoAmI, 40);
                Projectile.NewProjectile(npc.Center.X, npc.Center.Y, -20, 20, ModContent.ProjectileType<morbinspikehostile>(), 40, 0f, Main.myPlayer, npc.whoAmI, 40);
                Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 0, 20, ModContent.ProjectileType<morbinspikehostile>(), 40, 0f, Main.myPlayer, npc.whoAmI, 40);
                Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 40, -20, ModContent.ProjectileType<morbinspikehostile>(), 40, 0f, Main.myPlayer, npc.whoAmI, 40);
                Projectile.NewProjectile(npc.Center.X, npc.Center.Y, -40, -20, ModContent.ProjectileType<morbinspikehostile>(), 40, 0f, Main.myPlayer, npc.whoAmI, 40);
                Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 40, 0, ModContent.ProjectileType<morbinspikehostile>(), 40, 0f, Main.myPlayer, npc.whoAmI, 40);
                Projectile.NewProjectile(npc.Center.X, npc.Center.Y, -40, 0, ModContent.ProjectileType<morbinspikehostile>(), 40, 0f, Main.myPlayer, npc.whoAmI, 40);
                Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 40, 20, ModContent.ProjectileType<morbinspikehostile>(), 40, 0f, Main.myPlayer, npc.whoAmI, 40);
                Projectile.NewProjectile(npc.Center.X, npc.Center.Y, -40, 20, ModContent.ProjectileType<morbinspikehostile>(), 40, 0f, Main.myPlayer, npc.whoAmI, 40);

                fangTimer2 = 0;
            }

            #endregion

            #region Summon
            summonTimer++;

            if (summonTimer >= 300 && enraged == false)
            {
                NPC.NewNPC((int)npc.Center.X + 20, (int)npc.Center.Y, ModContent.NPCType<morbi>());
                summonTimer = 0;
            }

            if (summonTimer >= 120 && enraged == true)
            {
                NPC.NewNPC((int)npc.Center.X + 20, (int)npc.Center.Y, ModContent.NPCType<morbi>());
                summonTimer = 0;
            }
            #endregion

            #endregion
        }

        public override void FindFrame(int frameHeight)
        {
            #region Idle Frames
            if (this.frame == frameIdle)
            {
                counting += 2.0;
                if (counting < 8.0)
                {
                    npc.frame.Y = 0;
                }
                else if (counting < 16.0)
                {
                    npc.frame.Y = frameHeight;
                }
                else if (counting < 24.0)
                {
                    npc.frame.Y = frameHeight * 2;
                }
                else if (counting < 32.0)
                {
                    npc.frame.Y = frameHeight * 3;
                }
                else if (counting < 40.0)
                {
                    npc.frame.Y = frameHeight * 4;
                }
                else
                {
                    counting = 0.0;
                }
            }

            if (this.frame == frameIdle && stateFire == true)
            {
                counting += 2.0;
                if (counting < 4.0)
                {
                    npc.frame.Y = 0;
                }
                else if (counting < 6.0)
                {
                    npc.frame.Y = frameHeight;
                }
                else if (counting < 8.0)
                {
                    npc.frame.Y = frameHeight * 2;
                }
                else if (counting < 10.0)
                {
                    npc.frame.Y = frameHeight * 3;
                }
                else if (counting < 12.0)
                {
                    npc.frame.Y = frameHeight * 4;
                }
                else
                {
                    counting = 0.0;
                }
            }
            #endregion

            #region Blink Frames
            if (this.frame == frameBlink)
            {
                counting += 2.0;
                if (counting < 10.0)
                {
                    npc.frame.Y = frameHeight * 5;
                }
                else if (counting < 20.0)
                {
                    npc.frame.Y = frameHeight * 6;
                }
                else if (counting < 30.0)
                {
                    npc.frame.Y = frameHeight * 7;
                }
                else if (counting < 40.0)
                {
                    npc.frame.Y = frameHeight * 8;
                }
                else if (counting < 50.0)
                {
                    npc.frame.Y = frameHeight * 9;
                }
                else
                {
                    counting = 0.0;
                    stateIdle = true;
                    stateBlink = false;
                }
            }
            #endregion

            #region Enraged Frames
            if (this.frame == frameEnraged)
            {
                counting += 2.0;
                if (counting < 10.0)
                {
                    npc.frame.Y = frameHeight * 10;
                    stateIdle = false;
                    stateBlink = false;
                }
                else if (counting < 20.0)
                {
                    npc.frame.Y = frameHeight * 11;
                    stateIdle = false;
                    stateBlink = false;
                }
                else if (counting < 30.0)
                {
                    npc.frame.Y = frameHeight * 12;
                    stateIdle = false;
                    stateBlink = false;
                }
                else if (counting < 40.0)
                {
                    npc.frame.Y = frameHeight * 13;
                    stateIdle = false;
                    stateBlink = false;
                }
                else if (counting < 50.0)
                {
                    npc.frame.Y = frameHeight * 14;
                    stateIdle = false;
                    stateBlink = false;
                }
                else
                {
                    counting = 0.0;
                    stateIdle = false;
                    stateBlink = false;
                }
            }

            if (this.frame == frameEnraged && stateFire2 == true)
            {
                counting += 2.0;
                if (counting < 4.0)
                {
                    npc.frame.Y = frameHeight * 10;
                    stateIdle = false;
                    stateBlink = false;
                }
                else if (counting < 6.0)
                {
                    npc.frame.Y = frameHeight * 11;
                    stateIdle = false;
                    stateBlink = false;
                }
                else if (counting < 8.0)
                {
                    npc.frame.Y = frameHeight * 12;
                    stateIdle = false;
                    stateBlink = false;
                }
                else if (counting < 10.0)
                {
                    npc.frame.Y = frameHeight * 13;
                    stateIdle = false;
                    stateBlink = false;
                }
                else if (counting < 12.0)
                {
                    npc.frame.Y = frameHeight * 14;
                    stateIdle = false;
                    stateBlink = false;
                }
                else
                {
                    counting = 0.0;
                    stateIdle = false;
                    stateBlink = false;
                }
            }
            #endregion
        }

        public override void NPCLoot()
        {
            Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/Morbus2_1"), 1f);
            Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/Morbus2_2"), 1f);
            Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/Morbus2_3"), 1f);

            RetributionWorld.downedMorbus = true;
        }
    }
}