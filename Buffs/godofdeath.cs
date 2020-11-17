using Retribution.Dusts;
using Retribution.Projectiles.Minions;
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Retribution.Buffs
{	public class godofdeath : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("God of Death");
			Description.SetDefault("15% increased soul damage");
			Main.buffNoTimeDisplay[Type] = false;
		}

		public override void Update(Player player, ref int buffIndex)
		{
			RetributionPlayer modPlayer = RetributionPlayer.ModPlayer(player);

			modPlayer.reaperDamageAdd += 0.15f;
		}
	}
}