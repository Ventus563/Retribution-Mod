using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.DataStructures;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Retribution.Items.Souls
{
	public class damnedsoul : ModItem
	{

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Damned Soul");
			Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(5, 4));
			ItemID.Sets.AnimatesAsSoul[item.type] = true;
			ItemID.Sets.ItemNoGravity[item.type] = true;
		}

		public override void SetDefaults()
		{
			item.width = 18;
			item.height = 28;
			item.useStyle = 4;
			item.useAnimation = 15;
			item.useTime = 100;
			item.useTurn = true;
			item.UseSound = SoundID.Item25;
			item.maxStack = 999;
			item.consumable = false;
		}

		public override void PostUpdate()
		{
			Lighting.AddLight((int)((item.position.X + item.width / 2) / 16f), (int)((item.position.Y + item.height / 2) / 16f), 1f, 1f, 1f);
		}
	}
}