using System;
using System.IO;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Retribution.NPCs
{
    public class Chomper : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Chomper");
            Main.npcFrameCount[npc.type] = 4;

        }
        public override void SetDefaults()
        {

            npc.aiStyle = 1; 
            npc.lifeMax = 30;
            npc.damage = 22;
            npc.defense = 5;
            npc.knockBackResist = 0;
            npc.width = 40;
            npc.height = 30;
            animationType = NPCID.GreenSlime;
            aiType = NPCID.GreenSlime; 
            npc.lavaImmune = false;
            npc.noGravity = false;
            npc.noTileCollide = false;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath1;
            npc.netAlways = true;
        }
        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            return spawnInfo.player.ZoneCrimson ? .1f : 0f;

        }
        public override void AI()
        {
            npc.ai[0]++;
            Player player = Main.player[npc.target];
            if (npc.target < 0 || npc.target == 255 || Main.player[npc.target].dead || !Main.player[npc.target].active)
            {
                npc.TargetClosest(true);
            }
            npc.netUpdate = true;

        }
    }
}
