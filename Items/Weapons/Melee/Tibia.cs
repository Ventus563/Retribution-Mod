using System;
using System.IO;
using Microsoft.Xna.Framework;
using Terraria;
using Retribution;
using Terraria.GameContent.Events;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using Retribution.Projectiles;
using Retribution.Items.Souls;

namespace Retribution.Items.Weapons.Melee
{
	public class Tibia : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Tibia");
		}

        public override void SetDefaults()
        {
            item.maxStack = 1;
            item.damage = 34;
            item.crit = 2;
            item.width = 64;
            item.height = 64;
            item.useTime = 15;
            item.useAnimation = 15;
            item.useStyle = 1;
            item.knockBack = 1f;
            item.autoReuse = true;
            item.value = Item.sellPrice(0, 1, 0, 0);
            item.rare = 0;
            item.melee = true;
            item.UseSound = SoundID.Item1;
            item.useTurn = true;
            item.shoot = 623;
            item.shootSpeed = 15f;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Bone, 25);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
