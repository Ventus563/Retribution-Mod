using Retribution.Dusts;
using Retribution.Projectiles.Minions;
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Retribution.Buffs
{	public class TerrariasFrost : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Terraria's Frost");
			Description.SetDefault("Frostbite is slowly nipping at you");
			Main.debuff[Type] = true;
			Main.pvpBuff[Type] = true;
			Main.buffNoSave[Type] = true;
		}



		public override void Update(Player player, ref int buffIndex)
		{
			player.GetModPlayer<RetributionPlayer>().tFrost = true;
		}

        public override void Update(NPC npc, ref int buffIndex)
        {
			npc.GetGlobalNPC<RetributionNPC>().tFrost = true;
		}
	}
}