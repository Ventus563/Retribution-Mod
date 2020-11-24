using Terraria
using Terraria.ID
using Terraria.ModLoader;
using Retribution.Items.Materials

namespace Retribution.Items.Weapons.Melee
{
    public class SteelSword : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Steel Sword")
        }
        public override void SetStaticDefaults()
        {
            item.damage = 12;
            item.melee = true;
            item.width = 40;
            item.hight = 40;
            item.useTime = 20;
            item.useAnimation = 20;
            item.knockBack = 4;
            item.value = Item.buyPrice(Silver: 50);
            item.rare = ItemRarityID.Green;
            item.autoReuse = false
            item.crit = 0;
            item.useStyle = ItemUseStyleID.SwingThrow;
        }

        public override void AddRecipies()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient((mod.ItemType("SteelBar"), 4);
            recipe.AddTile(TileID.Anvils, );
            recipe.SetResult(this);
            recipe.needWater = false;
            recipe.AddRecipe()
        }
    }
}