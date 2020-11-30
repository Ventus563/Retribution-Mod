using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.ID;

namespace Retribution.Items.Materials
{
	public class paper : ModItem
	{

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Paper");
			Tooltip.SetDefault("Nothing special here.");
		}

		public override void SetDefaults()
		{
			item.maxStack = 999;
			item.width = 30;
			item.height = 34;
			item.value = 300;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Wood, 3);
			recipe.AddTile(TileID.WorkBenches);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}