using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Retribution.Items.Weapons.Melee
{
    public class RottenRound : ModItem
	{
		public override void SetStaticDefaults()
		{
			Displayname.SetDefault("RottenRound");
		}

		public override void SetDefaults()
		{
			item.maxStack = 1;
			item.damage = 20;
			item.width = 38;
			item.height = 38;
			item.useTime = 19;
			item.useAnimation = 19;
			item.useStyle = 1;
			item.noUseGraphic = true;
			item.knockBack = 3f;
			item.autoReuse = true;
			item.value = Item.sellPrice(0, 2, 0, 0);
			item.rare = 0;
			item.melee = true;
			item.UseSound = SoundID.Item1;
			item.useTurn = true;
			item.shoot = mod.ProjectileType("RottenRoundproj");
			item.shootSpeed = 7f;
		}
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.ShadowScale, 13);
			recipe.AddIngredient(ItemID.DemoniteBar,11);
			recipe.AddTile(TileID.WorkBenches);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
