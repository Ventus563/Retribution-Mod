using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.ID;

namespace Retribution.Items.Accessories
{
	public class soulcontract : ModItem
	{

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Soul Contract");
			Tooltip.SetDefault("Increases the amount of souls gained by 1");
		}

		public override void SetDefaults()
		{
			item.width = 20;
			item.height = 26;
			item.value = 1000;
			item.rare = ItemRarityID.Green;
			item.accessory = true;
			item.maxStack = 1;
		}
		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			var rP = player.GetModPlayer<RetributionPlayer>();

			rP.soulRecieve = 1;
		}
	}
}