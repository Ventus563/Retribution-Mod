using Retribution.Dusts;
using Retribution.Projectiles.Minions;
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Retribution.Buffs
{	public class FrozenHeart : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Frozen Heart");
			Description.SetDefault("The Frost Heart is suspending its use until you thaw off.");
			Main.debuff[Type] = true;
			Main.pvpBuff[Type] = true;
			Main.buffNoSave[Type] = true;
		}


		public override void Update(Player player, ref int buffIndex)
		{
			if (player.whoAmI == Main.myPlayer)
			{
				RetributionPlayer.canUseFrostHeart = false;
			}
		}
	}
}