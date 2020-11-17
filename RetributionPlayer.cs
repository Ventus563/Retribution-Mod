using Retribution.Dusts;
using Retribution.Items;
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
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using Terraria.GameContent.Events;
using Terraria.Graphics.Shaders;
using Microsoft.Xna.Framework.Input;
using System.Runtime.CompilerServices;

namespace Retribution
{
    public class RetributionPlayer : ModPlayer
    {
        private const int saveVersion = 0;
        public bool minionName = false;
        public bool Pet = false;
        public static bool hasProjectile;
        public bool blackholeMinion = false;

        public bool ZoneMoss = false;
		public bool addSoul = false;

        public override void UpdateBiomes()
        {
            ZoneMoss = (RetributionWorld.mossTiles > 350);
        }

        public override Texture2D GetMapBackgroundImage()
        {
            if (ZoneMoss)
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
			ResetVariables();
		}

		public static RetributionPlayer ModPlayer(Player player)
		{
			return player.GetModPlayer<RetributionPlayer>();
		}

		public float reaperDamageAdd;
		public float reaperDamageMult = 1f;
		public float reaperKnockback;
		public int reaperCrit;

		public int soulCurrent;
		public const int DefaultsoulMax = 25;
		public int soulMax;
		public int soulMax2;
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
			reaperDamageAdd = 0f;
			reaperDamageMult = 1f;
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
				soulCurrent += 1;
				addSoul = false;
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
				Main.LocalPlayer.AddBuff(mod.BuffType("godofdeath"), 3, true);
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
    }
}