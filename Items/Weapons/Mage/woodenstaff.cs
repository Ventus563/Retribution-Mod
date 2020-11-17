using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Retribution.Items.Weapons.Mage
{
	public class woodenstaff : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Wooden Staff");
			Tooltip.SetDefault("Shoots a small fire ball");
		}

		public override void SetDefaults()
		{
			item.damage = 5;
			item.width = 26;
			item.height = 28;
			item.magic = true;
			item.useTime = 30;
			item.useAnimation = 30;
			item.useStyle = 5;
			item.knockBack = 5f;
			item.value = Item.buyPrice(0, 0, 5, 0);
			item.rare = 0;
			item.autoReuse = true;
			item.shoot = mod.ProjectileType("damagebullet");
			item.shootSpeed = 10f;
			item.mana = 1;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Wood, 5);
			//recipe.AddIngredient(mod, "forestspirit", 3);
			recipe.AddTile(TileID.WorkBenches);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}