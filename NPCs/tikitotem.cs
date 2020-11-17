using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.IO;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Retribution;


namespace Retribution.NPCs
{
	// Party Zombie is a pretty basic clone of a vanilla NPC. To learn how to further adapt vanilla NPC behaviors, see https://github.com/tModLoader/tModLoader/wiki/Advanced-Vanilla-Code-Adaption#example-npc-npc-clone-with-modified-projectile-hoplite
	public class tikitotem : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Tiki Totem");
		}

		public override void SetDefaults()
		{
			npc.width = 44;
			npc.height = 84;
			npc.damage = 50;
			npc.defense = 100;
			npc.lifeMax = 200;
			npc.DeathSound = SoundID.NPCDeath2;
			npc.value = 60f;
			npc.knockBackResist = 10000f;
			npc.aiStyle = NPCID.VoodooDemon;
			aiType = NPCID.VoodooDemon;

			npc.CloneDefaults(NPCID.DungeonSpirit);
		}
	}
}
