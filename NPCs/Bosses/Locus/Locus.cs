using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Retribution.Projectiles;

namespace Retribution.NPCs.Bosses.Locus
{
    public class Locus : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Locus");
            Main.npcFrameCount[npc.type] = 8;
        }

        public override void SetDefaults()
        {
            npc.aiStyle = 0;
            npc.lifeMax = 7050;
            npc.damage = 40;
            npc.defense = 16;
            npc.knockBackResist = 0f;
            npc.width = 92;
            npc.height = 89;
            npc.value = Item.buyPrice(0, 12, 0, 0);
            npc.npcSlots = 12f;
            npc.boss = true;
            npc.alpha = 0;
            npc.lavaImmune = true;
            npc.noGravity = true;
            npc.noTileCollide = true;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.DD2_BetsyScream;

            music = mod.GetSoundSlot(SoundType.Music, "Sounds/Music/locust");


            for (int k = 0; k < npc.buffImmune.Length; k++)
            {
                npc.buffImmune[k] = true;
            }
        }
        private double counting;
        private int frame;
        private int frameIdle = 0;
        private bool stateIdle = false;
        private bool stateEnraged = false;
        private int phaseCount = 0;
        private int bulletTimer;
        private int summonTimer;

		public int counter;
		public int flux;
		public bool shift;
		public static bool sideRight;
		public int shifted;
		public int angry;
		public int attackState;
		public bool strike;
		public bool charge;
		public bool charging;
        public bool npcTrail = false;

        public override void AI()
        {
            #region Animations
            if (stateIdle == true)
            {
                frame = frameIdle;
            }
			#endregion

			#region Idle Behavior

			npc.ai[0] += 1f;
			npc.ai[2] += 1f;
			npc.ai[3] += 1f;
			if (npc.aiStyle != -1)
			{
				npc.ai[1] -= 1f;
			}
			npc.TargetClosest(true);
			Player player = Main.player[npc.target];
			Vector2 vector = Main.player[npc.target].Center + new Vector2(npc.Center.X, npc.Center.Y);
			Vector2 vector2 = npc.Center + new Vector2(npc.Center.X, npc.Center.Y);
			npc.netUpdate = true;

            if (npc.ai[0] == 80f)
            {
                counter = 12;
                strike = true;
            }
            if (npc.ai[2] >= 360f)
            {
                npc.velocity.X = 0f;
                npc.velocity.Y = 0f;
                npc.ai[0] = 0f;
                charge = true;
                charging = true;
                npcTrail = true;
                for (int i = 0; i < 5; i++)
                {
                    int num = Dust.NewDust(new Vector2(npc.position.X, npc.position.Y) - npc.velocity, npc.width, npc.height, 16, -((float)npc.spriteDirection * 8f), 0f, 0, default(Color), 0.75f);
                    Dust dust = Main.dust[num];
                    Main.dust[num].velocity *= 0.2f;
                    Main.dust[num].noGravity = true;
                }
            }
            if (npc.ai[2] >= 420f)
            {
                npc.aiStyle = -1;
                if (sideRight)
                {
                    sideRight = false;
                }
                else
                {
                    sideRight = true;
                }
                npcTrail = true;
                charge = true;
                charging = true;
                Vector2 vector3 = new Vector2(npc.Center.X, npc.Center.Y);
                float num2 = (float)Math.Atan2((double)(vector3.Y - (player.Center.Y - 350f)), (double)(vector3.X - player.Center.X));
                npc.velocity.X = (float)(Math.Cos((double)num2) * 14.0) * -1f;
                npc.velocity.Y = (float)(Math.Sin((double)num2) * 14.0) * -1f;
                npc.netUpdate = true;
                npc.ai[2] = 0f;
            }

            if (player.Center.X > npc.Center.X)
			{
				npc.spriteDirection = 1;
			}
			else
			{
				npc.spriteDirection = -1;
			}
			if (!shift)
			{
				flux += 2;
			}
			else
			{
				flux -= 2;
			}
			if (flux > 120 && !shift)
			{
				shift = true;
			}
			if (flux <= -60)
			{
				shift = false;
			}
			if (Main.player[npc.target].position.Y < npc.position.Y + 30f + (float)flux)
			{
				NPC npc2 = npc;
				npc2.velocity.Y = npc2.velocity.Y - ((npc.velocity.Y > 0f) ? 0.6f : 0.07f);
			}
			if (Main.player[npc.target].position.Y > npc.position.Y + 30f + (float)flux)
			{
				NPC npc3 = npc;
				npc3.velocity.Y = npc3.velocity.Y + ((npc.velocity.Y < 0f) ? 0.6f : 0.07f);
			}
			if (!charging)
			{
				npc.aiStyle = 14;
                if (sideRight)
				{
                    npcTrail = false;
					if (Main.player[npc.target].position.X < npc.position.X + 575f + (float)(flux / 2))
					{
						NPC npc4 = npc;
						npc4.velocity.X = npc4.velocity.X - ((npc.velocity.X > 0f) ? 2f : 1f);
					}
					if (Main.player[npc.target].position.X > npc.position.X + 475f + (float)(flux / 2))
					{
						NPC npc5 = npc;
						npc5.velocity.X = npc5.velocity.X + ((npc.velocity.X < 0f) ? 2f : 1f);
						return;
					}
				}
				else
				{
                    npcTrail = false;
                    if (Main.player[npc.target].position.X > npc.position.X - 575f + (float)(flux / 2))
					{
						NPC npc6 = npc;
						npc6.velocity.X = npc6.velocity.X + ((npc.velocity.X < 0f) ? 2f : 1f);
					}
					if (Main.player[npc.target].position.X < npc.position.X - 475f + (float)(flux / 2))
					{
						NPC npc7 = npc;
						npc7.velocity.X = npc7.velocity.X - ((npc.velocity.X > 0f) ? 2f : 1f);
						return;
					}
				}
			}
			else if (Main.player[npc.target].position.X < npc.position.X - 250f || Main.player[npc.target].position.X > npc.position.X + 250f)
			{
				charging = false;
			}
            #endregion

            #region Lightning Bolt
            bulletTimer++;
            if (bulletTimer >= 180 && Main.rand.NextFloat() < .15f)
            {

                stateIdle = false;

                Projectile.NewProjectile(npc.Center.X + -100, npc.Center.Y + - -100 + 60, 0, 20, ModContent.ProjectileType<LightningBolt>(), 30, 0, Main.myPlayer, npc.whoAmI, 30);
                Projectile.NewProjectile(npc.Center.X + - -100, npc.Center.Y + - -100 + 60, 0, 20, ModContent.ProjectileType<LightningBolt>(), 30, 0, Main.myPlayer, npc.whoAmI, 30);

                bulletTimer = 0;
                phaseCount = 2;
                stateIdle = true;
            }
            #endregion

            #region Summon
            summonTimer++;

            if (summonTimer >= 300 && stateEnraged == false)
            {
                NPC.NewNPC((int)npc.Center.X + 20, (int)npc.Center.Y, ModContent.NPCType<MiniLocus>());
                summonTimer = 0;
            }

            if (summonTimer >= 120 && stateEnraged == true)
            {
                NPC.NewNPC((int)npc.Center.X + 20, (int)npc.Center.Y, ModContent.NPCType<MiniLocus>());
                summonTimer = 0;
            }
            #endregion

            #region Wind Waves
            bulletTimer++;
            if (bulletTimer >= 180 && Main.rand.NextFloat() < .25f)
            {
                if (sideRight == true)
                {
                    stateIdle = false;

                    Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 6, -6, ModContent.ProjectileType<WindWaveLocus>(), 100, 0f, Main.myPlayer, npc.whoAmI, 100);
                    Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 6, 6, ModContent.ProjectileType<WindWaveLocus>(), 100, 0f, Main.myPlayer, npc.whoAmI, 100);

                    bulletTimer = 0;
                    phaseCount = 2;
                    stateIdle = true;
                }
                else
                {
                    stateIdle = false;

                    Projectile.NewProjectile(npc.Center.X, npc.Center.Y, -6, 6, ModContent.ProjectileType<WindWaveLocus>(), 100, 0f, Main.myPlayer, npc.whoAmI, 100);
                    Projectile.NewProjectile(npc.Center.X, npc.Center.Y, -6, -6, ModContent.ProjectileType<WindWaveLocus>(), 100, 0f, Main.myPlayer, npc.whoAmI, 100);

                    bulletTimer = 0;
                    phaseCount = 2;
                    stateIdle = true;
                }
            }
            #endregion

            #region Enraged
            if (npc.life <= npc.lifeMax / 2)
            {
                stateEnraged = true;
                stateIdle = false;
            }
            if (npc.alpha == 0 && phaseCount == 1)
            {
                Main.PlaySound(SoundID.DD2_BetsyScream, (int)npc.position.X, (int)npc.position.Y);
                Projectile.NewProjectile(npc.Center.X, npc.Center.Y - 60, 2, 0, ModContent.ProjectileType<LightningBolt>(), 30, 0f, Main.myPlayer, npc.whoAmI, 30);
                Projectile.NewProjectile(npc.Center.X, npc.Center.Y - 60, -2, 0, ModContent.ProjectileType<LightningBolt>(), 30, 0f, Main.myPlayer, npc.whoAmI, 30);

                phaseCount = 2;
                stateIdle = true;

            }
            #endregion
        }
        public override void FindFrame(int frameHeight)
        {
            #region Idle
            if (frame == frameIdle)
            {
                counting += 1.5;
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
                else if (counting < 48.0)
                {
                    npc.frame.Y = frameHeight * 5;
                }
                else if (counting < 56.0)
                {
                    npc.frame.Y = frameHeight * 6;
                }
                else if (counting < 64.0)
                {
                    npc.frame.Y = frameHeight * 7;
                }
                else
                {
                    counting = 0.0;
                }
            }
            #endregion
        }
    }
}
