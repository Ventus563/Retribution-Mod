using System;
using System.IO;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Retribution.NPCs
{
    public class Coagulate : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Coagulate");

        }
        public override void SetDefaults()
        {

            npc.aiStyle = 2; 
            npc.lifeMax = 90;
            npc.damage = 49;
            npc.defense = 5;
            npc.knockBackResist = 20;
            npc.width = 40;
            npc.height = 30;
            aiType = NPCID.DemonEye; 
            npc.lavaImmune = false;
            npc.noGravity = true;
            npc.noTileCollide = false;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath1;
            npc.netAlways = true;
        }
        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            return spawnInfo.player.ZoneCrimson ? .1f : 0f;

        }
        private double counting;
        private bool stateAttack = false;
        private int phaseCount = 0;
        private int bulletTimer;


        public override void AI()
        {


           #region Attack
            bulletTimer++;
            if (bulletTimer >= 120 && Main.rand.NextFloat() < .50f) 
            {
                Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 0, 8, ModContent.ProjectileType<Blood>(), 30, 0f, Main.myPlayer, npc.whoAmI, 30);


                bulletTimer = 0;
            }
            #endregion


        
        }
    }
}
    

