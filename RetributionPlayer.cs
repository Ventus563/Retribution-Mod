using Retribution.Dusts;
using Retribution.Items;
using Retribution.Items.StarterBags;
using Retribution.NPCs;
using Retribution.Projectiles.Minions;
using Retribution.Projectiles;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameInput;
using Terraria.ID;
using static Terraria.ModLoader.ModContent;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using Terraria.GameContent.Events;
using Terraria.Graphics.Shaders;
using Microsoft.Xna.Framework.Input;
using System.Runtime.CompilerServices;
using Terraria.Graphics.Effects;

namespace Retribution
{
    public class RetributionPlayer : ModPlayer
    {
        private const int saveVersion = 0;
        public bool minionName = false;
        public bool Pet = false;
        public static bool hasProjectile;
        public bool blackholeMinion = false;
		public bool peeperMinion = false;

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
            blackholeMinion = false;
			peeperMinion = false;
			ResetVariables();
		}

		public static RetributionPlayer ModPlayer(Player player)
		{
			return player.GetModPlayer<RetributionPlayer>();
		}

		public float reaperDamage = 1f;
		public float reaperKnockback;
		public int reaperCrit;

		public int soulCurrent;
		public const int DefaultsoulMax = 20;
		public int soulMax;
		public int soulMax2;
		public int soulRecieve = 0;
		public static readonly Color Healsoul = new Color(187, 91, 201);

        public override void Initialize()
		{
			soulMax = DefaultsoulMax;
		}

		public override void UpdateDead()
		{
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
				Main.LocalPlayer.AddBuff(mod.BuffType("godofdeath"), 180, true);
				deathBuff = false;
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
			if (Main.expertMode)
			{
				Item item = new Item();
				item.SetDefaults(ModContent.ItemType<emptybag>());
				item.stack = 1;
				items.Add(item);
			}
		}
	}
}