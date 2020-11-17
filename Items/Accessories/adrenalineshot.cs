using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.ID;

namespace Retribution.Items.Accessories
{
	public class adrenalineshot : ModItem
	{

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Adrenaline Vile");
			Tooltip.SetDefault("Permanently increases speed by 25%");
		}

		public override void SetDefaults()
		{
			item.width = 20;
			item.height = 26;
			item.useStyle = ItemUseStyleID.EatingUsing;
			item.useAnimation = 15;
			item.useTime = 15;
			item.useTurn = true;
			item.UseSound = SoundID.Item3;
			item.maxStack = 1;
			item.consumable = true;
		}

		public void UseItem(Player player)
		{
			player.moveSpeed += 0.25f;
			player.jumpSpeedBoost += 0.25f;
		}
	}
}