using Terraria.ModLoader;

namespace Retribution.Items.Blocks
{
    public class infectedgrassblockspread : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Infected Grass Block");
            Tooltip.SetDefault("Some festering piece of grass");
        }

        public override void SetDefaults()
        {
            item.width = 16;
            item.height = 16;
            item.maxStack = 999;
            item.value = 100;
            item.rare = 3;
            item.createTile = mod.TileType("infectedgrassspread");
            item.useTurn = true;
            item.autoReuse = true;
            item.useAnimation = 15;
            item.useTime = 10;
            item.useStyle = 1;
            item.consumable = true;
        }
    }
}