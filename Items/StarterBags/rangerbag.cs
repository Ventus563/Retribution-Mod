using Retribution.Items.Weapons.Ranger;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Retribution.Items.StarterBags
{
	public class rangerbag : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Ranger's Bag");
			Tooltip.SetDefault("Contains Ranger class items\n{$CommonItemTooltip.RightClickToOpen}");
		}

		public override void SetDefaults()
		{
			item.maxStack = 1;
			item.consumable = true;
			item.width = 26;
			item.height = 34;
			item.rare = ItemRarityID.Purple;
			item.expert = true;
		}

		public override bool CanRightClick()
		{
			return true;
		}

		public override void RightClick(Player player)
		{
			player.QuickSpawnItem(ModContent.ItemType<revolver>());
			player.QuickSpawnItem(ModContent.ItemType<brokengun>());
			player.QuickSpawnItem(ItemID.MusketBall, 500);
			player.QuickSpawnItem(ItemID.ArcheryPotion, 2);
			player.QuickSpawnItem(ItemID.AmmoReservationPotion, 2);
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<emptybag>());
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}