using Retribution.Projectiles;
using Retribution.Items.Souls;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Retribution.Items.Materials;
using Retribution.Items.Blocks;

namespace Retribution.Items.Weapons.Mage
{
	public class jadestaff : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Jade Staff");
			Item.staff[item.type] = true;
		}

		public override void SetDefaults()
		{
			item.damage = 16;
			item.magic = true;
			item.mana = 6;
			item.rare = ItemRarityID.Blue;
			item.width = 42;
			item.height = 40;
			item.useTime = 32;
			item.knockBack = 4.25f;
			item.UseSound = SoundID.Item43;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.shootSpeed = 8f;
			item.useAnimation = 32;
			item.shoot = ProjectileID.EmeraldBolt;
			item.value = Item.sellPrice(silver: 3);
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<rubidiumbar>(), 10);
			//recipe.AddIngredient(ModContent.ItemType<jade>(), 8);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}