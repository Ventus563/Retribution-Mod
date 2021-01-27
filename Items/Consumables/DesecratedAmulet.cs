using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System.Drawing;
using Terraria.Localization;
using Microsoft.Xna.Framework;

namespace Retribution.Items.Consumables
{
    public class DesecratedAmulet : NightmareRarity
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Desecrated Amulet");
            Tooltip.SetDefault("Plunges the World into a Nightmare.");
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
            item.width = 64;
            item.height = 50;
            item.useStyle = ItemUseStyleID.HoldingUp;
            item.useAnimation = 15;
            item.useTime = 15;
            item.useTurn = true;
            item.UseSound = SoundID.DD2_BetsyDeath;
            item.maxStack = 1;
            item.consumable = false;
            item.rare = ItemRarityID.White;
            item.value = Item.buyPrice(gold: 0);
        }

        public override bool UseItem(Player player)
        {
            if (RetributionWorld.nightmareMode == false)
            {
                Main.NewText("The Nightmares Have Been Released Into Your World.", 148, 0, 54, true);
                RetributionWorld.nightmareMode = true;
                return true;
            }

            if (RetributionWorld.nightmareMode == true)
            {
                Main.NewText("The Nightmares Have Been Suppressed.", 148, 0, 54, true);
                RetributionWorld.nightmareMode = false;
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}