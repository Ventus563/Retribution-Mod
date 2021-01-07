using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Retribution.Projectiles;

namespace Retribution.NPCs.Bosses.EvilSnowman
{
    //[AutoloadBossHead]
    public class Snowman : ModNPC
    {
        private const float maxSpeed = 8f;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Evil Snowman");
            Main.npcFrameCount[npc.type] = 1;
        }

        public override void SetDefaults()
        {
            npc.aiStyle = -1;
            npc.lifeMax = 4000;
            npc.damage = 25;
            npc.defense = 10;
            npc.knockBackResist = 0f;
            npc.width = 127;
            npc.height = 127;
            npc.value = Item.buyPrice(0, 12, 0, 0);
            npc.npcSlots = 12f;
            npc.boss = true;
            npc.lavaImmune = true;
            npc.noGravity = true;
            npc.noTileCollide = true;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath6;
            npc.buffImmune[BuffID.Poisoned] = true;
            npc.buffImmune[BuffID.Venom] = true;
            aiType = NPCID.SnowFlinx;
            //animationType = NPCID.BlackRecluseWall;

            for (int k = 0; k < npc.buffImmune.Length; k++)
            {
                npc.buffImmune[k] = true;
            }
            music = mod.GetSoundSlot(SoundType.Music, "Sounds/Music/kane");
        }

        public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            npc.lifeMax = (int)(npc.lifeMax * 0.7f * bossLifeScale);
            npc.damage = (int)(npc.damage * 0.7f);
        }

        /*public override bool? DrawHealthBar(byte hbPosition, ref float scale, ref Vector2 position)
        {
            scale = 1.5f;
            return null;
        }*/

        public override void AI()
        {

            #region spawn enemies
            npc.ai[0] += 1f;


            if (npc.ai[0] >= 180)
            {
                NPC.NewNPC((int)npc.Center.X + 20, (int)npc.Center.Y, NPCID.SnowFlinx);
                NPC.NewNPC((int)npc.Center.X - 20, (int)npc.Center.Y, NPCID.SnowFlinx);

                npc.ai[0] = 0;
            }
            #endregion

            #region shoot at player
            npc.ai[1] += 1f;


            if (npc.ai[1] >= 360)
            {
                int i = Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 0, 0, ModContent.ProjectileType<SnowflakeH>(), 20, 0f, Main.myPlayer);
               
                Main.projectile[i].hostile = true;
                Main.projectile[i].friendly = false;
                Main.projectile[i].timeLeft = 0;

                npc.ai[1] = 0f;

            #endregion
            }

            #region jump onto player
            npc.ai[2] += 1f;

            if (npc.ai[2] >= 840) //npc.lifeMax <= 3000
            {
                if (npc.ai[2] <= 2000)
                {
                    npc.position.Y++;
                }

                npc.ai[3] += 1f;

                if (npc.ai[3] >= 200)
                {
                    npc.position.X = Main.LocalPlayer.position.X;

                    npc.position.Y--;

                    npc.ai[2] = 0f;
                }
            }




            #endregion
        }
    }
}