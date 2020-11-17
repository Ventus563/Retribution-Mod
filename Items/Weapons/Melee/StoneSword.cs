using Terraria
using Terraria.ID
using Terraria.ModLoader

namespace Retribution.Items.Weapons.Melee
{
    public class StoneSword : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Stone Sword")

            Tooltip.SetDefault("Fate of the stone")


        }
        public override void SetStaticDefaults()
        {
            item.damage = 6;
            item.melee = true;
            item.width = 40;
            item.hight = 40;
            item.useTime = 10;
            item.useAnimation = 10;
            item.knockBack = 1;
            item.value = Items.buyPrice(Copper: 50);
            item.rare = ItemRarityID.Green;
            item.autoReuse = false
            item.crit = 0
            item.useStyle = ItemUseStyleID.SwingThrow;
        }

        public override void AddRecipies()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.StoneBlock, 10);
            recipe.AddTile(TileID.Workbeches, );
            recipe.SetResult(this);
            recipe.needWater = false;
            recipe.AddRecipe()
        }
    }
}