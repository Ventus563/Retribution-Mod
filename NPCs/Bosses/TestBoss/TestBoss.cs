using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Retribution.Projectiles;

namespace Retribution.NPCs.Bosses.TestBoss
{
    public class TestBoss : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("TestBoss");
        }

        public override void SetDefaults()
        {
            npc.aiStyle = 2;
            npc.lifeMax = 150;
            npc.damage = 169;
            npc.defense = 40;
            npc.knockBackResist = 0f;
            npc.width = 28;
            npc.height = 22;
            npc.lavaImmune = true;
            npc.noGravity = true;
            npc.noTileCollide = true;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath6;
            npc.buffImmune[BuffID.Poisoned] = true;
        }
            private int bulletTimer;

                public override void AI()
                {
                   #region Bullet Hell
                    bulletTimer++;
                    if (bulletTimer >= 120)



                    #endregion
               {

      }

}
    }
}

            



