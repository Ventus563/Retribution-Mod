using Terraria
using Terraria.ID
using Terraria.ModLoader

namespace Retribution.Items.Weapons.Melee
{
    public class CrimsonSaber : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Crimson Saber")
        }
        public override void SetStaticDefaults()
        {
            item.damage = 12;
            item.melee = true;
            item.width = 40;
            item.hight = 40;
            item.useTime = 10;
            item.useAnimation = 10;
            item.knockBack = 5;
            item.value = Item.buyPrice( Silver: 25);
            item.rare = ItemRarityID.Green;
            item.autoReuse = false
            item.crit = 0;
            item.useStyle = ItemUseStyleID.SwingThrow;
        }

        public override void AddRecipies()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.CrimtaineBlock, 15);
            recipe.AddIngredient(ItemID.IronBar 5); //uses either Iron or Lead Bars
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe()
        }
    }
}