using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Retribution.Items.Materials
{
    public class SolidBar : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Solid Bar");
        }

        public override void SetDefaults()
        {
            item.width = 26;
            item.height = 24;
            item.rare = ItemRarityID.Blue;
            item.value = Item.sellPrice(0, 0, 15, 0);
            item.maxStack = 999;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.LeadOre, 8);
            recipe.AddIngredient(ItemID.StoneBlock, 8);
            recipe.AddIngredient(ItemID.Gel, 10);
            recipe.AddTile(TileID.Furnaces);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }

    }
}