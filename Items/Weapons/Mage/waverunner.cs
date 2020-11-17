using Retribution.Projectiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Retribution.Items.Weapons.Mage
{
	public class waverunner : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Wave Runner");
			Tooltip.SetDefault("Creates a liquid beam to pulverize your enemies");
		}

		public override void SetDefaults()
		{
			item.damage = 1;
			item.channel = true;
			item.magic = true;
			item.mana = 2;
			item.rare = ItemRarityID.Blue;
			item.width = 28;
			item.height = 30;
			item.useTime = 20;
			item.UseSound = SoundID.Item13;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.shootSpeed = 14f;
			item.useAnimation = 20;
			item.shoot = ModContent.ProjectileType<oceanbeam>();
			item.value = Item.sellPrice(silver: 3);
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Seashell, 5);
			recipe.AddIngredient(ItemID.Starfish, 5);
			//recipe.AddIngredient(mod, "waterspirit", 3);
			recipe.needWater = true;
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}