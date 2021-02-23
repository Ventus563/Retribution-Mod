using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.IO;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Retribution;


namespace Retribution.NPCs
{
    public class LaserSlime : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Laser Slime");
            Main.npcFrameCount[npc.type] = 4;

        }

        public override void SetDefaults()
        {
            npc.width = 56;
            npc.height = 80;
            npc.damage = 16;
            npc.defense = 4;
            npc.lifeMax = 35;
            npc.DeathSound = SoundID.NPCDeath1;
            npc.knockBackResist = 0f;
            npc.aiStyle = 1;
            aiType = 1;

        }
        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            return Main.slimeRain ? 0.1f : 0f;
        }
        private double counting;
        private bool stateAttack = false;
        private int phaseCount = 0;
        private int bulletTimer;


        public override void AI()
        {


           #region Attack
            bulletTimer++;
            npc.TargetClosest(true);
            npc.netUpdate = true;
            Vector2 vector = Main.player[npc.target].Center + new Vector2(npc.Center.X, npc.Center.Y);
            Vector2 vector2 = npc.Center + new Vector2(npc.Center.X, npc.Center.Y);
            float num = (float)Math.Atan2((double)(vector2.Y - vector.Y), (double)(vector2.X - vector.X));
            if (bulletTimer >= 180 && Main.rand.NextFloat() < .50f) 
            {
                Projectile.NewProjectile(npc.Center.X, npc.Center.Y, (float)(Math.Cos((double)num) * 2.0 * -1.0), (float)(Math.Sin((double)num) * 2.0 * -1.0), ProjectileID.EyeLaser, 8, 0f, 0, 0f, 8f);


                bulletTimer = 0;
            }
            #endregion


        
        }
    }
}
