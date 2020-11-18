using Retribution.Items.Weapons.Melee;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Retribution.Items.StarterBags
{
	public class warriorbag : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Warrior's Bag");
			Tooltip.SetDefault("Contains Melee class items\n{$CommonItemTooltip.RightClickToOpen}");
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
			player.QuickSpawnItem(ModContent.ItemType<woodendagger>());
			player.QuickSpawnItem(ModContent.ItemType<brokenblade>());
			player.QuickSpawnItem(ItemID.FeralClaws);
			player.QuickSpawnItem(ItemID.WrathPotion, 2);
			player.QuickSpawnItem(ItemID.IronskinPotion, 2);
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