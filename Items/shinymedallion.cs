using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Retribution.Items
{
	public class shinymedallion : ModItem
	{

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Grimly Medallion");
			Tooltip.SetDefault("Returns the user to their last death position\nIs not consumed upon use");
		}

		public override void SetDefaults()
		{
			item.width = 36;
			item.height = 40;
			item.useStyle = 4;
			item.useAnimation = 15;
			item.useTime = 100;
			item.useTurn = true;
			item.UseSound = SoundID.Item25;
			item.maxStack = 1;
			item.value = 30000;
			item.consumable = false;
		}

		public override bool CanUseItem(Player player)
		{
			return player.showLastDeath;
		}

		public override bool UseItem(Player player)
		{
			if (Main.rand.Next(2) == 0)
				Dust.NewDust(player.position, player.width, player.height, 15, 0.0f, 0.0f, 150, Color.Red, 1.1f);
			if (player.itemAnimation == item.useAnimation / 2)
			{
				for (int index = 0; index < 70; ++index)
					Dust.NewDust(player.position, player.width, player.height, 15, (float)(player.velocity.X * 0.5), (float)(player.velocity.Y * 0.5), 150, Color.Red, 1.5f);

				player.Teleport(player.lastDeathPostion, -69);
				player.Center = player.lastDeathPostion;
				if (Main.netMode == NetmodeID.SinglePlayer)
					NetMessage.SendData(65, -1, -1, null, 0, (float)player.whoAmI, player.lastDeathPostion.X, player.lastDeathPostion.Y, 3);

				for (int index = 0; index < 70; ++index)
					Dust.NewDust(player.position, player.width, player.height, 15, 0.0f, 0.0f, 150, Color.Red, 1.5f);
				return true;
			}
			return false;
		}
	}
}