using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.DataStructures;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Retribution.Items.Materials
{
	public class brokenstaff : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Broken Staff");
		}

		public override void SetDefaults()
		{
			item.width = 48;
			item.height = 48;
			item.maxStack = 30;
			item.value = Item.sellPrice(0, 0, 50, 0);
			item.consumable = false;
		}
	}
}