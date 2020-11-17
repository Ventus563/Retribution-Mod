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

			if (Main.rand.NextFloat() < .05f && npc.CanBeChasedBy())
			{
				Item.NewItem(npc.getRect(), mod.ItemType("soul"));
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
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("snapshot"));
				}
			}
		}
	}
}