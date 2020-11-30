using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Retribution.Projectiles;

namespace Retribution.Items.Weapons.Mage
{
	public class bowstaff : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Bow Staff");
			Tooltip.SetDefault("Shoots spinning wooden bow to shoot arrows at your enemies");
		}

		public override void SetDefaults()
		{
			item.width = 42;
			item.height = 42;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.useTime = 23;
			item.useAnimation = 23;
			item.damage = 14;
			item.crit = 4;
			item.noMelee = true;
			item.magic = true;
			item.autoReuse = true;
			item.UseSound = SoundID.Item1;
			item.shoot = ModContent.ProjectileType<bow>();
			item.shootSpeed = 12f;
			item.mana = 3;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.WoodenBow, 1);
			recipe.AddIngredient(ItemID.WoodenArrow, 25);
			recipe.AddIngredient(ItemID.Gel, 25);
			recipe.AddTile(TileID.Solidifier);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}