using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.ID;

namespace Retribution.Items.Accessories
{
	public class FrostHeart : NightmareRarity
	{

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Frost Heart");
			Tooltip.SetDefault("When you deal damage, there is a 15% chance to release fast-moving ice spikes from your core.");
		}

		public override void ModifyTooltips(System.Collections.Generic.List<TooltipLine> list)
		{
			foreach (TooltipLine line2 in list)
			{
				if (line2.mod == "Terraria" && line2.Name == "ItemName")
				{
					line2.overrideColor = NightmareColor.Magenta;
				}
			}
		}

		public override void SetDefaults()
		{
			item.width = 54;
			item.height = 40;
			item.value = 1000;
			item.rare = ItemRarityID.White;
			item.accessory = true;
			item.maxStack = 1;
		}

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
			RetributionPlayer.frostHeart = true;
        }
    }
}