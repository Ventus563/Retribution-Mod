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
	public class brokengun : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Broken Gun");
		}

		public override void SetDefaults()
		{
			item.width = 49;
			item.height = 23;
			item.maxStack = 30;
			item.value = Item.sellPrice(0, 0, 50, 0);
			item.consumable = false;
		}
	}
}