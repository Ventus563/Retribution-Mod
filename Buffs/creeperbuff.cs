using Retribution.Dusts;
using Retribution.Projectiles.Minions;
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Retribution.Buffs
{	public class creeperbuff : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Creeper");
			Description.SetDefault("A Creeper is disorientating your enemies");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex)
		{
			if (player.ownedProjectileCounts[ModContent.ProjectileType<creeper>()] > 0)
			{
				player.buffTime[buffIndex] = 18000;
			}
			else
			{
				player.DelBuff(buffIndex);
				buffIndex--;
			}
		}
	}
}