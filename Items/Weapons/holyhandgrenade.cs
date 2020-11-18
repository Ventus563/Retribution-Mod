using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Retribution.Items.Weapons
{
    public class holyhandgrenade : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Holy Hand Grenade");
            Tooltip.SetDefault("Explodes upon colliding with a tile. Throws out more grenades to explode after.");
        }
        public override void SetDefaults()
        {
            item.damage = 0;
            item.width = 14;
            item.height = 22;
            item.thrown = true;
            item.maxStack = 99;
            item.consumable = true;
            item.useStyle = 1;
            item.rare = 2;
            item.UseSound = SoundID.Item1;
            item.useTime = 20;
            item.useAnimation = 20;
            item.value = 10000;
            item.noUseGraphic = true;
            item.noMelee = true;
            item.shoot = mod.ProjectileType("holygrenade");
            item.shootSpeed = 7f;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Grenade, 5);
            recipe.AddIngredient(ItemID.GoldBar, 1);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(this, 5);
            recipe.AddRecipe();
        }
    }
}