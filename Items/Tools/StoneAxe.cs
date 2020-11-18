using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Retribution.Items.Tools
{
	public class StoneAxe : ModItem
	{
		public override void
		{
			item.damage = 7;
			item.melee = true;
			item.width = 42;
			item.height = 36;
			item.useTime = 20;
			item.useAnimation = 20;
			item.knockBack = 4;
			item.value = Item.sellPrice(0, 0, 45, 0);
			item.rare = ItemRarityID.White;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.crit = 6;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.useTurn = true;
			item.axe = 9;
		}
	    public override void AddRecipes()
	    {
		  ModRecipe recipe = new ModRecipe(mod);
		  recipe.AddIngredient(ItemID.Wood, 5);
		  recipe.AddIngredient(ItemID.StoneBlock, 12);
		  recipe.AddTile(TileID.Anvils);
		  recipe.SetResult(this);
		  recipe.AddRecipe();
	    }
    }
}