using Retribution.Items.StarterBags;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using Terraria;
using Retribution.Items.Consumables;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using Terraria.ID;
using Retribution.Items.Weapons.Mage;
using Retribution.Items.Accessories;
using Retribution.Buffs;

namespace Retribution
{
	public class RetributionPlayer : ModPlayer
	{
		private const int saveVersion = 0;
		public bool minionName = false;
		public bool Pet = false;
		public static bool hasProjectile;

        #region Minions
        public bool blackholeMinion = false;
		public bool peeperMinion = false;
		public bool creeperMinion = false;
		public bool eWormMinion = false;
		public bool waterwarriorMinion = false;
        #endregion

        public bool ZoneSwamp = false;
		public bool addSoul = false;


		public override void UpdateBiomes()
		{
			ZoneSwamp = (RetributionWorld.swampTiles > 350);

		}

		public override Texture2D GetMapBackgroundImage()
		{
			if (ZoneSwamp)
			{
				return mod.GetTexture("Backgrounds/MossnMapBackground");
			}
			return null;
		}
		public override void ResetEffects()
		{
			minionName = false;
			Pet = false;
			tFrost = false;
			frostHeart = false;

			#region Minions
			eWormMinion = false;
			blackholeMinion = false;
			peeperMinion = false;
			waterwarriorMinion = false;
			#endregion
			ResetVariables();
		}

		public static RetributionPlayer ModPlayer(Player player)
		{
			return player.GetModPlayer<RetributionPlayer>();
		}
		public float reaperDamage = 1f;
		public float reaperKnockback;
		public int reaperCrit;

		public bool tFrost;

		public int soulCurrent;
		public const int DefaultsoulMax = 20;
		public int soulMax;
		public int soulMax2;
		public int soulRecieve = 0;

		public static bool canUseFrostHeart = false;
		public static bool frostHeart = false;
		private static int frostHeartUsed = 0;

		public static readonly Color Healsoul = new Color(187, 91, 201);

		public override void Initialize()
		{
			soulMax = DefaultsoulMax;
		}

        public override void OnHitAnything(float x, float y, Entity victim)
        {
			if (player.whoAmI == Main.myPlayer && canUseFrostHeart == true && frostHeartUsed == 0)
			{
				Projectile.NewProjectile(player.Center.X, player.Center.Y, 0, -8, ModContent.ProjectileType<TundraBallSpike>(), 15, 0f, Main.myPlayer);
				Projectile.NewProjectile(player.Center.X, player.Center.Y, 6, -6, ModContent.ProjectileType<TundraBallSpike>(), 15, 0f, Main.myPlayer);
				Projectile.NewProjectile(player.Center.X, player.Center.Y, 8, 0, ModContent.ProjectileType<TundraBallSpike>(), 15, 0f, Main.myPlayer);
				Projectile.NewProjectile(player.Center.X, player.Center.Y, 6, 6, ModContent.ProjectileType<TundraBallSpike>(), 15, 0f, Main.myPlayer);
				Projectile.NewProjectile(player.Center.X, player.Center.Y, 0, 8, ModContent.ProjectileType<TundraBallSpike>(), 15, 0f, Main.myPlayer);
				Projectile.NewProjectile(player.Center.X, player.Center.Y, -6, 6, ModContent.ProjectileType<TundraBallSpike>(), 15, 0f, Main.myPlayer);
				Projectile.NewProjectile(player.Center.X, player.Center.Y, -8, 0, ModContent.ProjectileType<TundraBallSpike>(), 15, 0f, Main.myPlayer);
				Projectile.NewProjectile(player.Center.X, player.Center.Y, -6, -6, ModContent.ProjectileType<TundraBallSpike>(), 15, 0f, Main.myPlayer);

				frostHeartUsed = 1;

				player.AddBuff(ModContent.BuffType<FrozenHeart>(), 180);
			}
        }

        public override void UpdateDead()
		{
			tFrost = false;
			ResetVariables();
		}

		#region Reaper Class
		private void ResetVariables()
		{
			reaperDamage = 1f;
			reaperKnockback = 0f;
			reaperCrit = 0;
			soulMax2 = soulMax;
		}

		public override void PostUpdateMiscEffects()
		{
			UpdateResource();
		}

		private void UpdateResource()
		{
			if (addSoul == true)
			{
				soulCurrent += 1 + soulRecieve;
				addSoul = false;
				soulRecieve = 0;
			}

			soulCurrent = Utils.Clamp(soulCurrent, 0, soulMax2);
		}

		public bool deathBuff = false;

		public override void PreUpdate()
		{
			if (soulCurrent == soulMax)
			{
				deathBuff = true;
			}

			if (deathBuff == true)
			{
				Main.LocalPlayer.AddBuff(ModContent.BuffType<godofdeath>(), 180, true);
				deathBuff = false;
			}

			if (player.whoAmI == Main.myPlayer && frostHeart == true && !player.HasBuff(ModContent.BuffType<FrozenHeart>()))
			{
				frostHeartUsed = 0;
				canUseFrostHeart = true;
			}
		}
		#endregion

		#region Save/Load
		public override TagCompound Save()
		{
			return new TagCompound {
				{"soulStorage", soulMax},
				{"soulCurrent", soulCurrent},
			};
		}

		public override void Load(TagCompound tag)
		{
			soulMax = tag.GetInt("soulStorage");
			soulCurrent = tag.GetInt("soulCurrent");
		}
		#endregion

		public override void SetupStartInventory(IList<Item> items, bool mediumcoreDeath)
		{
			Item item = new Item();
			item.SetDefaults(ModContent.ItemType<emptybag>());
			item.stack = 1;
			items.Add(item);

			if (Main.expertMode)
			{
				Item item2 = new Item();
				item2.SetDefaults(ModContent.ItemType<DesecratedAmulet>());
				item2.stack = 1;
				items.Add(item2);
			}
		}

		public override void UpdateBadLifeRegen()
		{
			if (tFrost)
			{
				if (player.lifeRegen > 0)
				{
					player.lifeRegen = 0;
				}
				player.lifeRegenTime = 0;
				player.lifeRegen -= 4;
			}
		}

        public override void PostUpdateRunSpeeds()
        {
			if (player.whoAmI == Main.myPlayer && player.HasBuff(ModContent.BuffType<TerrariasFrost>()))
			{
				player.accRunSpeed = 4;
			}
		}

        public override void DrawEffects(PlayerDrawInfo drawInfo, ref float r, ref float g, ref float b, ref float a, ref bool fullBright)
        {
			if (tFrost)
			{
				if (Main.rand.Next(4) < 3)
				{
					int dust = Dust.NewDust(player.position - new Vector2(2f, 2f), player.width + 4, player.height + 4, 185, player.velocity.X * 0.4f, player.velocity.Y * 0.4f, 100, default(Color));
					Main.dust[dust].noGravity = true;
					Main.dust[dust].velocity *= 1.8f;
					Main.dust[dust].velocity.Y -= 0.5f;
					if (Main.rand.NextBool(4))
					{
						Main.dust[dust].noGravity = false;
						Main.dust[dust].scale *= 0.05f;
					}
				}
				Lighting.AddLight(player.position, 0.1f, 0.1f, 0.7f);
			}
		}
    }
}