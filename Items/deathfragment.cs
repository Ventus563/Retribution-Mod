using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.DataStructures;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Retribution.Items
{
	public class deathfragment : ReaperClass
	{

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Death Fragment");
			Tooltip.SetDefault("A fragment festering with the power of death");
			ItemID.Sets.ItemIconPulse[item.type] = true;
			ItemID.Sets.ItemNoGravity[item.type] = true;
		}

		public override void SafeSetDefaults()
		{
			item.width = 18;
			item.height = 22;
			item.UseSound = SoundID.Item25;
			item.rare = ItemRarityID.Cyan;
			item.maxStack = 999;
			item.value = 2000;
		}
    }
}