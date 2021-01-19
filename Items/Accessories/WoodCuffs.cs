using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Retribution.Items.Accessories
{
	public class WoodCuffs : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Wood Handcuffs");
			Tooltip.SetDefault("increases all class damage by 2%");
		}

		public override void SetDefaults()
		{
			item.accessory = true;
			item.width = 26;
			item.height = 24;
			item.rare = ItemRarityID.White;
			item.value = Item.sellPrice(0, 0, 0, 80);
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.meleeDamage += 0.02f;
			player.rangedDamage += 0.02f;
			player.magicDamage += 0.02f;
			player.minionDamage += 0.02f;
			player.thrownDamage += 0.02f;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Wood, 30);
			recipe.AddTile(TileID.WorkBenches);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}