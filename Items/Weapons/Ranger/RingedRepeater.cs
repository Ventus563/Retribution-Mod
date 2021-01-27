using Terraria.ID;
using Terraria.ModLoader;

namespace Retribution.Items.Weapons.Ranger
{
    public class RingedRepeater : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Ringed Repeater");
        }
        public override void SetDefaults()
        {
            item.damage = 6;
            item.ranged = true;
            item.width = 54;
            item.height = 24;
            item.maxStack = 1;
            item.useTime = 14;
            item.useAnimation = 28;
            item.useStyle = 5;
            item.knockBack = 4;
            item.value = 15000;
            item.rare = ItemRarityID.Blue;
            item.UseSound = SoundID.Item5;
            item.noMelee = true;
            item.shoot = 1;
            item.useAmmo = AmmoID.Arrow;
            item.shootSpeed = 10f;
            item.autoReuse = true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Coral, 5);
            recipe.AddIngredient(ItemID.Seashell, 3);
            recipe.AddIngredient(ItemID.IronBar, 12);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}