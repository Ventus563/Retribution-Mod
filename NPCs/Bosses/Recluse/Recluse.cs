using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Retribution.NPCs.Bosses.Recluse
{
    //[AutoloadBossHead]
    public class Recluse : ModNPC
    {
        private const float maxSpeed = 8f;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Recluse");
            Main.npcFrameCount[npc.type] = 4;
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
            npc.aiStyle = 10;
            aiType = NPCID.BlackRecluseWall;
            animationType = NPCID.BlackRecluseWall;

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
                NPC.NewNPC((int)npc.Center.X + 20, (int)npc.Center.Y, NPCID.WallCreeperWall);
                NPC.NewNPC((int)npc.Center.X - 20, (int)npc.Center.Y, NPCID.WallCreeperWall);

                npc.ai[0] = 0;
            }
            #endregion

            #region shoot at player
            npc.ai[1] += 1f;


            if (npc.ai[1] >= 500)
            {
                Main.PlaySound(SoundID.NPCHit52, npc.position);

                Player player = Main.player[npc.target];

                float projectileSpeed = 10f;
                float knockBack = 10;

                Vector2 velocity = Vector2.Normalize(new Vector2(player.position.X + player.width / 2, player.position.Y + player.height / 2) -
                new Vector2(npc.position.X + npc.width / 2, npc.position.Y + npc.height / 2)) * projectileSpeed;

                Projectile.NewProjectile(npc.position.X + npc.width / 2, npc.position.Y + npc.height / 2, velocity.X, velocity.Y, ProjectileID.WebSpit, 15, knockBack, Main.myPlayer);

                int numberProjectiles = 4 + Main.rand.Next(4);
                for (int i = 0; i < numberProjectiles; i++)
                {
                    Vector2 perturbedSpeed = new Vector2(player.position.X + player.width / 2, player.position.Y + player.height / 2) -
                    new Vector2(npc.position.X + npc.width / 2, npc.position.Y + npc.height / 2).RotatedByRandom(MathHelper.ToRadians(1));

                    Projectile.NewProjectile(npc.position.X + npc.width / 2, npc.position.Y + npc.height / 2, perturbedSpeed.X, perturbedSpeed.Y, ProjectileID.WebSpit, 15, knockBack, Main.myPlayer);
                    npc.ai[1] = 0;
                }
                #endregion
            }
        }
    }
}