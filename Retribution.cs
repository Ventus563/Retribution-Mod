using Retribution;
using Retribution.Tiles;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Graphics;
using System;
using System.Collections.Generic;
using System.IO;
using Terraria;
using Terraria.GameContent.Dyes;
using Terraria.GameContent.UI;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.UI;
using static Terraria.ModLoader.ModContent;
using Retribution.UI;
using Retribution.NPCs.Bosses.Kane;

namespace Retribution
{
	public class Retribution : Mod
	{

		private UserInterface _soulbarUserInterface;

		internal soulbar soulbar;

        public override void Load()
        {
			if (!Main.dedServ)
			{
				soulbar = new soulbar();
				_soulbarUserInterface = new UserInterface();
				_soulbarUserInterface.SetState(soulbar);
			}
		}

		public override void UpdateUI(GameTime gameTime)
		{
			_soulbarUserInterface?.Update(gameTime);
		}

		public override void ModifyInterfaceLayers(List<GameInterfaceLayer> layers)
		{
			int resourceBarIndex = layers.FindIndex(layer => layer.Name.Equals("Vanilla: Resource Bars"));
			if (resourceBarIndex != -1)
			{
				layers.Insert(resourceBarIndex, new LegacyGameInterfaceLayer(
					"Retribution: Soul Fragments",
					delegate {
						_soulbarUserInterface.Draw(Main.spriteBatch, new GameTime());
						return true;
					},
					InterfaceScaleType.UI)
				);
			}
		}

		public override void Close()
		{
			var slots = new int[] {
				GetSoundSlot(SoundType.Music, "Sounds/Music/moss"),
				GetSoundSlot(SoundType.Music, "Sounds/Music/kane")
			};
			foreach (var slot in slots)
			{
				if (Main.music.IndexInRange(slot) && Main.music[slot]?.IsPlaying == true)
				{
					Main.music[slot].Stop(Microsoft.Xna.Framework.Audio.AudioStopOptions.Immediate);
				}
			}
			base.Close();
		}

		public override void UpdateMusic(ref int music, ref MusicPriority priority)
        {
			if (Main.LocalPlayer.GetModPlayer<RetributionPlayer>().ZoneMoss)
			{
				music = GetSoundSlot(SoundType.Music, "Sounds/Music/moss");
			}
		}

		/*public override void ModifySunLightColor(ref Color tileColor, ref Color backgroundColor)
		{
			if (RetributionWorld.mossTiles <= 0)
			{
				return;
			}

			if (RetributionWorld.mossTiles > 350)
			{
				float Strength = RetributionWorld.mossTiles / 200f;
				Strength = Math.Min(Strength, 1f);

				int sunR = backgroundColor.R;
				int sunG = backgroundColor.G;
				int sunB = backgroundColor.B;

				sunR = Utils.Clamp(sunR, 3, 255);
				sunG = Utils.Clamp(sunG, 50, 255);
				sunB = Utils.Clamp(sunB, 150, 155);

				backgroundColor.R = (byte)sunR;
				backgroundColor.G = (byte)sunG;
				backgroundColor.B = (byte)sunB;
			}
		}*/

		public override void PostSetupContent()
		{
			Mod bossChecklist = ModLoader.GetMod("BossChecklist");
			if (bossChecklist != null)
			{
				bossChecklist.Call(
					"AddBoss",
					6.5f,
					ModContent.NPCType<NPCs.Bosses.Kane.Kane>(),
					this, // Mod
					"Kāne, the God of Life",
					(Func<bool>)(() => RetributionWorld.downedKane),
					ModContent.ItemType<Items.mysterioustikitotem>(),
					new List<int> { ModContent.ItemType<Items.scythemold>(), ModContent.ItemType<Items.scythemold>() },
					new List<int> { ModContent.ItemType<Items.scythemold>(), ModContent.ItemType<Items.scythemold>() },
					"Can be summoned any time of day in the Jungle",
					"",
					"Retribution/NPCs/Bosses/Kane/Kane_Boss");
			}
		}
	}
}