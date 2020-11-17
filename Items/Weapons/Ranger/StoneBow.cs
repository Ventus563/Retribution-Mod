
using ExampleMod.Tiles;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExampleMod.Items.Weapons
{
	public class StoneBow : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Stone Bow")
		}

		public override void SetDefaults()
		{
			item.damage = 6; 
			item.ranged = true; 
			item.width = 40; 
			item.height = 20; 
			item.useTime = 20; 
			item.useAnimation = 20;
			item.useStyle = ItemUseStyleID.HoldingOut; 
			item.noMelee = true; 
			item.knockBack = 1; 
			item.value = Item.buyPrice(Copper: 1); 
			item.rare = ItemRarityID.Green; 
			item.UseSound = SoundID.Item11;
			item.autoReuse = false;  
			item.shootSpeed = 8f; 
			item.useAmmo = AmmoID.Arrow; 
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.StoneBlocks, 10);
			recipe.AddTile(TileID.WorkBenches);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}