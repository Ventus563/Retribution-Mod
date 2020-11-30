using Retribution.Projectiles;
using Retribution.Items.Souls;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Retribution.Items.Materials;

namespace Retribution.Items.Weapons.Reaper
{
	public class theristis : ReaperClass
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Theristis");
		}

		public override void SafeSetDefaults()
		{
			item.damage = 1;
			item.channel = true;
			item.rare = ItemRarityID.Blue;
			item.width = 60;
			item.height = 56;
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
			recipe.AddIngredient(ModContent.ItemType<evilsoul>(), 5);
			recipe.AddIngredient(ModContent.ItemType<brokenscythe>(), 1);
			//recipe.AddIngredient(ModContent.ItemType<residue>(), 1);
			//recipe.AddTile(TileID.MysticForge);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}