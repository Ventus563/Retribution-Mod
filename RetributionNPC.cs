using System.IO;
using System.Collections.Generic;
using Terraria;
using System;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.World.Generation;
using Microsoft.Xna.Framework;
using Terraria.GameContent.Generation;
using System.Linq;
using Microsoft.Xna.Framework.Graphics;
using Terraria.DataStructures;
using Terraria.GameInput;
using Terraria.ModLoader.IO;


namespace Retribution
{
	public class RetributionNPC : GlobalNPC
	{
		public override void HitEffect(NPC npc, int hitDirection, double damage)
		{
			var retributionPlayer = Main.LocalPlayer.GetModPlayer<RetributionPlayer>();

			if (npc.CanBeChasedBy())
			{
				if (Main.rand.NextFloat() < .50f)
				{
					retributionPlayer.addSoul = true;
				}
			}

			if (npc.life <= 0 && npc.CanBeChasedBy())
			{
				retributionPlayer.addSoul = true;
			}
		}


        public override void NPCLoot(NPC npc)
		{

			if (npc.type == NPCID.EyeofCthulhu)
			{
				if (Main.rand.NextFloat() < .20f)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("snapshot"), 1);
				}
			}

            #region Souls
            if (Main.player[Player.FindClosest(npc.position, npc.width, npc.height)].ZoneDesert)
			{
				if (Main.rand.NextFloat() < .15f)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("desertsoul"));
				}
			}
			if (Main.player[Player.FindClosest(npc.position, npc.width, npc.height)].ZoneSnow)
			{
				if (Main.rand.NextFloat() < .15f)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("frozensoul"));
				}
			}
			if (Main.player[Player.FindClosest(npc.position, npc.width, npc.height)].ZoneCorrupt)
			{
				if (Main.rand.NextFloat() < .15f)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("evilsoul"));
				}
			}
			if (Main.player[Player.FindClosest(npc.position, npc.width, npc.height)].ZoneCrimson)
			{
				if (Main.rand.NextFloat() < .15f)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("evilsoul"));
				}
			}
			if (Main.player[Player.FindClosest(npc.position, npc.width, npc.height)].ZoneJungle)
			{
				if (Main.rand.NextFloat() < .15f)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("junglesoul"));
				}
			}
			if (Main.player[Player.FindClosest(npc.position, npc.width, npc.height)].ZoneRockLayerHeight)
			{
				if (Main.rand.NextFloat() < .15f)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("cavernsoul"));
				}
			}
			if (Main.player[Player.FindClosest(npc.position, npc.width, npc.height)].ZoneUnderworldHeight)
			{
				if (Main.rand.NextFloat() < .15f)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("damnedsoul"));
				}
			}
			if (Main.player[Player.FindClosest(npc.position, npc.width, npc.height)].ZoneDungeon)
			{
				if (Main.rand.NextFloat() < .15f)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("dungeonsoul"));
				}
			}
			#endregion
		}
	}
}