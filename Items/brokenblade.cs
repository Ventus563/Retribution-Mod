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
	public class brokenblade : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Broken Blade");
		}

		public override void SetDefaults()
		{
			item.width = 32;
			item.height = 36;
			item.maxStack = 30;
			item.value = Item.sellPrice(0, 0, 50, 0);
			item.consumable = false;
		}
	}
}