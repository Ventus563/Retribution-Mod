using System;
using System.IO;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Retribution.Items.Weapons.Ranger;
using Retribution.Items.Accessories;
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

			if (npc.type == NPCID.EyeofCthulhu && !Main.expertMode)
			{
				if (Main.rand.NextFloat() < .20f)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("snapshot"), 1);
				}

				if (Main.rand.NextFloat() < .20f)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("peeperstaff"), 1);
				}
			}

			if (npc.type == NPCID.EyeofCthulhu && !Main.expertMode)
			{
				if (Main.rand.NextFloat() < .20f)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("honeyray"), 1);
				}
			}

			if (npc.type == NPCID.WallCreeper)
			{
				if (Main.rand.NextFloat() < .02f)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("arachnoblaster"), 1);
				}
			}

			if (npc.type == NPCID.WallCreeperWall)
			{
				if (Main.rand.NextFloat() < .02f)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("arachnoblaster"), 1);
				}
			}

			if (npc.type == NPCID.WallofFlesh && !Main.expertMode)
			{
				if (!Main.expertMode && Main.rand.NextFloat() < .15f)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("reaperemblem"), 1);
				}
			}

				if (npc.type == NPCID.KingSlime && !Main.expertMode)
			{
				if (Main.rand.NextFloat() < .20f)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("kingskatana"), 1);
				}
			}

			#region Unique Drops
			if (Main.LocalPlayer.ZoneCrimson)
			{
				if (Main.rand.NextFloat() < .002f)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("soulcontract"));
				}
			}
			#endregion

			#region Death Fragment
			if (npc.type == NPCID.LunarTowerSolar && Main.expertMode)
			{
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("deathfragment"), Main.rand.Next(6, 15));
			}

			if (npc.type == NPCID.LunarTowerSolar && !Main.expertMode)
			{
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("deathfragment"), Main.rand.Next(5, 10));
			}

			if (npc.type == NPCID.LunarTowerNebula && Main.expertMode)
			{
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("deathfragment"), Main.rand.Next(6, 15));
			}

			if (npc.type == NPCID.LunarTowerNebula && !Main.expertMode)
			{
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("deathfragment"), Main.rand.Next(5, 10));
			}

			if (npc.type == NPCID.LunarTowerVortex && Main.expertMode)
			{
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("deathfragment"), Main.rand.Next(6, 15));
			}

			if (npc.type == NPCID.LunarTowerVortex && !Main.expertMode)
			{
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("deathfragment"), Main.rand.Next(5, 10));
			}

			if (npc.type == NPCID.LunarTowerStardust && Main.expertMode)
			{
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("deathfragment"), Main.rand.Next(6, 15));
			}

			if (npc.type == NPCID.LunarTowerStardust && !Main.expertMode)
			{
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("deathfragment"), Main.rand.Next(5, 10));
			}
			#endregion

			#region Souls
			if (Main.player[Player.FindClosest(npc.position, npc.width, npc.height)].ZoneDesert)
			{
				if (Main.rand.NextFloat() < .05f)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("desertsoul"));
				}
			}
			if (Main.player[Player.FindClosest(npc.position, npc.width, npc.height)].ZoneSnow)
			{
				if (Main.rand.NextFloat() < .05f)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("frozensoul"));
				}
			}
			if (Main.player[Player.FindClosest(npc.position, npc.width, npc.height)].ZoneCorrupt)
			{
				if (Main.rand.NextFloat() < .05f)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("evilsoul"));
				}
			}
			if (Main.player[Player.FindClosest(npc.position, npc.width, npc.height)].ZoneCrimson)
			{
				if (Main.rand.NextFloat() < .05f)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("evilsoul"));
				}
			}
			if (Main.player[Player.FindClosest(npc.position, npc.width, npc.height)].ZoneJungle)
			{
				if (Main.rand.NextFloat() < .05f)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("junglesoul"));
				}
			}
			if (Main.player[Player.FindClosest(npc.position, npc.width, npc.height)].ZoneRockLayerHeight)
			{
				if (Main.rand.NextFloat() < .05f)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("cavernsoul"));
				}
			}
			if (Main.player[Player.FindClosest(npc.position, npc.width, npc.height)].ZoneUnderworldHeight)
			{
				if (Main.rand.NextFloat() < .05f)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("hellfiresoul"));
				}
			}
			if (Main.player[Player.FindClosest(npc.position, npc.width, npc.height)].ZoneDungeon)
			{
				if (Main.rand.NextFloat() < .05f)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("dungeonsoul"));
				}
			}
			#endregion
		}

		public override void SetupShop(int type, Chest shop, ref int nextSlot)
		{
			if (type == NPCID.ArmsDealer)
			{
				shop.item[nextSlot].SetDefaults(ModContent.ItemType<autorifle>());
				nextSlot++;
			}
		}
	}
}