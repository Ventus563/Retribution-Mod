using Retribution.Items.Weapons.Mage;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Retribution.Items.Materials;

namespace Retribution.Items.StarterBags
{
	public class magebag : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Mage's Bag");
			Tooltip.SetDefault("Contains Mage class items\n{$CommonItemTooltip.RightClickToOpen}");
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
			player.QuickSpawnItem(ModContent.ItemType<woodenstaff>());
			player.QuickSpawnItem(ModContent.ItemType<brokenstaff>());
			player.QuickSpawnItem(ItemID.NaturesGift);
			player.QuickSpawnItem(ItemID.ManaCrystal, 2);
			player.QuickSpawnItem(ItemID.LesserManaPotion, 5);
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