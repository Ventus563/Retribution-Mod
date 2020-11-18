using Retribution.Projectiles;
using Retribution.Items.Souls;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Retribution.Items.Weapons.Mage
{
	public class maitz : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Maitz");
		}

		public override void SetDefaults()
		{
			item.damage = 1;
			item.channel = true;
			item.magic = true;
			item.mana = 2;
			item.rare = ItemRarityID.Blue;
			item.width = 48;
			item.height = 48;
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
			recipe.AddIngredient(ModContent.ItemType<oceansoul>(), 5);
			//recipe.AddIngredient(ModContent.ItemType<brokenstaff>(), 1);
			//recipe.AddIngredient(ModContent.ItemType<residue>(), 1);
			//recipe.AddTile(TileID.MysticForge);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}