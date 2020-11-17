using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Retribution;

namespace Retribution.Items.Consumables
{
    public class soulpotion : ReaperClass
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Soul Potion");
            Tooltip.SetDefault("Fills half of your soul storage");
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

            rP.soulCurrent = rP.soulCurrent + (rP.soulMax2 / 2);

            for (int d = 0; d < 20; d++)
            {
                Dust.NewDust(player.position, player.width, player.height, 277, 0f, 0f, 150, default, 1.5f);
            }
            return true;
        }
    }
}