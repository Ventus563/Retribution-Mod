using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Retribution;

namespace Retribution.Items.Accessories
{
    public class resetsouls : ReaperClass
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Reset Souls");
        }

        public override void SafeSetDefaults()
        {
            item.width = 18;
            item.height = 26;
            item.useStyle = ItemUseStyleID.EatingUsing;
            item.useAnimation = 15;
            item.useTime = 15;
            item.useTurn = true;
            item.UseSound = SoundID.Item3;
            item.maxStack = 30;
            item.consumable = true;
            item.rare = ItemRarityID.Orange;
            item.value = Item.buyPrice(gold: 1);
        }

        public override bool UseItem(Player player)
        {
            var rP = player.GetModPlayer<RetributionPlayer>();

            rP.soulMax = 20;

            return true;
        }
    }
}