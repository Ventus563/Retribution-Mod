using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Retribution.Projectiles;

namespace Retribution.Items.Weapons.Mage
{
	public class frostbite : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Frostbite");
			Tooltip.SetDefault("Shoots spinning ice crystal that explodes into shards");
		}

		public override void SetDefaults()
		{
			item.width = 36;
			item.height = 36;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.useTime = 30;
			item.useAnimation = 30;
			item.damage = 14;
			item.crit = 4;
			item.noMelee = true;
			item.magic = true;
			item.autoReuse = true;
			item.UseSound = SoundID.Item28;
			item.shoot = ModContent.ProjectileType<icemistfriendly>();
			item.shootSpeed = 9f;
			item.mana = 3;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<bowstaff>(), 1);
			recipe.AddIngredient(ItemID.FallenStar, 5);
			recipe.AddIngredient(ItemID.Gel, 25);
			recipe.AddTile(TileID.Solidifier);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}