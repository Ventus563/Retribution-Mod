using Retribution.Projectiles;
using Retribution.Items.Souls;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Retribution.Items.Materials;

namespace Retribution.Items.Weapons.Mage
{
	public class rimesword : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Rime Swordstaff");
			Item.staff[item.type] = true;
		}

		public override void SetDefaults()
		{
			item.width = 88;
			item.height = 88;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.useTime = 30;
			item.useAnimation = 30;
			item.damage = 21;
			item.crit = 4;
			item.noMelee = true;
			item.magic = true;
			item.autoReuse = true;
			item.UseSound = SoundID.Item28;
			item.shoot = ModContent.ProjectileType<rimeswordproj>();
			item.shootSpeed = 12f;
			item.mana = 6;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<oceansoul>(), 5);
			recipe.AddIngredient(ModContent.ItemType<brokenstaff>(), 1);
			//recipe.AddIngredient(ModContent.ItemType<residue>(), 1);
			//recipe.AddTile(TileID.MysticForge);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}