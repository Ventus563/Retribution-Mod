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
            Main.npcFrameCount[npc.type] = 15;
        }

        public override void SetDefaults()
        {
            npc.aiStyle = 0;
            npc.lifeMax = 7050;
            npc.damage = 40;
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
            music = mod.GetSoundSlot(SoundType.Music, "Sounds/Music/locust");

            for (int k = 0; k < npc.buffImmune.Length; k++)
            {
                npc.buffImmune[k] = true;
            }
        }
        private double counting;
        private int frame;
        private int frameName = 0;
        private int frameIdle = 0;
        private int frameBlink = 1;
        private int frameShoot = 2;
        private int frameEnraged = 3;
        private bool stateIdle = false;
        private bool stateBlink = false;
        private bool stateShoot = false;
        private bool stateEnraged = false;
        private int opacityTimer;
        private int phaseCount = 0;
        private int bulletTimer;
        private int dashTimer;
        private int soundCount = 0;

		public int counter;
		public int flux;
		public bool shift;
		public bool sideRight;
		public int shifted;
		public int angry;
		public int attackState;
		public bool strike;
		public bool charge;
		public bool charging;

		public override void AI()
        {
            #region Animations
            if (stateIdle == true)
            {
                this.frame = frameIdle;
            }

            if (stateBlink == true)
            {
                this.frame = frameBlink;
            }

            if (stateShoot == true)
            {
                this.frame = frameShoot;
            }
            if (stateEnraged == true)
            {
                this.frame = frameEnraged;
            }
			#endregion

			#region Idle Behavior

			base.npc.ai[0] += 1f;
			base.npc.ai[2] += 1f;
			base.npc.ai[3] += 1f;
			if (base.npc.aiStyle != -1)
			{
				base.npc.ai[1] -= 1f;
			}
			base.npc.TargetClosest(true);
			Player player = Main.player[base.npc.target];
			Vector2 vector = Main.player[base.npc.target].Center + new Vector2(base.npc.Center.X, base.npc.Center.Y);
			Vector2 vector2 = base.npc.Center + new Vector2(base.npc.Center.X, base.npc.Center.Y);
			base.npc.netUpdate = true;

            this.attackState = 0;
            if ((double)base.npc.life < (double)base.npc.lifeMax * 0.82)
            {
                this.angry = 15;
            }
            else
            {
                this.angry = 0;
            }
            if (base.npc.ai[0] == 80f)
            {
                this.counter = 12;
                this.strike = true;
            }
            if (base.npc.ai[2] >= 360f)
            {
                base.npc.velocity.X = 0f;
                base.npc.velocity.Y = 0f;
                base.npc.ai[0] = 0f;
                this.charge = true;
                this.charging = true;
                for (int i = 0; i < 3; i++)
                {
                    int num = Dust.NewDust(new Vector2(base.npc.position.X, base.npc.position.Y) - base.npc.velocity, base.npc.width, base.npc.height, DustID.Electric, -((float)base.npc.spriteDirection * 8f), 0f, 100, default(Color), 0.75f);
                    Dust dust = Main.dust[num];
                    Main.dust[num].velocity *= 0.2f;
                    Main.dust[num].noGravity = true;
                }
            }
            if (base.npc.ai[2] >= 420f)
            {
                base.npc.aiStyle = -1;
                if (this.sideRight)
                {
                    this.sideRight = false;
                }
                else
                {
                    this.sideRight = true;
                }
                Vector2 vector3 = new Vector2(base.npc.Center.X, base.npc.Center.Y);
                float num2 = (float)Math.Atan2((double)(vector3.Y - (player.Center.Y - 350f)), (double)(vector3.X - player.Center.X));
                base.npc.velocity.X = (float)(Math.Cos((double)num2) * 14.0) * -1f;
                base.npc.velocity.Y = (float)(Math.Sin((double)num2) * 14.0) * -1f;
                base.npc.netUpdate = true;
                base.npc.ai[2] = 0f;
            }

            if (player.Center.X > base.npc.Center.X)
			{
				base.npc.spriteDirection = 1;
			}
			else
			{
				base.npc.spriteDirection = -1;
			}
			if (!this.shift)
			{
				this.flux += 2;
			}
			else
			{
				this.flux -= 2;
			}
			if (this.flux > 120 && !this.shift)
			{
				this.shift = true;
			}
			if (this.flux <= -60)
			{
				this.shift = false;
			}
			if (Main.player[base.npc.target].position.Y < base.npc.position.Y + 30f + (float)this.flux)
			{
				NPC npc2 = base.npc;
				npc2.velocity.Y = npc2.velocity.Y - ((base.npc.velocity.Y > 0f) ? 0.8f : 0.07f);
			}
			if (Main.player[base.npc.target].position.Y > base.npc.position.Y + 30f + (float)this.flux)
			{
				NPC npc3 = base.npc;
				npc3.velocity.Y = npc3.velocity.Y + ((base.npc.velocity.Y < 0f) ? 0.8f : 0.07f);
			}
			if (!this.charging)
			{
				base.npc.aiStyle = 14;
				this.charge = false;
				if (this.sideRight)
				{
					if (Main.player[base.npc.target].position.X < base.npc.position.X + 375f + (float)(this.flux / 2))
					{
						NPC npc4 = base.npc;
						npc4.velocity.X = npc4.velocity.X - ((base.npc.velocity.X > 0f) ? 2f : 1f);
					}
					if (Main.player[base.npc.target].position.X > base.npc.position.X + 475f + (float)(this.flux / 2))
					{
						NPC npc5 = base.npc;
						npc5.velocity.X = npc5.velocity.X + ((base.npc.velocity.X < 0f) ? 2f : 1f);
						return;
					}
				}
				else
				{
					if (Main.player[base.npc.target].position.X > base.npc.position.X - 375f + (float)(this.flux / 2))
					{
						NPC npc6 = base.npc;
						npc6.velocity.X = npc6.velocity.X + ((base.npc.velocity.X < 0f) ? 2f : 1f);
					}
					if (Main.player[base.npc.target].position.X < base.npc.position.X - 475f + (float)(this.flux / 2))
					{
						NPC npc7 = base.npc;
						npc7.velocity.X = npc7.velocity.X - ((base.npc.velocity.X > 0f) ? 2f : 1f);
						return;
					}
				}
			}
			else if (Main.player[base.npc.target].position.X < base.npc.position.X - 250f || Main.player[base.npc.target].position.X > base.npc.position.X + 250f)
			{
				this.charging = false;
			}
            #endregion

            /*#region Lightning Bolt
            bulletTimer++;
            if (bulletTimer >= 180 && Main.rand.NextFloat() < .15f)
            {

                stateIdle = false;
                stateShoot = true;
                stateBlink = false;

                Projectile.NewProjectile(npc.Center.X + -100, npc.Center.Y + - -100 - +60, 0, 20, ModContent.ProjectileType<LightningBolt>(), 200, 0f, Main.myPlayer, npc.whoAmI, 200);
                Projectile.NewProjectile(npc.Center.X + - -100, npc.Center.Y + - -100 - +60, 0, 20, ModContent.ProjectileType<LightningBolt>(), 200, 0f, Main.myPlayer, npc.whoAmI, 200);

                bulletTimer = 0;
                phaseCount = 2;
                stateIdle = true;
                stateBlink = false;
                stateShoot = false;
            }
            #endregion

            #region Tornado
            bulletTimer++;
            if (bulletTimer >= 180 && Main.rand.NextFloat() < .15f)
            {

                stateIdle = false;
                stateShoot = true;
                stateBlink = false;

                Projectile.NewProjectile(npc.Center.X + -100, npc.Center.Y + - -100 - 60, 0, 0, ModContent.ProjectileType<Tornado>(), 200, 0f, Main.myPlayer, npc.whoAmI, 200);
                Projectile.NewProjectile(npc.Center.X + - -100, npc.Center.Y + - -100 - 60, 0, 0, ModContent.ProjectileType<Tornado>(), 200, 0f, Main.myPlayer, npc.whoAmI, 200);

                bulletTimer = 0;
                phaseCount = 2;
                stateIdle = true;
                stateBlink = false;
                stateShoot = false;
            }
            #endregion

            #region Wind Waves
            bulletTimer++;
            if (bulletTimer >= 180 && Main.rand.NextFloat() < .25f)
            {

                stateIdle = false;
                stateShoot = true;
                stateBlink = false;

                Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 0, -8, ModContent.ProjectileType<WindWaveLocus>(), 100, 0f, Main.myPlayer, npc.whoAmI, 100);
                Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 8, -8, ModContent.ProjectileType<WindWaveLocus>(), 100, 0f, Main.myPlayer, npc.whoAmI, 100);
                Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 8, 0, ModContent.ProjectileType<WindWaveLocus>(), 100, 0f, Main.myPlayer, npc.whoAmI, 100);
                Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 8, 8, ModContent.ProjectileType<WindWaveLocus>(), 100, 0f, Main.myPlayer, npc.whoAmI, 100);
                Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 0, 8, ModContent.ProjectileType<WindWaveLocus>(), 100, 0f, Main.myPlayer, npc.whoAmI, 100);
                Projectile.NewProjectile(npc.Center.X, npc.Center.Y, -8, 8, ModContent.ProjectileType<WindWaveLocus>(), 100, 0f, Main.myPlayer, npc.whoAmI, 100);
                Projectile.NewProjectile(npc.Center.X, npc.Center.Y, -8, 0, ModContent.ProjectileType<WindWaveLocus>(), 100, 0f, Main.myPlayer, npc.whoAmI, 100);
                Projectile.NewProjectile(npc.Center.X, npc.Center.Y, -8, -8, ModContent.ProjectileType<WindWaveLocus>(), 100, 0f, Main.myPlayer, npc.whoAmI, 100);

                bulletTimer = 0;
                phaseCount = 2;
                stateIdle = true;
                stateBlink = false;
                stateShoot = false;
            }
            #endregion

            #region Enraged
            if (npc.life <= npc.lifeMax / 2)
            {
                stateEnraged = true;
                stateIdle = false;
                stateBlink = false;
                stateShoot = false;
            }
            if (npc.alpha == 0 && phaseCount == 1)
            {
                Main.PlaySound(SoundID.DD2_BetsyScream, (int)npc.position.X, (int)npc.position.Y);
                Projectile.NewProjectile(npc.Center.X, npc.Center.Y - 60, 2, 0, ModContent.ProjectileType<LightningBolt>(), 200, 0f, Main.myPlayer, npc.whoAmI, 200);
                Projectile.NewProjectile(npc.Center.X, npc.Center.Y - 60, -2, 0, ModContent.ProjectileType<LightningBolt>(), 200, 0f, Main.myPlayer, npc.whoAmI, 200);

                phaseCount = 2;
                stateIdle = true;
                stateBlink = false;
                stateShoot = false;

            }*/
        }
        public override void FindFrame(int frameHeight)
        {
            #region Idle
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

            if (this.frame == frameIdle && stateShoot == true)
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

            #region Blink
            #endregion

            #region Shoot
            if (this.frame == frameShoot)
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

            #region Enraged
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

            if (this.frame == frameEnraged && stateShoot == true)
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
    }
}

