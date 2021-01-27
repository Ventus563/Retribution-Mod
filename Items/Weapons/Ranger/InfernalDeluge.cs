using System;
using System.IO;
using Microsoft.Xna.Framework;
using Terraria;
using Retribution;
using Terraria.GameContent.Events;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using Retribution.Projectiles;
using Microsoft.Xna.Framework.Graphics;

namespace Retribution.Items.Weapons.Ranger
{
	public class InfernalDeluge : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Infernal Deluge");
			Tooltip.SetDefault("Turns arrows into Infernal Fireballs");
		}

		public override void SetDefaults()
		{
			item.damage = 30;
			item.ranged = true;
			item.width = 22;
			item.height = 64;
			item.useTime = 20;
			item.useAnimation = 20;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.noMelee = true;
			item.knockBack = 15;
			item.value = 10000;
			item.rare = ItemRarityID.Green;
			item.UseSound = SoundID.Item5;
			item.autoReuse = true;
			item.shoot = 10;
			item.shootSpeed = 10f;
			item.useAmmo = AmmoID.Arrow;
		}

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
			Projectile.NewProjectile(position.X, position.Y, speedX, speedY, ModContent.ProjectileType<delugeproj>(), damage, knockBack, player.whoAmI, 0f, 0f);
			return false;
		}
    }

	public class delugeproj : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.width = 1;
			projectile.height = 1;
			projectile.aiStyle = 1;
			projectile.friendly = true;
			projectile.alpha = 255;
			projectile.tileCollide = true;
			projectile.penetrate = 1;
			projectile.extraUpdates = 1;
		}

		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			target.AddBuff(BuffID.ShadowFlame, 120);

			if (target.life <= 0)
			{
				Projectile.NewProjectile(target.Center.X, target.Center.Y, 0, -1, ModContent.ProjectileType<delugehome>(), 100, 5f, Main.myPlayer);
			}
		}

		public override void Kill(int timeLeft)
		{
			Main.PlaySound(SoundID.Dig, (int)projectile.position.X, (int)projectile.position.Y);
			Vector2 usePos = projectile.position;

			Vector2 rotVector = (projectile.rotation - MathHelper.ToRadians(90f)).ToRotationVector2();
			usePos += rotVector * 16f;

			const int NUM_DUSTS = 20;

			for (int i = 0; i < NUM_DUSTS; i++)
			{
				Dust dust;
				dust = Main.dust[Terraria.Dust.NewDust(projectile.position, projectile.width, projectile.height, DustID.Shadowflame, 0f, 0f, 0, new Color(255, 0, 201), 2f)];
				dust.noGravity = true;
			}
		}


		public override void AI()
        {
			for (int d = 0; d < 5; d++)
			{
				Dust dust;
				dust = Main.dust[Terraria.Dust.NewDust(projectile.position, projectile.width, projectile.height, DustID.Shadowflame, 0f, 0f, 150, new Color(0, 142, 255), 1f)];
				dust.noGravity = true;
			}
		}
    }

	public class delugehome : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.width = 1;
			projectile.height = 1;
			projectile.aiStyle = 1;
			projectile.friendly = true;
			projectile.alpha = 255;
			projectile.tileCollide = false;
			projectile.penetrate = 1;
			projectile.extraUpdates = 8;
		}

		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			target.AddBuff(BuffID.ShadowFlame, 120);
		}

		public override void Kill(int timeLeft)
		{
			Main.PlaySound(SoundID.Dig, (int)projectile.position.X, (int)projectile.position.Y);
			Vector2 usePos = projectile.position;

			Vector2 rotVector = (projectile.rotation - MathHelper.ToRadians(90f)).ToRotationVector2();
			usePos += rotVector * 16f;

			const int NUM_DUSTS = 20;

			for (int i = 0; i < NUM_DUSTS; i++)
			{
				Dust dust;
				dust = Main.dust[Terraria.Dust.NewDust(projectile.position, projectile.width, projectile.height, DustID.Shadowflame, 0f, 0f, 0, new Color(255, 0, 201), 2f)];
				dust.noGravity = true;
			}
		}


		public override void AI()
		{
			Dust dust;
			dust = Terraria.Dust.NewDustPerfect(projectile.position, 62, new Vector2(0f, 0f), 0, new Color(255, 255, 255), 1f);
			dust.noGravity = true;

			float num132 = (float)Math.Sqrt((double)(projectile.velocity.X * projectile.velocity.X + projectile.velocity.Y * projectile.velocity.Y));
			float num133 = projectile.localAI[0];
			if (num133 == 0f)
			{
				projectile.localAI[0] = num132;
				num133 = num132;
			}
			float num134 = projectile.position.X;
			float num135 = projectile.position.Y;
			float num136 = 1000f;
			bool flag3 = false;
			int num137 = 0;
			if (projectile.ai[1] == 0f)
			{
				for (int num138 = 0; num138 < 200; num138++)
				{
					if (Main.npc[num138].CanBeChasedBy(this, false) && (projectile.ai[1] == 0f || projectile.ai[1] == (float)(num138 + 1)))
					{
						float num139 = Main.npc[num138].position.X + (float)(Main.npc[num138].width / 2);
						float num140 = Main.npc[num138].position.Y + (float)(Main.npc[num138].height / 2);
						float num141 = Math.Abs(projectile.position.X + (float)(projectile.width / 2) - num139) + Math.Abs(projectile.position.Y + (float)(projectile.height / 2) - num140);
						if (num141 < num136 && Collision.CanHit(new Vector2(projectile.position.X + (float)(projectile.width / 2), projectile.position.Y + (float)(projectile.height / 2)), 1, 1, Main.npc[num138].position, Main.npc[num138].width, Main.npc[num138].height))
						{
							num136 = num141;
							num134 = num139;
							num135 = num140;
							flag3 = true;
							num137 = num138;
						}
					}
				}
				if (flag3)
				{
					projectile.ai[1] = (float)(num137 + 1);
				}
				flag3 = false;
			}
			if (projectile.ai[1] > 0f)
			{
				int num142 = (int)(projectile.ai[1] - 1f);
				if (Main.npc[num142].active && Main.npc[num142].CanBeChasedBy(this, true) && !Main.npc[num142].dontTakeDamage)
				{
					float num143 = Main.npc[num142].position.X + (float)(Main.npc[num142].width / 2);
					float num144 = Main.npc[num142].position.Y + (float)(Main.npc[num142].height / 2);
					if (Math.Abs(projectile.position.X + (float)(projectile.width / 2) - num143) + Math.Abs(projectile.position.Y + (float)(projectile.height / 2) - num144) < 1000f)
					{
						flag3 = true;
						num134 = Main.npc[num142].position.X + (float)(Main.npc[num142].width / 2);
						num135 = Main.npc[num142].position.Y + (float)(Main.npc[num142].height / 2);
					}
				}
				else
				{
					projectile.ai[1] = 0f;
				}
			}
			if (!projectile.friendly)
			{
				flag3 = false;
			}
			if (flag3)
			{
				float num145 = num133;
				Vector2 vector10 = new Vector2(projectile.position.X + (float)projectile.width * 0.5f, projectile.position.Y + (float)projectile.height * 0.5f);
				float num146 = num134 - vector10.X;
				float num147 = num135 - vector10.Y;
				float num148 = (float)Math.Sqrt((double)(num146 * num146 + num147 * num147));
				num148 = num145 / num148;
				num146 *= num148;
				num147 *= num148;
				int num149 = 8;
				projectile.velocity.X = (projectile.velocity.X * (float)(num149 - 1) + num146) / (float)num149;
				projectile.velocity.Y = (projectile.velocity.Y * (float)(num149 - 1) + num147) / (float)num149;
			}
		}
	}
}