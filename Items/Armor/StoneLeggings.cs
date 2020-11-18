using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Retribution.Items.Armor
{
	AutoloadEquip(EquipType.Legs)]
	public class StoneLeggings : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Stone Leggings")
			Tooltip.SetDefault("2% increased movement speed");
		}

		public override void SetDefaults()
		{
			item.width = 18;
			item.height = 18;
			item.value = 10000;
			item.rare = ItemRarityID.Green;
			item.defense = 1;
		}

		public override void UpdateEquip(Player player)
		{
			player.moveSpeed += 0.02f;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.StoneBlock, 17);
			recipe.AddTile(TileID.WorkBenches);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
