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

				AddMusicBox(GetSoundSlot(SoundType.Music, "Sounds/Music/cursedprotector"), ItemType("CursedProtector"), TileType("CursedProtectorBox"));
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
					"Retribution: Souls",
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
				GetSoundSlot(SoundType.Music, "Sounds/Music/cursedprotector"),
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
			if (Main.LocalPlayer.GetModPlayer<RetributionPlayer>().ZoneSwamp)
			{
				music = GetSoundSlot(SoundType.Music, "Sounds/Music/moss");
			}
		}

		public override void ModifySunLightColor(ref Color tileColor, ref Color backgroundColor)
		{
			if (RetributionWorld.swampTiles <= 0)
			{
				return;
			}

			float exampleStrength = RetributionWorld.swampTiles / 200f;
			exampleStrength = Math.Min(exampleStrength, 1f);

			int sunR = backgroundColor.R;
			int sunG = backgroundColor.G;
			int sunB = backgroundColor.B;
			// Remove some green and more red.
			sunR -= (int)(180f * exampleStrength * (backgroundColor.R / 255f));
			sunB -= (int)(90f * exampleStrength * (backgroundColor.B / 255f));
			sunR = Utils.Clamp(sunR, 15, 255);
			sunG = Utils.Clamp(sunG, 15, 255);
			sunB = Utils.Clamp(sunB, 15, 255);
			backgroundColor.R = (byte)sunR;
			backgroundColor.G = (byte)sunG;
			backgroundColor.B = (byte)sunB;
		}

		public override void PostSetupContent()
		{
			Mod bossChecklist = ModLoader.GetMod("BossChecklist");
			if (bossChecklist != null)
			{
				bossChecklist.Call(
					"AddBoss",
					7f,
					ModContent.NPCType<NPCs.Bosses.Morbus.Morbus>(),
					this,
					"Morbus",
					(Func<bool>)(() => RetributionWorld.downedMorbus),
					ModContent.ItemType<Items.Summons.rottenfang>(),
					new List<int> { ModContent.ItemType<Items.scythemold>(), ModContent.ItemType<Items.scythemold>() },
					new List<int> { ModContent.ItemType<Items.scythemold>(), ModContent.ItemType<Items.scythemold>() },
					"Can be summoned at night time in the Corruption",
					"",
					"Retribution/NPCs/Bosses/Morbus/Morbus_Thumb");

				bossChecklist.Call(
					"AddMiniBoss",
					1.1f,
					ModContent.NPCType<NPCs.Minibosses.sanguine>(),
					this,
					"Sanguine",
					(Func<bool>)(() => RetributionWorld.downedSanguine),
					null,
					new List<int> { ModContent.ItemType<Items.scythemold>(), ModContent.ItemType<Items.scythemold>() },
					new List<int> { ModContent.ItemType<Items.scythemold>(), ModContent.ItemType<Items.scythemold>() },
					"Has a 5% chance to spawn in the Crimson when it's raining",
					"",
					"",
					(Func<bool>)(() => WorldGen.crimson == true));

				bossChecklist.Call(
					"AddMiniBoss",
					1.2f,
					ModContent.NPCType<NPCs.Minibosses.vilacious>(),
					this,
					"Vilacious",
					(Func<bool>)(() => RetributionWorld.downedVilacious),
					null,
					new List<int> { ModContent.ItemType<Items.scythemold>(), ModContent.ItemType<Items.scythemold>() },
					new List<int> { ModContent.ItemType<Items.scythemold>(), ModContent.ItemType<Items.scythemold>() },
					"Has a 5% chance to spawn in the Corruption when it's raining",
					"",
					"",
					(Func<bool>)(() => WorldGen.crimson == false));
			}
		}
	}
}