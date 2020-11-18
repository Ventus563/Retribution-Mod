using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Retribution.Items.Tools
{
	public class StonePickaxe : ModItem
	{
		public override void SetStaticDefaults()
		{
			item.damage = 4;
			item.melee = true;
			item.width = 40;
			item.height = 40;
			item.useTime = 10;
			item.useAnimation = 10;
			item.pick = 40;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.knockBack = 0;
			item.rare = ItemRarityID.Green;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
		}

		public override void
		{
		  ModRecipe recipe = new ModRecipe(mod);
		  recipe.AddIngredient(ItemID.StoneBlock, 10);
		  recipe.AddTile(TileID.Workbenches);
		  recipe.SetResult(this);
		  recipe.AddRecipe();
		}
    }
}
