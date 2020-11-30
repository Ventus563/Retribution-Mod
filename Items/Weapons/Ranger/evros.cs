using Retribution.Projectiles;
using Retribution.Items.Souls;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Retribution.Items.Materials;

namespace Retribution.Items.Weapons.Ranger
{
	public class evros : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Evros");
		}

		public override void SetDefaults()
		{
			item.damage = 1;
			item.channel = true;
			item.magic = true;
			item.mana = 2;
			item.rare = ItemRarityID.Blue;
			item.width = 50;
			item.height = 28;
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
			recipe.AddIngredient(ModContent.ItemType<frozensoul>(), 5);
			recipe.AddIngredient(ModContent.ItemType<brokengun>(), 1);
			//recipe.AddIngredient(ModContent.ItemType<residue>(), 1);
			//recipe.AddTile(TileID.MysticForge);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}