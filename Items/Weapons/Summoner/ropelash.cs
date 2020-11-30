using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using Retribution.Projectiles;

namespace Retribution.Items.Weapons.Summoner
{
    public class ropelash : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Rope Lash");
        }
        public override void SetDefaults()
        {
			item.width = 34;
			item.height = 30;
            item.useStyle = 5;
            item.channel = true;
            item.useAnimation = 18;
            item.useTime = 18;
            item.UseSound = SoundID.Item19;
            item.noUseGraphic = true;
            item.noMelee = true;
            item.summon = true;
            item.damage = 4;
            item.crit = item.damage + 4;
            item.knockBack = 3.5f;
            item.shoot = ModContent.ProjectileType<ropelashproj>();
            item.shootSpeed = 80f;
            item.rare = 0;
            item.value = Item.sellPrice(0,0,0,80);
        }
        public override void AddRecipes() {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Rope, 50);
            recipe.AddIngredient(ItemID.Gel, 15);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            Projectile.NewProjectile(position.X, position.Y, speedX, speedY, type, damage, knockBack, player.whoAmI, 0, 
            Main.rand.Next(-300, 300) * 0.001f * player.gravDir);
            return false;
        }
    }
}