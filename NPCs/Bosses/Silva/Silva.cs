using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.Graphics.Effects;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Retribution.Buffs;
using Retribution.Items.Weapons.Ranger;

namespace Retribution.NPCs.Bosses.Silva
{
    [AutoloadBossHead]
    public class Silva : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Silva");
            Main.npcFrameCount[npc.type] = 4;
        }

        public override void SetDefaults()
        {
            npc.aiStyle = -1;

            if (RetributionWorld.nightmareMode == false)
            {
                npc.lifeMax = 2000;
            }
            if (RetributionWorld.nightmareMode == true)
            {
                npc.lifeMax = 3000;
            }

            if (RetributionWorld.nightmareMode == false)
            {
                npc.damage = 10;
            }

            if (RetributionWorld.nightmareMode == true)
            {
                npc.damage = 25;
            }

            npc.defense = 8;
            npc.knockBackResist = 0f;
            npc.width = 202;
            npc.height = 242;
            npc.value = Item.buyPrice(0, 4, 0, 0);
            npc.npcSlots = 12f;
            npc.boss = true;
            npc.alpha = 0;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.DD2_BetsyScream;
            npc.buffImmune[BuffID.Confused] = true;
            music = mod.GetSoundSlot(SoundType.Music, "Sounds/Music/silva");
        }

        private double counting;

        public int frameIdle = 0;
        public int frameIceBolt = 1;
        public int frameEnraged = 2;

        private int frame;

        private bool enraged = false;
        private bool moving = true;
        private int soundAmount = 0;

        private bool stateIdle = true;
        private bool stateIceBolt = false;

        private int boltTimer;
        private int attachTimer;
        private int dashTimer;

        public bool crash;
        public int teleport;
        public int bail;
        public int babySpawn;
        public int noise;

        public override void OnHitPlayer(Player target, int damage, bool crit)
        {
            target.AddBuff(ModContent.BuffType<TerrariasFrost>(), 180);
        }

        public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            npc.lifeMax = (int)(npc.lifeMax * 0.625f * bossLifeScale);
            npc.damage = (int)(npc.damage * 0.6f);
        }

        public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            if (enraged == true)
            {
                Vector2 vector = new Vector2(0f, 0f);
                SpriteEffects effects = (base.npc.spriteDirection < 0) ? SpriteEffects.None : SpriteEffects.FlipHorizontally;
                for (int i = 0; i < base.npc.oldPos.Length; i++)
                {
                    Vector2 position = base.npc.oldPos[i] - Main.screenPosition + vector + new Vector2(0f, npc.gfxOffY);
                    Color value = base.npc.GetAlpha(new Color(255, 255, 255, 10)) * ((float)(base.npc.oldPos.Length - i) / (float)base.npc.oldPos.Length);
                    spriteBatch.Draw(Main.npcTexture[base.npc.type], position, new Rectangle?(base.npc.frame), value * 0.25f, base.npc.rotation, vector, base.npc.scale, effects, 0f);
                }
            }
            return true;
        }

        public override void AI()
        {
            #region Animation Sets
            if (stateIdle == true)
            {
                this.frame = frameIdle;
            }

            if (stateIceBolt == true)
            {
                this.frame = frameIceBolt;
            }
            #endregion

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
                npc.alpha = 80;
            }

            if (enraged == true && soundAmount == 0)
            {
                Main.PlaySound(SoundID.DD2_DrakinDeath, (int)npc.position.X, (int)npc.position.Y);

                soundAmount = 1;
            }
            #endregion
        }

        public override void FindFrame(int frameHeight)
        {
            #region Idle Frames
            if (this.frame == frameIdle)
            {
                counting += 1.0;
                if (counting < 6.0)
                {
                    npc.frame.Y = 0;
                }
                else if (counting < 12.0)
                {
                    npc.frame.Y = frameHeight;
                }
                else if (counting < 18.0)
                {
                    npc.frame.Y = frameHeight * 2;
                }
                else if (counting < 24.0)
                {
                    npc.frame.Y = frameHeight * 3;
                }
                else
                {
                    counting = 0.0;
                }
            }
            #endregion

            #region IceBolt Frames
            if (this.frame == frameIceBolt)
            {
                counting += 1.0;
                if (counting < 6.0)
                {
                    npc.frame.Y = frameHeight * 4;
                    stateIdle = false;
                }
                else if (counting < 12.0)
                {
                    npc.frame.Y = frameHeight * 5;
                    stateIdle = false;
                }
                else if (counting < 18.0)
                {
                    npc.frame.Y = frameHeight * 6;
                    stateIdle = false;
                }
                else if (counting < 24.0)
                {
                    npc.frame.Y = frameHeight * 7;
                    stateIdle = false;
                }
                else if (counting < 30.0)
                {
                    npc.frame.Y = frameHeight * 8;
                    stateIdle = false;
                }
                else if (counting < 36.0)
                {
                    npc.frame.Y = frameHeight * 9;
                    stateIdle = false;
                }
                else if (counting < 42.0)
                {
                    npc.frame.Y = frameHeight * 10;
                    stateIdle = false;
                }
                else if (counting < 48.0)
                {
                    npc.frame.Y = frameHeight * 11;
                    stateIdle = false;
                }
                else if (counting > 54.0)
                {
                    stateIdle = true;
                    stateIceBolt = false;
                    counting = 0.0;
                }
            }
            #endregion
        }

        public override void NPCLoot()
        {
            Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/Tesca1"), 1f);
            Gore.NewGore(npc.position, -npc.velocity, mod.GetGoreSlot("Gores/Tesca0"), 1f);

            if (Main.rand.NextFloat() < .20f)
            {
                Item.NewItem(npc.getRect(), ModContent.ItemType<SnowingFrost>(), 1);
            }

            //RetributionWorld.downedTesca = true;
        }
    }
}