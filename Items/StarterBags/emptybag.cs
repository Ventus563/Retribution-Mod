using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.DataStructures;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Retribution.Items.StarterBags
{
	public class emptybag : ModItem
	{

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Mysterious Bag");
			Tooltip.SetDefault("Strange bag. Seems to be empty...");
		}

		public override void SetDefaults()
		{
			item.width = 26;
			item.height = 34;
			item.maxStack = 1;
			item.value = Item.sellPrice(0, 0, 0, 0);
			item.consumable = false;
		}
	}
}