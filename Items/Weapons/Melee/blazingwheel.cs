using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Retribution.Items.Weapons.Melee
{
	public class blazingwheel : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Blazing Wheel");
			Tooltip.SetDefault("Applies fire to enemies");
		}

		public override void SetDefaults()
		{
			item.maxStack = 1;
			item.damage = 34;
			item.width = 38;
			item.height = 38;
			item.useTime = 20;
			item.useAnimation = 23;
			item.useStyle = 1;
			item.noUseGraphic = true;
			item.knockBack = 3f;
			item.autoReuse = true;
			item.value = Item.sellPrice(0, 1, 75, 0);
			item.rare = 0;
			item.melee = true;
			item.UseSound = SoundID.Item1;
			item.useTurn = true;
			item.shoot = mod.ProjectileType("blazingwheelproj");
			item.shootSpeed = 7f;
		}
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.HellstoneBar, 13);
			recipe.AddTile(TileID.IronAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}